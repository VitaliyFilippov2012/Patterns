using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullObject
{
    abstract class TextConverter
    {
        public abstract string Convert(string text);
    }

    class UpperCaseTextConverter : TextConverter
    {
        public override string Convert(string text)
        {
            return text.ToUpper();
        }
    }

    class NullTextConverter : TextConverter //Будем присваивать вместо null этот класс
    {
        public override string Convert(string text)
        {
            return text;
        }
    }
}
