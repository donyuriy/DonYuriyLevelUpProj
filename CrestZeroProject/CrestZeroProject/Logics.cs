using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CrestZeroProject
{
    class Logics
    {
        struct Cells
        {
            private int n1;
            private int n2;
            private int n3;
            public int N1 { get { return n1; } }
            public int N2 { get { return n2; } }
            public int N3 { get { return n3; } }
            public Cells(int n1, int n2, int n3)
            {
                this.n1 = n1;
                this.n2 = n2;
                this.n3 = n3;
            }
        }

        List<Cells> WinConfiguration;
        public Logics()
        {
            this.WinConfiguration = new List<Cells>();
            this.WinConfiguration.Add(new Cells(1, 2, 3));
            this.WinConfiguration.Add(new Cells(4, 5, 6));
            this.WinConfiguration.Add(new Cells(7, 8, 9));
            this.WinConfiguration.Add(new Cells(1, 4, 7));
            this.WinConfiguration.Add(new Cells(2, 5, 8));
            this.WinConfiguration.Add(new Cells(3, 6, 9));
            this.WinConfiguration.Add(new Cells(1, 5, 9));
            this.WinConfiguration.Add(new Cells(3, 5, 7));
        }

        public void WinConfig(List<Button> lb1,ref string str)
        {
            int count = 0;  //счётчик совпадений позиций Х или О с выйгранными комбинациями
            //str = count.ToString();
            for (int a = 0; a < this.WinConfiguration.Count-1; a++)
            {
                count = 0;
                for (int i = 0; i <lb1.Count ; i++)
                {
                    if (this.WinConfiguration[a].N1 == Convert.ToInt32(lb1[i].Tag))
                    {
                        count++;
                        str = count.ToString();
                    }
                    if (this.WinConfiguration[a].N2 == Convert.ToInt32(lb1[i].Tag))
                    {
                        count++;
                        str = count.ToString();
                    }
                    if (this.WinConfiguration[a].N3 == Convert.ToInt32(lb1[i].Tag))
                    {
                        count++;
                        str = count.ToString();
                    }
                    if (count==3)   //если есть 3 совпадения то ПОБЕДА
                    {
                        str = string.Format("Победил {0}",lb1[i].Content);
                        break;
                    }
                }
            }
        }
    }
}
