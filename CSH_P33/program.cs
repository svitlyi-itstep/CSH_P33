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
    Console.WriteLine($"{player1.Name} атакував {player2.Name} і наніс {player1_damage} шкоди.");
    Console.WriteLine($"У {player2.Name} залишилось {player2.Health} здоров\'я.");
    int player2_damage = player2.Attack(player1);
    Console.WriteLine($"{player2.Name} атакував {player1.Name} і наніс {player2_damage} шкоди.");
    Console.WriteLine($"У {player1.Name} залишилось {player1.Health} здоров\'я.");
    Thread.Sleep(500);
}


Console.WriteLine("\n");
player1.Print();
player2.Print();


/*
    Реалізувати механіку останнього шансу для класу Berserk. Коли Berserk отримує 
    смертельну шкоду, він не помирає, а його здоров`я одноразово встановлюється на 1.
    Наступна смертельна шкода вже не має викликати подібного ефекту.

 */
