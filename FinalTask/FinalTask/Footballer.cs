using System;
using System.Collections.Generic;
using System.Text;

namespace FinalTask
{
    class Footballer
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Level { get; set; }

        public Footballer(string name, int age)
        {
            Random rend = new Random();
            Name = name;
            Age = age;
            Level = rend.Next(0, 101);
        }
    }
}
