using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SpicyInvaders
{
    internal class ShootingBall
    {
        public int xPosition = 0;
        public int yPosition = 0;
        public string myShootingBall = "|";
        public bool shoot = false;

        public int Width = 1;
        public int Height = 1;

        Spaceship mySpaceship = new Spaceship();
        public void Update(Spaceship mySpaceship)
        {
            xPosition = mySpaceship.xPosition; // Start position at the center of the window
            yPosition = mySpaceship.yPosition - 5; // Start position at the center of the window

            if (Keyboard.IsKeyDown(Key.Space))
            {
                shoot = true;
                while (yPosition > 0)
                {
                    Console.SetCursorPosition(mySpaceship.xPosition, mySpaceship.yPosition);
                    Console.WriteLine(mySpaceship.mySpaceShip);

                    Draw();
                    Console.SetCursorPosition(xPosition, yPosition);
                    Console.WriteLine(" ");
                    yPosition--;
                }
                yPosition = mySpaceship.yPosition - 5; //Reinistialisation... enchaînements des tirs
            }

            xPosition = mySpaceship.xPosition;
        }

        public void Draw()
        {
            Console.SetCursorPosition(xPosition, yPosition);
            Console.WriteLine(myShootingBall);
            System.Threading.Thread.Sleep(25);
        }

    }
}