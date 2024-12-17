using System.Text;
using Game;

Console.OutputEncoding = UTF8Encoding.UTF8;
Console.InputEncoding = UTF8Encoding.UTF8;

Random rnd = new Random();

Berserk player1 = new Berserk();
player1.Print();
Console.WriteLine();


Character player2 = new Character("James", 90, 8, 0, CharacterRace.Ork);
player2.Print();

while (player1.IsAlive() && player2.IsAlive())
{
    Console.WriteLine();
    int player1_damage = player1.Attack(player2);
    Console.WriteLine($"{player1.name} атакував {player2.name} і наніс {player1_damage} шкоди.");
    Console.WriteLine($"У {player2.name} залишилось {player2.Health} здоров\'я.");
    int player2_damage = player2.Attack(player1);
    Console.WriteLine($"{player2.name} атакував {player1.name} і наніс {player2_damage} шкоди.");
    Console.WriteLine($"У {player1.name} залишилось {player1.Health} здоров\'я.");
}


Console.WriteLine("\n");
player1.Print();
player2.Print();


