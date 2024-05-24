using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpicyInvaders
{
    internal class FallingBall
    {
        public int xBallPosition = 0;
        public int yBallPosition = 0;
        public string myFallingBall = "|";

        Random random = new Random();

        public void Update(Enemy myEnemy)
        {
            int waitTime = random.Next(80, 450);
            int fallingBallPosition = random.Next(0, 7);


            xBallPosition = myEnemy.xPosition + fallingBallPosition;
            yBallPosition = myEnemy.yPosition + 5;
            Draw(waitTime);
        }

        public void Draw(int waitTime)
        {
            //Affichage du missile
            if (waitTime % 5 == 0)
            {
                while (yBallPosition < Console.WindowHeight - 1) //Le -1 permet d'effacer la dernière apparition du missile
                {
                    Console.SetCursorPosition(xBallPosition, yBallPosition);
                    Console.WriteLine(myFallingBall);
                    System.Threading.Thread.Sleep(25);
                    Console.SetCursorPosition(xBallPosition, yBallPosition);
                    Console.WriteLine(" ");
                    yBallPosition++;
                }
            }
        }
    }
}
