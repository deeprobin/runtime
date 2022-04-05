// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace System.Runtime.Engineering.Cli;

public sealed class ConsoleWindow : ConsoleComponent
{
    public override void Draw()
    {
        DrawVerticalLine(1, 1, Console.WindowWidth - 1);
        DrawVerticalLine(Console.WindowHeight - 3, 1, Console.WindowWidth - 1);
        DrawVerticalLine(Console.WindowHeight - 1, 1, Console.WindowWidth - 1);
    }

    private static void DrawVerticalLine(int y, int startX, int endX)
    {
        Console.SetCursorPosition(startX, y);
        for (int x = startX; x < endX; x++)
        {
            /*if (x == startX)
            {
                Console.Write('╔');
            } else if (x == endX)
            {
                Console.Write('╗');
            }
            else
            {*/
                Console.Write('═');
            //}
        }
    }
}
