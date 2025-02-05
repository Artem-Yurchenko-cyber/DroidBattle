using DroidBattle.Droids;

namespace DroidBattle.Droids
{
    public class AttackDroid : Droid
    {
        public AttackDroid(string name) : base(name, 100, 20) { }

        public AttackDroid(string name, int health, int damage) : base(name, health, damage) { }
    }
}
