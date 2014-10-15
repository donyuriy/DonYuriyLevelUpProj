using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication21
{
    class IOclass
    {
        public static string filelog;
        public static string fullPath="";
        public static void SetCurrentDir(string path)   //устанавливает текущую папку
        {
            try
            {
                fullPath = Path.GetFullPath(path);  //в блоке try чтобы не ругалось на нажатый Enter(null)
            }
            catch
            {
                fullPath = @"c:\"; //если путь не указан, то ссылаемся на диск "С", так как он имеется на подавляющем большинстве компьютеров
                FileLog(String.Format("Указанный путь не найден. По умолчанию установлен каталог с:\\"));
            }                             
            try
            {
                Directory.SetCurrentDirectory(fullPath);
                foreach (string item in Directory.GetDirectories(path))         //выводим содержимое директории(подкаталоги)
                {
                    Console.WriteLine(item);
                }
                foreach (string item in Directory.GetFiles(path))               //выводим содержимое директории(файлы)
                {
                    Console.WriteLine(item);
                }
                FileLog(String.Format("Текущая директория установлена в:  {0}",fullPath));      //запись в лог-файл совершённого действия
            }
            catch (IOException)                                                 //если путь не верный или не существует
            {
                Console.WriteLine("Заданный путь не найден, повторите попытку");
                
            }
            catch (Exception e)                                                 //перестраховка на случай прочих ошибок
            {
                Console.WriteLine("Произошла ошибка: " + e.Message);
            }
        }

        public static void JumpTo(string path)  //перейти в другую директорию
        {
            try
            {
                path = Path.GetFullPath(path);    //избегаем ошибки пре передачи пустого пути
            }
            catch 
            {
                Console.WriteLine("Был введён неправильный путь, попробуйте ещё раз.");
                return;
            }
            Directory.SetCurrentDirectory(path); 
            foreach (string item in Directory.GetDirectories(path)) //выводим содержимое директории(подкаталоги)
            {
                Console.WriteLine(item);
            }
            foreach (string item in Directory.GetFiles(path))       //выводим содержимое директории(файлы)
            {
                Console.WriteLine(item);
            }
            FileLog("Текущая директория установлена:  " + path);           //запись в лог-файл совершённого действия
        }

        public static void CreateFile(string path)  //создание нового файла
        {
            path = Path.GetFullPath(path);
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
            {
                string str;                                                         //текст который нужно передать в файл
                fs.Seek(0, SeekOrigin.End);                                         //если в файле уже чтото есть то записываем в хвост
                StreamWriter sr = new StreamWriter(fs, Encoding.UTF8);
                Console.WriteLine("Введите данные для сохранения в файл "+ path);
                str = Console.ReadLine();                                           //за 1 раз можем передать только 1 строчку текста
                sr.Write(str);
                sr.Dispose();
            }
            FileLog(String.Format("Создан файл {0}", path));                   //запись в лог-файл совершённого действия
            Console.WriteLine("Файл создан");
        }

        public static void CreateDirectory(string path)     //создаём новую папку
        {
            path = Path.GetFullPath(path);
            Directory.CreateDirectory(path);
            FileLog(String.Format("Создан каталог {0}", path));   //запись в лог-файл совершённого действия
            Console.WriteLine("Каталог создан");
        }

        public static void DelFile(string path)         //удаление файла
        {
            path = Path.GetFullPath(path);
            Console.WriteLine("Вы действительно хотите удалить файл " + path + "? (y/n)");    //спрашиваем перед тем как что-либо удалить
            string answer = Console.ReadLine();
            if (answer=="y")                                            //если "да" - то убиваем
            {
                File.Delete(path);
                FileLog(String.Format("Файл {0} удалён", path));   //запись в лог-файл совершённого действия
                Console.WriteLine(String.Format("Файл {0} удалён", path));
            }
            else
                Console.WriteLine("Удаление отменено.");                //если нет - то отмена
        }

        public static void DelDir(string path)  //удаление каталога
        {
            path = Path.GetFullPath(path);
            Console.WriteLine("Вы действительно хотите удалить каталог " + path + " со всем содержимым? (y/n)");
            string answer = Console.ReadLine();                 //спрашиваем перед тем как что-либо удалить
            if (answer == "y")                                  //если "да" - то убиваем
            {
                Directory.Delete(path,true);                    //удаление каталога со всем содержимым
                FileLog(String.Format("Каталог {0} удалён", path));  //запись в лог-файл совершённого действия
                Console.WriteLine(String.Format("Каталог {0} удалён", path));
            }
            else
                Console.WriteLine("Удаление отменено.");        //если нет - то отмена
        }

        public static void CopyFile(string source, string dest) //копирование файла
        {
            string path1;
            string path2;
            try
            {
                path1 = Path.GetFullPath(source);       //проверяем оба пути в блоке try на null
                path2 = Path.GetFullPath(dest);
            }
            catch
            {
                Console.WriteLine("Введён пустой путь или имя файла");
                FileLog(String.Format("Невозможно скопировать файл(введён пустой путь)"));
                return;
            }

            try  //если введено имя не файла а директории то сработает этот try-catch
            {       
                File.Copy(path1, path2, true);  //копирование
                Console.WriteLine("Файл успешно скопирован.");      //сообщение пользователю
                FileLog(String.Format("Файл {0} скопирован в директорию {1}", source, path2));    //запись в лог
            }
            catch
            {
                Console.WriteLine("Невозможно скопировать файл, указан некорректый путь или имя файла.");   //сообщение пользователю
                FileLog(String.Format("Невозможно скопировать файл: {0}",source));  //запись в лог
            }
        }
        public static void CopyDir(string source, string dest)  //копирование каталога
        {
            string path1;
            string path2;
            try
            {
                path1 = Path.GetFullPath(source);       //проверяем оба пути в блоке try на null
                path2 = Path.GetFullPath(dest);
            }
            catch
            {
                Console.WriteLine("Введён пустой путь или имя директории");
                FileLog(String.Format("Невозможно скопировать директорию(введён пустой путь)"));
                return;
            }

            DirectoryInfo d1 = new DirectoryInfo(source);   
            DirectoryInfo[] subDirs = d1.GetDirectories();  //список подкаталогов
            if (!d1.Exists) //если нет каталога который нужно скопировать(неверный путь)
            {
                Console.WriteLine("Директория не существует");
                FileLog(String.Format("Директория {0} не существует",source));
            }
            if (!Directory.Exists(path2))
            {
                Directory.CreateDirectory(path2);
            }

            FileInfo[] fs = d1.GetFiles();  //список файлов в каталоге
            for (int i = 0; i < fs.Length; i++)
            {
                string tempPath = Path.Combine(path2,fs[i].Name);   //новые пути для файлов
                fs[i].CopyTo(tempPath,false);           //копируем
            }
            foreach (DirectoryInfo subdir in subDirs)       //рекурсивный вызов копирование подкаталогов
            {
                string temppath = Path.Combine(path2, subdir.Name); //новые пути для всех подкаталогов
                CopyDir(subdir.FullName, temppath);
            }
            FileLog(String.Format("Каталог {0} скопирован в {1}",path1,path2));
            Console.WriteLine(String.Format("Каталог {0} скопирован в {1}", path1, path2));
        }

        public static void FileLog(string s)    //запись в лог-файл
        {                                       //файл не затирается при перезапусках программы
            string dirPath = @"c:\filemanager\";
            string filePath = @"filelog.log";
            DirectoryInfo dir = new DirectoryInfo(dirPath);
            if (!dir.Exists)
            {
                Directory.CreateDirectory(dirPath);
            }
            DateTime date = new DateTime();
            date = DateTime.Now;                //указание времени очередного действия
            filelog = dirPath + filePath;
            using (FileStream fs = new FileStream(filelog, FileMode.OpenOrCreate, FileAccess.Write))
            {
                fs.Seek(0, SeekOrigin.End); //дописіваем всегда в конец
                StreamWriter sr = new StreamWriter(fs, Encoding.UTF8);
                sr.Write(date + " ");   //сначала вписываем дату и время
                sr.WriteLine(s);        // переменная s приходит из каждого метода 
                sr.Dispose();
            }
        }
    }
}
