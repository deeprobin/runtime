// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Immutable;
using System.Runtime.Engineering.Arguments;
using System.Runtime.Engineering.Parameters;

namespace System.Runtime.Engineering.Tasks;

public abstract class EngineeringTask
{
    public abstract IEnumerable<string> Identifiers { get; }

    public abstract IEnumerable<ParameterDefinition> ParameterDefinitions { get; }

    public abstract ImmutableArray<ArgumentDefinition> ArgumentDefinitions { get; }

    public abstract Task RunAsync(IOutputNotifier output, ArgumentCollection argumentCollection, ParameterCollection parameters, CancellationToken cancellationToken);
}
