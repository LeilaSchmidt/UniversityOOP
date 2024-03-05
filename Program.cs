﻿using System;

// Base class for all individuals
public abstract class Person
{
    public string Name { get; set; }
    public DateTime Birthdate { get; set; }
    public int IdNumber { get; set; }

    public Person(string name, DateTime birthdate, int idNumber)
    {
        Name = name;
        Birthdate = birthdate;
        IdNumber = idNumber;
    }
}

// Base class for all employees
public class Employee : Person
{
    public string Supervisor { get; set; }
    public double HourlySalary { get; set; }
    public string Title { get; set; }


    public Employee(string name, DateTime birthdate, int idNumber, string supervisor, double hourlySalary, string title)
        : base(name, birthdate, idNumber)
    {
        Supervisor = supervisor;
        HourlySalary = hourlySalary;
        Title = title;
    }


    public double CalculateYearlySalary()
    {
        return HourlySalary * 40 * 52;
    }
}

// Professor class, inheriting from Employee
public class Professor : Employee
{
    public string Subject { get; set; }
    public Professor(string name, DateTime birthdate, int idNumber, string supervisor, double hourlySalary, string title, string subject)
        : base(name, birthdate, idNumber, supervisor, hourlySalary, title)
    {
        Subject = subject;
    }
}

// Student class, inheriting from Person
public class Student : Person
{
    public DateTime EnrollmentDate { get; set; }

    public Student (string name, DateTime birthdate, int idNumber, DateTime enrollmentDate)
        : base(name, birthdate, idNumber)
    {
        EnrollmentDate = enrollmentDate;
    }

    public int CalculateRemainingSemesters()
    {
        //assume a regular study time of 6 semesters 
        DateTime currentDate = DateTime.Today;
        int remainingSemesters = 6 - ((currentDate.Year - EnrollmentDate.Year) * 2);
        if (currentDate.Month < 7)
            remainingSemesters--;

        return remainingSemesters;
    }
}


class Program
{
    static void Main(string[] args)
    {

        Employee employee = new Employee("John Appleseed", new DateTime(1990, 5, 15), 83566, "Manager", 25.5, "Accountant");
        Professor professor = new Professor("Jane Bananaseed", new DateTime(1980, 10, 21), 96882, "Department Head", 50.75, "Professor", "Philosophy");
        Student student1 = new Student("Albert Einstein", new DateTime(2000, 8, 30), 12288, new DateTime(2022, 9, 1));
        Student student2 = new Student("Alan Turing", new DateTime(1998, 6, 25), 12497, new DateTime(2023, 1, 15));


        // Output information
        Console.WriteLine($"Employee {employee.Name} has a yearly salary of {employee.CalculateYearlySalary()}.");
        Console.WriteLine($"Professor {professor.Name} has a yearly salary of {professor.CalculateYearlySalary()}.");
        Console.WriteLine($"Professor {professor.Name} teaches {professor.Subject}.");
        Console.WriteLine($"Student {student1.Name} has {student1.CalculateRemainingSemesters()} remaining semesters.");
        Console.WriteLine($"Student {student2.Name} has {student2.CalculateRemainingSemesters()} remaining semesters.");
    }
}
