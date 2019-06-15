using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID
{

    //Single responsibility
    //Один класс несёт единственную ответственность
    //Класс сотрудника может добавлять нового, а другой класс составляет отчёт в различных форматах
    //Open closed principle
    public class Employee
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public bool Add(Employee emp)
        {
            // Вставить данные сотрудника в таблицу БД
            return true;
        }
    }

    public class IEmployeeReport
    {
        /// <summary>
        /// Метод для создания отчета
        /// </summary>
        public virtual void GenerateReport(Employee em)
        {
            // Базовая реализация, которую нельзя модифицировать
        }
    }

    public class EmployeeCSVReport : IEmployeeReport
    {
        public override void GenerateReport(Employee em)
        {
            // Генерация отчета в формате CSV
        }
    }

    public class EmployeePDFReport : IEmployeeReport
    {
        public override void GenerateReport(Employee em)
        {
            // Генерация отчета в формате PDF
        }
    }

    //Liskov substitution
    //Использование любого производного класс вместо родительского класса и вести себя с ним таким же образом без внесения изменений
    public abstract class Programmer
    {
        public virtual string GetWorkDetails()
        {
            return "Base Work";
        }
    }

    public class SeniorProgrammer : Programmer
    {
        public override string GetWorkDetails()
        {
            return "Senior programmer";
        }

        public string GetDetails(int id)
        {
            return "Senior programmer v3.0";
        }
    }

    public class JuniorProgrammer : Programmer
    {
        public override string GetWorkDetails()
        {
            return "Junior programmer";
        }
    }

    public class Test//В параметр можно закинуть как Senior так и Juniora и всё отработет как надо
    {
        public string TestLiskov(Programmer programmer)
        {
            return programmer.GetWorkDetails();
        }
    }

    //Interface segregation
    //Разделение ответственностей по интерфейсам, чтобы другой класс, не использующий этот метод не знал о нём
    public interface IWork
    {
        bool Work();//Оба класса
    }
    public interface IReport
    {
        bool CreateReport();//Только директор

    }

    public class Worker : IWork
    {
        public bool Work()
        {
            //реализация
            return true;
        }
    }

    public class Director : IWork, IReport
    {
        public bool CreateReport()
        {
            //реализация
            return true;
        }

        public bool Work()
        {
            //реализация
            return false;
        }
    }


    //Dependency Inversion
    public interface IMessenger
    {
        void Send();
    }

    public class Email : IMessenger//Зависит от абстракции
    {
        public void Send()
        {
            // код для отправки email-письма
        }
    }
    // Уведомление
    public class Notification
    {
        private IMessenger _messenger;//Зависит от абстракции, ничего не зная об классе Email
        public Notification(IMessenger messenger)
        {
            _messenger = messenger;
        }

        public void DoNotify()
        {
            _messenger.Send();
        }
    }
}
