using System.Text;
using Game;
using Game.Spells;

Console.OutputEncoding = UTF8Encoding.UTF8;
Console.InputEncoding = UTF8Encoding.UTF8;

Random rnd = new Random();

Character player1 = new Berserk();
player1.Print();
Console.WriteLine();


Character player2 = new Character("James", 90, 8, 0, CharacterRace.Ork);
player2.Print();

Spell fireball = new Fireball();

while (player1.IsAlive() && player2.IsAlive())
{
    Console.WriteLine();
    int player1_damage = player1.Attack(player2);
    Console.WriteLine($"{player1.Name} атакував {player2.Name} і наніс {player1_damage} шкоди.");
    Console.WriteLine($"У {player2.Name} залишилось {player2.Health} здоров\'я.");
    int player2_damage = player2.Attack(player1);
    Console.WriteLine($"{player2.Name} атакував {player1.Name} і наніс {player2_damage} шкоди.");
    Console.WriteLine($"У {player1.Name} залишилось {player1.Health} здоров\'я.");

    player1.CastRandomSpell(player2);
    player2.CastRandomSpell(player1);
    Thread.Sleep(500);
}


Console.WriteLine("\n");
player1.Print();
player2.Print();
