using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fractions
{
    class Fraction
    {
        public int Numerator { get; private set; }     //числитель
        public int Denominator { get; private set; }   //знаминатель
        public bool Negative { get; private set; }      //дробь отрицательна
        public int IntegerPart { get; private set; }  //целая часть

        public Fraction(int n = 0, int d = 0, int i = 0)    //не только инициализирует поля но и приводит к форме без целой части
        {
            //1.конструктор сразу преобразует дробь так чтобы не было целой части
            //2.если дробь отрицательная конструктор преобразует её в положительную и ставит Negative в true
            //в связи с этим инциализация в конструкторе происходит в зависимости от значений целого, числителя, знаменателя, отрицательности
            bool f = false;//показывает что инициализация прошла в одном из следующих блоков
            if (i == 0 && n > 0 && d != 0 && !f)    
            {
                this.Denominator = d;
                this.Numerator = n;
                this.IntegerPart = 0;
                this.Negative = false;
                f = !f;
            }
            if (i == 0 && n < 0 && d != 0 && !f)
            {
                this.Denominator = d;
                this.Numerator = -n;
                this.IntegerPart = 0;
                this.Negative = true;
                f = !f;
            }
            if (i > 0 && n > 0 && d != 0&&!f)
            {
                this.Denominator = d;
                this.Numerator = n + (i * d);
                this.IntegerPart = 0;
                this.Negative = false;
                f = !f;
            }
            if (i < 0 && n > 0 && d != 0 && !f)
            {
                this.Denominator = d;
                this.Numerator = n + (-i * d);
                this.IntegerPart = 0;
                this.Negative = true;
                f = !f;
            }
            if (i > 0 && n < 0 && d != 0 && !f)
            {
                this.Denominator = d;
                this.Numerator = -n + (i * d);
                this.IntegerPart = 0;
                this.Negative = true;
                f = !f;
            }
            if (i < 0 && n < 0 && d != 0 && !f)
            {
                this.Denominator = d;
                this.Numerator = -n + (-i * d);
                this.IntegerPart = 0;
                this.Negative = true;
                f = !f;
            }
            if (d == 0 && !f)
            {
                this.Denominator = 1;
                this.Numerator = (i * d);
                this.IntegerPart = 0;
                this.Negative = true;
                f = !f;
            }
        }
        public override string ToString()   //для вариантов без целого и без дробной части
        {
            string s;
            if (IntegerPart == 0)
                s = String.Format("({0}/{1})", Numerator, Denominator);
            else if (Numerator == 0)
                s = String.Format("{0}",IntegerPart);
            else
                s = String.Format("{0}({1}/{2})", IntegerPart, Numerator, Denominator);

            return s;
        }
        public static Fraction operator +(Fraction obj1, Fraction obj2)     //СЛОЖЕНИЕ
        {
            Fraction obj3 = new Fraction();
            if (obj1.Denominator == obj2.Denominator)   //если знаменатели равны
            {
                if (obj1.Negative && obj2.Negative)
                {//обе дроби отрицательные
                    obj3.Numerator=-obj1.Numerator - obj2.Numerator;
                    obj3.Denominator=obj1.Denominator;
                    return obj3;
                }
                else if (!obj1.Negative && obj2.Negative)
                {//левая дробь отрицательная
                    obj3.Numerator=obj1.Numerator - obj2.Numerator;
                    obj3.Denominator = obj1.Denominator;
                    return obj3;
                }
                else if (obj1.Negative && !obj2.Negative)
                {//правая дробь отрицательная
                    obj3.Numerator=-obj1.Numerator + obj2.Numerator;
                    obj3.Denominator = obj1.Denominator;
                    return obj3;
                }
                obj3.Numerator=obj1.Numerator + obj2.Numerator;
                obj3.Denominator=obj1.Denominator;   //обе дроби положительные
                return obj3;
            }
            else
            {
                obj1.Numerator *= obj2.Denominator;
                obj2.Numerator *= obj1.Denominator;
                obj1.Denominator *= obj2.Denominator;
                obj2.Denominator = obj1.Denominator;

                if (obj1.Negative && obj2.Negative)
                {//обе дроби отрицательные
                    obj3.Numerator = -obj1.Numerator - obj2.Numerator;
                    obj3.Denominator = obj1.Denominator;
                    return obj3;
                }
                else if (!obj1.Negative && obj2.Negative)
                {//левая дробь отрицательная
                    obj3.Numerator = obj1.Numerator - obj2.Numerator;
                    obj3.Denominator = obj1.Denominator;
                    return obj3;
                }
                else if (obj1.Negative && !obj2.Negative)
                {//правая дробь отрицательная
                    obj3.Numerator = -obj1.Numerator + obj2.Numerator;
                    obj3.Denominator = obj1.Denominator;
                    return obj3;
                }
                obj3.Numerator = obj1.Numerator + obj2.Numerator;
                obj3.Denominator = obj1.Denominator;   //обе дроби положительные
                return obj3;
            }
        }
        public static Fraction operator -(Fraction obj1, Fraction obj2)     //ВЫЧИТАНИЕ
        {
            Fraction obj3 = new Fraction();

            if (obj1.Denominator == obj2.Denominator)       //если знаменатели одинаковые 
            {
                if (obj1.Negative && obj2.Negative)
                {
                    //обе дроби отрицательные
                    obj3.Numerator = -obj1.Numerator + obj2.Numerator;
                    obj3.Denominator = obj1.Denominator;
                    return obj3;
                }
                else if (!obj1.Negative && obj2.Negative)
                {//левая дробь отрицательная
                    obj3.Numerator = obj1.Numerator + obj2.Numerator;
                    obj3.Denominator = obj1.Denominator;
                    return obj3;
                }
                else if (obj1.Negative && !obj2.Negative)
                {//правая дробь отрицательная
                    obj3.Numerator=-obj1.Numerator - obj2.Numerator;
                    obj3.Denominator = obj1.Denominator;
                    return obj3;
                }
                obj3.Numerator=obj1.Numerator - obj2.Numerator;
                obj3.Denominator = obj1.Denominator;  //обе дроби положительные
                return obj3;
            }
            else            //если знаменатели разные
            {
                obj1.Numerator *= obj2.Denominator;
                obj2.Numerator *= obj1.Denominator;
                obj1.Denominator *= obj2.Denominator;
                obj2.Denominator = obj1.Denominator;

                if (obj1.Negative && obj2.Negative)
                {
                    //обе дроби отрицательные
                    obj3.Numerator = -obj1.Numerator + obj2.Numerator;
                    obj3.Denominator = obj1.Denominator;
                    return obj3;
                }
                else if (!obj1.Negative && obj2.Negative)
                {//левая дробь отрицательная
                    obj3.Numerator = obj1.Numerator + obj2.Numerator;
                    obj3.Denominator = obj1.Denominator;
                    return obj3;
                }
                else if (obj1.Negative && !obj2.Negative)
                {//правая дробь отрицательная
                    obj3.Numerator = -obj1.Numerator - obj2.Numerator;
                    obj3.Denominator = obj1.Denominator;
                    return obj3;
                }
                obj3.Numerator = obj1.Numerator - obj2.Numerator;
                obj3.Denominator = obj1.Denominator;  //обе дроби положительные
                return obj3;
            }
        }
        public static Fraction operator *(Fraction obj1, Fraction obj2)     //УМНОЖЕНИЕ ДРОБЕЙ
        {
            Fraction obj3 = new Fraction();
            if ((obj1.Negative && obj2.Negative) || (!obj1.Negative && !obj2.Negative))
            {
                obj3.Numerator = obj1.Numerator * obj2.Numerator;
                obj3.Denominator = obj1.Denominator * obj2.Denominator;
                return obj3;
            }
            else
            {
                obj3.Numerator = -obj1.Numerator * obj2.Numerator;
                obj3.Denominator = obj1.Denominator * obj2.Denominator;
                return obj3;
            }
        }
        public static Fraction operator /(Fraction obj1, Fraction obj2)     //ДЕЛЕНИЕ
        {
            Fraction obj3 = new Fraction();
            if ((obj1.Negative && obj2.Negative) || (!obj1.Negative && !obj2.Negative))
            {
                obj3.Numerator = obj1.Numerator * obj2.Denominator;
                obj3.Denominator = obj1.Denominator * obj2.Numerator;
                return obj3;
            }
            else
            {
                obj3.Numerator = -obj1.Numerator * obj2.Denominator;
                obj3.Denominator = obj1.Denominator * obj2.Numerator;
                return obj3;
            }

        }
        public static Fraction operator *(Fraction obj, int a)  //УМНОЖЕНИЕ ДРОБИ НА ЦЕЛОЕ ЧИСЛО
        {
            Fraction obj3 = new Fraction();
            if (obj.Negative)
            {
                obj3.Numerator = -obj.Numerator * a;
                obj3.Denominator = obj.Denominator;
                return obj3;
            }
            else
            {
                obj3.Numerator = obj.Numerator * a;
                obj3.Denominator = obj.Denominator;
                return obj3;
            }
        }
        public static Fraction operator /(Fraction obj, int a)  //ДЕЛЕНИЕ ДРОБИ НА ЦЕЛОЕ ЧИСЛО
        {
            Fraction obj3 = new Fraction();
            if (obj.Negative)
            {
                obj3.Numerator = -obj.Numerator;
                obj3.Denominator = obj.Denominator*a;
                return obj3;
            }
            else
            {
                obj3.Numerator = obj.Numerator;
                obj3.Denominator = obj.Denominator*a;
                return obj3;
            }
        }
        public static bool operator >(Fraction obj1, Fraction obj2)     //БОЛЬШЕ
        {
            double a = (double)obj1.Numerator / (double)obj1.Denominator;
            double b = (double)obj2.Numerator / (double)obj2.Denominator;
            if (a > b) return true;
            else return false;
        }
        public static bool operator <(Fraction obj1, Fraction obj2)     //МЕНЬШЕ
        {
            double a = (double)obj1.Numerator / (double)obj1.Denominator;
            double b = (double)obj2.Numerator / (double)obj2.Denominator;
            if (a < b) return true;
            else return false;
        }
        public static bool operator ==(Fraction obj1, Fraction obj2)    //РАВНО
        {
            if (obj1.Negative)
                obj1.Numerator = -obj1.Numerator;
            if (obj2.Negative)
                obj2.Numerator = -obj2.Numerator;
            double a = (double)obj1.Numerator / (double)obj1.Denominator;
            double b = (double)obj2.Numerator / (double)obj2.Denominator;
            if (a == b) return true;
            else return false;
        }
        public static bool operator !=(Fraction obj1, Fraction obj2)    //НЕРАВНО
        {
            if (obj1.Negative)
                obj1.Numerator = -obj1.Numerator;
            if (obj2.Negative)
                obj2.Numerator = -obj2.Numerator;
            double a = (double)obj1.Numerator / (double)obj1.Denominator;
            double b = (double)obj2.Numerator / (double)obj2.Denominator;
            if (a != b) return true;
            else return false;
        }
        public override bool Equals(object obj)                         //Equals
        {
            if (obj == null) return false;
            Fraction f = obj as Fraction;
            if (f == null) return false;
            return(this.Numerator == f.Numerator && this.Denominator == f.Denominator);
        }
        public override int GetHashCode()                               //GetHashCode
        {
            return Numerator^Denominator;
        }
        public static bool operator true(Fraction obj)              
        {
            double a = (double)obj.Numerator / (double)obj.Denominator;
            if (a < 1) return true;
            else return false;
        }
        public static bool operator false(Fraction obj)
        {
            double a = (double)obj.Numerator / (double)obj.Denominator;
            if (a > 1) return true;
            else return false;
        }

        public Fraction IntPartSeparation(Fraction obj) //выделяет целую части из неправильной дробной
        {
            if (obj.Negative && obj.Numerator > 0)
                obj.Numerator = -obj.Numerator;
            obj.IntegerPart = obj.Numerator / obj.Denominator;
            if (obj.IntegerPart < 0)
            {
                obj.IntegerPart = -obj.IntegerPart;
                obj.Numerator = -obj.Numerator;
                obj.Numerator = obj.Numerator - obj.IntegerPart * obj.Denominator;
                obj.IntegerPart = -obj.IntegerPart;
                return obj;
            }
            else
            {
                if (obj.IntegerPart > 0)
                {
                    obj.Numerator = obj.Numerator - obj.IntegerPart * obj.Denominator;
                    return obj;
                }
                else
                    return obj;
            }
        }

        public Fraction Summ(Fraction obj1, Fraction obj2)  //операция суммирования с переходом к отделению целой части
        {
            Fraction obj3 = new Fraction();
            obj3 = obj1 + obj2;
            return IntPartSeparation(obj3);
        }
        public Fraction Difference(Fraction obj1, Fraction obj2)    //операция вычитания с переходом к отделению целой части
        {
            Fraction obj3 = new Fraction();
            obj3 = obj1 - obj2;
            return IntPartSeparation(obj3);
        }
        public Fraction Multiplication(Fraction obj1, Fraction obj2) //операция умножения с переходом к отделению целой части
        {
            Fraction obj3 = new Fraction();
            obj3 = obj1 * obj2;
            return IntPartSeparation(obj3);
        }
        public Fraction MultiplicationInt(Fraction obj1, int a)     // для перемножения с ЦЕЛЫМ ЧИСЛОМ
        {
            Fraction obj3 = new Fraction();
            obj3 = obj1 * a;
            return IntPartSeparation(obj3);
        }
        public Fraction SummDouble(Fraction obj1, double a)          //для сложения дроби с DOUBLE
        {
            Fraction obj2 = new Fraction();
            Fraction obj3 = new Fraction();
            if (a < 0)
            {
                obj2.Negative = true;
                a = -a;
            }
            int i = (int)a;
            a -= i;
            obj2.Denominator = 1000;                                            //приведение к знаменателю 1000
            obj2.Numerator = Convert.ToInt32((a * 1000)+(i*obj2.Denominator));    //округление до тысячных долей и создание дроби
            obj3 = obj1 + obj2;
            return obj3;
        }
        public Fraction Division(Fraction obj1, Fraction obj2) //операция деления с переходом к отделению целой части
        {
            Fraction obj3 = new Fraction();
            obj3 = obj1 / obj2;
            return IntPartSeparation(obj3);
        }
        public string Greater(Fraction obj1, Fraction obj2) //операция больше-меньше
        {
            if (obj1.Negative)
                obj1.Numerator = -obj1.Numerator;
            if (obj2.Negative)
                obj2.Numerator = -obj2.Numerator;
            if (obj1 > obj2) return String.Format("{0} больше {1}", IntPartSeparation(obj1), IntPartSeparation(obj2));
            else if (obj1 < obj2) return String.Format("{0} меньше {1}", IntPartSeparation(obj1), IntPartSeparation(obj2));
            else return String.Format("{0} равно {1}", IntPartSeparation(obj1), IntPartSeparation(obj2));
        }
        public string Equality(Fraction obj1, Fraction obj2)    // Сравнение на равенство-неравенство
        {
            if (obj1 == obj2) return String.Format("{0} равно {1}", IntPartSeparation(obj1), IntPartSeparation(obj2));
            else return String.Format("{0} неравно {1}", IntPartSeparation(obj1), IntPartSeparation(obj2));
        }
        public string Improper(Fraction obj)    //некорректная работа метода Improper(Fraction obj) возможна в связи со спецификой инициализации объектов
        {
            if (obj)
               return String.Format("Дробь {0} является правильной \n", obj);
            else
               return String.Format("Дробь {0} является неправильной", obj);
        }

    }
}
