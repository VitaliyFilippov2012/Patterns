using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    // Originator
    class Hero
    {
        private int patrons =5; // кол-во патронов
        private int lives = 3; // кол-во жизней

        public string Shoot()
        {
            if (patrons > 0)
            {
                patrons--;
                return $"Производим выстрел. Осталось {patrons} патронов";
            }
            else
                return "Патронов больше нет";
        }
        // сохранение состояния
        public HeroMemento SaveState()
        { 
            return new HeroMemento(patrons, lives);
        }

        // восстановление состояния
        public string RestoreState(HeroMemento memento)
        {
            this.patrons = memento.Patrons;
            this.lives = memento.Lives;
            return $"Восстановление игры. Параметры: {patrons} патронов, {lives} жизней";
        }
    }
    // Memento
    class HeroMemento
    {
        public int Patrons { get; private set; }
        public int Lives { get; private set; }

        public HeroMemento(int patrons, int lives)
        {
            this.Patrons = patrons;
            this.Lives = lives;
        }
    }

    // Caretaker
    class GameHistory
    {
        public Stack<HeroMemento> History { get; private set; }
        public GameHistory()
        {
            History = new Stack<HeroMemento>();
        }
    }
}
