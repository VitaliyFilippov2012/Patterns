using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class SingletonClassic
    {
        private static SingletonClassic instance;
        public string Date { get; private set; }

        private SingletonClassic()
        {
            Date = System.DateTime.Now.TimeOfDay.ToString();

        }

        public static SingletonClassic getInstance()
        {
            if (instance == null)
                instance = new SingletonClassic();
            return instance;
        }
    }

    class SingletonWithTread
    {
        private static SingletonWithTread instance;
        public string Date { get; private set; }

        private static object lockk = new Object();
        private SingletonWithTread()
        {
            Date = System.DateTime.Now.TimeOfDay.ToString();
        }

        public static SingletonWithTread getInstance()
        {
            if (instance == null)
            {
                lock (lockk)
                {
                    if(instance == null)
                        instance = new SingletonWithTread();

                }
            }
            return instance;
        }
    }

    public class SingletonWithTreadStatic
    {
        private static readonly SingletonWithTreadStatic instance = new SingletonWithTreadStatic();

        public string Date { get; private set; }

        private SingletonWithTreadStatic()
        {
            Date = System.DateTime.Now.TimeOfDay.ToString();
        }

        public static SingletonWithTreadStatic GetInstance()
        {
            return instance;
        }
    }

    public class SingletonLazy
    {
        private static readonly Lazy<SingletonLazy> lazy =
        new Lazy<SingletonLazy>(() => new SingletonLazy());

        public string Date { get; private set; }


        private SingletonLazy()
        {
            Date = System.DateTime.Now.TimeOfDay.ToString();
        }

        public static SingletonLazy GetInstance()
        {
            return lazy.Value;
        }
    }
}
