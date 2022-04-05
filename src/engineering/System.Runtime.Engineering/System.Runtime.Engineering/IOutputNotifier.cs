// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace System.Runtime.Engineering;

public interface IOutputNotifier
{
    public Task InfoAsync(string message, CancellationToken cancellationToken = default);
    public Task VerboseAsync(string message, CancellationToken cancellationToken = default);
    public Task WarnAsync(string message, CancellationToken cancellationToken = default);
    public Task ErrorAsync(string message, CancellationToken cancellationToken = default);
}
