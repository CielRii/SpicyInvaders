//using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SpicyInvaders
{
    internal class Enemy
    {
        public int xPosition = 0;
        public int yPosition = 5;
        //public int[,] position = null;
        public bool enemyIsAlive = true;
        //List <string> myEnemies = new List<string>();
        List<Enemy> enemies = new List<Enemy>();
        int nbEnemies = 24;
        //public string[,] myEnemies = { { "X", "X", "X", "X", "X", "X" }, { "X", "X", "X", "X", "X", "X" }, { "X", "X", "X", "X", "X", "X" }, { "X", "X", "X", "X", "X", "X" } };
        Spaceship mySpaceship = new Spaceship();
        ShootingBall myShootingBall = new ShootingBall();
        FallingBall myFallingBall = new FallingBall();
        private string enemy = "X";

        public const int Width = 6;
        public const int Height = 4;

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

        //public void CreateInvaders()
        //{

        //    for (int j = 0; j < nbEnemies; j++)
        //    {
        //        if (j%6 == 0)
        //        {
        //            this.xPosition = 0;
        //            this.yPosition++;
        //        }

        //        enemies.Add(new Enemy());
        //        enemies[j].xPosition = this.xPosition;
        //        enemies[j].yPosition = this.yPosition;

        //        this.xPosition += 1;
        //    }
        //}

        public void Draw()
        {

            if (enemyIsAlive)
            {

                //for (int j = 0; j < enemies.Count; j++)
                //{
                //    Console.SetCursorPosition(enemies[j].xPosition, enemies[j].yPosition);
                //    Console.Write(enemies[j].EnemyShip);
                //}

                for (int i = 0; i < 4; i++)
                {
                    //enemies[i].Draw();
                    //enemies.Add();

                }


                if (enemyIsAlive)
                {
                    for (int i = 0; i < Height; i++)
                    {
                        for (int j = 0; j < Width; j++)
                        {
                            //Console.SetCursorPosition(xPosition + j, yPosition + i);
                            //Console.Write(myEnemies[i, j]);
                        }
                    }
                    System.Threading.Thread.Sleep(50); //On doit augmenter sa valeur pour voir le retour en arrière. Problème : déplacement de l'ennemi et non du vaisseau
                }
            }
        }
        public Rectangle hitbox ()
        {
            return new Rectangle (xPosition, yPosition, 4, 6);
        }
    }
}