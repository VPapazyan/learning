using System;

namespace FactoryMethodPattern
{
    class WoodHouse : House
    {
        public WoodHouse() 
        {
            Console.WriteLine("Деревянный дом построен");
        }
    }
}
