using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermDynamics
{
    public class Stocks
    {

        public Stocks(double rublesPerStock, double avgRublesPerStock, DateTime time)
        {
            this.rublesPerStock = rublesPerStock;
            this.time = time;
            this.avgRublesPerStock = avgRublesPerStock;
        }
        public double rublesPerStock { get; set; }
        public double avgRublesPerStock { get; set; }
        public DateTime time { get; set; }
    }
}
