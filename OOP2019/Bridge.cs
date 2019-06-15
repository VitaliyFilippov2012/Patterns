using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    interface ILanguage
    {
        string Build();
        string Execute();
    }

    class CPPLanguage : ILanguage
    {
        public string Build()
        {
            return("С помощью компилятора C++ компилируем программу в бинарный код");
        }

        public string Execute()
        {
            return("Запускаем исполняемый файл программы");
        }
    }

    class CSharpLanguage : ILanguage
    {
        public string Build()
        {
            return("С помощью компилятора Roslyn компилируем исходный код в файл exe");
        }

        public string Execute()
        {
            return("JIT компилирует программу бинарный код - CLR выполняет скомпилированный бинарный код");
        }
    }

    abstract class Programmer
    {
        protected ILanguage language;
        public ILanguage Language
        {
            set { language = value; }
        }
        public Programmer(ILanguage lang)
        {
            language = lang;
        }
        public virtual string DoWork()
        {
           return language.Build() + " and " + language.Execute();
        }
        public abstract string EarnMoney();
    }

    class FreelanceProgrammer : Programmer
    {
        public FreelanceProgrammer(ILanguage lang) : base(lang)
        {
        }
        public override string EarnMoney()
        {
            return("Получаем оплату за выполненный заказ");
        }
    }
    class CorporateProgrammer : Programmer
    {
        public CorporateProgrammer(ILanguage lang)
            : base(lang)
        {
        }
        public override string EarnMoney()
        {
            return("Получаем в конце месяца зарплату");
        }
    }
}
