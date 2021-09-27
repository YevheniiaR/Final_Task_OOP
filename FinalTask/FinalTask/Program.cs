using System;
using System.Collections;
using System.Collections.Generic;

namespace FinalTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Coach coach1 = new Coach("Olhov");
            Team t1 = new Team("Champions", coach1);
            t1.AddFotballer(new Footballer("Ivanov", 24));
            //t1.AddFotballer(new Footballer("Olegov", 31));
            t1.AddFotballer(new Footballer("Pavlov", 29));

            Coach coach2 = new Coach("Zernov");
            List<Footballer> list2 = new List<Footballer>() {
            new Footballer("Petrov", 33),
            new Footballer("Denisov", 31),
            new Footballer("Igorev", 35)
            };
            Team t2 = new Team("The best team", list2, coach2);
            
            Game game = new Game(t1, t2, new Referee("Koshkin"));
            Stadium stadium = new Stadium("Мюнхен", 30000, 15000, 100);
            stadium.GetAverageOccupancy(game);
            game.ResultGame();


        }
    }
}
