using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Media;
using System.IO;
using SpicyInvaders;

namespace SpicyInvaders
{
    internal class TheGame
    {
        public TheGame()
        {
            Enemy myEnemy = new Enemy();
            Spaceship mySpaceship = new Spaceship();
            ShootingBall myShootingBall = new ShootingBall();
            FallingBall myFallingBall = new FallingBall();
            bool gameOver = false;
            bool winner = false;

            string[] typeOfScore = new string[] { " SCORE < 1 >", "HI-SCORE", "SCORE < 2 > " };
            int score = 123;
            int highscore = 9867;

            while (!gameOver)
            {
                Console.SetCursorPosition(0, 0);
                // Example variables (you can replace these with actual values)
                //string typeOfScore = "SCORE < 1 >";

                // Calculate the xPosition for the typeOfScore label
                int xPosition = Console.BufferWidth / 2 - typeOfScore[0].Length / 2 - typeOfScore[1].Length / 2 - typeOfScore[2].Length / 2 - 12 / 2;
                Console.SetCursorPosition(xPosition, 0);
                Console.Write(typeOfScore[0]);

                xPosition = xPosition + typeOfScore[0].Length / 2 + 6 + typeOfScore[1].Length / 2;
                //xPosition = xPosition + typeOfScore[0].Length + 6;
                Console.SetCursorPosition(xPosition, 0);
                Console.Write(typeOfScore[1]);

                xPosition = xPosition + typeOfScore[1].Length / 2 + 6 + typeOfScore[2].Length / 2;
                //xPosition = xPosition + typeOfScore[1].Length + 6;
                Console.SetCursorPosition(xPosition, 0);
                Console.Write(typeOfScore[2]);

                // Format the score and highscore to always have 4 digits
                string formattedScore = score.ToString("D4");
                string formattedHighscore = highscore.ToString("D4");

                // Calculate the new xPosition for the score value
                //xPosition = Console.BufferWidth / 2 - typeOfScore.Length / 2 + typeOfScore[0].Length / 2 - 4 / 2;
                xPosition = Console.BufferWidth / 2 - typeOfScore[0].Length / 2 - typeOfScore[1].Length / 2 - typeOfScore[2].Length / 2 - 12 / 2 + typeOfScore[0].Length / 2 - 2;
                Console.SetCursorPosition(xPosition, 1);
                Console.Write(formattedScore);

                // Calculate the new xPosition for the highscore value
                //xPosition = Console.BufferWidth / 2 - typeOfScore.Length / 2 + typeOfScore[0].Length + 3 + typeOfScore[1].Length / 2 - 4 / 2;
                xPosition = Console.BufferWidth / 2 - typeOfScore[0].Length / 2 - typeOfScore[1].Length / 2 - typeOfScore[2].Length / 2 - 12 / 2
                    + typeOfScore[0].Length / 2 + 6 + typeOfScore[1].Length / 2 + typeOfScore[1].Length / 2 - 2;
                Console.SetCursorPosition(xPosition, 1);
                Console.Write(formattedHighscore);



                myEnemy.Update(mySpaceship); //Evite qu'un nouveau vaisseau ne soit créé
                myEnemy.Draw();
                myFallingBall.Update(myEnemy);
                mySpaceship.Update();
                mySpaceship.Draw();
                myShootingBall.Update(mySpaceship);

                TheOptions theOptions = new TheOptions();
                if (theOptions.Sound)
                {
                    //System.Media.SystemSounds.Asterisk.Play("D:\\PROJETS\\4-Trimestre");
                    string path = @"D:\\sample-12s.wav";

                    // Create a new SoundPlayer instance
                    SoundPlayer player = new SoundPlayer(path);

                    // Play the sound
                    player.Play();
                }

                //K.O. du joueur
                if (myFallingBall.xBallPosition == mySpaceship.xPosition)
                {
                    mySpaceship.nbLifes--;
                    if (mySpaceship.nbLifes == 0)
                    {
                        gameOver = true;
                        break;
                    }
                }

                int[,] j = { { 1, 2, 3, 4, 5, 6 }, { 1, 2, 3, 4, 5, 6 }, { 1, 2, 3, 4, 5, 6 }, { 1, 2, 3, 4, 5, 6 } };
                int[] y = { 1, 2, 3, 4, 5, 6 };


                ////K.O. de l'ennemi
                for (int i = 0; i < myEnemy.myEnemies.GetLength(0); i++) //4
                {
                    if (myShootingBall.xPosition == myEnemy.xPosition + i && myShootingBall.shoot == true)
                    {
                        // Calculate the correct index for accessing j
                        int columnIndex = j[i, y[i] - 1]; // Adjusting to 0-based indexing

                        if (myEnemy.myEnemies[i, columnIndex] != " ")
                        {
                            myEnemy.myEnemies[i, columnIndex] = " ";
                            myShootingBall.shoot = false;
                            score += 30;
                            break;
                        }
                    }

                    //for (int j = 0; j < myEnemy.myEnemies.GetLength(1); j++)
                    //{
                    //    if (myEnemy.myEnemies[i, j] != " ")
                    //    {
                    //        Rectangle enemyRect = new Rectangle(
                    //            myEnemy.xPosition + j * myEnemy.Width,
                    //            myEnemy.yPosition + i * myEnemy.Height,
                    //            myEnemy.Width,
                    //            myEnemy.Height
                    //        );

                    //        Rectangle shootingBallRect = new Rectangle(
                    //            myShootingBall.xPosition,
                    //            myShootingBall.yPosition,
                    //            myShootingBall.Width,
                    //            myShootingBall.Height
                    //        );

                    //        if (myShootingBall.shoot && enemyRect.IntersectsWith(shootingBallRect))
                    //        {
                    //            myEnemy.myEnemies[i, j] = " ";
                    //            myShootingBall.shoot = false;
                    //            break;
                    //        }
                    //    }
                    //}
                }


                if (myEnemy.myEnemies == null)
                {
                    myEnemy.enemyIsAlive = false;
                    gameOver = true;
                    winner = true;
                    break;
                }

                //Console.WriteLine("Score: " + score.ToString("D").Length + 3);
            }

            if (winner)
                Console.WriteLine("GAME OVER");
            else
                Console.WriteLine("CONGRATULATION ! YOU DID IT !");

            if (gameOver)
            {
                Console.Clear();
                Console.Write("YOUR NAME : ");
                string userName = Console.ReadLine();
                List<string> users = new List<string>();
                List<int> scores = new List<int>();
                users.Add(userName);
                scores.Add(score);

                ///* AJOUT DES DONNÉES DE LA LISTE DANS UN FICHIER */
                //string path = "D:\\PROJETS\\4-Trimestre\\Highscore.txt"; //Création du chemin du fichier
                //File.AppendAllLines(path, users);     //Ajout des données
                ////File
                //string[] lines = File.ReadAllLines(path);
                //foreach (string line in lines) 
                //{ 

                //}
            }
        }
    }
}