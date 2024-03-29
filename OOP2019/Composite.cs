﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    abstract class Component
    {
        protected string name;

        public Component(string name)
        {
            this.name = name;
        }

        public virtual void Add(Component component) { }

        public virtual void Remove(Component component) { }

        public virtual string Print()
        {
            return(name);
        }
    }
    class Directory : Component
    {
        private List<Component> components = new List<Component>();

        public Directory(string name)
            : base(name)
        {
        }

        public override void Add(Component component)
        {
            components.Add(component);
        }

        public override void Remove(Component component)
        {
            components.Remove(component);
        }

        public override string Print()
        {
            string res = "Узел " + name + "- Подузлы: ";
            for (int i = 0; i < components.Count; i++)
            {
                res  += components[i].Print();
            }
            return res;
        }
    }

    class File : Component
    {
        public File(string name)
                : base(name)
        { }
    }
}
