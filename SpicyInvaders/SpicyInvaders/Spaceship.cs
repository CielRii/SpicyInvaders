using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Drawing;

namespace SpicyInvaders
{
    internal class Spaceship
    {
        public int xPosition = Console.WindowWidth / 2; // Start position at the center of the window
        public int yPosition = Console.WindowHeight / 2; // Start position at the center of the window
        public string mySpaceShip = "X";
        public int nbLifes = 3;

        public int Width = 1;
        public int Height = 1;

        public void Update()
        {
            // Clear previous position of the spaceship
            Console.SetCursorPosition(xPosition, yPosition);
            Console.WriteLine(" ");


            // Check for continuous movement
            if (Keyboard.IsKeyDown(Key.Right) && xPosition < Console.WindowWidth - 2)
            {
                xPosition++;
            }
            if (Keyboard.IsKeyDown(Key.Left) && xPosition > 0)
            {
                xPosition--;
            }
        }

        public void Draw()
        {
            Console.SetCursorPosition(xPosition, yPosition);
            Console.WriteLine(mySpaceShip);
            // Delay to control character movement speed
            System.Threading.Thread.Sleep(100);
        }

        public Rectangle hitbox()
        {
            return new Rectangle(xPosition, yPosition, 1, 1);
        }
    }
}