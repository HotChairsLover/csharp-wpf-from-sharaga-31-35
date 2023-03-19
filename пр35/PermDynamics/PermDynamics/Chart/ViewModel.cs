using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace PermDynamics
{
    public class ViewModel
    {
        public static ObservableCollection<Stocks> DynamicData { get; set; }
        public static List<double> rubPerStock = new List<double>();
        public ViewModel()
        {
            Random rnd = new Random();
            double random = rnd.Next(1000, 3000);
            DynamicData = new ObservableCollection<Stocks>()
            {
                new Stocks(random, random, DateTime.Now)
            };
            rubPerStock.Add(random);
        }
    }
}
