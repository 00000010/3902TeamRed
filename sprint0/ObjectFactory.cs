using System;
namespace sprint0
{
    public class ObjectFactory : IFactory
    {
        public ObjectFactory()
        {}

        //public IFactory GetFactory(string factory)
        //{
        //    Activator.CreateInstance("Instance", factory);
        //    return factory;
        //}

        public void Print()
        {
            Console.WriteLine("Printed!");
        }
    }
}

