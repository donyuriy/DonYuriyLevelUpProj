using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Kasino21
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int tableNumber;    //номер текущего игрального стола
        int TableNumber
        {
            get{return tableNumber;}
            set
            {
                if(value>0)
                    tableNumber= value;
                else
                    tableNumber=1;
            }
        }            
        object[] GP;                //Game Parameters - это массив object который служит для связи Controls и Logic
        Kasino kObj = new Kasino(); //это наше Казино
        MemoryStream ms;            // сериализовать будем в буфер
        BinaryFormatter bf;         //используя бинарную сериализацию
        public MainWindow()
        {
            InitializeComponent();
            ChooseTableWindow win = new ChooseTableWindow();
            win.ShowDialog();                                       //открываем диалоговое окно выбора стола
            this.img1.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("cards.jpg");// картинка колоды карт
            TableNumber = win.tableNumber;
            this.Title = string.Format("Стол {0}", TableNumber);    //передаём номер стола с Title основного окна
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            ms = new MemoryStream();    //перед сериализацией каждый раз создаём новый поток, чтобы легче было найти последние данные
            bf = new BinaryFormatter();
            bf.Serialize(ms, kObj);      //Сериализация данных(объект класса Kasino в буфер)
            ChooseTableWindow win = new ChooseTableWindow();    //по нажатию кнопки "Выбрать стол" открываем диалоговое окно выбора
            win.ShowDialog();
            TableNumber = win.tableNumber;
            this.Title = string.Format("Стол {0}", TableNumber); //передаём номер стола с Title основного окна
            ms.Seek(0,SeekOrigin.Begin);    //перед десериализацией переходим в начало потока MemorySteam
            kObj = (Kasino)bf.Deserialize(ms);  //десериализация в уже существующий объект Казино
            GP = kObj.GetData(TableNumber);     //получаем сохранённые параметры для очков и последних выпавших карт
            btnUserCard.Content = GP[0];
            btnComputerCard.Content = GP[2];
            lb1.Content = GP[1];
            lb2.Content = GP[3];
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
        }

        private void btnTurnClick(object sender, RoutedEventArgs e)
        {
            GP = kObj.Play(TableNumber, Convert.ToInt32(lb1.Content), Convert.ToInt32(lb2.Content));    //наинаем игру
            btnUserCard.Content = GP[0];    //выводим результат хода
            btnComputerCard.Content = GP[2];
            lb1.Content = GP[1];
            lb2.Content = GP[3];
            if (Convert.ToInt32(GP[1]) > 21 && Convert.ToInt32(GP[3]) < 22)    //проверки на конец игры
            {
                MessageBox.Show("Победил Компьютер", "Игра окончена", MessageBoxButton.OK);
            }
            if (Convert.ToInt32(GP[3]) > 21 && Convert.ToInt32(GP[1]) < 22)
            {
                MessageBox.Show("Вы победили", "Игра окончена", MessageBoxButton.OK);
            }
            if (Convert.ToInt32(GP[1]) > 21 && Convert.ToInt32(GP[3]) > 21)
            {
                MessageBox.Show("Ничья", "Игра окончена", MessageBoxButton.OK);
            }
        }

        private void btnEndGameClick(object sender, RoutedEventArgs e)      //начать игру с начала
        {
            kObj.NewGame(TableNumber);
            btnUserCard.Content = "";
            btnComputerCard.Content = "";
            lb1.Content = "0";
            lb2.Content = "0";
        }

        private void btnStopOnClick(object sender, RoutedEventArgs e)   //перестать брать карты(Компьютер продолжает сам)
        {
            while (Convert.ToInt32(lb2.Content) < 18)   //игра идёт до условия что компьютер не берёт карты если у него больше 18 очков
            {
                GP = kObj.StopPlay(TableNumber, Convert.ToInt32(lb2.Content));
                btnUserCard.Content = GP[0];    //выводим результат хода
                btnComputerCard.Content = GP[2];
                lb1.Content = GP[1];
                lb2.Content = GP[3];
            }
            if (Convert.ToInt32(GP[1]) > 21 && Convert.ToInt32(GP[3]) < 22)    //проверки на конец игры
            {
                MessageBox.Show("Победил Компьютер", "Игра окончена", MessageBoxButton.OK);
            }
            if (Convert.ToInt32(GP[3]) > 21 && Convert.ToInt32(GP[1]) < 22)
            {
                MessageBox.Show("Вы победили", "Игра окончена", MessageBoxButton.OK);
            }
            if (Convert.ToInt32(GP[1]) > 21 && Convert.ToInt32(GP[3]) > 21)
            {
                MessageBox.Show("Ничья", "Игра окончена", MessageBoxButton.OK);
            }
            if ((Convert.ToInt32(GP[1]) > Convert.ToInt32(GP[3])) && (Convert.ToInt32(GP[1]) < 22) && (Convert.ToInt32(GP[3]) < 22))
            {
                MessageBox.Show("Вы победили", "Игра окончена", MessageBoxButton.OK);
            }
            if (Convert.ToInt32(GP[1]) < Convert.ToInt32(GP[3]) && (Convert.ToInt32(GP[1]) < 22) && (Convert.ToInt32(GP[3]) < 22))
            {
                MessageBox.Show("Победил Компьютер", "Игра окончена", MessageBoxButton.OK);
            }
            if (Convert.ToInt32(GP[1]) == Convert.ToInt32(GP[3]) && (Convert.ToInt32(GP[1]) < 22) && (Convert.ToInt32(GP[3]) < 22))
            {
                MessageBox.Show("Ничья", "Игра окончена", MessageBoxButton.OK);
            }

        }
    }
}
