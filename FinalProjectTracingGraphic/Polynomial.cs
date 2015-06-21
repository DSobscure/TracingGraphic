using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectTracingGraphic
{
    public class Polynomial
    {
        public List<Item> Items;

        public Polynomial()
        {
            Items = new List<Item>();
        }
        public double F(double x)
        {
            double result = 0;
            foreach(Item i in Items)
            {
                result += i.Coefficient * Math.Pow(x,i.Degree);
            }
            return result;
        }
        public double dF(double x)
        {
            double result = 0;
            foreach (Item i in Items)
            {
                result += i.Degree*i.Coefficient * Math.Pow(x, i.Degree-1);
            }
            return result;
        }
    }

    public struct Interval
    {
        public double LeftBound;
        public double RightBound;
    }

    public struct Item
    {
        public double Degree;
        public double Coefficient;
    }
}
