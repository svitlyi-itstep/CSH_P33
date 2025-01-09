namespace CSH_P33
{

    // АГРЕГАЦІЯ ТА КОМПОЗИЦІЯ
    // Студент: ім'я, список оцінок, середній бал
    //      Розрахунок середнього балу
    //      Подача інформації про студента у вигляді рядка
    class Student
    {
        // 1. Перелічення полів та властивостей класу
        string? name;
        List<int> grades;
        double avgGrade;

        public string? Name { get { return this.name; } set { this.name = value; } }
        public List<int> Grades { get { return this.grades; } }
        public double AvgGrade { get { return this.avgGrade; } }

        // 2. Створення конструкторів (з параметрами та за замвочанням)
        public Student(string? name, int[] grades)
        {
            this.name = name;
            this.grades = new List<int>(grades);
            this.CountAvgGrade();
        }

        public Student(string? name)
        {
            this.name = name;
            this.grades = new List<int>();
            this.avgGrade = 0;
        }

        public Student() : this("Student") { }

        // 3. Реалізація методів класу
        public double CountAvgGrade()
        {
            if (this.grades.Count == 0)
            {
                this.avgGrade = 0;
                return 0;
            }
            this.avgGrade = (double)this.grades.Sum() / this.grades.Count;
            return this.avgGrade;
        }

        public override string ToString()
        {
            return $"{this.name} ({this.avgGrade}): {String.Join(", ", this.grades)}";
        }
    }

    internal class Lesson_7
    {
        static public void Main(string[] args)
        {
            Student student = new Student("John", new int[] { 4, 3, 6, 1 });
            student.Grades.Add(5);
            student.CountAvgGrade();
            Console.WriteLine(student);
        }
        
    }
}
