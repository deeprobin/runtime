// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace System.Runtime.Engineering.Cli;

public sealed class ConsoleSpinner : ConsoleComponent
{
    private char _char = '/';
    private byte _tick;

    public int X { get; set; }
    public int Y { get; set; }

    public override void Draw()
    {
        _tick++;
        if (_tick <= 5)
        {
            return;
        }

        SwitchChar();
        Console.SetCursorPosition(X, Y);
        Console.Write(_char);
        _tick = 0;
    }

    private void SwitchChar()
    {
        if (_char == '/')
        {
            _char = '-';
        }

        if (_char == '-')
        {
            _char = '\\';
        }

        if (_char == '\\')
        {
            _char = '/';
        }
    }
}
