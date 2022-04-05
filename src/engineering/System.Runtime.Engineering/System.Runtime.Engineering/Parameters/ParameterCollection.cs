// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace System.Runtime.Engineering.Parameters;

public sealed class ParameterCollection
{
    private readonly IReadOnlyDictionary<ParameterDefinition, object> _values;

    public ParameterCollection(IReadOnlyDictionary<ParameterDefinition, object> values)
    {
        _values = values;
    }

    public bool TryGetString(ParameterDefinition definition, out string? value)
    {
        if (_values.ContainsKey(definition))
        {
            value = (string)_values[definition];
            return true;
        }

        value = default;
        return false;
    }
}
