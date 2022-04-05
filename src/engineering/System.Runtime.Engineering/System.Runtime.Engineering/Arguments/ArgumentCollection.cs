// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Runtime.Engineering.Arguments;

namespace System.Runtime.Engineering.Arguments;

public sealed class ArgumentCollection
{
    private readonly IReadOnlyDictionary<ArgumentDefinition, object> _values;

    public ArgumentCollection(IReadOnlyDictionary<ArgumentDefinition, object> values)
    {
        _values = values;
    }

    public object this[ArgumentDefinition index] => _values[index];
}
