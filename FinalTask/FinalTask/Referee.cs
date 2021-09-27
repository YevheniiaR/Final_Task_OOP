using System;
using System.Collections.Generic;
using System.Text;

namespace FinalTask
{
    class Referee
    {
        public string Name { get; set; }
        public int Preference { get; set; }

        public Referee(string name)
        {
            Random rend = new Random();
            Name = name;
            Preference = rend.Next(0,3);
        }

        public void GolEvent(string team_name)
        {
            Console.WriteLine($"Команда {team_name} забивает ГОООЛ!!!");
        }
        public void FoulEvent(string team_name)
        {
            Console.WriteLine($"Команда {team_name} считает, что судья {Name} предвзят и начинает нарушать правила.");
        }
    }
}
