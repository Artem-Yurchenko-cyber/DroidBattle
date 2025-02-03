using System;
using DroidBattle.Droids;
using DroidBattle.Core;

namespace DroidBattle.Modes
{
    public static class RPGMode
    {
        public static void Start()
        {
            Console.Write("Введіть ім'я вашого дроїда: ");
            string name = Console.ReadLine();
            Droid player = new AttackDroid(name);

            int round = 1;
            int defeatedEnemies = 0;

            while (player.IsAlive())
            {
                int enemyHealth = 50 + (round - 1) * 5;
                int enemyDamage = 10 + (round - 1) * 2;
                Droid enemy = new AttackDroid("Ворог-" + round, enemyHealth, enemyDamage);

                Console.WriteLine($"\nРаунд {round}: {enemy.Name} (Здоров'я: {enemyHealth}, Урон: {enemyDamage})");

                while (player.IsAlive() && enemy.IsAlive())
                {
                    Console.WriteLine("\nНатисніть Enter для атаки, E для суперудару, M для прокачки:");
                    ConsoleKeyInfo key = Console.ReadKey();

                    if (key.Key == ConsoleKey.Enter)
                    {
                        player.Attack(enemy);
                    }
                    else if (key.Key == ConsoleKey.E)
                    {
                        player.UseSuperAttack(enemy);
                    }
                    else if (key.Key == ConsoleKey.M)
                    {
                        player.Upgrade();
                    }

                    if (enemy.IsAlive())
                    {
                        enemy.Attack(player);
                    }
                }

                if (!player.IsAlive())
                {
                    Console.WriteLine("Вас знищено! Гра закінчена.");
                    break;
                }
                else
                {
                    Console.WriteLine("Ви перемогли ворога!");
                    defeatedEnemies++;
                    player.GainEnergy();
                    player.GainMana();
                    round++;
                }
            }
        }
    }
}
