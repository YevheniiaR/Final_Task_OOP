using System;
using System.Collections.Generic;
using System.Text;

namespace FinalTask
{
    class Stadium
    {
        public string Stadium_name { get; set; }
        public int Сheap_places { get; set; }
        public int Expensive_places { get; set; }
        public int VIP_places { get; set; }

        public Stadium(string stadium_name, int сheap_places, int expensive_places, int vIP_places)
        {
            Stadium_name = stadium_name;
            Сheap_places = сheap_places;
            Expensive_places = expensive_places;
            VIP_places = vIP_places;
        }

        public int GetTotalPlaces()
        {
            return Expensive_places + VIP_places + Сheap_places;
        }

        public void GetAverageOccupancy(Game game)
        {
            //Определяется заполнение стадиона в зависимости от общего уровня команд. Если команды сильные, то болельщиков много, если слабые - мало.
            Console.WriteLine($"Игра проходит на стадионе {Stadium_name}");
            Random rend = new Random();
            double percent;
            if (game.team1.Team_level + game.team2.Team_level > (game.team1.list.Count + game.team2.list.Count) * 70)
            {
                percent = rend.Next(80, 100) / 100.0;
                Console.WriteLine($"Это очень сильные команды, поэтому стадион заполнен на {percent*100}%. Это {Math.Round(GetTotalPlaces()*percent)} мест из {GetTotalPlaces()}!");
            } 
            else if (game.team1.Team_level + game.team2.Team_level > (game.team1.list.Count + game.team2.list.Count) * 40)
            {
                percent = rend.Next(40, 80) / 100.0;
                Console.WriteLine($"Это хорошие команды, но не самые сильные, поэтому стадион заполнен на {percent * 100}%. Это {Math.Round(GetTotalPlaces() * percent)} мест из {GetTotalPlaces()}!");
            }
            else
            {
                percent = rend.Next(10, 40) / 100.0;
                Console.WriteLine($"Это будет не интересная игра, поэтому стадион заполнен на {percent * 100}%. Это {Math.Round(GetTotalPlaces() * percent)} мест из {GetTotalPlaces()}!");
            }

        }

        



    }
}
