namespace CSH_P33.SnakeGame
{
    enum Direction { UP, DOWN, LEFT, RIGHT }
    class Snake
    {
        //* Властивості класу:
        //* - Список сегментів змії;
        //* - Напрям руху змії(enum з списком напрямів);
        public Direction direction = Direction.RIGHT;
         //* - Символ голови змії;
         //* - Символ тіла змії.

         //* Методи:
         //* - Отримати голову змії;
         //* - Отримати хвіст змії;
         //* - Перевірка зіткнення з тілом змії;
         //* - Видалити хвіст;
         //* - Оновлення стану змії(Update).
    }

    class Game
    {

        //* Властивості класу:
        //* - Розмір поля;
        //* - Список точок, в яких знаходиться їжа;
        //* - Об'єкт змії;
        Snake snake = new Snake();
        //* - Прапорець GameOver.
        public bool IsGameOver = false;

        //* Методи:
        //* - Оновлення стану гри (Update);
        public void Update() { }
        //* — Малювання гри(Draw);
        public void Draw()
        {
            Console.SetCursorPosition(0, 0);
            this.DrawSnakeDirection();
        }
        public void DrawSnakeDirection() 
        {
            if (snake.direction == Direction.UP) Console.Write("⬆️");
            else if (snake.direction == Direction.DOWN) Console.Write("⬇️");
            else if (snake.direction == Direction.LEFT) Console.Write("⬅️");
            else if (snake.direction == Direction.RIGHT) Console.Write("➡️");
        }
        //* - Зміна напряму руху змії.
        public void ChangeSnakeDirection(Direction direction) { snake.direction = direction; }
    }
}
