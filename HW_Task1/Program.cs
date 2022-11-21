using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HW_Task1
{
    class Program
    {
        static int a = Convert.ToInt32(Console.ReadLine());
        static int b = Convert.ToInt32(Console.ReadLine());
        static char[,] cleanBox = new char[a, b];//Пустой массив для заполнения
        static int[,] timeBox = new int[a, b];//Массив для заплнения рандомными цифрафи(временем на обработку)

        static void Main(string[] args)
        {
            #region Массив для проверки времени
            Console.WriteLine("Время на обработку каждого поля:");
            Random random = new Random();
            for (int i = 0; i < a; i++)
            {
                Console.WriteLine();

                for (int j = 0; j < b; j++)
                {
                    timeBox[i, j] = random.Next(0, 50);
                    Console.Write("{0,3}", timeBox[i, j]);
                }
            }
            Console.WriteLine();
            #endregion

            ThreadStart threadStart = new ThreadStart(GardnerX);
            Thread thread = new Thread(threadStart);
            thread.Start();

            GardnerO();

            Console.WriteLine();
            Console.WriteLine("X - Первый садовник. O - Второй садовник");
            for (int i = 0; i < a; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < b; j++)
                {
                    Console.Write("{0,3}", cleanBox[i, j]);
                }
            }

            Console.WriteLine();
            Console.ReadKey();


        }
        static void GardnerX() //с верхнего левого угла сада и перемещается слева направо, сделав ряд, он спускается вниз.
        {
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                    if (cleanBox[i, j] == 'O')
                    {
                        break;
                    }
                    else if (timeBox[i, j] >= 0)
                    {
                        int delay = timeBox[i, j];
                        cleanBox[i, j] = 'X';
                        Thread.Sleep(delay);
                    }
            }
        }
        static void GardnerO() //с нижнего правого угла сада и перемещается снизу вверх, сделав ряд, он перемещается влево
        {
            for (int i = b - 1; i > 0; i--)
            {
                for (int j = a - 1; j > 0; j--)
                {
                    if (cleanBox[j, i] == 'X')
                        break;
                    else if (timeBox[j, i] >= 0)
                    {
                        int delay = timeBox[j, i];
                        cleanBox[j, i] = 'O';
                        Thread.Sleep(delay);
                    }
                }
            }
        }
    }
}
