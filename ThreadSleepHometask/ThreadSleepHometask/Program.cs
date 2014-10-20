using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadSleepHometask
{
    /*1. Создать несколько потоков, выводящих на консоль в цикле свой hashcode. Посмотреть порядок вывода.
        Добавить Sleep(1), Sleep(10), Sleep(0). Посмотреть изменения в порядке вывода.  
     * Закоментировать Sleep() и установить приоритеты потокам. Посмотреть изменения в порядке вывода.*/
    class Program
    {
        static void Print(object o)
        {
            Console.WriteLine("Поток {0}",o);
            for (; ; ) { }
        }

        static void Main(string[] args)
        {
            int flag = 0;

            ParameterizedThreadStart p = new ParameterizedThreadStart(Print);
            Thread th1 = new Thread(p);
            Thread th2 = new Thread(p);
            Thread th3 = new Thread(p);
            Thread th4 = new Thread(p);
            Thread th5 = new Thread(p);
            th1.Priority = ThreadPriority.Lowest;
            th2.Priority = ThreadPriority.Lowest;
            th3.Priority = ThreadPriority.Lowest;
            th4.Priority = ThreadPriority.Highest;
            th5.Priority = ThreadPriority.Lowest;
            th1.Start(1);
            th2.Start(2);
            th3.Start(3);
            th4.Start(4);
            th5.Start(5);

            do
            {
                //Thread.Sleep(0);
                //Thread.Sleep(10);
                //Thread.Sleep(1);
                Console.WriteLine("----" + flag + "----");
                if (Thread.CurrentThread.IsAlive)
                    Console.WriteLine("Main thread "+Thread.CurrentThread.GetHashCode());
                if (th1.IsAlive)
                    Console.WriteLine("Thread 1 " + th1.GetHashCode());
                if (th2.IsAlive)
                    Console.WriteLine("Thread 2 " + th2.GetHashCode());
                if (th3.IsAlive)
                    Console.WriteLine("Thread 3 " + th3.GetHashCode());
                if (th4.IsAlive)
                    Console.WriteLine("Thread 4 " + th4.GetHashCode());
                if (th5.IsAlive)
                    Console.WriteLine("Thread 5 " + th5.GetHashCode());
                
                flag++;

            } while (flag<5000);
            Console.WriteLine("The End");
            Console.ReadKey();
        }
    }
}
