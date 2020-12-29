using System;
using System.IO;
using System.Threading.Tasks;

namespace Bug
{
    class Program
    {
        static void Main(string[] args)
        {
            Bug bug = new Bug();
            string[] lines = File.ReadAllLines(@"C:\Users\mrmel\source\repos\Bug\Bug\in.txt");
            int[,] num = new int[lines.Length, lines[0].Split(' ').Length];
            for (int i = 0; i < lines.Length; i++)
            {
                string[] temp = lines[i].Split(' ');
                for (int j = 0; j < temp.Length; j++)
                {
                    num[i, j] = Convert.ToInt32(temp[j]);
                    if (num[i, j] == 2)
                    {
                        bug.X = i;
                        bug.Y = j;
                    }
                }
                
            }

            /* проверяем выводом на консоль
            for (int i = 0; i < num.GetLength(0); i++)
                for (int j = 0; j < num.GetLength(1); j++)
                    Console.WriteLine(num[i, j]);
            */
            
            Console.ReadLine();
        }
        class Move
        {
            Bug bug = new Bug();
            private void Turn(int X, int Y)
            {
                switch (X)
                {
                    case 0:
                        {
                            switch (Y)
                            {
                                case 1:
                                    bug.DirectionX = 1;
                                    bug.DirectionY = 0;
                                    break;
                                case -1:
                                    bug.DirectionX = -1;
                                    bug.DirectionY = 0;
                                    break;
                                default: break;
                            }
                            break;
                        }
                    case 1:
                        {
                            switch (Y)
                            {
                                case 0:
                                    bug.DirectionX = 0;
                                    bug.DirectionY = -1;
                                    break;
                                default: break;
                            }
                            break;
                        }
                    case -1:
                        {
                            switch (Y)
                            {
                                case 0:
                                    bug.DirectionX = 0;
                                    bug.DirectionY = 1;
                                    break;
                                default: break;
                            }
                            break;
                        }
                    default: break; 
                }
            }
            void LookAround(int [,] arr, int X, int Y, int DirectionX, int DirectionY)
            {
                
                if (arr[X + DirectionX, Y + DirectionY] == 0)
                {
                    bug.X = bug.X + DirectionX;
                    bug.Y = bug.Y + DirectionY;
                    bug.Score++;
                    LookAround(arr, bug.X, bug.Y, bug.DirectionX, bug.DirectionY);
                }
                else if (arr[X + DirectionX, Y + DirectionY] == 1)
                {
                    Turn(DirectionX, DirectionY);
                    LookAround(arr, bug.X, bug.Y, bug.DirectionX, bug.DirectionY);
                }
                else if (arr[X + DirectionX, Y + DirectionY] == 3)
                {
                    return;
                }
            }

        }
        class Bug
        {
            public int X;
            public int Y;
            public int DirectionY = 1; //(-1) - up, (1) - down
            public int DirectionX = 0; //(-1) - left, (1) - right
            public int Score = 0;
        }
    }
}
