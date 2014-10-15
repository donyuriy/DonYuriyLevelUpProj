using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorDeligate
{
    class Patient
    {
        public string Name { get;private set; }            //имя
        public bool HighTemperature { get; set; }   //высокая температура
        public bool Headache { get; set; }          //головная боль
        public bool BrokenLeg { get; set; }         //сломана нога
        public bool Gunshot { get; set; }           //пулевое ранение
        public bool FeltWorse { get; set; }         //пациенту становится хуже
        public string Treatment { get; set; }       //назначенное лечение
        public bool Happy { get; set; }             //насколько пациент доволен доктором            

        public Patient(string str)
        {
            this.Name=str;                          // через конструктор у пациента только имя
        }
        public override string ToString()
        {
            if(Happy==true)
                return String.Format("Пациент {0}. После процедур доволен своим врачём )))",this.Name);
            else
                return String.Format("Пациент {0}. После процедур ненавидитсвоего врача!",this.Name);
        }
        
    }
}
