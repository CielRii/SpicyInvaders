using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpicyInvaders
{
    internal class TheHighscore
    {
        public TheHighscore()
        {
            string path = "D:\\PROG\\POO\\TRAINING\\SPACE INVADERS\\Highscore.txt";
            string[] lines = { };
            int xPosition = 0;
            int yPosition = 0;

            Console.SetCursorPosition(Console.BufferWidth / 2 - 17, 7);
            Console.WriteLine("NAME                         SCORE\n");

            lines = File.ReadAllLines(path); //https://www.delftstack.com/fr/howto/csharp/how-to-read-a-text-file-line-by-line-in-csharp/
            foreach (string elements in lines)
            {
                if (int.TryParse(elements, out int nb))
                {
                    //if ()
                    Console.WriteLine(nb);
                }
                else
                {
                    Console.SetCursorPosition(Console.BufferWidth / 2 - 17 + 4, 7 + yPosition);
                    Console.Write(elements);
                    int count = elements.Length;
                    Console.Write("                         ");
                }
                yPosition++;
            }

            Console.SetCursorPosition(Console.BufferWidth / 2 - 4, Console.BufferHeight - 9);
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("NEW GAME");
            ConsoleKeyInfo key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                TheGame theGame = new TheGame();
            }

        }
    }
}