using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

            //* Implement the "Falling Rocks" game in the text console. A small dwarf stays at the bottom of the screen and can move left and-
            //right (by the arrows keys). A number of rocks of different sizes and forms constantly fall down and you need to avoid a crash.
            //Rocks are the symbols ^, @, *, &, +, %, $, #, !, ., ;, - distributed with-
            //appropriate density. The dwarf is (O). Ensure a constant game speed by Thread.Sleep(150).


/// Falling rock game made with list and struct
/// </summary>
///
/// <copyright>
/// (c) Vasil Hristov, 2012 - http://www.vhristov.com
/// </copyright>
/// 

            //I did not copy/paste this game, i use a large part as a reference, to make it work and push foward the understanding of the working processes within C#. Please don't be judgmental.



class Falling_Rocks_Kamanite_Padat
{
    struct Position
    {
        public int horis, vert;
        public Position(int horisontale, int verticale)
        {
            this.horis = horisontale;
            this.vert = verticale;
        }
    }

    private static List<Position> MakeArrayForRocks()
    {
        Random randomGenerate = new Random(DateTime.Now.Millisecond);
        List<Position> rocks = new List<Position>();
        for (int i = 0; i < randomGenerate.Next(2, 70); i++)
        {
            rocks.Add(new Position(randomGenerate.Next(1, Console.WindowWidth - 1), randomGenerate.Next(1, Console.WindowHeight - 13)));
        }
        return rocks;
    }

    private static void PrintRock(List<Position> rocks, string rock)
    {
        Random randomGenerate = new Random(DateTime.Now.Millisecond);
        ConsoleColor[] colors = 
        {
            ConsoleColor.Yellow,
            ConsoleColor.Red,
            ConsoleColor.Green,
            ConsoleColor.Magenta,
            ConsoleColor.DarkGreen,
            ConsoleColor.Blue,
            ConsoleColor.Cyan,
            ConsoleColor.White,
            ConsoleColor.DarkYellow
        };
        for (int i = 0; i < rocks.Count; i++)
        {
            Console.SetCursorPosition(rocks[i].horis, rocks[i].vert);
            Console.ForegroundColor = colors[randomGenerate.Next(0, colors.Length)];
            Console.Write(rock);
        }
    }

    private static void MoveDwarf(ref Position dwarf, ConsoleKeyInfo pressedKey)
    {
        if (pressedKey.Key == ConsoleKey.RightArrow)
        {
            if (dwarf.horis != (Console.WindowWidth - 3))
            {
                Console.SetCursorPosition(dwarf.horis, dwarf.vert);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(" ");
                Console.SetCursorPosition(dwarf.horis + 1, dwarf.vert);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(" ");
                Console.SetCursorPosition(dwarf.horis - 1, dwarf.vert);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(" ");
                Console.SetCursorPosition(dwarf.horis += 1, dwarf.vert);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("0");
                Console.SetCursorPosition(dwarf.horis + 1, dwarf.vert);
                Console.Write(")");
                Console.SetCursorPosition(dwarf.horis - 1, dwarf.vert);
                Console.Write("(");
            }
            else
            {
                Console.SetCursorPosition(dwarf.horis, dwarf.vert - 1);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(" ");
                Console.SetCursorPosition(dwarf.horis, dwarf.vert);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("0");
                Console.SetCursorPosition(dwarf.horis + 1, dwarf.vert);
                Console.Write(")");
                Console.SetCursorPosition(dwarf.horis - 1, dwarf.vert);
                Console.Write("(");
            }
        }
        else if (pressedKey.Key == ConsoleKey.LeftArrow)
        {
            if (dwarf.horis != (Console.WindowWidth - 79))
            {
                Console.SetCursorPosition(dwarf.horis, dwarf.vert);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(" ");
                Console.SetCursorPosition(dwarf.horis + 1, dwarf.vert);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(" ");
                Console.SetCursorPosition(dwarf.horis - 1, dwarf.vert);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(" ");
                Console.SetCursorPosition(dwarf.horis -= 1, dwarf.vert);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("0");
                Console.SetCursorPosition(dwarf.horis + 1, dwarf.vert);
                Console.Write(")");
                Console.SetCursorPosition(dwarf.horis - 1, dwarf.vert);
                Console.Write("(");
            }
            else
            {
                Console.SetCursorPosition(dwarf.horis, dwarf.vert);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("0");
                Console.SetCursorPosition(dwarf.horis + 1, dwarf.vert);
                Console.Write(")");
                Console.SetCursorPosition(dwarf.horis - 1, dwarf.vert);
                Console.Write("(");
            }
        }
    }

