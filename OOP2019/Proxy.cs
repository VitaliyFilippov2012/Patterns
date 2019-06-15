using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    class Page
    {
        public Page(int id, int number, string text)
        {
            Id = id;
            Number = number;
            Text = text;
        }

        public int Id { get; set; }
        public int Number { get; set; }
        public string Text { get; set; }
    }

    class PageContext:IDisposable
    {
        public PageContext()
        {
            Pages = new List<Page>();
            Pages.Add(new Page(1, 2, "12"));
            Pages.Add(new Page(3, 4, "34"));
            Pages.Add(new Page(5, 6, "56"));
            Pages.Add(new Page(7, 8, "78"));
            Pages.Add(new Page(9, 10, "910"));
            Pages.Add(new Page(11, 12, "1112"));
            Pages.Add(new Page(13, 14, "1314"));
            Pages.Add(new Page(15, 16, "1516"));
            Pages.Add(new Page(17, 18, "1718"));
        }

        public List<Page> Pages { get; set; }
       


        public void Dispose()
        {
                Dispose();
        }
    }

    interface IBook : IDisposable
    {
        Page GetPage(int number);
    }

    class BookStore : IBook//Допусти он берёт данные из БД
    {
        PageContext db;
        public BookStore()
        {
            db = new PageContext();
        }
        public Page GetPage(int number)
        {
            return db.Pages.FirstOrDefault(p => p.Number == number);
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }

    class BookStoreProxy : IBook//Смотрит в лист, если он пустой, то уже обращается к BookStore чтобы достать данные из бд, таким образом снижается нагрузка
    {
        List<Page> pages;
        BookStore bookStore;
        public BookStoreProxy()
        {
            pages = new List<Page>();
        }
        public Page GetPage(int number)
        {
            Page page = pages.FirstOrDefault(p => p.Number == number);
            if (page == null)
            {
                if (bookStore == null)
                    bookStore = new BookStore();
                page = bookStore.GetPage(number);
                pages.Add(page);
            }
            return page;
        }

        public void Dispose()
        {
            if (bookStore != null)
                bookStore.Dispose();
        }
    }
}
