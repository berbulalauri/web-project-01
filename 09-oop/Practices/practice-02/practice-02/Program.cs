using System;
public class Person
{
    public string Name { get; set; }
    public string PassportId { get; set; }
    public int CourseNumber { get; set; }
    public string StudentAddress { get; set; }

    public Person(string a, string b)
    {
        this.Name = a;
        this.PassportId = b;
        Console.WriteLine($"Name: {Name}, PassportId: {PassportId}");
    }
    public Person(string a){ }
    public virtual void GetInfo() { }
}
class Student : Person
{
    public Student(string a, string b, int c) : base(a, b)
    {
        Name = a;
        PassportId = b;
        CourseNumber = c;
    }
    public override void GetInfo()
    {
        Console.WriteLine($"Name: {Name}, PassportId: {PassportId}, CourseNumber:{CourseNumber}");
    }
}
class StudentInfo : Person
{
    public StudentInfo(string a) : base(a)
    {
        this.StudentAddress = a;
    }
    public override void GetInfo()
    {
        Console.WriteLine($"Student Address: {StudentAddress}");
    }
}

public class main_method
{
    public static void Main()
    {
        Student student = new Student("Bob", "UI096701", 3);
        student.GetInfo();
        StudentInfo info = new StudentInfo("4, Ramdas Rd, Gujarat");
        info.GetInfo();
    }
}