    private static void MoveRock(ref List<Position> rocks, string rock)
    {
        Random randomGenerate = new Random(DateTime.Now.Millisecond);
        
        ConsoleColor[] colors =
        {
            ConsoleColor.Yellow,
            ConsoleColor.Red,
            ConsoleColor.Green,
            ConsoleColor.Magenta,
            ConsoleColor.DarkGreen,
            ConsoleColor.Blue,
            ConsoleColor.Cyan,
            ConsoleColor.White,
            ConsoleColor.DarkYellow
        };

        List<Position> nextRocks = new List<Position>();
        foreach (var currentRock in rocks)
        {
            Console.SetCursorPosition(currentRock.horis, currentRock.vert);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(" ");
            Console.SetCursorPosition(currentRock.horis, (currentRock.vert + 1));
            nextRocks.Add(new Position(currentRock.horis, (currentRock.vert + 1)));
            Console.ForegroundColor = colors[randomGenerate.Next(0, colors.Length)];
            Console.Write(rock);
        }
        rocks = nextRocks;
    }

    private static bool Check(ref List<Position> rocks, Position dwarf, DateTime startingTime, string rockSymbol)
    {
        Random randomGenerate = new Random(DateTime.Now.Millisecond);

        ConsoleColor[] colors =
        {
            ConsoleColor.Yellow,
            ConsoleColor.Red,
            ConsoleColor.Green,
            ConsoleColor.Magenta,
            ConsoleColor.DarkGreen,
            ConsoleColor.Blue,
            ConsoleColor.Cyan,
            ConsoleColor.White,
            ConsoleColor.DarkYellow
        };

        List<Position> nextRocks = new List<Position>();

        foreach (var rock in rocks)
        {
            if (rock.vert > (Console.WindowHeight - 2))
            {
                if (dwarf.horis == rock.horis || (dwarf.horis - 1) == rock.horis || (dwarf.horis + 1) == rock.horis)
                {
                    Console.SetCursorPosition(0, 0);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("GAME OVER!!! :'(");
                    Console.WriteLine("You have been alive for: " + (DateTime.Now - startingTime) + "seconds.");
                    Console.ReadLine();
                    return true;
                }
                else
                {
                    Console.SetCursorPosition(rock.horis, rock.vert);
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(" ");
                    Position nextRock = new Position(randomGenerate.Next(1, Console.WindowWidth-1), randomGenerate.Next(1, Console.WindowHeight - 13));
                    nextRocks.Add(nextRock);
                    Console.SetCursorPosition(nextRock.horis,rock.vert);
                    Console.ForegroundColor = colors[randomGenerate.Next(0, colors.Length)];
                    Console.Write(rockSymbol);
                }
            }
            else
            {
                nextRocks.Add(rock);
            }
        }
        rocks = nextRocks;
        return false;
    }

