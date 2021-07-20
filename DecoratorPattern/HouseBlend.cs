using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    class HouseBlend : Beverage
    {
        public HouseBlend()
        {
            Description = "House Blend Coffee";
        }
        public override double Cost()
        {
            return .89;
        }

        public double RemoveSoyFromCost()
        {
            throw new NotImplementedException();
        }

        public double RemoveSoyFromDescription()
        {
            throw new NotImplementedException();
        }
    }
}
