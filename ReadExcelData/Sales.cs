using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadExcelData
{
    class Sales
    {
        public string Rep { get; }
        public string Item { get; }
        public int Unit { get; }
        public double UnitCost { get; }

        public Sales(string rep, string item, int unit, double unitCost)
        {
            Rep = rep;
            Item = item;

            if (unit < 0)
                throw new ArgumentException("Unit count can't be negative number");
            else
                Unit = unit;

            if (unitCost < 0)
                throw new ArgumentException("Unit cost count can't be negative number");
            else
                UnitCost = unitCost;
        }

        public override string ToString()
        {
            return $"{Rep,8} {Item,8} {Unit,5} {UnitCost,5}";
        }
    }
}
