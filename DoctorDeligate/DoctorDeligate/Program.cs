using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorDeligate
{
    class Program
    {
        static void Main(string[] args)
        {
            Patient p1 = new Patient("Ivanov");
            Patient p2 = new Patient("Petrov");
            Patient p3 = new Patient("Sidorov");
            Patient p4 = new Patient("Smirnov");
            Patient p5 = new Patient("Kovrov"); //ему не стаёт хуже(сравнительный)

            p1.FeltWorse = true; p2.FeltWorse = true; p3.FeltWorse = true; p4.FeltWorse = true; //им всем стало хуже
            //раздаём людям проблемы:...........
            p1.BrokenLeg = true;
            p2.Headache = true;
            p3.HighTemperature = true;
            p4.Gunshot = true;

            DoctorSmith docSmith = new DoctorSmith();   //доктор Смитт
            DoctorNeznajka docNeznajka = new DoctorNeznajka();  //доктор Незнайка
            DoctorDeligate docHelps = new DoctorDeligate(docSmith.MedicalExamination);  //наш делегат
            List<Patient> patientListOfSmith = new List<Patient> { p1, p2, p5 };    //изначальный список пациентов доктора Смита
            List<Patient> patientListOfNeznajka = new List<Patient> { p3, p4 };     //изначальный список пациентов доктора Незнайки
            int q = 0; //для выхода из цикла do-while
            do
            {
                q++;
                foreach (var item in patientListOfSmith)       //лечит Смит
                {
                    if (item.FeltWorse)
                    {
                        if (item.BrokenLeg)
                        {
                            docHelps += docSmith.Injection;
                        }
                        if (item.HighTemperature)
                        {
                            docHelps += docSmith.GiveAPill;
                        }
                        if (item.Headache)
                        {
                            docHelps += docSmith.TryOnBloodPreasure;
                        }
                        if (item.Gunshot)
                        {
                            docHelps += docSmith.MedicalOperation;
                        }
                        docHelps(item);
                        if (item.Happy)
                            Console.WriteLine("Пациент доволен приёмом");
                        else
                            Console.WriteLine("Все доктора козлы!");


                        docHelps = docSmith.MedicalExamination; //очистка делегата для следующего пациента
                        Console.WriteLine();
                    }
                }
                docHelps = null;    //очистка делегата для следующего доктора
                Console.WriteLine();

                foreach (var item in patientListOfNeznajka)       //лечит Ватсон
                {
                    if (item.FeltWorse)
                    {
                        if (item.BrokenLeg)
                        {
                            docHelps += docNeznajka.TakeMoney;
                        }
                        if (item.HighTemperature)
                        {
                            docHelps += docNeznajka.SleepOnTheCouch;
                        }
                        if (item.Headache)
                        {
                            docHelps += docNeznajka.TakeMoney;
                        }
                        if (item.Gunshot)
                        {
                            docHelps += docNeznajka.SleepOnTheCouch;
                        }
                        docHelps(item);
                        if (item.Happy)
                            Console.WriteLine("Пациент доволен приёмом");
                        else
                            Console.WriteLine("Все доктора козлы!");

                        docHelps = null;
                        Console.WriteLine();
                    }
                }
                Console.WriteLine("\n");
                docSmith.GetRaport();   //выдать отчёты
                docNeznajka.GetRaport();
                Console.WriteLine("День {0} завершён.",q);
                //переход недовольных пациентов к другому доктору
                for (int i = 0; i < patientListOfSmith.Count; i++)  
                {
                    if (!patientListOfSmith[i].Happy)   //пациент переходит к другому доктору если он не доволен своим
                    {
                        patientListOfSmith[i].Happy = true;                 // меняем Happy на true чтобы не было бесконечкого перемещения между докторами
                        patientListOfNeznajka.Add(patientListOfSmith[i]);   //добавляем его к другому доктору
                        patientListOfSmith.RemoveAt(i);                     //и удаляем у своего
                        i--;    //откатываемся на одного пациента назад
                    }
                }
                for (int i = 0; i < patientListOfNeznajka.Count; i++)   //с Незнайкой тоже самое что и со Смитом
                {
                    if (!patientListOfNeznajka[i].Happy)
                    {
                        patientListOfNeznajka[i].Happy = true;
                        patientListOfSmith.Add(patientListOfNeznajka[i]);
                        patientListOfNeznajka.RemoveAt(i);
                        i--;
                    }
                }
                Console.ReadKey();
                Console.Clear();
            } while (q != 5);       //по умолчанию просматриваем 1 рабочую неделю
        }
    }
}
