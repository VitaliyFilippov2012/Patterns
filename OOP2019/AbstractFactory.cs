using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    //абстрактный класс - оружие
    abstract class Weapon
    {
        public abstract string Hit();
    }
    // абстрактный класс движение
    abstract class Movement
    {
        public abstract string Move();
    }

    // класс арбалет
    class Arbalet : Weapon
    {
        public override string Hit()
        {
            return ("Стреляем из арбалета");
        }
    }
    // класс меч
    class Sword : Weapon
    {
        public override string Hit()
        {
            return ("Бьем мечом");
        }
    }
    // движение полета
    class FlyMovement : Movement
    {
        public override string Move()
        {
            return ("Летим");
        }
    }
    // движение - бег
    class RunMovement : Movement
    {
        public override string Move()
        {
            return("Бежим");
        }
    }
    // класс абстрактной фабрики
    abstract class HeroFactory
    {
        public abstract Movement CreateMovement();
        public abstract Weapon CreateWeapon();
    }
    // Фабрика создания летящего героя с арбалетом
    class ElfFactory : HeroFactory
    {
        public override Movement CreateMovement()
        {
            return new FlyMovement();
        }

        public override Weapon CreateWeapon()
        {
            return new Arbalet();
        }
    }
    // Фабрика создания бегущего героя с мечом
    class VoinFactory : HeroFactory
    {
        public override Movement CreateMovement()
        {
            return new RunMovement();
        }

        public override Weapon CreateWeapon()
        {
            return new Sword();
        }
    }
    // клиент - сам супергерой
    class Hero
    {
        private Weapon weapon;
        private Movement movement;
        public Hero(HeroFactory factory)
        {
            weapon = factory.CreateWeapon();
            movement = factory.CreateMovement();
        }
        public string Run()
        {
            return movement.Move();
        }
        public string Hit()
        {
            return weapon.Hit();
        }
    }
}
