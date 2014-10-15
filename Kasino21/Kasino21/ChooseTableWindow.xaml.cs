using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Kasino21
{
    /// <summary>
    /// Логика взаимодействия для ChooseTableWindow.xaml
    /// </summary>
    public partial class ChooseTableWindow : Window
    {
        public int tableNumber = 0; //номер стола
        public ChooseTableWindow()
        {
            InitializeComponent();
        }

        private void btn1_OnClick(object sender, RoutedEventArgs e)
        {
            tableNumber = Convert.ToInt32((sender as Button).Tag);  //получаем номер выбранного стола
            this.Close();                                           //закрываем окно выбора
        }
    }
}
