using System;
using System.Threading;

class Program
{
    static int dinoY = 0;
    static int jump = 0;

    static int cactusX = 40;
    static int score = 0;

    static bool gameOver = false;

    static void Main()
    {
        Console.CursorVisible = false;

        while (!gameOver)
        {
            // Check Keyboard
            if (Console.KeyAvailable)
            {
                ConsoleKey Key = Console.ReadKey(true).Key;

                if (Key == ConsoleKey.Spacebar && dinoY == 0)
                {
                    jump = 6;
                }
            }

            // Jump
            if (jump > 0)
            {
                dinoY = jump;
                jump--;
            }
            else
            {
                dinoY = 0;
            }

            // Move cactus
            cactusX--;

            // Reset cactus
            if (cactusX < 0)
            {
                cactusX = 40;
                score++;
            }

            // Collision
            if (cactusX == 5 && dinoY == 0)
            {
                gameOver = true;
            }

            Draw();

            Thread.Sleep(100);
        }

        Console.Clear();

        Console.WriteLine();
        Console.WriteLine("GAME OVER!");
        Console.WriteLine();
        Console.WriteLine("Score: " + score);
        Console.WriteLine();
        Console.WriteLine("Press any key to exit.");

        Console.ReadKey();
    }

    static void Draw()
    {
        Console.Clear();

        Console.WriteLine("DINO GAME");
        Console.WriteLine("Score: " + score);
        Console.WriteLine();

        // Empty space above ground
        for (int i = 0; i < dinoY; i++)
        {
            Console.WriteLine();
        }

        // Draw dino and cactus
        string line = "";

        for (int x = 0; x < 45; x++)
        {
            if (x == 5)
            {
                line += "D";
            }
            else if (x == cactusX)
            {
                line += "|";
            }
            else
            {
                line += " ";
            }
        }

        Console.WriteLine(line);

        // Ground
        Console.WriteLine("---------------------------------------------");

        Console.WriteLine();
        Console.WriteLine("SPACE = JUMP");
    }
}