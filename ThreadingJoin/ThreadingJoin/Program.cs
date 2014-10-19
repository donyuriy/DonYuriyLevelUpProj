using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingJoin
{
    /*2. Написать программу, демонстрирующую работу Join():
     * основной поток должен дожидаться окончания работы (не менее) 2-х потоков,
     * потом продолжать работу. Конструктивно: дополнительные потоки должны предоставлять данные,
     * необходимые для дальнейшей работы основного потока.*/

    public class MyClass
    {
        
        public int flag = 0;    //значение этой переменной должен получить Основной поток
        public void Mathematics(object obj) 
        {
            Console.WriteLine(String.Format("Started in {0}",Thread.CurrentThread.Name));   //выводим номер потока, в котором запущен метод
            flag = (int)obj;    //некие математические действия
                if (flag == 2)
                {
                    flag *= flag;
                }
                if (flag == 3)
                {
                    flag = 10;
                }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            MyClass mObj = new MyClass();
            Console.WriteLine("Variable's value is {0}", mObj.flag);    //начальное значение искомой переменной
            Console.WriteLine();
            ParameterizedThreadStart pts = new ParameterizedThreadStart(mObj.Mathematics);  //для старта метода с параметрами
            Thread th1 = new Thread(pts);
            Thread th2 = new Thread(pts);
            Thread th3 = new Thread(pts);
            th1.Name = "Thread1";   //каждому потоку присваеваем Имя
            th2.Name = "Thread2";
            th3.Name = "Thread3";

            th1.Start(1);   //старт потоков
            th2.Start(2);
            th3.Start(3);
            Console.WriteLine("Variable's value is {0}", mObj.flag);  //промежуточное значение искомой переменной  
            Console.WriteLine();
            while (true)
            {
                if (th1.IsAlive || th2.IsAlive || th3.IsAlive)  //
                {
                    Thread.Sleep(5);
                    Console.WriteLine("Main thread stoped");    //если Дочерние потоки не завершены, то останавливаем Основной
                }
                else
                    break;
            }
            Console.WriteLine("Main Tread continued");
            Console.WriteLine();
            Console.WriteLine("Variable's value is {0}", mObj.flag);  //конечное значение искомой переменной
            Console.ReadKey();
        }
    }
}
