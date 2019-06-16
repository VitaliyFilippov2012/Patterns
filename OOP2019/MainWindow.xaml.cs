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
using ChainOfResponsibility;
using Command;
using Proxy;
using Bridge;
using Composite;
using Facade;
using Decorator;
using Adapter;
using LazyInitialization;
using AbstractFactory;
using FactoryMethod;
using ObjectPool;
using Prototype;
using Builder;


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
            Memento.Hero hero = new Memento.Hero();
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
            Iterator.Library library = new Iterator.Library();
            Iterator.Reader reader = new Iterator.Reader();
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

        private void ChainStart(object sender, RoutedEventArgs e)
        {
            Handler h1 = new ConcreteHandler1();
            Handler h2 = new ConcreteHandler2();
            h1.Successor = h2;
            MessageBox.Show(h1.HandleRequest(2,""));
        }

        private void CommandStart(object sender, RoutedEventArgs e)
        {
            Pult pult = new Pult();
            TV tv = new TV();
            pult.SetCommand(new TVOnCommand(tv));
            MessageBox.Show(pult.PressButton());
            MessageBox.Show(pult.PressUndo());
            
        }

        private void ProxyStart(object sender, RoutedEventArgs e)
        {
            try
            {
                IBook book = new BookStoreProxy();
                // читаем первую страницу
                Proxy.Page page1 = book.GetPage(2);
                MessageBox.Show(page1.Text);
                // читаем вторую страницу
                Proxy.Page page2 = book.GetPage(6);
                MessageBox.Show(page2.Text);
                // возвращаемся на первую страницу    
                page1 = book.GetPage(16);
                MessageBox.Show(page1.Text);

            }

            catch { }
        }

        private void BridgeStart(object sender, RoutedEventArgs e)
        {
            // создаем нового программиста, он работает с с++
            Bridge.Programmer freelancer = new FreelanceProgrammer(new CPPLanguage());
            MessageBox.Show(freelancer.DoWork());
            MessageBox.Show(freelancer.EarnMoney());
            // пришел новый заказ, но теперь нужен c#
            freelancer.Language = new CSharpLanguage();
            MessageBox.Show(freelancer.DoWork());
            MessageBox.Show(freelancer.EarnMoney());
        }

        private void AdapterStart(object sender, RoutedEventArgs e)
        {
            // путешественник
            Driver driver = new Driver();
            // машина
            Auto auto = new Auto();
            // отправляемся в путешествие
            MessageBox.Show(driver.Travel(auto));
            // встретились пески, надо использовать верблюда
            Camel camel = new Camel();
            // используем адаптер
            ITransport camelTransport = new CamelToTransportAdapter(camel);
            // продолжаем путь по пескам пустыни
            MessageBox.Show(driver.Travel(camelTransport));
        }

        private void DecoratorStart(object sender, RoutedEventArgs e)
        {
            Pizza pizza1 = new ItalianPizza();
            pizza1 = new TomatoPizza(pizza1); // итальянская пицца с томатами
            MessageBox.Show($"Название: {pizza1.Name}");
            MessageBox.Show($"Цена: { pizza1.GetCost().ToString()}");

            Pizza pizza2 = new ItalianPizza();
            pizza2 = new CheesePizza(pizza2);// итальянская пиццы с сыром
            MessageBox.Show($"Название: {pizza2.Name}");
            MessageBox.Show($"Цена: {pizza2.GetCost().ToString()}" );

            Pizza pizza3 = new BulgerianPizza();
            pizza3 = new TomatoPizza(pizza3);
            pizza3 = new CheesePizza(pizza3);// болгарская пиццы с томатами и сыром
            MessageBox.Show($"Название: {pizza3.Name}");
            MessageBox.Show($"Цена: {pizza3.GetCost().ToString()}");
        }

        private void CompositeStart(object sender, RoutedEventArgs e)
        {
            Component fileSystem = new Directory("Файловая система");
            // определяем новый диск
            Component diskC = new Directory("Диск С");
            // новые файлы
            Component pngFile = new File("12345.png");
            Component docxFile = new File("Document.docx");
            // добавляем файлы на диск С
            diskC.Add(pngFile);
            diskC.Add(docxFile);
            // добавляем диск С в файловую систему
            fileSystem.Add(diskC);
            // выводим все данные
            MessageBox.Show(fileSystem.Print());

            Console.WriteLine();
            // удаляем с диска С файл
            diskC.Remove(pngFile);
            // создаем новую папку
            Component docsFolder = new Directory("Мои Документы");
            // добавляем в нее файлы
            Component txtFile = new File("readme.txt");
            Component csFile = new File("Program.cs");
            docsFolder.Add(txtFile);
            docsFolder.Add(csFile);
            diskC.Add(docsFolder);

            MessageBox.Show(fileSystem.Print());
        }

        private void FacadeStart(object sender, RoutedEventArgs e)
        {
            TextEditor textEditor = new TextEditor();
            Compiller compiller = new Compiller();
            CLR clr = new CLR();

            VisualStudioFacade ide = new VisualStudioFacade(textEditor, compiller, clr);

            Facade.Programmer programmer = new Facade.Programmer();
            MessageBox.Show(programmer.CreateApplication(ide));
        }

        private void LazyStart(object sender, RoutedEventArgs e)
        {
            LazyInitialization.Reader reader = new LazyInitialization.Reader();
            MessageBox.Show(reader.ReadEbook());
            MessageBox.Show(reader.ReadBook());
            MessageBox.Show(reader.ReadBook());
        }

        private void BuilderStart(object sender, RoutedEventArgs e)
        {
            // содаем объект пекаря
            Baker baker = new Baker();
            // создаем билдер для ржаного хлеба
            BreadBuilder builder = new RyeBreadBuilder();
            // выпекаем
            Bread ryeBread = baker.Bake(builder);
            MessageBox.Show(ryeBread.ToString());
            // оздаем билдер для пшеничного хлеба
            builder = new WheatBreadBuilder();
            Bread wheatBread = baker.Bake(builder);
            MessageBox.Show(wheatBread.ToString());
        }

        private void PoolStart(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Initialize pool");
            var pool = new ConnectionPool(minSize: 2, maxSize: 5);
            MessageBox.Show("Get connection #1 (fast)");
            var c1 = pool.GetConnection();
            MessageBox.Show("Get connection #2 (fast)");
            var c2 = pool.GetConnection();
            MessageBox.Show("Get connection #3 (slow)");
            var c3 = pool.GetConnection();
            MessageBox.Show("Get connection #4 (slow)");
            var c4 = pool.GetConnection();
            MessageBox.Show("Release connection #3");
            pool.ReleaseConnection(c3);
            MessageBox.Show("Release connection #2");
            pool.ReleaseConnection(c2);
            MessageBox.Show("Get connection #5 (c2)");
            var c5 = pool.GetConnection();
            MessageBox.Show(ReferenceEquals(c2, c5).ToString()); // True;
            pool.GetConnection();
            foreach(string n in Connection.History)
            {
                MessageBox.Show(n);
            }
        }

        private void PrototypeStart(object sender, RoutedEventArgs e)
        {
            IFigure figure = new Prototype.Rectangle(30, 40);
            IFigure clonedFigure = figure.Clone();
            MessageBox.Show(figure.GetInfo());
            MessageBox.Show(clonedFigure.GetInfo());

            figure = new Circle(30);
            clonedFigure = figure.Clone();
            MessageBox.Show(figure.GetInfo());
            MessageBox.Show(clonedFigure.GetInfo());

            figure = new Circle(15);
            MessageBox.Show(figure.GetInfo());
            Circle deepClonedFigure = figure.DeepCopy() as Circle;
            MessageBox.Show(deepClonedFigure.GetInfo());


        }

        private void AbstractFactoryStart(object sender, RoutedEventArgs e)
        {
            AbstractFactory.Hero elf = new AbstractFactory.Hero(new ElfFactory());
            MessageBox.Show(elf.Hit());
            MessageBox.Show(elf.Run());

            AbstractFactory.Hero voin = new AbstractFactory.Hero(new VoinFactory());
            MessageBox.Show(voin.Hit());
            MessageBox.Show(voin.Run());
        }

        private void FactoryMethodStart(object sender, RoutedEventArgs e)
        {
            Developer dev = new PanelDeveloper("ООО КирпичСтрой");
            House house2 = dev.Create();
            MessageBox.Show(dev.Name+" - "+house2.GetName());
            dev = new WoodDeveloper("Частный застройщик");
            House house = dev.Create();
            MessageBox.Show(dev.Name + " - " + house.GetName());

        }
    }
}
