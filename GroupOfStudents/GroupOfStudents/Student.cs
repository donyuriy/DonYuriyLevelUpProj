using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace GroupOfStudents
{
    public static class RandomX        // нужен для заполнения успеваемости студентов
    {
        public static int Rnd(int a, int b) //возвращает значение от a до b так же как Random
        {
            Thread.Sleep(1);    //для правильной отработки Ramdom
            Random r = new Random();
            return r.Next(a,b);
        }
    }
    class Student
    {
        private string name;
        private string lastName;
        private int age;
        public int[][] scores;
        public double scoresAverage;
        public Student(string n, string ln, int a)
        {
            this.Name = n;      //имя
            this.LastName = ln; //фамилия
            this.Age = a;       //возраст
            this.scores = new int[5][];   // ставим 5 предметов для каждого студента
            this.scoresAverage = this.scores.Length;    // среднее значение успеваемости по всем предметам

            this.Graduation();  //вариант автоматического занесения оценок
        }

        public string Name
        {
            get { return name; }
            set 
            {
                if (value != null&& value!="")  //!null
                    name = value;
                else
                    name = "Unknown";
            }
        }

        public string LastName
        {
            get { return lastName; }
            set 
            {
                if (value != null && value != "")   //!null
                    lastName = value;
                else
                    lastName = "Unknown";
            }
        }

        public int Age
        {
            get { return age; }
            set 
            {
                if (value > 0)      //!null
                    age = value;
                else
                    age = 1;
            }
        }

        private void Graduation()   //автоматическое заполнение успеваемости студентов
        {
            int count = 0;  //количество оценок(всего)
            for (int i = 0; i < this.scores.Length; i++) //заносим оценки по 5 предметам
            {
                this.scores[i] = new int[RandomX.Rnd(1, 10)];   //количество оценок по каждому предмету тоже Рандомное

                for (int j = 0; j < this.scores[i].Length; j++)
                {
                    this.scores[i][j] = RandomX.Rnd(1, 100);  // забрасываем оценки Рандомом
                    this.scoresAverage += this.scores[i][j];
                    count++;
                }
            }
            this.scoresAverage /= count;    //средняя успеваемость
        }

        public int CompareTo(object obj)    //Для сравнения студентов по возрасту перегружаем CompareTo
        {
            Student st = (Student)obj;
            if (this.Age > st.Age)
            {
                return 1;   //если первый старше
            }
            if (this.Age < st.Age)
            {
                return -1;  //если первый младьше
            }
            else return 0;  //если одгого возраста
        }

        
        public override string ToString()
        {
            return String.Format("{0}\t{1}\t{2} лет\t Средняя успеваемость: {3}",this.Name,this.LastName,this.Age,this.scoresAverage);
        }

    }
}
