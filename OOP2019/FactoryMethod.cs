using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    // абстрактный класс строительной компании
    abstract class Developer
    {
        public string Name { get; set; }

        public Developer(string n)
        {
            Name = n;
        }
        // фабричный метод
        abstract public House Create();
    }
    // строит панельные дома
    class PanelDeveloper : Developer
    {
        public PanelDeveloper(string n) : base(n)
        { }

        public override House Create()
        {
            return new PanelHouse();
        }
    }
    // строит деревянные дома
    class WoodDeveloper : Developer
    {
        public WoodDeveloper(string n) : base(n)
        { }

        public override House Create()
        {
            return new WoodHouse();
        }
    }

    abstract class House
    {
        string name = "";
        public abstract string GetName();
        
        public string Name { get => name; set => name = value; }

    }

    class PanelHouse : House
    {

        public PanelHouse(string name = "Панельный дом")
        {
            this.Name = name;
        }

        public override string GetName()
        {
            return this.Name;
        }
    }
    class WoodHouse : House
    {
        public WoodHouse(string name = "Деревянный дом")
        {
            this.Name = name;

        }

        public override string GetName()
        {
            return this.Name;

        }
    }
}
