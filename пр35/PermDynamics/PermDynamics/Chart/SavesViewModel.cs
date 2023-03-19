using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermDynamics.Chart
{
    class SavesViewModel
    {
        public static ObservableCollection<Stocks> OpenData { get; set; }
        public SavesViewModel()
        {
            OpenData = new ObservableCollection<Stocks>();

        }
    }
}
