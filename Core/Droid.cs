using System;

namespace DroidBattle.Core
{
    public abstract class Droid
    {
        public string Name { get; protected set; }
        public int Health { get; protected set; }
        public int Damage { get; protected set; }
        public int Energy { get; private set; } = 0;
        public int Mana { get; private set; } = 0;
        private static Random random = new Random();

        public Droid(string name, int health, int damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }

        public void TakeDamage(int amount)
        {
            Health -= amount;
            if (Health < 0) Health = 0;
        }

        public bool IsAlive() => Health > 0;

        public void GainEnergy() => Energy++;

        public void GainMana() => Mana += 10;

        public void Attack(Droid target)
        {
            int chance = random.Next(1, 101); 

            if (chance <= 15)
            {
                Console.WriteLine($"{Name} промахнувся!");
                return;
            }
            else if (chance >= 90)
            {
                int critDamage = Damage * 2;
                target.TakeDamage(critDamage);
                Console.WriteLine($"{Name} завдає КРИТИЧНИЙ удар! {target.Name} отримує {critDamage} урону, залишилось {target.Health} HP.");
            }
            else
            {
                target.TakeDamage(Damage);
                Console.WriteLine($"{Name} атакує {target.Name}! {target.Name} отримує {Damage} урону, залишилось {target.Health} HP.");
            }
        }

        public void UseSuperAttack(Droid target)
        {
            if (Energy >= 5)
            {
                Console.WriteLine($"{Name} використовує СУПЕРУДАР!");
                target.TakeDamage(9999);
                Console.WriteLine($"{target.Name} знищено суперударом!");
                Energy = 0;
            }
            else
            {
                Console.WriteLine("Недостатньо енергії для суперудару!");
            }
        }

        public void Upgrade()
        {
            if (Mana >= 10)
            {
                Console.WriteLine($"{Name} використовує ману для покращення!");
                Damage += 5;
                Health += 10;
                Mana -= 10;
            }
            else
            {
                Console.WriteLine("Недостатньо мани для прокачки!");
            }
        }
    }
}
