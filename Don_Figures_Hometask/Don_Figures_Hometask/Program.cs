using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Don_Figures_Hometask
{
    class Program
    {
        static void Main(string[] args)
        {
            const int n = 6;
            const int m = 6;
            /*
            //1.Пустой квадрат
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i==0||j==0||i==m-1||j==n-1)
                    {
                        Console.Write("* ");
                    }
                    else Console.Write("  ");
                }
                Console.WriteLine();
            }
           //Console.WriteLine();
            Console.ReadLine();

            //2. заполненый квадрад

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine();
            }
            Console.ReadLine();

            //3.Треугольник 1 пустой
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j || i == m - 1 || j == 0)
                    {
                        Console.Write("* ");
                    }
                    else Console.Write("  ");
                }
                Console.WriteLine();
            }
            Console.ReadLine();

            //4.Треугольник 1 заполненый
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i >= j || i == m - 1 || j == 0)
                    {
                        Console.Write("* ");
                    }
                    else Console.Write("  ");
                }
                Console.WriteLine();
            }
            Console.ReadLine();

            //5.Треугольник 2 пустой
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i==j||i==0||j==n-1)
                    {
                        Console.Write("* ");
                    }
                    else Console.Write("  ");
                }
                Console.WriteLine();
            }
            Console.ReadLine();

            //6.Треугольник 2 закрашен
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i <= j || i == 0 || j == n - 1)
                    {
                        Console.Write("* ");
                    }
                    else Console.Write("  ");
                }
                Console.WriteLine();
            }
            Console.ReadLine();

            
            //7.Треугольник 3 пустой
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == 0 || j == 0 || i+j == n-1)
                    {
                        Console.Write("* ");
                    }
                    else Console.Write("  ");
                }
                Console.WriteLine();
            }
            Console.ReadLine();

            //8.Треугольник 3 заполненый
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == 0 || j == 0 || i + j <= n - 1)
                    {
                        Console.Write("* ");
                    }
                    else Console.Write("  ");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
               
            //9.Треугольник 4 пустой
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == m-1 || j == n-1 || i + j == n - 1)
                    {
                        Console.Write("* ");
                    }
                    else Console.Write("  ");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
             
            //10.Треугольник 3 заполненый
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == n - 1 || j == n - 1 || i + j >= n - 1)
                    {
                        Console.Write("* ");
                    }
                    else Console.Write("  ");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
              
              //11.Прямоугольник с диагоналями
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j || i == 0 || i == m - 1 || i + j == n - 1||j==0||j==n-1)
                    {
                        Console.Write("* ");
                    }
                    else Console.Write("  ");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
             
            //12. Песочные часы пустые
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j || i == 0 || i == m - 1 || i + j == n - 1)
                    {
                        Console.Write("* ");
                    }
                    else Console.Write("  ");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
                        
            //13. Бантик пустой 
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j || j == 0 || j == n - 1 || i + j == n - 1)
                    {
                        Console.Write("* ");
                    }
                    else Console.Write("  ");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
           
            //14 Паралеллограм пустой
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < 2 * n; j++)
                {
                    if (i + j == n - 1  || (i == m - 1 && j <= n) || (i == 0 && j >= n) || i + j == 2 * n - 1 )
                    {
                        Console.Write("* ");
                    }
                    else Console.Write("  ");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
            
            //15 Паралеллограм заполненый
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < 2 * n; j++)
                {
                    if (i + j >= n - 1 && i + j <= 2 * n - 1 || (i == m - 1 && j <= n) || (i == 0 && j >= n) || i + j == 2 * n - 1)
                    {
                        Console.Write("* ");
                    }
                    else Console.Write("  ");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
              */
            //16/ Ромб пустой
            for (int i = 0; i < 2*m; i++)
            {
                for (int j = 0; j < 2 * n; j++)
                {
                    if ((i + j == n - 1 && i <= m - 1) || i == j + m || i + j == 2 * n + m - 1 || (i==j-m))
                    {
                        Console.Write("* ");
                    }
                    else Console.Write("  ");
                }
                Console.WriteLine();
            }
            Console.ReadLine();

            /*
            //Найти из диапазона все простые числа
            int a = 0, b = 0;
            Console.WriteLine("Введите начальное число диапазона: ");
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите конечное число диапазона: ");
            b = Convert.ToInt32(Console.ReadLine());
            for (int i = a; i < b; i++)
            {
                for (int j = 2; j < i; j++)
                {
                    if (i%j==0)
                    {
                        break;
                    }
                    else if (j==i-1)
                    {
                        Console.WriteLine("Число {0} является простым",i);
                    }
                }
            }
            Console.ReadKey();

            //Найти совершенные числа
            int a = 0, b = 0, sum = 0;
            Console.WriteLine("Введите начальное число диапазона: ");
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите конечное число диапазона: ");
            b = Convert.ToInt32(Console.ReadLine());
            for (int i = a; i < b; i++)
            {
                sum = 0;
                for (int j = 1; j < i; j++)
                {
                    if (i%j==0)
                    {
                        sum += j;
                    }
                }
                if (sum==i)
                {
                    Console.WriteLine("Число {0} является совершенным",i);
                }
            }
            Console.ReadKey();
            

            //Ввести число и найти сколько цифр в числе, сумму чисел в числе и число наоборот
            int a = 0, b=0, capacity = 0, summ = 0;
            Console.WriteLine("Введите число");
            a = Convert.ToInt32(Console.ReadLine());
            b = a;  //это для того чтобы сохранить число
            do
            {
                capacity++;     //определяем сколько цифр в числе(разрядность)
                summ += a % 10; //суммируем
                a = a / 10;     

            } while (a>=1);
            a = 0;
            for (int i = capacity-1; i >-1; i--)
            {
                int tenToThePower = 1;
                for (int j = 0; j < i; j++)
                {
                    tenToThePower *= 10;
                }
                a += (b % 10)*tenToThePower;  //делим с остатком и умножаем на 10 в степени разрадности
                b /= 10;
                tenToThePower = 1;
            }
            Console.WriteLine("Разрядность числа равна: {0}\nСумма цифр числп равна: {1}\nЧисло наоборот: {2}", capacity, summ,a);
            Console.ReadKey();
            */
        }
    }
}
