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
        protected string? name;
        protected int health;
        protected int damage;
        protected int defence;
        protected CharacterRace race;

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

        public string? Name { get { return this.name; } set { this.name = value; } }
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

        public virtual int TakeDamage(int damage)
        {
            this.health = Math.Max(this.health - damage, 0);
            return damage;
        }

        public virtual int Attack(Character target)
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
        bool lastChance = true;        
        public Berserk(string name, int health, int damage, int defence, CharacterRace race)
            : base(name, health, damage, defence, race) { }
        public Berserk() : this("Jonny", 100, 5, 0, CharacterRace.Human) { }

        public override int Attack(Character target)
        {
            Random rnd = new Random(Convert.ToInt32(DateTimeOffset.Now.ToUnixTimeSeconds()));
            int final_damage = this.health < 50 ? (int)(this.damage * 1.5) : this.damage;
            final_damage = Math.Max(final_damage + rnd.Next(-3, 3), 0);
            return target.TakeDamage(final_damage);
        }

        public override int TakeDamage(int damage)
        {
            this.health = Math.Max(this.health - damage, 0);
            if(this.health <= 0 && this.lastChance) {
                this.health = 1;
                this.lastChance = false;
            }
            return damage;
        }
    }
}
