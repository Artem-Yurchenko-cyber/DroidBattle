using System;
using DroidBattle.Core;
using DroidBattle.Droids;

namespace DroidBattle.Modes
{
    public static class BattleModes
    {
        public static void StartDuel(Droid droid1, Droid droid2)
        {
            Console.WriteLine($"Бій починається між {droid1.Name} та {droid2.Name}!");

            while (droid1.IsAlive() && droid2.IsAlive())
            {
                droid1.Attack(droid2);
                if (droid2.IsAlive())
                    droid2.Attack(droid1);
            }

            Console.WriteLine(droid1.IsAlive() ? $"{droid1.Name} переміг!" : $"{droid2.Name} переміг!");
        }

        public static void PlayerVsPlayer()
        {
            Droid player1 = ChooseDroid("Гравець 1");
            Droid player2 = ChooseDroid("Гравець 2");

            StartDuel(player1, player2);
        }

        public static void PlayerVsDroid()
        {
            Droid player = ChooseDroid("Гравець");
            Droid bot = new DefenseDroid("Бот");

            StartDuel(player, bot);
        }

        public static void DroidVsDroid()
        {
            Droid droid1 = new AttackDroid("Атакуючий Дроїд");
            Droid droid2 = new DefenseDroid("Захисний Дроїд");

            StartDuel(droid1, droid2);
        }

        public static void TeamBattle()
        {
            Console.WriteLine("Гравець 1 обирає дроїда:");
            Droid player1 = ChooseDroid("Гравець 1");

            Console.WriteLine("Гравець 2 обирає дроїда:");
            Droid player2 = ChooseDroid("Гравець 2");

            Console.WriteLine("Гравець 3 обирає дроїда:");
            Droid player3 = ChooseDroid("Гравець 3");

            Console.WriteLine("Гравець 4 обирає дроїда:");
            Droid player4 = ChooseDroid("Гравець 4");

            Console.WriteLine("Починається командний бій 2 на 2!");

            while ((player1.IsAlive() || player2.IsAlive()) && (player3.IsAlive() || player4.IsAlive()))
            {
                if (player1.IsAlive()) player1.Attack(player3.IsAlive() ? player3 : player4);
                if (player2.IsAlive()) player2.Attack(player4.IsAlive() ? player4 : player3);
                if (player3.IsAlive()) player3.Attack(player1.IsAlive() ? player1 : player2);
                if (player4.IsAlive()) player4.Attack(player2.IsAlive() ? player2 : player1);
            }

            Console.WriteLine((player1.IsAlive() || player2.IsAlive()) ? "Перемогла команда 1!" : "Перемогла команда 2!");
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

    }
}
