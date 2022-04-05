// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace System.Runtime.Engineering.Parameters;

public sealed class ParameterDefinition
{
    public IEnumerable<string> Identifiers { get; set; }
    public bool Required { get; set; }

    public ParameterDefinition(IEnumerable<string> identifiers, bool required = true)
    {
        Identifiers = identifiers;
        Required = required;
    }
}
