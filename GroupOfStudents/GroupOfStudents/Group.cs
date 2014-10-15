using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupOfStudents
{
    class Group:IEnumerable
    {
        public Student[] group;
        private int next;
        private string name;

        public Group(string n)
        {
            this.Name = n;
            group = new Student[10];
            next = 0;   //следующий номер студента
        }

        public string Name
        {
            get { return name; }
            set 
            {
                if (value != null)  //!null
                    name = value;
                else
                    name = "Unknown Group";
            }
        }
        public int Quantity
        {
            get { return next; }
            set 
            {
                if (value>0)    //!null
                    next = value;
            }
        }
        public IEnumerator GetEnumerator()  //GetEnumerator интерфейса IEnumerable
        {
            for (int i = 0; i < next; i++)
            {
                Student stNew = group[i];
                int index = i;
                for (int j = i + 1; j < next; j++)
                {
                    if (stNew.CompareTo(group[j])==1)
                    {
                        stNew = group[j];
                        index = j;
                    }
                }
                group[index] = group[i];
                group[i] = stNew;
                yield return group[i];
            }
        }

        
        public void Add(Student obj)    //добавление студентов в группу
        {
            if (next >= 10) //пока в группе меньше 10 человек
            {
                Console.WriteLine("No empty spaces avaliable!");
                return;
            }
            foreach (Student item in group) //если Имя и Фамилия совпадают, то не добавляем в группу
            {
                if (item==null)
                    break;
                if (obj.Name == item.Name && obj.LastName == item.LastName)
                {
                    Console.WriteLine("Student with sauch Name and Last Name is already in this group");
                    return;
                }
            }
            group[next] = obj;
            next++;
        }
        public int Count 
        {
            get
            {
                int q = 0;
                foreach (Student item in group)
                {
                    q++;
                }
                return q;
            }
        }
        public class SortByName : IComparer //класс отвечающий за сортировку студентов по Имени
        {
            int IComparer.Compare(object obj1, object obj2)
            {
                Student stud1 = (Student)obj1;
                Student stud2 = (Student)obj2;
                return String.Compare(stud1.Name, stud2.Name);
            }
        }
        public class SortByLastName : IComparer //класс отвечающий за сортировку студентов по Фамилии
        {
            int IComparer.Compare(object obj1, object obj2)
            {
                Student stud1 = (Student)obj1;
                Student stud2 = (Student)obj2;
                return String.Compare(stud1.LastName, stud2.LastName);
            }
        }
        public class SortByAge : IComparer  //класс отвечающий за сортировку студентов по Возрасту
        {
            int IComparer.Compare(Object obj1, object obj2)
            {
                Student st1 = (Student)obj1;
                Student st2 = (Student)obj2;
                if (st1.Age > st2.Age)
                    return 1;
                if (st2.Age > st1.Age)
                    return -1;
                else
                    return 0;
            }
        }
        public class SortByGrade :IComparer //класс отвечающий за сортировку студентов по Средней успеваемости
        {
            int IComparer.Compare(Object obj1, object obj2)
            {
                Student st1 = (Student)obj1;
                Student st2 = (Student)obj2;
                if (st1.scoresAverage > st2.scoresAverage)
                    return 1;
                if (st1.scoresAverage < st2.scoresAverage)
                    return -1;
                else
                    return 0;
            }
        }
    }
}
