// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace System.Runtime.Engineering.Cli;

public sealed class ConsoleProgressBar : ConsoleComponent
{
    public int X { get; set; }
    public int Y { get; set; }

    public int Value { get; set; }
    public int MaxValue { get; set; }

    public int ActualWidth => MaxWidth / MaxValue * Value;
    public int MaxWidth { get; set; }

    public override void Draw()
    {
        for (int x = X; x < (X + ActualWidth); x++)
        {
            Console.SetCursorPosition(x, Y);
            Console.Write('█');
        }
        for (int x = (X + ActualWidth); x < (X + MaxWidth); x++)
        {
            Console.SetCursorPosition(x, Y);
            Console.Write('░');
        }
    }
}
