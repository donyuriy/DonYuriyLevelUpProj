using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonMassivesHometask
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            //1. Преобразовать массив так, что бы сначала шли все отрицательные элементы, а потом положительные, 0 считать положительным.
            int[] mas = new int[10] { -2, 15, -3, 7, -8, 12, 6, -9, 0, 6 };
            int temp = 0, n = 0;
            for (int i = 0; i < mas.Length; i++)
            {
                Console.Write(mas[i] + " ");
            }
            Console.WriteLine();
            for (int i = 0; i < mas.Length; i++)    
            {
                
                if (mas[i] < 0)
                {
                    temp = mas[i];
                    for (int j = i-1; j > n-1; j--)
                    {
                        mas[j+1] = mas[j];
                    }
                    mas[n] = temp;
                    n++;
                }
            }
            for (int i = 0; i < mas.Length; i++)
            {
                Console.Write(mas[i] + " ");
            }
            Console.ReadKey();
            

            //2.Написать программу, которая предлагает пользователю ввести число и считает сколько раз это число встречается в массиве.
            Random r=new Random();
            int a = 0, numbers = 0;
            int[] mas1 = new int[50];
            for (int i = 0; i < mas1.Length; i++)
            {
                mas1[i] = r.Next(1,50);
            }
            Console.WriteLine("Ведите искомое число: ");
            a = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < mas1.Length; i++)
            {
                if (a==mas1[i])
                {
                    numbers++;
                }
            }
            Console.WriteLine("Число {0} встречается в массиве {1} раз\t",a,numbers);
            Console.WriteLine("Массив: "); 
            foreach (int item in mas1)
            {
                Console.Write(item + " ");
            }
            Console.ReadLine();

            //3. Сжать массив, удалив из него все 0 и заполнить освободившиеся справа элементы значениями -1.
            int[] mas2 = new int[] { 1, 4, -2, 0, 5, 67, 0, 23, 0, 5, 1, 7, 8, 9 };
            Console.WriteLine("Начальный массив:");
            foreach (int item in mas2)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            int n = 0;
            for (int i = 0; i < mas2.Length; i++)
            {
                if (mas2[i]==0)
                {
                    for (int j = i; j < mas2.Length-1; j++)
                    {
                        mas2[j] = mas2[j + 1];
                    }
                    n++;
                    mas2[mas2.Length - n] = -1;
                }
            }
            Console.WriteLine("Сжатый массив:");
            foreach (int item in mas2)
            {
                Console.Write(item+ " ");
            }
            Console.ReadLine();
             

            //4. В двумерном массиве порядка М на N поменяйте местами заданные столбцы.
            int [,]myArr = new int [4,8];
            int [] tempMas = new int [myArr.GetLength(0)];
            int M = 0, N = 0;
            Random r = new Random();
            Console.WriteLine("Исходный массив: ");
            for (int i = 0; i < myArr.GetLength(0); i++)    //i - сторока
            {
                for (int j = 0; j < myArr.GetLength(1); j++)    //j - столбец
                {
                    myArr[i, j] = r.Next(-20,20);
                    Console.Write(myArr[i, j]+ "\t ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Введите номера столбцов для замены");
            Console.WriteLine("Номер Первый столбец");
            M = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Второй столбец");
            N = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            for (int i = 0; i < myArr.GetLength(0); i++)
            {
                for (int j = 0; j < M; j++)
                {
                    tempMas[i] = myArr[i, M];
                    myArr[i, M] = myArr[i, N];
                    myArr[i, N] = tempMas[i];
                }
            }
            for (int i = 0; i < myArr.GetLength(0); i++)    
            {
                for (int j = 0; j < myArr.GetLength(1); j++)    
                {
                    Console.Write(myArr[i, j] + "\t ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();

            //5. Даны два массива. Массив А состоит из N элементов и отсортирован по возрастанию.
            //Массив В состоит из М элементов и отсортирован по убыванию.
            Random r = new Random();
            int[] A = new int[10];   //по возрастанию
            int[] B = new int[10];
            int temp = 0;
            Console.WriteLine("Базовый массив А:");
            for (int i = 0; i < A.Length; i++)
            {
                A[i] = r.Next(-20, 20);
                Console.Write(A[i] + " ");
            }
            Console.WriteLine();

            for (int i = 0; i < A.Length; i++)
            {
                for (int j = 0; j < A.Length; j++)
                {
                    if (A[i] < A[j])
                    {
                        temp = A[i];
                        A[i] = A[j];
                        A[j] = temp;
                    }
                }
            }
            Console.WriteLine("Массив А отсортирован по возрастанию:");
            for (int i = 0; i < A.Length; i++)
            {
                Console.Write(A[i] + " ");
            }
            Console.WriteLine("\n");
            Console.WriteLine("Базовый массив B:");
            for (int i = 0; i < B.Length; i++)
            {
                B[i] = r.Next(-20, 20);
                Console.Write(B[i] + " ");
            }
            Console.WriteLine();

            for (int i = 0; i < B.Length; i++)
            {
                for (int j = 0; j < B.Length; j++)
                {
                    if (B[i] > B[j])
                    {
                        temp = B[i];
                        B[i] = B[j];
                        B[j] = temp;
                    }
                }
            }
            Console.WriteLine("Массив B отсортирован по убыванию:");
            for (int i = 0; i < B.Length; i++)
            {
                Console.Write(B[i] + " ");
            }
            Console.Read();
             * 
            //6. Найти два самых маленьких элемента в массиве. Указать их значения и индексы.
            int []mas= new int[20];
            int temp2 = 0;
            int temp = 0;
            int n1 = -1;
            int n2 = -1;
            Random r = new Random();
            Console.WriteLine("Наш массив:");
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = r.Next(-20,20);
                Console.Write(mas[i]+" ");
            }
            Console.WriteLine();

            temp = mas[0];
            for (int i = 0; i < mas.Length; i++)
            {
                if (temp > mas[i])
                {
                    temp = mas[i];
                    n1 = i;
                }
            }

            temp2 = mas[0];
            for (int i = 0; i < mas.Length; i++)
			{
                if (temp2 > mas[i] && mas[i] != temp)
                {
                    temp2 = mas[i];
                    n2 = i;
                }
			}
            Console.WriteLine("Первый наименьший элемент: {0} имеет индекс {1}", mas[n1], n1);
            Console.WriteLine("Второй наименьший элемент: {0} имеет индекс {1}", mas[n2], n2);
            Console.ReadKey();
             * 
            //7. Дан массив А[n]. Каждый его элемент, кроме первого, заменить суммой всех предыдущих элементов (т.н. нарастающий итог).
            Random n = new Random();
            int[] A = new int[n.Next(10, 20)];
            int temp = 0;
            Console.WriteLine("Базовый массив: ");
            for (int i = 0; i < A.Length; i++)
            {
                A[i] = n.Next(0, 10);
                Console.Write(A[i]+ " ");
            }
            Console.WriteLine();
            for (int i = 1; i < A.Length; i++)
            {
                for (int j = i-1; j > -1; j--)
                {
                    temp += A[j];
                }
                A[i] = temp;
                temp = 0;
            }
            Console.WriteLine("Нарастающий итог:");
            for (int i = 0; i < A.Length; i++)
            {
                Console.Write(A[i]+ " ");
            }
            Console.ReadKey();
             
            //8. Каждый из элементов X[i] массива X[n] заменить средним значением первых i элементов этого массива (т.н.задача текущего сглаживания).
            Random r=new Random();
            int[] X = new int[r.Next(5,20)];
            int[] Y = new int[X.Length+1];
            int temp = 0;
            Console.WriteLine("Базовый массив: ");//вывод базового массива
            for (int i = 0; i < X.Length; i++)
            {
                X[i] = r.Next(0,20);
                Console.Write(X[i]+ " ");
            }
            Console.WriteLine();
            Y[0] = X[0];
            for (int i = 0; i < X.Length; i++)
            {
                for (int j = i; j > -1; j--)
                {
                    temp += X[j];
                    if (j==0)
                    {
                        temp /= (i+1); 
                    }
                }
                Y[i + 1] = temp;
                temp = 0;
            }

            Console.WriteLine("Текущее сглаживание:");// вывод полученого массива
            for (int i = 0; i < Y.Length; i++)
            {
                Console.Write(Y[i]+ " ");
            }
            Console.ReadKey();
             
            //9. Проверить, является ли заданный двумерный массив магическим квадратом.
            //(Суммы элементов всех строк, всех столбцов и обеих диагоналей в таком массиве одинаковы ).
            int[,] newArr = new int[5, 5];
            int[] sum = new int[newArr.GetLength(0)*2+2];   //массив сумм
            int check = 0;
            Random r = new Random();
            Console.WriteLine("Квадратный массив: ");
            for (int i = 0; i < newArr.GetLength(0); i++)   //заполнение
            {
                for (int j = 0; j < newArr.GetLength(1); j++)
                {
                    newArr[i, j] = r.Next(0,3);
                    Console.Write(newArr[i, j]+ "\t");
                }
                Console.WriteLine();
            }

            for (int i = 0; i < newArr.GetLength(0); i++)           //математика
            {
                for (int j = 0; j < newArr.GetLength(1); j++)
                {
                    if (i == j)                                     //диагональ 1
                        sum[sum.Length - 1] += newArr[i, j];
                    if (i == newArr.GetLength(0) - j-1)             //диагональ 2
                        sum[sum.Length - 2] += newArr[i, j];

                    sum[i] += newArr[i, j];                         // суммируем ряды
                    sum[((sum.Length-2)/2) +j] +=newArr[i, j];      // суммируем столбцы
                }
            }
            Console.WriteLine("Суммы:");                            //выдача проверки
            for (int i = 0; i < sum.Length; i++)
            {
                Console.Write(sum[i]+ " ");
            }
            Console.WriteLine();
            check = sum[0];
            for (int i = 0; i < sum.Length; i++)
            {
                if (check!=sum[i])
                {
                    Console.WriteLine("Данный двумерный массив магическим квадратом не является");
                    break;
                }
                else if(check==sum[i] && i==sum.Length-1)
                    Console.WriteLine("Данный двумерный массив является магическим квадратом");
            }

            Console.ReadKey();
            
            //10. В заданном двумерном массиве найти индекс строки, сумма элементов которой максимальна.
            
            int[,] checkArr = new int[7, 3];
            int[] sum = new int[checkArr.GetLength(0)];   // суммы строк массива checkArr
            int number = 0;
            Random r = new Random();
            Console.WriteLine("Заданный массив:");
            for (int i = 0; i < checkArr.GetLength(0); i++)   //заполнение
            {
                for (int j = 0; j < checkArr.GetLength(1); j++)
                {
                    checkArr[i, j] = r.Next(0,5);
                    Console.Write(checkArr[i, j]+ "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            for (int i = 0; i < checkArr.GetLength(0); i++)
            {
                for (int j = 0; j < checkArr.GetLength(1); j++)
                {
                    sum[i] += checkArr[i, j];       //суммируем строки
                }       
            }
            for (int i = 0; i < sum.Length; i++)
            {
                if (sum[i]>sum[number])
                    number = i;
            }
            Console.WriteLine("{0} строка содержит максимальную сумму элементов(начиная с нулевой)", number);
            Console.ReadKey();
             */
        }
    }
}
