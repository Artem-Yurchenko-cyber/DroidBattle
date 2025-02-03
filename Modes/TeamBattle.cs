using System;
using DroidBattle.Core;
using DroidBattle.Droids;

namespace DroidBattle.Modes
{
    class TeamBattle
    {
        public static void StartTeamBattle()
        {
            Console.WriteLine("Бій 2 на 2!");

            Droid[] team1 = { ChooseDroid("Гравець 1"), ChooseDroid("Гравець 2") };
            Droid[] team2 = { ChooseDroid("Гравець 3"), ChooseDroid("Гравець 4") };

            while (TeamIsAlive(team1) && TeamIsAlive(team2))
            {
                foreach (var droid in team1)
                {
                    if (droid.IsAlive()) droid.Attack(GetRandomAliveDroid(team2));
                }

                foreach (var droid in team2)
                {
                    if (droid.IsAlive()) droid.Attack(GetRandomAliveDroid(team1));
                }
            }

            Console.WriteLine(TeamIsAlive(team1) ? "Перемогла команда 1!" : "Перемогла команда 2!");
        }

        private static Droid ChooseDroid(string playerName)
        {
            Console.Write($"{playerName}, виберіть дроїда (1 - Атакуючий, 2 - Захисний): ");
            string choice = Console.ReadLine();

            if (choice == "1")
                return new AttackDroid(playerName);
            else
                return new DefenseDroid(playerName);
        }


        private static bool TeamIsAlive(Droid[] team)
        {
            foreach (var droid in team)
                if (droid.IsAlive()) return true;
            return false;
        }

        private static Droid GetRandomAliveDroid(Droid[] team)
        {
            Random random = new Random();
            Droid target;
            do
            {
                target = team[random.Next(team.Length)];
            } while (!target.IsAlive());

            return target;
        }
    }
}

