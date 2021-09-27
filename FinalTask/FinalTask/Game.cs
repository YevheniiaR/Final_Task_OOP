using System;
using System.Collections.Generic;
using System.Text;

namespace FinalTask
{
    delegate void GoalDelegat();

    class Game
    {
        public Team team1;
        public Team team2;
        public Referee referee;

        public Game(Team team1, Team team2, Referee referee)
        {
            this.team1 = team1;
            this.team2 = team2;
            this.referee = referee;
        }

        public event GoalDelegat GameEvent;
        public void OnGoal()
        {
            Console.WriteLine("ГОООЛ!!!");
        }
        public void OnFoul()
        {
            Console.WriteLine("Нарушение!");
        }
        public void StartGame()
        {
            GameEvent?.Invoke();
            Team little_team = team1.list.Count > team2.list.Count ? team2 : team1;
            try
            {
                if (team1.list.Count != team2.list.Count)
                {
                    throw new FootballGameException($"Ошибка! Разное количество игроков! У {little_team.Team_name} меньше игроков!");
                } 
            }
            catch (FootballGameException)
            {
                Footballer forAdd = new Footballer("Olegov", 31);
                little_team.AddFotballer(forAdd);
                Console.WriteLine($"На поле выходит {forAdd.Name} из команды {little_team.Team_name}");
                
            }
        }



        public void ResultGame()
        {
            StartGame();

            //Выбор команды и ввод ставки
            int team = 0, bid = 0;
            try
            {
                Console.WriteLine($"Введите 1, чтоб сделать ставку на команду {team1.Team_name} или 2 за команду {team2.Team_name}");
                team = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите вашу ставку");
                bid = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Вы выбрали неизвестную команду или неправильную ставку");
            }
            Console.WriteLine();

            Console.WriteLine("Удача первого тренера - " + team1.Team_coach.Level);
            Console.WriteLine($"Сила команды {team1.Team_name} - {team1.Team_level}");
            Console.WriteLine("Удача второго тренера - " + team2.Team_coach.Level);
            Console.WriteLine($"Сила команды {team2.Team_name} - {team2.Team_level}");
            Console.WriteLine("-------------");


            //Учет предпочтения судьи
            if (referee.Preference == 1)
            {
                team1.Team_level += 40;
                Console.WriteLine($"Судья {referee.Name} отдает предпочтение команде {team1.Team_name}.\nТеперь их сила составляет {team1.Team_level}");
                referee.FoulEvent(team2.Team_name);
            }
            else if (referee.Preference == 2)
            {
                team2.Team_level += 40;
                Console.WriteLine($"Судья {referee.Name} отдает предпочтение команде {team2.Team_name}.\nТеперь их сила составляет {team2.Team_level}");
                referee.FoulEvent(team1.Team_name);
            }
            else Console.WriteLine("Судья беспристрастен");


            //Результат игры
            if (Math.Abs(team1.Team_level - team2.Team_level) < (team1.Team_level > team2.Team_level ? team1.Team_level * 0.1 : team2.Team_level * 0.1))
            {
                Console.WriteLine("Ничья");
            }
            else 
            {
                referee.GolEvent(team1.Team_level > team2.Team_level ? team1.Team_name : team2.Team_name);
                Console.WriteLine("Победила команда " + (team1.Team_level > team2.Team_level ? team1.Team_name : team2.Team_name));
            }
            Team_bet(team, bid);
            Console.WriteLine();
        }

        public void Team_bet(int team, int bid)
        {
            switch (team)
            {
                case 1:
                    bid = team1.Team_level > team2.Team_level ? bid * 5 : 0;
                    Console.WriteLine("Ваша ставка принесла вам " + bid);
                    break;
                case 2:
                    bid = team1.Team_level > team2.Team_level ? 0 : bid * 5;
                    Console.WriteLine("Ваша ставка принесла вам " + bid);
                    break;
                default:
                    Console.WriteLine("Похоже, вы не сделали ставку или выбрали не ту команду");
                    break;
            }
        }
    }
}
