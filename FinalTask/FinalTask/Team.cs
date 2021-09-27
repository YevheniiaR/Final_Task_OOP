using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FinalTask
{
    class Team
    {
        public string Team_name { get; set; }
        public List<Footballer> list;
        public int Team_level { get; set; }
        public Coach Team_coach { get; set; }

        public Team(string team_name, List<Footballer> list, Coach team_coach)
        {
            Team_name = team_name;
            this.list = list;
            Team_coach = team_coach;
            int tmp = 0;
            foreach (var el in list)
            {
                tmp += el.Level;
            }
            Team_level = Convert.ToInt32(tmp*team_coach.Level);
        }

        public Team(string team_name, Coach team_coach)
        {
            Team_name = team_name;
            Team_coach = team_coach;
            list = new List<Footballer>();
        }

        public void AddFotballer(Footballer footballer)
        {
            list.Add(footballer);
            Team_level += Convert.ToInt32(footballer.Level * Team_coach.Level);
        }

        public void ListAll()
        {
            Console.WriteLine($"Список игроков команды {Team_name}:");
            foreach (var person in list.OrderBy(x => x.Name))
            {
                Console.WriteLine($"Имя: {person.Name}, возраст: {person.Age}, уровень: {person.Level}");
            }
        }
        public void ListOverThirty()
        {
            Console.WriteLine($"ТОП игроков старше 30 из команды {Team_name}:");
            foreach (var person in list.Where(x=> x.Age > 30).OrderByDescending(x=> x.Level))
            {
                Console.WriteLine($"Имя: {person.Name}, возраст: {person.Age}, уровень: {person.Level}");
            }
        }

    }
}

