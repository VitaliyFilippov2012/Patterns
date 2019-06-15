using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    interface ICommand
    {
        string Execute();
        string Undo();
    }

    // Receiver - Получатель
    class TV
    {
        public string On()
        {
            return"Телевизор включен!";
        }

        public string Off()
        {
            return "Телевизор выключен...";
        }
    }

    class TVOnCommand : ICommand
    {
        TV tv;
        public TVOnCommand(TV tvSet)
        {
            tv = tvSet;
        }
        public string Execute()
        {
            return tv.On();
        }
        public string Undo()
        {
            return tv.Off();
        }
    }

    // Invoker - инициатор
    class Pult
    {
        ICommand command;

        public Pult() { }

        public void SetCommand(ICommand com)
        {
            command = com;
        }

        public string PressButton()
        {
           return command.Execute();
        }
        public string PressUndo()
        {
           return command.Undo();
        }
    }
}
