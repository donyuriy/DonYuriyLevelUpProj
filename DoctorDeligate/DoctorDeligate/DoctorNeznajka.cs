using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorDeligate
{
    class DoctorNeznajka    //плохой дктор
    {
        public string Name { get;private set; }   //имя доктора
        private List<string> NeznajkaRaport = new List<string>();   //отчёт доктора Незнайки
        public DoctorNeznajka()
        {
            this.Name = "Доктор Незнайка";
        }
        
        public void TakeMoney(Patient obj)  //взять деньги(методы лечения бывают разные)
        {
            obj.Happy = !obj.Happy; //
            NeznajkaRaport.Add(String.Format("Доктор Незнайка. Пациент {0}. Назначено лечение: ---. Получено денег: 50$ ",obj.Name));
            Console.WriteLine(this.Name+ " взял деньги у "+obj.Name+" и ушёл...");
        }
        public void SleepOnTheCouch(Patient obj)    //уснуть на кушетке(методы лечения бывают разные)
        {
            obj.Happy = !obj.Happy; // 
            NeznajkaRaport.Add(String.Format("Доктор Незнайка. Пациент {0}. Назначено лечение: ? ", obj.Name));
            Console.WriteLine(this.Name + " уснул на кушетке вместо осмотра " + obj.Name);
        }
        public void GetRaport() //выдача рапорта от Незнайки
        {
            Console.WriteLine("Корявый отчёт доктора Незнайки:");
            if (NeznajkaRaport.Count()==0)
            {
                Console.WriteLine("У Др.Незнайки сегодня не было пациентов.");
            }
            else
            {
                foreach (string i in NeznajkaRaport)
                {
                    Console.WriteLine(i);
                }
            }
            Console.WriteLine();
            NeznajkaRaport.Clear();
        }
    }
}
