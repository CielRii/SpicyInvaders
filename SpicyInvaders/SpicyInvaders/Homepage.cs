using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SpicyInvaders
{
    //Constat : 29.04.24 - 10 mn -fermeture automatique de la fenêtre sous VS Code 2019 avec "Environnemenet.Exit(0)", ne prend du coup pas en charge l'ouverture d'une autre page
    internal class TheHomepage
    {
        public List<string> list = new List<string>() { "Jouer", "Options", "Highscore", "A propos", "Quitter" };
        public int xPosition = 0;
        public int yPosition = 0;

        public TheHomepage()
        {
            DisplayMenu();

            //https://stackoverflow.com/questions/5891538/listen-for-key-press-in-net-console-app
            do
            {
                NavigationDownConsole(yPosition);
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.DownArrow && yPosition < list.Count - 1)
                {
                    yPosition++;
                    NavigationDownConsole(yPosition);
                }
                else if (key.Key == ConsoleKey.UpArrow && yPosition > 0)
                {
                    yPosition--;
                    //NavigationThroughConsole(yPosition);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(xPosition, yPosition + 1);
                    Console.WriteLine(list[yPosition + 1]);

                    Console.SetCursorPosition(xPosition, yPosition);
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine(list[yPosition]);
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;

                    if (yPosition == 0)
                    {
                        TheGame theGame = new TheGame();
                        break;
                    }
                    if (yPosition == 1)
                    {
                        TheOptions theOptions = new TheOptions();
                        break;
                    }
                    if (yPosition == 2)
                    {
                        TheHighscore theHighscore = new TheHighscore();
                        break;
                    }
                    if (yPosition == 3)
                    {
                        break;
                    }
                    if (yPosition == 4) //https://www.delftstack.com/fr/howto/csharp/exit-console-application-in-csharp/#quitter-une-application-console-avec-la-m%c3%a9thode-return-en-c
                    {
                        Environment.Exit(0);
                        //Console.SetOut(TextWriter.Null);
                        // Bool WINAPI FreeConsole(void);
                        //System.Diagnostics.Process.GetCurrentProcess().Kill();
                        //Program program = new Program();
                        //program.Close();
                    }
                }

            } while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape));

            //if (Keyboard.IsKeyDown(Key.Down) && yPosition > 0)
            //{
            //    yPosition++;
            //}
            //else if (Keyboard.IsKeyDown(Key.Up) && yPosition < list.Count)
            //{
            //    yPosition--;
            //}
        }

        private void NavigationDownConsole(int yPosition)
        {
            //https://learn.microsoft.com/en-us/dotnet/api/system.console.backgroundcolor?view=net-8.0
            Console.ForegroundColor = ConsoleColor.White;
            if (yPosition > 0)
            {
                Console.SetCursorPosition(xPosition, yPosition - 1);
                Console.WriteLine(list[yPosition - 1]);
            }


            Console.SetCursorPosition(xPosition, yPosition);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(list[yPosition]);

        }

        private void DisplayMenu()
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
        }
    }
}
