using System;
using System.Text;

namespace FactoryMethodPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Developer dev = new PanelDeveloper("ООО КирпичСтрой");
            House house2 = dev.Create();

            dev = new WoodDeveloper("Частный застройщик");
            House house = dev.Create();

            Console.ReadLine();
        }
    }
}
