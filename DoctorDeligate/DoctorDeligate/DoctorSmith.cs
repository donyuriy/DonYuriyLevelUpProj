using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorDeligate
{

    delegate void DoctorDeligate(Patient obj);

    class DoctorSmith   //хороший доктор
    {
        public string Name { get;private set; }                            //имя доктора
        private List<Patient> SmihtPatients = new List<Patient>();  //список пациентов др.Смитта
        public DoctorSmith()
        {
            this.Name = "Доктор Смит";
        }
        public void MedicalExamination(Patient obj)                 //провести мед.обследование
        {
            Console.WriteLine(this.Name+" провёл мед.осмотр "+obj.Name+"y");
        }
        public void GiveAPill(Patient obj)                          //дать таблетку
        {
            obj.Happy = true;                                       //пациент доволен
            obj.Treatment = "Таблетка от головы";                   //название процедуры
            Console.WriteLine(this.Name + " дал таблетку " + obj.Name + "y");
            SmihtPatients.Add(obj);                                 //занесение в отчёт доктора
        }
        public void Injection(Patient obj)                          //сделать укол
        {
            obj.Happy = true;                                       //пациент доволен
            obj.Treatment = "Укол ";                                 //название процедуры
            Console.WriteLine(this.Name + " сделал укол " + obj.Name + "y");
            SmihtPatients.Add(obj);                                 //занесение в отчёт доктора
        }
        public void TryOnBloodPreasure(Patient obj)                 //измерить кровяное давление
        {
            obj.Happy = true;                                       //пациент доволен
            obj.Treatment = "Измерение давления";                   //название процедуры
            Console.WriteLine(this.Name + " померял давление " + obj.Name + "y");
            SmihtPatients.Add(obj);                                  //занесение в отчёт доктора
        }
        public void MedicalOperation(Patient obj)                   //провести операцию
        {
            obj.Happy = true;                                       //пациент доволен
            obj.Treatment = "Операция";                             //название процедуры
            Console.WriteLine(this.Name + " сделал операцию " + obj.Name + "y");
            SmihtPatients.Add(obj);                                 //занесение в отчёт доктора
        }
        public void GetRaport()                                     //выдача отчёта
        {
            Console.WriteLine("Отчёт за день (Dr.Smith)");
            for (int i = 0; i < SmihtPatients.Count; i++)
			{
                if (SmihtPatients[i].BrokenLeg) //если сломана нога
                {
                    Console.WriteLine(String.Format("Пациент: {0}. Проблема: сломана нога. Назначено: {1}.", SmihtPatients[i].Name, SmihtPatients[i].Treatment));
                }
                if (SmihtPatients[i].HighTemperature)   //если высокая температура
                {
                    Console.WriteLine(String.Format("Пациент: {0}. Проблема: повышенная температура. Назначено: {1}.", SmihtPatients[i].Name, SmihtPatients[i].Treatment));
                }
                if (SmihtPatients[i].Headache)  //если головная боль
                {
                    Console.WriteLine(String.Format("Пациент: {0}. Проблема: головная боль. Назначено: {1}.", SmihtPatients[i].Name, SmihtPatients[i].Treatment));
                }
                if (SmihtPatients[i].Gunshot)   //если пулевое ранение
                {
                    Console.WriteLine(String.Format("Пациент: {0}. Проблема: пулевое ранение. Назначено: {1}.", SmihtPatients[i].Name, SmihtPatients[i].Treatment));
                }
			}
            Console.WriteLine();
            SmihtPatients.Clear();  //очистка отчёта в конце дня
        }
    }
}
