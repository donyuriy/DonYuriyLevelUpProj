using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fractions
{
    class Program
    {
        static void Main(string[] args)
        {
            int i1=0,n1=0,d1=0,i2=0,n2=0,d2=0;
            char action='q';
            string str="";
            //  МЕНЮ ПОЛЬЗОВАТЕЛЯ
            do              
            {
                Console.Clear();
                try
                {
                    Console.WriteLine("Введите целую часть первой дроби: ");
                    i1 = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("0");
                    i1 = 0;
                }
                try
                {
                    Console.WriteLine("Введите числитель первой дроби: ");
                    n1 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите знаменатель первой дроби: ");
                    d1 = Convert.ToInt32(Console.ReadLine());
                    if (d1 < 0)
                        throw new FormatException("Знаменатель должен быть не отрицательным числом");
                }
                catch (FormatException e)
                {
                    Console.WriteLine("У дроби не может быть такого значения числителя или знаменателя!" +e.Message);
                    Console.ReadKey();
                    continue;
                }
                Console.Clear();
                try
                {
                    Console.WriteLine("Введите целую часть второй дроби: ");
                    i2 = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("0");
                    i2 = 0;
                }
                try
                {
                    Console.WriteLine("Введите числитель второй дроби: ");
                    n2 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите знаменатель второй дроби: ");
                    d2 = Convert.ToInt32(Console.ReadLine());
                    if (d2 < 0)
                        throw new FormatException("Знаменатель должен быть не отрицательным числом");
                }
                catch (FormatException e)
                {
                    Console.WriteLine("У дроби не может быть такого значения числителя или знаменателя!"+e.Message);
                    Console.ReadKey();
                    continue;
                }
                
                Console.WriteLine("Выберите действие:\n+ сложение\n- вычитание\n* умножение\n/ деление \n= сравнить дроби на равенство "+
                    "\n> или < cравнить дроби на больше-меньше \n1 проверить на правильность первую дробь \n2 проверить на правильность вторую дробь"+
                    "\n3 дополнительная часть(a=10, f*a; d=1.5, f+d)");
                action = Convert.ToChar(Console.ReadLine());
                Console.Clear();
                if (i1 == 0 && i2 != 0)
                    Console.WriteLine("({0}/{1}) {2} {3}({4}/{5}) = \n\nВсё верно? (y/n)", n1, d1, action, i2, n2, d2);
                else if (i2 == 0 && i1 != 0)
                    Console.WriteLine("{0}({1}/{2}) {3} ({4}/{5}) = \n\nВсё верно? (y/n)", i1, n1, d1, action, n2, d2);
                else if (i1 == 0 && i2 == 0)
                    Console.WriteLine("({0}/{1}) {2} ({3}/{4}) = \n\nВсё верно? (y/n)", n1, d1, action, n2, d2);
                else
                    Console.WriteLine("{0}({1}/{2}) {3} {4}({5}/{6}) = \n\nВсё верно? (y/n)", i1, n1, d1, action, i2, n2, d2);
                str = Console.ReadLine();
            } while (str != "y");

            // СОЗДАНИЕ ОБЪЕКТОВ
            Fraction f1 = new Fraction(n1,d1,i1);
            Fraction f2 = new Fraction(n2,d2,i2);
            Fraction f3 = new Fraction();
            
            switch (action)
            {
                case '+':
                    Console.WriteLine("Cумма чисел: " + f3.Summ(f1, f2));
                    break;
                case '-':
                    Console.WriteLine("Разность чисел: " + f3.Difference(f1, f2));
                    break;
                case '*':
                    Console.WriteLine("Произведение чисел: "+f3.Multiplication(f1,f2));
                    break;
                case '/':
                    Console.WriteLine("Частное чисел: "+f3.Division(f1,f2));
                    break;
                case '<':
                    Console.WriteLine(f3.Greater(f1, f2));
                    break;
                case '>':
                    Console.WriteLine(f3.Greater(f1, f2));
                    break;
                case '=':
                    Console.WriteLine(f3.Equality(f1,f2));
                    break;
                case '1':
                    Console.WriteLine(f3.Improper(f1));
                    break;
                case '2':
                    Console.WriteLine(f3.Improper(f2));
                    break;
                case '3':
                    int a = 10;
                    double d = 1.5;
                    Console.WriteLine("This part is not accomplished yet.................");
                    Console.WriteLine("{0}\n{1}",f3.MultiplicationInt(f1,a),f3.SummDouble(f1,d));
                    break;
                case 'q':
                    Console.WriteLine("До свидания!");
                    break;
                default:
                    Console.WriteLine("Действие не возможно!");
                    break;
            }
            Console.ReadLine();
        }
    }
}
