using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Memento;
using OBSERVER;
using Strategy;
using NullObject;
using Iterator;
using Mediator;
using Visitor;


namespace OOP2019
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MementoStart(object sender, RoutedEventArgs e)
        {
            Hero hero = new Hero();
            MessageBox.Show(hero.Shoot()); // делаем выстрел, осталось 4 патронов
            MessageBox.Show("Сохранились");
            GameHistory game = new GameHistory();
            game.History.Push(hero.SaveState()); // сохраняем игру
            MessageBox.Show(hero.Shoot()); //делаем выстрел, осталось 3 патронов
            MessageBox.Show("Возвращаемся к последнему сохранению");
            MessageBox.Show(hero.RestoreState(game.History.Pop()));
            MessageBox.Show(hero.Shoot()); //делаем выстрел, осталось 4 патронов
        }

        private void NullStart(object sender, RoutedEventArgs e)
        {
            TextConverter textConverter = new UpperCaseTextConverter();
            MessageBox.Show(textConverter.Convert("Hello World"));
            MessageBox.Show("Объект - заглушка");
            textConverter = new NullTextConverter();//Вместо null (объект -заглушка)
            MessageBox.Show(textConverter.Convert("Hello World"));

        }

        private void StrategyStart(object sender, RoutedEventArgs e)
        {
            Car auto = new Car(4, "Volvo", new PetrolMove());
            MessageBox.Show("Едем на дачу");
            MessageBox.Show(auto.Move());
            MessageBox.Show("Топливо закончилось, переходим на электричество");

            auto.Movable = new ElectricMove();
            MessageBox.Show(auto.Move());
        }

        private void ObserverStart(object sender, RoutedEventArgs e)
        {
            Stock stock = new Stock();
            Bank bank = new Bank("ЮнитБанк", stock);
            Broker broker = new Broker("Иван Иваныч", stock);
            // имитация торгов
            MessageBox.Show("Начинаем торги");
            stock.Market();
            foreach(string n in stock.Notifies)
            {
                MessageBox.Show(n);
            }
            // брокер прекращает наблюдать за торгам
            MessageBox.Show("Брокер вышел из наблюдения");

            broker.StopTrade();
            // имитация торгов
            MessageBox.Show("Начинаем торги");

            stock.Market();
            foreach (string n in stock.Notifies)
            {
                MessageBox.Show(n);
            }
        }

        private void IteratorStart(object sender, RoutedEventArgs e)
        {
            Library library = new Library();
            Reader reader = new Reader();
            reader.SeeBooks(library);
            foreach(string n in reader.Books)
            {
                MessageBox.Show(n);
            }
        }

        private void MediatorStart(object sender, RoutedEventArgs e)
        {
            ManagerMediator mediator = new ManagerMediator();
            Colleague customer = new CustomerColleague(mediator);
            Colleague programmer = new ProgrammerColleague(mediator);
            Colleague tester = new TesterColleague(mediator);
            mediator.Customer = customer;
            mediator.Programmer = programmer;
            mediator.Tester = tester;
            MessageBox.Show(customer.Send("Есть заказ, надо сделать программу"));
            MessageBox.Show(programmer.Send("Программа готова, надо протестировать"));
            MessageBox.Show(tester.Send("Программа протестирована и готова к продаже"));
        }

        private void VisitorStart(object sender, RoutedEventArgs e)
        {
            var structure = new Cartoteka();
            structure.Add(new Person { Name = "Иван Алексеев", Number = "82184931" });
            structure.Add(new Company { Name = "Microsoft", RegNumber = "ewuir32141324", Number = "3424131445" });
            structure.Accept(new HtmlVisitor());
            MessageBox.Show("HTML");

            foreach (string n in structure.Notify)
            {
                MessageBox.Show(n);
            }
            structure.Notify.Clear();
            structure.Accept(new XmlVisitor());
            MessageBox.Show("XMl");

            foreach (string n in structure.Notify)
            {
                MessageBox.Show(n);
            }
            structure.Notify.Clear();
        }
    }
}
