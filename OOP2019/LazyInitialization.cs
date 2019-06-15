using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyInitialization
{
    class Reader
    {
        Lazy<Library> library = new Lazy<Library>();
        public string ReadBook()
        {
            library.Value.GetBook();
            return("Читаем бумажную книгу");
        }

        public string ReadEbook()
        {
            return("Читаем книгу на компьютере");
        }
    }

    class Library
    {
        private string[] books = new string[9];

        public string GetBook()
        {
            return("Выдаем книгу читателю");
        }
    }
}
