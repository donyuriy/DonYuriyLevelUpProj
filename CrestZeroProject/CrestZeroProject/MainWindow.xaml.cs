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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CrestZeroProject
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Button> ButtonList1;
        List<Button> ButtonListX;
        List<Button> ButtonListO;
        string symbol;
        public MainWindow()
        {
            ChooseSymbolWindow win = new ChooseSymbolWindow();
            win.ShowDialog();
            this.symbol = win.Symbol;
            InitializeComponent();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            lbSymbol.Content += this.symbol;
            ButtonList1 = new List<Button>();
            ButtonListX = new List<Button>();
            ButtonListO = new List<Button>();
            foreach (var item in gridPanell.Children)
            {
                if (item is Button)
                {
                    ButtonList1.Add(item as Button);
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string label = "";
            Logics l1 = new Logics();
            int quantity = 0;
            (sender as Button).Content = this.symbol;
            foreach (Button item in ButtonList1)    //если кнопка нажато,то она становится не активной
            {
                if (item.Content.ToString() == "X" || item.Content.ToString() == "O")
                {
                    item.IsEnabled = false;
                    quantity++;
                }
            }

            if ((sender as Button).Content.ToString() == "X")   // алгоритм занесения кнопок Х в коллекцию для дальнейшего сравнения
            {
                for (int i = 0; i < ButtonListX.Count+1; i++)
                {
                    if (ButtonListX.Count==0)               //если в коллекции с кнопками ничего нет, то заносим кнопку в коллекцию сразу
                        ButtonListX.Add(sender as Button);
                    if (ButtonListX[i].Tag==(sender as Button).Tag)
                        break;                              //если нажатая кнопка уже есть в коллекции, то дальше не сравниваем
                    if (i == ButtonListX.Count - 1)
                    {
                        ButtonListX.Add(sender as Button);  //если после сравнения со всей коллекцией нажатая кнопка не найдена, то заносим её
                        break;                              
                    }
                }
            }
            
            l1.WinConfig(ButtonListX, ref label);   //метод сравнения с выйгрышными комбинациями
            lb1.Content = label;
            MessageBoxResult result;

            if (label == "Победил X" || label == "Победил O")   //если победа то предлагает начать заново
            {
                result = MessageBox.Show("Игра окончена. "+label+". Начать заново?", "Game Over", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.No)
                {
                    this.Close();
                }
                if (result == MessageBoxResult.Yes)
                {
                    this.Close();
                    System.Windows.Forms.Application.Restart();
                }
            }
            else if (quantity == 9) //если ничья то предлагает начать заново
            {
                result = MessageBox.Show("Игра окончена. Начать заново?", "Game Over", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.No)
                {
                    this.Close();
                }
                if (result == MessageBoxResult.Yes)
                {
                    this.Close();
                    System.Windows.Forms.Application.Restart();
                }
            }
            
        }
    }
}
