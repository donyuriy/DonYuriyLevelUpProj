using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication21
{
    class Program
    {
        static void Main(string[] args)
        {
            string str;
            string str2;
            char c = '0';
            Console.WriteLine("Введите начальный путь:");
            string path = Console.ReadLine();
            IOclass.SetCurrentDir(path);

            do
            {
                Console.WriteLine("\nТекущая папка: " + Directory.GetCurrentDirectory());
                Console.WriteLine("Меню\n1 - вверх по дереву каталогов\n2 - войти в подкаталог\n3 - создать каталог\n4 - создать файл\n"+
                    "5 - удалить каталог\n6 - удалить файл\n7 - копировать каталог\n8 - копировать файл\n9 - содержимое текущего каталога"+
                    "\n0 - перейти в другой каталог\nq - выход");
                try
                {
                    c = Convert.ToChar(Console.ReadLine()); //в блоке try чтобы не ругалось на нажатый Enter
                }
                catch { }

                switch (c)
                {
                    case '1':   //вверх по дереву каталогов
                        Console.Clear();
                        IOclass.JumpTo("..");   
                        break;
                    case '2':   //войти в подкаталог
                        Console.WriteLine("Введите имя каталога:");
                        str = Console.ReadLine();   
                        Console.Clear();
                        IOclass.JumpTo(str);
                        break;
                    case '3':   //создать каталог
                        Console.WriteLine("Введите имя каталога для создания: ");
                        str = Console.ReadLine();
                        Console.Clear();
                        IOclass.CreateDirectory(str);
                        break;
                    case '4':   //создать файл
                        Console.WriteLine("Введите имя файла для создания: ");
                        str = Console.ReadLine();
                        Console.Clear();
                        IOclass.CreateFile(str);
                        break;
                    case '5':   //удалить каталог
                        Console.WriteLine("Введите имя каталога для удаления: ");
                        str = Console.ReadLine();
                        IOclass.DelDir(str);
                        break;
                    case '6':   //удалить файл
                        Console.WriteLine("Введите имя файла для удаления: ");
                        str = Console.ReadLine();
                        Console.Clear();
                        IOclass.DelFile(str);
                        break;
                    case '7':   //копировать каталог
                        Console.WriteLine("Введите имя каталога для копирования: ");
                        str = Console.ReadLine();
                        Console.WriteLine("Введите путь куда вы хотите копировать выбранный каталог");
                        str2 = Console.ReadLine();
                        Console.Clear();
                        IOclass.CopyDir(str,str2);
                        break;
                    case '8':   //копировать файл
                        Console.WriteLine("Введите имя файла для копирования: ");
                        str = Console.ReadLine();
                        Console.WriteLine("Введите путь куда вы хотите копировать выбранный файл");
                        str2 = Console.ReadLine();
                        Console.Clear();
                        IOclass.CopyFile(str,str2);
                        break;
                    case '9':   //содержимое текущего каталога
                        Console.Clear();
                        IOclass.SetCurrentDir(Directory.GetCurrentDirectory());
                        break;
                    case '0':   //перейти в другой каталог
                        Console.WriteLine("Введите адрес для перехода: ");
                        str = Console.ReadLine();
                        Console.Clear();
                        IOclass.JumpTo(str);
                        break;
                    case 'q':   //выход
                        Console.Clear();
                        Console.WriteLine(String.Format("Путь к лог-файлу: {0}",IOclass.filelog));
                        Console.WriteLine("\nДо свидания!");
                        Console.ReadKey();
                        break;
                    default:    //если выбрано действи которого нет в наличие
                        Console.WriteLine("Выбрано неверное действие. Повторите пожалуйста попытку снова.");
                        Console.ReadKey();
                        break;
                }
            } while (c != 'q');
        }
    }
}
