using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{

    interface IVisitor
    {
        string VisitPersonAcc(Person acc);
        string VisitCompanyAc(Company acc);
    }

    // сериализатор в HTML
    class HtmlVisitor : IVisitor
    {
        public string VisitPersonAcc(Person acc)
        {
            string result = "<table><tr><td>Свойство<td><td>Значение</td></tr>";
            result += "<tr><td>Name<td><td>" + acc.Name + "</td></tr>";
            result += "<tr><td>Number<td><td>" + acc.Number + "</td></tr></table>";
            return result;
        }

        public string VisitCompanyAc(Company acc)
        {
            string result = "<table><tr><td>Свойство<td><td>Значение</td></tr>";
            result += "<tr><td>Name<td><td>" + acc.Name + "</td></tr>";
            result += "<tr><td>RegNumber<td><td>" + acc.RegNumber + "</td></tr>";
            result += "<tr><td>Number<td><td>" + acc.Number + "</td></tr></table>";
            return result;
        }
    }

    // сериализатор в XML
    class XmlVisitor : IVisitor
    {
        public string VisitPersonAcc(Person acc)
        {
            string result = "<Person><Name>" + acc.Name + "</Name>" +
                "<Number>" + acc.Number + "</Number><Person>";
            return result;
        }

        public string VisitCompanyAc(Company acc)
        {
            string result = "<Company><Name>" + acc.Name + "</Name>" +
                "<RegNumber>" + acc.RegNumber + "</RegNumber>" +
                "<Number>" + acc.Number + "</Number><Company>";
            return result;
        }
    }

    class Cartoteka
    {

        List<string> notify;
        List<IAccount> accounts;

        public List<string> Notify { get => notify; set => notify = value; }

        public Cartoteka()
        {
            notify = new List<string>();
            accounts = new List<IAccount>();
        }

        public void Add(IAccount acc)
        {
            accounts.Add(acc);
        }
        public void Remove(IAccount acc)
        {
            accounts.Remove(acc);
        }
        public void Accept(IVisitor visitor)
        {
            foreach (IAccount acc in accounts)
                notify.Add(acc.Accept(visitor));
        }
    }

    interface IAccount
    {
        string Accept(IVisitor visitor);
    }

    class Person : IAccount
    {
        public string Name { get; set; }
        public string Number { get; set; }

        public string Accept(IVisitor visitor)
        {
            return visitor.VisitPersonAcc(this);
        }
    }

    class Company : IAccount
    {
        public string Name { get; set; }
        public string RegNumber { get; set; }
        public string Number { get; set; }

        public string Accept(IVisitor visitor)
        {
            return visitor.VisitCompanyAc(this);
        }
    }
}
