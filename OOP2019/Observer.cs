using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBSERVER
{
    interface IObserver
    {
        string Update(Object ob);
    }

    interface IObservable
    {
        void RegisterObserver(IObserver o);
        void RemoveObserver(IObserver o);
        void NotifyObservers();
    }

    class Stock : IObservable
    {
        StockInfo sInfo; // информация о торгах
        List<String> notifies;
        List<IObserver> observers;

        public List<string> Notifies { get => notifies; set => notifies = value; }

        public Stock()
        {
            notifies = new List<string>();
            observers = new List<IObserver>();
            sInfo = new StockInfo();
        }
        public void RegisterObserver(IObserver o)
        {
            observers.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            observers.Remove(o);
        }

        public void NotifyObservers()
        {
            foreach (IObserver o in observers)
            {
                Notifies.Add(o.Update(sInfo));
            }
        }

        public void Market()
        {
            Notifies.Clear();
            Random rnd = new Random();
            sInfo.USD = rnd.Next(20, 40);
            sInfo.Euro = rnd.Next(30, 50);
            NotifyObservers();
        }
    }

    class StockInfo
    {
        public int USD { get; set; }
        public int Euro { get; set; }
    }

    class Broker : IObserver
    {
        public string Name { get; set; }
        IObservable stock;
        public Broker(string name, IObservable obs)
        {
            this.Name = name;
            stock = obs;
            stock.RegisterObserver(this);
        }
        public string Update(object ob)
        {
            StockInfo sInfo = (StockInfo)ob;

            if (sInfo.USD > 30)
                 return $"Брокер {this.Name} продает доллары;  Курс доллара: {sInfo.USD}";
            else
                return $"Брокер {this.Name} покупает доллары;  Курс доллара: {sInfo.USD}";
        }
        public void StopTrade()
        {
            stock.RemoveObserver(this);
            stock = null;
        }
    }

    class Bank : IObserver
    {
        public string Name { get; set; }
        IObservable stock;
        public Bank(string name, IObservable obs)
        {
            this.Name = name;
            stock = obs;
            stock.RegisterObserver(this);
        }
        public string Update(object ob)
        {
            StockInfo sInfo = (StockInfo)ob;

            if (sInfo.Euro > 40)
                return $"Банк {this.Name} продает евро;  Курс евро: {sInfo.Euro}";
            else
                 return $"Банк {this.Name} покупает евро;  Курс евро: {sInfo.Euro}";
        }
    }
}
