using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermDynamics.Chart
{
    class Saves
    {
        public Saves(string id, string dateTime)
        {
            this.id = id;
            this.dateTime = dateTime;
        }
        public string id { get; set; }
        public string dateTime { get; set; }
    }
}
