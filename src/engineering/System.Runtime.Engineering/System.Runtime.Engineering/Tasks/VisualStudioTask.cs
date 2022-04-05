// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Immutable;
using System.Diagnostics;
using System.Runtime.Engineering.Arguments;
using System.Runtime.Engineering.Parameters;

namespace System.Runtime.Engineering.Tasks;

public sealed class VisualStudioTask : EngineeringTask
{
    private readonly ArgumentDefinition _solutionArgument = new();
    private readonly ParameterDefinition _visualStudioExecutable = new(new[] { "vs-exec" }, false);

    public override IEnumerable<string> Identifiers => new[] { "visual-studio", "vs" };
    public override IEnumerable<ParameterDefinition> ParameterDefinitions => new[] { _visualStudioExecutable };
    public override ImmutableArray<ArgumentDefinition> ArgumentDefinitions => new()
    {
        _solutionArgument
    };

    public override async Task RunAsync(IOutputNotifier output, ArgumentCollection argumentCollection, ParameterCollection parameters, CancellationToken cancellationToken)
    {
        if (!parameters.TryGetString(_visualStudioExecutable, out string? devEnvPath))
        {
            if (!TryFindVisualStudio(out devEnvPath))
            {
                await output.ErrorAsync(@"
Cannot find Visual Studio executable. Make sure it is installed.
Either you add it to your `PATH` env or you pass a vs-exec arg.
", cancellationToken);
                return;
            }
        }

        await output.VerboseAsync($"Found Visual Studio at {devEnvPath}", cancellationToken);
        string solutionFile = (string)argumentCollection[_solutionArgument];
        if (!solutionFile.EndsWith(".sln"))
        {
            solutionFile += ".sln";
        }

        var processStartInfo = new ProcessStartInfo(devEnvPath!)
        {
            Arguments = solutionFile,
        };
        var process = Process.Start(processStartInfo);
        if (process is null)
        {
            await output.ErrorAsync($"Cannot start process {devEnvPath}", cancellationToken);
            return;
        }

    }

    private static bool TryFindVisualStudio(out string? path)
    {
        foreach (string pathVar in GetPathVariableContents())
        {
            string[] dirFiles = Directory.GetFiles(pathVar, "devenv.exe", SearchOption.TopDirectoryOnly);
            if (dirFiles.Length <= 0)
            {
                continue;
            }

            path = dirFiles[0];
            return true;
        }

        string programFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
        string vsPath = Path.Combine(programFiles, "Microsoft Visual Studio");
        if (!Directory.Exists(vsPath))
        {
            path = default;
            return false;
        }

        string[] vsFiles = Directory.GetFiles(vsPath, "devenv.exe", SearchOption.AllDirectories);
        if (vsFiles.Length > 0)
        {
            path = vsFiles[0];
            return true;
        }

        path = default;
        return false;
    }

    private static IEnumerable<string> GetPathVariableContents()
    {
        IEnumerable<string> processPath = GetPathVariableContents(EnvironmentVariableTarget.Process);
        IEnumerable<string> userPath = GetPathVariableContents(EnvironmentVariableTarget.User);
        IEnumerable<string> machinePath = GetPathVariableContents(EnvironmentVariableTarget.Machine);

        return processPath.Concat(userPath).Concat(machinePath);
    }

    private static IEnumerable<string> GetPathVariableContents(EnvironmentVariableTarget target)
    {
        string? env = Environment.GetEnvironmentVariable("PATH", target);
        if (env is null)
        {
            yield break;
        }

        foreach (string path in env.Split(Path.PathSeparator))
        {
            yield return path;
        }
    }
}
