using System.Collections;

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

    class Group: IEnumerable
    {
        string? name;
        List<Student> students;
        double totalAvgGrade;

        public string? Name { get { return this.name; } set { this.name = value; } }
        public List<Student> Students { get { return this.students; } }
        public double TotalAvgGrade { get { return this.totalAvgGrade; } }

        public Group(string? name, Student[] students) 
        {
            this.name = name;
            this.students = new List<Student>(students);
            this.CountTotalAvgGrade();
        }
        public Group(string? name)
        {
            this.name = name;
            this.students = new List<Student>();
            this.totalAvgGrade = 0;
        }
        public Group() : this("Group") { }

        public double CountTotalAvgGrade()
        {
            List<double> avgGrades = new List<double>();
            foreach(var student in this.students) { avgGrades.Add(student.CountAvgGrade()); }
            if(avgGrades.Count == 0)
            {
                this.totalAvgGrade = 0;
                return 0;
            }
            this.totalAvgGrade = (double)avgGrades.Sum() / avgGrades.Count;
            return this.totalAvgGrade;
        }

        public override string ToString()
        {
            return $"{this.name} ({this.totalAvgGrade}):\n  {String.Join("\n  ", this.students)}";
        }

        public IEnumerator GetEnumerator()
        {
            return this.students.GetEnumerator();
        }

    }

    //internal class Lesson_7
    //{
    //    static public void Main(string[] args)
    //    {
    //        Student student1 = new Student("John", new int[] { 4, 3, 6, 1 });
    //        Student student2 = new Student("Max", new int[] { 8, 9, 7, 5 });
    //        Group gr1 = new Group("GR1", new Student[] { student1, student2 });
    //        // Console.WriteLine(gr1);
    //        foreach(var student in gr1)
    //        {
    //            Console.WriteLine(student);

    //        }
    //    }

    //}
}
