using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    class TextEditor
    {
        public string CreateCode()
        {
            return("Написание кода");
        }
        public string Save()
        {
            return("Сохранение кода");
        }
    }
    class Compiller
    {
        public string Compile()
        {
            return("Компиляция приложения");
        }
    }
    class CLR
    {
        public string Execute()
        {
            return("Выполнение приложения");
        }
        public string Finish()
        {
            return("Завершение работы приложения");
        }
    }

    class VisualStudioFacade
    {
        TextEditor textEditor;
        Compiller compiller;
        CLR clr;
        public VisualStudioFacade(TextEditor te, Compiller compil, CLR clr)
        {
            this.textEditor = te;
            this.compiller = compil;
            this.clr = clr;
        }
        public string Start()
        {
            string res = "";
            res = textEditor.CreateCode();
            res += " >> "+textEditor.Save();
            res += " >> " + compiller.Compile();
            res += " >> " + clr.Execute();
            return res;
        }
        public string Stop()
        {
            return clr.Finish();
        }
    }

    class Programmer
    {
        public string CreateApplication(VisualStudioFacade facade)
        {
            string res = "";
            res += " Включил вижлу " + facade.Start();
            res += " >> " + facade.Stop();
            return res;
        }
    }
}
