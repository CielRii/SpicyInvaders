//using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpicyInvaders
{
    internal class Enemy
    {
        public int xPosition = 0;
        public int yPosition = 5;
        //public int[,] position = null;
        public bool enemyIsAlive = true;
        //List <string> myEnemies = new List<string>();
        public string[,] myEnemies = { { "X", "X", "X", "X", "X", "X" }, { "X", "X", "X", "X", "X", "X" }, { "X", "X", "X", "X", "X", "X" }, { "X", "X", "X", "X", "X", "X" } };
        Spaceship mySpaceship = new Spaceship();
        ShootingBall myShootingBall = new ShootingBall();
        FallingBall myFallingBall = new FallingBall();

        public int Width = 6;
        public int Height = 4;

        public void Update(Spaceship mySpaceship)
        {
            if (enemyIsAlive)
            {
                for (int i = 0; i < 4; i++)
                {
                    Console.SetCursorPosition(xPosition, yPosition + i);
                    Console.Write("      ");
                }


                if (xPosition >= Console.WindowWidth - 6)
                {
                    while (xPosition > 0)
                    {
                        xPosition--;
                        Draw(); //Dessiner avant d'effacer évite qu'au retour, l'effaçage ne soit pas exécuté
                        //myFallingBall.Update();
                        mySpaceship.Update();
                        mySpaceship.Draw();
                        myShootingBall.Update(mySpaceship);
                        for (int i = 0; i < 4; i++)
                        {
                            Console.SetCursorPosition(xPosition, yPosition + i);
                            Console.Write("      ");
                        }
                    }
                    yPosition++;
                }
                else
                {
                    xPosition++;
                }
            }
        }

        public void Draw()
        {
            if (enemyIsAlive)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        Console.SetCursorPosition(xPosition + j, yPosition + i);
                        Console.Write(myEnemies[i, j]);
                    }
                }
                System.Threading.Thread.Sleep(100); //On doit augmenter sa valeur pour voir le retour en arrière. Problème : déplacement de l'ennemi et non du vaisseau
            }
        }
    }
}