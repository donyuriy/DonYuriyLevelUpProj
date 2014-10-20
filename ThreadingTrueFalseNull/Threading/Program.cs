using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Threading
{
    class UserClass
    {
        Queue<bool?> q = new Queue<bool?>();
       
        public void TrueFalseNull(object o)
        {
            bool? flag;
            do
            {
                Console.WriteLine();
                int a = 0;
                Thread.Sleep(100);
                Random r = new Random();
                Thread.Sleep(100);
                a = r.Next(1, 4);
                if (a == 1)
                {
                    flag = true;
                    
                }
                if (a == 2)
                {
                    flag = false;
                }
                else
                {
                    flag = null;
                    Console.WriteLine("Поток" + (int)o);
                    Console.WriteLine("NULL");
                    Console.WriteLine();
                }

                if (flag != null)
                {
                    q.Enqueue(flag);
                    Console.WriteLine("Поток" + (int)o);
                    Console.WriteLine("{0} записан в очередь", flag);
                    Console.WriteLine();
                }
                
            } while (flag != null);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            UserClass uObj = new UserClass();

            ParameterizedThreadStart param = new ParameterizedThreadStart(uObj.TrueFalseNull);

            Thread t1 = new Thread(param);
            Thread t2 = new Thread(param);
            Thread t3 = new Thread(param);

            t1.Start(1);
            t2.Start(2);
            t3.Start(3);
            Thread.Sleep(2000);
            if (!t1.IsAlive)
                Console.WriteLine("Поток 1 завершён");
            if (!t2.IsAlive)
                Console.WriteLine("Поток 2 завершён");
            if (!t3.IsAlive)
                Console.WriteLine("Поток 3 завершён"); 
            Console.ReadKey();
            
        }
    }
}
