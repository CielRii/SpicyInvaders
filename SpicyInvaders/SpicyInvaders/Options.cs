using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpicyInvaders
{
    internal class TheOptions
    {
        public bool Sound { get; set; }
        private int _xPosition = 0;
        private int _yPosition = 1;
        private int _userChoice = 1;

        public TheOptions()
        {
            Sound = true;
        }

        public void SoundParameters()
        {
            Sound = false;

            Console.WriteLine("SON");
            Console.Write("ON ");
            _xPosition = _xPosition + 3;
            Spotlight();
            Console.Write("OFF");
            Console.WriteLine("DIFFICULTÉ");
            Console.Write("FACILE");
            Console.Write("DIFFICLE");

            do
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.LeftArrow && _xPosition > 0)
                {
                    _xPosition = _xPosition - 3;
                    Spotlight();
                    Console.WriteLine("ON");
                    _xPosition = _xPosition + 3;
                    Anonymity();
                    Console.Write("OFF");
                    _xPosition = 0;
                    _userChoice = 1;
                }
                else if (key.Key == ConsoleKey.RightArrow && _xPosition < 3)
                {
                    _xPosition = _xPosition + 3;
                    Spotlight();
                    Console.Write("OFF");
                    _xPosition = _xPosition - 3;
                    Anonymity();
                    Console.Write("ON");
                    _xPosition = 3;
                    _userChoice = 2;
                }

                if (key.Key == ConsoleKey.Enter)
                {
                    if (_userChoice == 1)
                        Sound = true;
                    else if (_userChoice == 2)
                        Sound = false;
                }

                if (key.Key == ConsoleKey.DownArrow && _yPosition < 4)
                {
                    _yPosition++;

                }
                if (key.Key == ConsoleKey.UpArrow && _yPosition > 0)
                {
                    _yPosition--;
                }

            } while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape));
        }

        private void Anonymity()
        {
            Console.SetCursorPosition(_xPosition, _yPosition);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void Spotlight()
        {
            Console.SetCursorPosition(_xPosition, _yPosition);
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
        }
    }
}
