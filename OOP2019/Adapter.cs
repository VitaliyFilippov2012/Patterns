using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    interface ITransport
    {
        string Drive();
    }
    // класс машины
    class Auto : ITransport
    {
        public string Drive()
        {
            return("Машина едет по дороге");
        }
    }
    class Driver
    {
        public string Travel(ITransport transport)
        {
            return transport.Drive();
        }
    }
    // интерфейс животного
    interface IAnimal
    {
        string Move();
    }
    // класс верблюда
    class Camel : IAnimal
    {
        public string Move()
        {
            return("Верблюд идет по пескам пустыни");
        }
    }
    // Адаптер от Camel к ITransport
    class CamelToTransportAdapter : ITransport
    {
        Camel camel;
        public CamelToTransportAdapter(Camel c)
        {
            camel = c;
        }

        public string Drive()
        {
            return camel.Move();
        }
    }
}
