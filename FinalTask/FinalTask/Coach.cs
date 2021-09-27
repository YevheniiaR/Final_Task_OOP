using System;
using System.Collections.Generic;
using System.Text;

namespace FinalTask
{
    class Coach
    {
        public string Name { get; set; }
        public double Level { get; set; }

        public Coach(string name)
        {
            Random rend = new Random();
            Name = name;
            Level = Math.Round(rend.NextDouble() + 0.5, 1);
        }
    }
}
