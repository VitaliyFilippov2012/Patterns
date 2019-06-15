using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    interface IMovable
    {
        string Move();
    }

    class PetrolMove : IMovable
    {
        public string Move()
        {
            return "Перемещение на бензине";
        }
    }

    class ElectricMove : IMovable
    {
        public string Move()
        {
            return "Перемещение на электричестве";
        }
    }
    class Car
    {
        protected int passengers; // кол-во пассажиров
        protected string model; // модель автомобиля

        public Car(int num, string model, IMovable mov)
        {
            this.passengers = num;
            this.model = model;
            Movable = mov;
        }
        public IMovable Movable { private get; set; }
        public string Move()
        {
            return Movable.Move();
        }
    }
}