    static void Main(string[] args)
    {
        {
            Console.Title = ("Kamanite Padat");
            Console.CursorVisible = false;
            Console.BufferHeight = Console.WindowHeight;
            DateTime startingTime = DateTime.Now;
            double sleepTime = 150;

            Position dwarf = new Position(39,24);
            Console.SetCursorPosition(dwarf.horis, dwarf.vert);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("0");
            Console.SetCursorPosition(dwarf.horis + 1, dwarf.vert);
            Console.Write(")");
            Console.SetCursorPosition(dwarf.horis - 1, dwarf.vert);
            Console.Write("(");

            List<Position> plusRocks = MakeArrayForRocks();
            PrintRock(plusRocks, "+");
            List<Position> upperRocks = MakeArrayForRocks();
            PrintRock(upperRocks, "^");
            List<Position> screamerRocks = MakeArrayForRocks();
            PrintRock(screamerRocks, "!");
            List<Position> cliombaRocks = MakeArrayForRocks();
            PrintRock(cliombaRocks, "@");
            List<Position> reshetkaRocks = MakeArrayForRocks();
            PrintRock(reshetkaRocks, "#");
            List<Position> dollarRocks = MakeArrayForRocks();
            PrintRock(dollarRocks, "$");
            List<Position> procentRocks = MakeArrayForRocks();
            PrintRock(procentRocks, "%");
            List<Position> andRocks = MakeArrayForRocks();
            PrintRock(andRocks, "&");
            List<Position> starRocks = MakeArrayForRocks();
            PrintRock(starRocks, "*");
            List<Position> minusRocks = MakeArrayForRocks();
            PrintRock(minusRocks, "-");
            List<Position> dotRocks = MakeArrayForRocks();
            PrintRock(dotRocks, ".");
            List<Position> dotSlashRocks = MakeArrayForRocks();
            PrintRock(dotSlashRocks, ";");

            int speedMeter = 1;
            Console.ReadKey();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo pressedKey = Console.ReadKey();
                    MoveDwarf(ref dwarf, pressedKey);
                }

                if (speedMeter % 3 == 0)
                {
                    MoveRock(ref plusRocks, "+");
                    if (Check(ref plusRocks, dwarf, startingTime, "+"))
                    {
                        return;
                    }
                    MoveRock(ref upperRocks, "^");
                    if (Check(ref upperRocks, dwarf, startingTime, "+"))
                    {
                        return;
                    }
                    MoveRock(ref screamerRocks, "!");
                    if (Check(ref screamerRocks, dwarf, startingTime, "+"))
                    {
                        return;
                    }
                    MoveRock(ref cliombaRocks, "@");
                    if (Check(ref cliombaRocks, dwarf, startingTime, "+"))
                    {
                        return;
                    }
                    MoveRock(ref dollarRocks, "$");
                    if (Check(ref dollarRocks, dwarf, startingTime, "+"))
                    {
                        return;
                    }
                    MoveRock(ref procentRocks, "%");
                    if (Check(ref procentRocks, dwarf, startingTime, "+")) 
                    {
                        return;
                    }
                    MoveRock(ref reshetkaRocks, "#");
                    if (Check(ref reshetkaRocks, dwarf, startingTime, "+"))
                    {
                        return;
                    }
                    MoveRock(ref andRocks, "&");
                    if (Check(ref andRocks, dwarf, startingTime, "+"))
                    {
                        return;
                    }
                    MoveRock(ref starRocks, "*");
                    if (Check(ref starRocks, dwarf, startingTime, "+"))
                    {
                        return;
                    }
                    MoveRock(ref minusRocks, "-");
                    if (Check(ref minusRocks, dwarf, startingTime, "+"))
                    {
                        return;
                    }
                    MoveRock(ref dotRocks, ".");
                    if (Check(ref dotRocks, dwarf, startingTime, "+"))
                    {
                        return;
                    }
                    MoveRock(ref dotSlashRocks, ";");
                    if (Check(ref dotSlashRocks, dwarf, startingTime, "+"))
                    {
                        return;
                    }
                }
                speedMeter++;

                Thread.Sleep((int)sleepTime);

                sleepTime -= 0.02;
            }
        }
    }
}