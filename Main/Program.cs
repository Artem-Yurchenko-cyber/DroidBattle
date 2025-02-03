﻿using System;
using System.Text;
using DroidBattle.Modes;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        Console.WriteLine("Виберіть режим:");
        Console.WriteLine("1 - Гравець проти дроїда");
        Console.WriteLine("2 - Гравець проти гравця");
        Console.WriteLine("3 - Дроїд проти дроїда");
        Console.WriteLine("4 - РПГ режим");
        Console.WriteLine("5 - Бій 2 на 2");

        Console.Write("Режим бою: ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                BattleModes.PlayerVsDroid();
                break;
            case "2":
                BattleModes.PlayerVsPlayer();
                break;
            case "3":
                BattleModes.DroidVsDroid();
                break;
            case "4":
                RPGMode.Start();
                break;
            case "5":
                BattleModes.TeamBattle();
                break;
            default:
                Console.WriteLine("Невірний вибір!");
                break;
        }
    }
}
