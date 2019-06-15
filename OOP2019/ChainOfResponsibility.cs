using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    abstract class Handler
    {
        public Handler Successor { get; set; }
        public abstract string HandleRequest(int condition,string res);
    }

    class ConcreteHandler1 : Handler
    {
        public override string HandleRequest(int condition,string res)
        {
            if (condition == 1)
            {
                return "1";
                // обработка;
            }
            else if (Successor != null)
            {
                return Successor.HandleRequest(condition,"1 + ");
            }
            else
            {
                return "";
            }
        }
    }

    class ConcreteHandler2 : Handler
    {
        public override string HandleRequest(int condition,string res)
        {
            if (condition == 2)
            {
                return res + "2";
                // обработка;
            }
            else if (Successor != null)
            {
                return Successor.HandleRequest(condition,res+"2");
            }
            else
            {
                return "";
            }
        }
    }
}
