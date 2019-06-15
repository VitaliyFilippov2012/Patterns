using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    abstract class Mediator
    {
        public abstract string Send(string msg, Colleague colleague);
    }

    abstract class Colleague
    {
        protected Mediator mediator;

        public Colleague(Mediator mediator)
        {
            this.mediator = mediator;
        }

        public virtual string Send(string message)
        {
            return mediator.Send(message, this);
        }
        public abstract string Notify(string message);
    }

    // класс заказчика
    class CustomerColleague : Colleague
    {
        public CustomerColleague(Mediator mediator)
            : base(mediator)
        { }

        public override string Notify(string message)
        {
            return "Сообщение заказчику: " + message;
        }
    }
    // класс программиста
    class ProgrammerColleague : Colleague
    {
        public ProgrammerColleague(Mediator mediator)
            : base(mediator)
        { }

        public override string Notify(string message)
        {
            return "Сообщение программисту: " + message;
        }
    }
    // класс тестера
    class TesterColleague : Colleague
    {
        public TesterColleague(Mediator mediator)
            : base(mediator)
        { }

        public override string Notify(string message)
        {
            return "Сообщение тестеру: " + message;
        }
    }

    class ManagerMediator : Mediator
    {
        public Colleague Customer { get; set; }
        public Colleague Programmer { get; set; }
        public Colleague Tester { get; set; }
        public override string Send(string msg, Colleague colleague)
        {
            // если отправитель - заказчик, значит есть новый заказ
            // отправляем сообщение программисту - выполнить заказ
            if (Customer == colleague)
                return Programmer.Notify(msg);
            // если отправитель - программист, то можно приступать к тестированию
            // отправляем сообщение тестеру
            else if (Programmer == colleague)
                return Tester.Notify(msg);
            // если отправитель - тест, значит продукт готов
            // отправляем сообщение заказчику
            else if (Tester == colleague)
                return Customer.Notify(msg);
            else 
                return "";
        }
    }
}
