// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace System.Runtime.Engineering.Arguments;

public sealed class ArgumentDefinition
{
    public bool Required { get; }

    public ArgumentDefinition(bool required = true)
    {
        Required = required;
    }
}
