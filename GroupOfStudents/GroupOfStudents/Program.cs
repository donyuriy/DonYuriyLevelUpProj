using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupOfStudents
{
    class Program
    {
        static void Main(string[] args)
        {
            Student st1 = new Student("Ivan","Ivanov",18);
            Student st2 = new Student("Petr", "Petrov", 25);
            Student st3 = new Student("Alex", "Frejd", 37);
            Student st4 = new Student("Simon", "Fenix", 19);
            Student st5 = new Student("Jason", "Object", 20);
            Student st6 = new Student("Sidor", "Abc", 22);
            Student st10 = new Student("Ivan", "Ivanov", 19);
            Student st7 = new Student("Vilyam", "Sidorov", 24);
            Student st8 = new Student("Mark", "Abc", 33);
            Student st9 = new Student("Yuriy", "Don", 34);
            Student st0 = new Student("N", "n", 17);

            Group gr1 = new Group("New Group");
            gr1.Add(st1);
            gr1.Add(st2);
            gr1.Add(st3);
            gr1.Add(st4);
            gr1.Add(st5);
            gr1.Add(st6);
            gr1.Add(st7);
            gr1.Add(st8);
            gr1.Add(st9);
            gr1.Add(st10);
            gr1.Add(st0);

            Console.WriteLine("Not sorted group");
            foreach (Student item in gr1)
            {
                Console.WriteLine(item.Name+ "\t "+item.LastName+ "\t "+item.Age+ "лет");
            }
            Console.WriteLine();
            Array.Sort(gr1.group, new Group.SortByLastName());
            Console.WriteLine("Sorted by Last Name");
            foreach (var item in gr1.group)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            Array.Sort(gr1.group, new Group.SortByName());
            Console.WriteLine("Sorted by Name");
            foreach (var item in gr1.group)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            Array.Sort(gr1.group, new Group.SortByAge());
            Console.WriteLine("Sorted by Age");
            foreach (var item in gr1.group)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            Array.Sort(gr1.group, new Group.SortByGrade());
            Console.WriteLine("Sorted by Grade");
            foreach (var item in gr1.group)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();

        }
    }
}
