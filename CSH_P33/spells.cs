using System.ComponentModel;
using Game;

namespace Game.Spells
{
    abstract class Spell
    {
        protected string? name;
        public string? Name { get { return this.name; } }

        protected Spell(string? name) { this.name = name; }

        public abstract void Cast(Character caster, Character target);
    }

    class Fireball : Spell
    {
        int damage = 13;

        public Fireball() : base("Вогняна куля") { }
        public override void Cast(Character caster, Character target)
        {
            target.TakeDamage(this.damage);
        }

    }

    class VampiricStrike : Spell
    {
        double healRate = 0.5;
        public VampiricStrike() : base("Удар вампіра") { }
        public override void Cast(Character caster, Character target)
        {
            int damageDone = target.TakeDamage(caster.Damage);
            caster.Health += Convert.ToInt32(damageDone * this.healRate);
        }

    }

}

/*
    Зробити 3 класи, які реалізують різні заклинання.

    У клас Character додати масив заклинань, які може використовувати персонаж.

    Реалізувати метод CastRandomSpell(), який застосує випадкове заклинання на персонажа,
    який передано у функцію.

    Реалізувати метод Cast(), який приймає в якості параметрів заклинання і ціль для
    його застосування та застосовує його тільки в тому разі, якщо це заклинання є
    в масиві заклинань персонажа.

    В основному коді зробити так, щоб персонаж випадково обирав як атакувати ворога: звичайною
    атакою або заклинанням. Виводити повідомлення про застосоване заклинання.
 */