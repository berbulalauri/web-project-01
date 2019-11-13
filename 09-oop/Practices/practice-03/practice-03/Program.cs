using System;
public class Person
{
    public string Name { get; set; }
    public string PassportId { get; set; }
    public int CourseNumber { get; set; }
    public int ExperienceInLessons { get; set; }
    public string StudentAddress { get; set; }
    public virtual void GetInfo(){}
}
class Student : Person
{
    public Student(string a, string b, int c)
    {
        Name = a;
        PassportId = b;
        CourseNumber = c;
    }
    public override void GetInfo()
    {
        Console.WriteLine($"student \nName: {Name}, PassportId: {PassportId}, CourseNumber: {CourseNumber}\n");
    }
    public void BeReadyForLesson()
    {
        Console.WriteLine($"I am ready for the lesson");
    }
}
class Teacher : Person
{
    public Teacher(string a, string b, int c)
    {
        Name = a;
        PassportId = b;
        ExperienceInLessons = c;
    }
    public override void GetInfo()
    {
        Console.WriteLine($"Teacher \nName: {Name}, PassportId: {PassportId}, ExperienceInLessons: {ExperienceInLessons}\n");
    }
    public void GoToClasses()
    {
        Console.WriteLine($"I am going to class");
    }
    public void IncreaseExperience()
    {
        ExperienceInLessons++;
    }
    public void Explain()
    {
        Console.WriteLine($"Explanation begins\n");
    }
}
public class main_method
{
    public static void Main()
    {
        Student student = new Student("Bob", "UI096701", 3);
        student.GetInfo();
        Teacher teacher = new Teacher("Mr Green", "KO723157", 5);
        teacher.GetInfo();

        teacher.GoToClasses();
        student.BeReadyForLesson();
        teacher.Explain();
        teacher.IncreaseExperience();
        teacher.GetInfo();
    }
}
