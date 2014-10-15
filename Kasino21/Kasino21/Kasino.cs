using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameDll;  //подключаем dll  склассом Game


namespace Kasino21
{
    [Serializable]
    class Kasino
    {
        Game g1;
        Game g2;
        Game g3;
        Game g4;
        Game g5;

        // 0 - карта пользователя
        // 1 - очки пользователя
        // 2 - карта компьютера
        // 3 - очки компьютера
        object[] gameParameters1;
        object[] gameParameters2;
        object[] gameParameters3;
        object[] gameParameters4;
        object[] gameParameters5;
        public Kasino()
        {
            g1 = new Game();
            g2 = new Game();
            g3 = new Game();
            g4 = new Game();
            g5 = new Game();
            gameParameters1 = new object[4];
            gameParameters2 = new object[4];
            gameParameters3 = new object[4];
            gameParameters4 = new object[4];
            gameParameters5 = new object[4];
        }
        public object[] Play(int tableNumber,int score1, int score2)
        {
            object[] nextUserCard;  //информация о карте пользователя
            object[] nextCompCard;  //информация о карте компьютера
            switch (tableNumber)    //в зависимости от номера выбраного стола
            {
                case 1:
                    nextUserCard = g1.UserTurns(score1);        //ход пользователя
                    nextCompCard = g1.ComputerTurns(score2);    //ход компьютера
                    score1 += Convert.ToInt32(nextUserCard[1]); //суммирование очков
                    score2 += Convert.ToInt32(nextCompCard[1]);
                    gameParameters1[0] = nextUserCard[0];       //перенос в общий массив для возврата данных в (Controls)
                    gameParameters1[1] = score1;
                    gameParameters1[2] = nextCompCard[0];
                    gameParameters1[3] = score2;
                    return gameParameters1;
                case 2:
                    nextUserCard = g2.UserTurns(score1);
                    nextCompCard = g2.ComputerTurns(score2);
                    score1 += Convert.ToInt32(nextUserCard[1]);
                    score2 += Convert.ToInt32(nextCompCard[1]);
                    gameParameters2[0] = nextUserCard[0];
                    gameParameters2[1] = score1;
                    gameParameters2[2] = nextCompCard[0];
                    gameParameters2[3] = score2;
                    return gameParameters2;
                case 3:
                    nextUserCard = g3.UserTurns(score1);
                    nextCompCard = g3.ComputerTurns(score2);
                    score1 += Convert.ToInt32(nextUserCard[1]);
                    score2 += Convert.ToInt32(nextCompCard[1]);
                    gameParameters3[0] = nextUserCard[0];
                    gameParameters3[1] = score1;
                    gameParameters3[2] = nextCompCard[0];
                    gameParameters3[3] = score2;
                    return gameParameters3;
                case 4:
                    nextUserCard = g4.UserTurns(score1);
                    nextCompCard = g4.ComputerTurns(score2);
                    score1 += Convert.ToInt32(nextUserCard[1]);
                    score2 += Convert.ToInt32(nextCompCard[1]);
                    gameParameters4[0] = nextUserCard[0];
                    gameParameters4[1] = score1;
                    gameParameters4[2] = nextCompCard[0];
                    gameParameters4[3] = score2;
                    return gameParameters4;
                case 5:
                    nextUserCard = g5.UserTurns(score1);
                    nextCompCard = g5.ComputerTurns(score2);
                    score1 += Convert.ToInt32(nextUserCard[1]);
                    score2 += Convert.ToInt32(nextCompCard[1]);
                    gameParameters5[0] = nextUserCard[0];
                    gameParameters5[1] = score1;
                    gameParameters5[2] = nextCompCard[0];
                    gameParameters5[3] = score2;
                    return gameParameters5;
            }
            return null;
        }
        public object[] StopPlay(int tableNumber, int score2)   //компьютер берёт карты сам
        {
            object[] nextCompCard;  //информация о карте компьютера
            switch (tableNumber)
            {
                case 1:
                    nextCompCard = g1.ComputerTurns(score2);    //ход компьютера
                    score2 += Convert.ToInt32(nextCompCard[1]);
                    gameParameters1[2] = nextCompCard[0];
                    gameParameters1[3] = score2;
                    return gameParameters1;
                case 2:
                    nextCompCard = g1.ComputerTurns(score2);    //ход компьютера
                    score2 += Convert.ToInt32(nextCompCard[1]);
                    gameParameters2[2] = nextCompCard[0];
                    gameParameters2[3] = score2;
                    return gameParameters2;
                case 3:
                    nextCompCard = g1.ComputerTurns(score2);    //ход компьютера
                    score2 += Convert.ToInt32(nextCompCard[1]);
                    gameParameters3[2] = nextCompCard[0];
                    gameParameters3[3] = score2;
                    return gameParameters3;
                case 4:
                    nextCompCard = g1.ComputerTurns(score2);    //ход компьютера
                    score2 += Convert.ToInt32(nextCompCard[1]);
                    gameParameters4[2] = nextCompCard[0];
                    gameParameters4[3] = score2;
                    return gameParameters4;
                case 5:
                    nextCompCard = g1.ComputerTurns(score2);    //ход компьютера
                    score2 += Convert.ToInt32(nextCompCard[1]);
                    gameParameters5[2] = nextCompCard[0];
                    gameParameters5[3] = score2;
                    return gameParameters5;
            }
            return null;
        }
        public void NewGame(int tableNumber)    //восстановление начальных параметорв
        {
            switch (tableNumber)    //в зависимости от номера выбраного стола
            {
                case 1:
                    g1 = new Game();
                    gameParameters1 = new object[4];
                    break;
                case 2:
                    g2 = new Game();
                    gameParameters2 = new object[4];
                    break;
                case 3:
                    g3 = new Game();
                    gameParameters3 = new object[4];
                    break;
                case 4:
                    g4 = new Game();
                    gameParameters4 = new object[4];
                    break;
                case 5:
                    g5 = new Game();
                    gameParameters5 = new object[4];
                    break;
            }
        }
        public object[] GetData(int tableNumber)    //для возобновления данных после сериализации
        {
            switch (tableNumber)    //в зависимости от номера выбраного стола
            {
                case 1:
                    return gameParameters1;
                case 2:
                    return gameParameters2;
                case 3:
                    return gameParameters3;
                case 4:
                    return gameParameters4;
                case 5:
                    return gameParameters5;
            }
            return null;
        }
    }
}
