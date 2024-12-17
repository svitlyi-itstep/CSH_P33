using System.ComponentModel;

namespace Game
{
    enum CharacterRace
    {
        Human,
        Ork,
        Elf
    }

    class Character
    {
        public string? name;
        int health;
        int damage;
        int defence;
        CharacterRace race;

        public CharacterRace Race
        {
            get { return race; }
            set { race = value; }
        }

        public int Health
        {
            get { return this.health; }
            set { this.health = Math.Max(value, 0); }
        }

        public Character(string name, int health, int damage, int defence, CharacterRace race)
        {
            this.name = name;
            this.health = health;
            this.damage = damage;
            this.defence = defence;
            this.race = race;
        }

        public Character() : this("Jonny", 100, 5, 0, CharacterRace.Human) { }

        public void Print()
        {
            Console.WriteLine($" -< {this.name} >-");
            Console.WriteLine($" Здоров\'я: {this.health}");
            Console.WriteLine($" Шкода: {this.damage}");
            Console.WriteLine($" Захист: {this.defence}");
            Console.WriteLine($" Раса: {this.race}");
        }

        public int TakeDamage(int damage)
        {
            this.health = Math.Max(this.health - damage, 0);
            return damage;
        }

        public int Attack(Character target)
        {
            Random rnd = new Random(Convert.ToInt32(DateTimeOffset.Now.ToUnixTimeSeconds()));
            int final_damage = Math.Max(this.damage + rnd.Next(-3, 3), 0);
            return target.TakeDamage(final_damage);
        }

        public bool IsAlive()
        {
            return this.health > 0;
        }
    }

    class Berserk : Character
    {
        public Berserk(string name, int health, int damage, int defence, CharacterRace race)
            : base(name, health, damage, defence, race) { }
        public Berserk() : this("Jonny", 100, 5, 0, CharacterRace.Human) { }
    }
}
