using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace xxxx
{
    class Program

    {
        static char[,] matrix = new char[16, 32];
        static char[,] pointQ = new char[3, 3];
        static char[,] pointW = new char[3, 3];
        static char[,] pointR = new char[3, 3];
        static char[,] pointY = new char[3, 3];
        static int counterq = 0;
        static int counterw= 0;
        static int counterr = 0;
        static int counteralive = 0;
        static int step = 0;
        static char[,] tempQ = new char[3, 3];

     

        static char[,] RotateMatrix(char[,] matrix)
        {
            char[,] ret = new char[3, 3];

            ret[0, 0] = matrix[2, 0];
            ret[0, 1] = matrix[1, 0];
            ret[0, 2] = matrix[0, 0];

            ret[1, 0] = matrix[2, 1];
            ret[1, 1] = matrix[1, 1];
            ret[1, 2] = matrix[0, 1];

            ret[2, 0] = matrix[2, 2];
            ret[2, 1] = matrix[1, 2];
            ret[2, 2] = matrix[0, 2];

            return ret;
        }

        static void particleQ(int x, int y)
        {
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (pointQ[i + 1, j + 1] == 'o') matrix[y + i, x + j] = pointQ[i + 1, j + 1];
                }
            }
        }
        static void particleW(int x, int y)
        {
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (pointW[i + 1, j + 1] == 'o')
                        matrix[y + i, x + j] = pointW[i + 1, j + 1];
                }
            }
        }
        static void particleR(int x, int y)
        {
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (pointR[i + 1, j + 1] == 'o') matrix[y + i, x + j] = pointR[i + 1, j + 1];
                }
            }
        }

        static void particleY(int x, int y)
        {
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (pointY[i + 1, j + 1] == 'o') matrix[y + i, x + j] = pointY[i + 1, j + 1];
                }
            }
        }

        //public MatrixTemp(int[,] newGrid)
        //{
        //    generation = (int[,])newGrid.Clone();

        //    generationCount = 1;

        //    width = generation.GetLength(1);
        //    height = generation.GetLength(0);

        //    lastGeneration = new int[height, width];
        //}


        //public void ProcessGeneration()
        //{
        //   char[,] nextGeneration = new char[16,32];

        //    lastGeneration = (int[,])generation.Clone();

        //    generationCount++;

        //    for (int y = 0; y < height; y++)
        //    {
        //        for (int x = 0; x < width; x++)
        //        {
        //            if (Neighbours(x, y) < 2)
        //                nextGeneration[y, x] = 0;
        //            else if (generation[y, x] == 0 && Neighbours(x, y) == 3)
        //                nextGeneration[y, x] = 1;
        //            else if (generation[y, x] == 1 &&
        //                    (Neighbours(x, y) == 2 || Neighbours(x, y) == 3))
        //                nextGeneration[y, x] = 1;
        //            else
        //                nextGeneration[y, x] = 0;
        //        }
        //    }

        //    generation = (int[,])nextGeneration.Clone();
        //}



        static void screen()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("+-----------------------------------------------------------------+");
            Console.WriteLine("|                                                                 |");
            Console.WriteLine("|                                                                 |");
            Console.WriteLine("|                                                                 |");
            Console.WriteLine("|                                                                 |");
            Console.WriteLine("|                                                                 |");
            Console.WriteLine("|                                                                 |");
            Console.WriteLine("|                                                                 |");
            Console.WriteLine("|                                                                 |");
            Console.WriteLine("|                                                                 |");
            Console.WriteLine("|                                                                 |");
            Console.WriteLine("|                                                                 |");
            Console.WriteLine("|                                                                 |");
            Console.WriteLine("|                                                                 |");
            Console.WriteLine("|                                                                 |");
            Console.WriteLine("|                                                                 |");
            Console.WriteLine("|                                                                 |");
            Console.WriteLine("+-----------------------------------------------------------------+");


            Console.SetCursorPosition(70, 1);
            Console.Write("Step:" + step);

            Console.SetCursorPosition(70, 3);
            Console.Write("Live:"+counteralive);

            Console.SetCursorPosition(70, 6);
            Console.Write("Q");

            Console.SetCursorPosition(70, 10);
            Console.Write("W");

            Console.SetCursorPosition(70, 14);
            Console.Write("R");

            for (int i = 0; i < 3; i++) // yanda particle Q için
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.SetCursorPosition(72 + j * 2 + 2, 4 + i + 1);
                    Console.Write(pointQ[i, j]);
                }
            }

            for (int i = 0; i < 3; i++) // yanda particle W için
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.SetCursorPosition(72 + j * 2 + 2, 8 + i + 1);
                    Console.Write(pointW[i, j]);
                }
            }

            for (int i = 0; i < 3; i++) // yanda particle R için
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.SetCursorPosition(72 + j * 2 + 2, 12 + i + 1);
                    Console.Write(pointR[i, j]);
                }
            }


            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 32; j++)
                {
                    Console.SetCursorPosition(j * 2 + 2, i + 1);
                    Console.Write(matrix[i, j]);
                }
            }
        }
        static void Main(string[] args)
        {
            ConsoleKeyInfo csi;
            int cursorx = 16, cursory = 8;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = '.';
                }
            }
            //q
            pointQ[0, 0] = '.';
            pointQ[1, 0] = 'o';
            pointQ[2, 0] = '.';
            pointQ[0, 1] = '.';
            pointQ[1, 1] = 'o';
            pointQ[2, 1] = '.';
            pointQ[0, 2] = '.';
            pointQ[1, 2] = 'o';
            pointQ[2, 2] = '.';
            //w
            pointW[0, 0] = 'o';
            pointW[1, 0] = 'o';
            pointW[2, 0] = '.';
            pointW[0, 1] = 'o';
            pointW[1, 1] = '.';
            pointW[2, 1] = 'o';
            pointW[0, 2] = 'o';
            pointW[1, 2] = '.';
            pointW[2, 2] = '.';
            //r
            tempQ[0, 0] = '.';
            tempQ[1, 0] = '.';
            tempQ[2, 0] = '.';
            tempQ[0, 1] = '.';
            tempQ[1, 1] = '.';
            tempQ[2, 1] = '.';
            tempQ[0, 2] = '.';
            tempQ[1, 2] = '.';
            tempQ[2, 2] = '.';
            Random b = new Random();
            int a = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {


                    a = b.Next(1, 3);
                    if (a == 1)
                    {
                        pointR[i, j] = '.';
                    }
                    else if (a == 2)
                    {
                        pointR[i, j] = 'o';
                    }

                }
            }


            screen();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    csi = Console.ReadKey(true);
                    if (csi.Key == ConsoleKey.RightArrow && cursorx < 31)
                    {
                        Console.SetCursorPosition(cursorx, cursory);
                   
                        cursorx++;
                    }
                    if (csi.Key == ConsoleKey.LeftArrow && cursorx > 0)
                    {
                        Console.SetCursorPosition(cursorx, cursory);
                    
                        cursorx--;
                    }
                    if (csi.Key == ConsoleKey.UpArrow && cursory > 0)
                    {
                        Console.SetCursorPosition(cursorx, cursory);
                 
                        cursory--;
                    }
                    if (csi.Key == ConsoleKey.DownArrow && cursory < 15)
                    {
                        Console.SetCursorPosition(cursorx, cursory);
                       
                        cursory++;
                    }
                    if (csi.Key == ConsoleKey.Escape)
                    {
                        break;
                    }
                    if (csi.Key == ConsoleKey.E)
                    {
                        matrix[cursory, cursorx] = 'o';
                    }
                    if (csi.Key == ConsoleKey.D3 || csi.Key == ConsoleKey.NumPad3)
                    {
                        matrix[cursory, cursorx] = '.';
                    }
                    if (csi.Key == ConsoleKey.D0)
                    {
                        for (int i = 0; i < 16; i++)
                        {
                            for (int j = 0; j < 32; j++)
                            {
                                matrix[i, j] = '.';
                            }
                        }

                    }
                    if (csi.Key == ConsoleKey.D1)//rotation of Q
                    {
                        pointQ = RotateMatrix(pointQ);
                    }
                    if (csi.Key == ConsoleKey.D2) //rotation of W
                    {
                        pointW = RotateMatrix(pointW);
                        

                    }
                    if (csi.Key == ConsoleKey.D4)//rotation of 
                    {
                        pointR = RotateMatrix(pointR);
                    }
                    if (csi.Key == ConsoleKey.Q)
                    {

                        particleQ(cursorx, cursory);

                    }
                    if (csi.Key == ConsoleKey.W)
                    {

                        particleW(cursorx, cursory);

                    }
                    if (csi.Key == ConsoleKey.R)
                    {

                        particleR(cursorx, cursory);

                    }
                    if (csi.Key == ConsoleKey.T)
                    {

                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {


                                a = b.Next(1, 3);
                                if (a == 1)
                                {
                                    pointR[i, j] = '.';
                                }
                                else if (a == 2)
                                {
                                    pointR[i, j] = 'o';
                                }

                            }
                        }



                    }
                    if (csi.Key == ConsoleKey.Y)
                    {

                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {


                                a = b.Next(1, 3);
                                if (a == 1)
                                {
                                    pointY[i, j] = '.';
                                }
                                else if (a == 2)
                                {
                                    pointY[i, j] = 'o';
                                }

                            }

                        }

                        int x = 0;
                        Random rnd = new Random();
                        x = rnd.Next(0, 33);

                        cursorx = x;

                        int y = 0;
                        Random rnd1 = new Random();
                        y = rnd1.Next(0, 17);

                        cursory = y;
                        particleY(cursorx, cursory);


                    }



                    if (csi.Key == ConsoleKey.Spacebar)
                    {
                        step++;

                    
                    }


                    for (int i = 0; i < 16; i++)
                    {
                        for (int j = 0; j < 32; j++)
                        {
                            Console.SetCursorPosition(j * 2 + 2, i + 1);
                            if (matrix[i, j] == 'o')
                                counteralive++;
                        }
                    }
                    screen();
                   
                    Console.SetCursorPosition(cursorx * 2 + 2, cursory + 1);
                }

                Thread.Sleep(50);
            }
            Console.ReadLine();
        }
    }
}