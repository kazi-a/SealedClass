using System;

interface IEmployee
{
    //Properties
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    //Methods
    public string Fullname();
    public double Pay();
}

class Employee : IEmployee
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public Employee()
    {
        Id = 0;
        FirstName = string.Empty;
        LastName = string.Empty;
    }

    public Employee(int id, string firstName, string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }

    public string Fullname()
    {
        return FirstName + " " + LastName;
    }

    public virtual double Pay()
    {
        double salary;
        Console.WriteLine($"What is {this.Fullname()}'s weekly salary?");
        salary = double.Parse(Console.ReadLine());
        return salary;
    }
}

sealed class Executive : Employee
{
    public string Title { get; set; }
    public double Salary { get; set; }

    public Executive() : base()
    {
        Title = string.Empty;
        Salary = 0;
    }

    public Executive(int id, string firstName, string lastName, string title, double salary)
        : base(id, firstName, lastName)
    {
        Title = title;
        Salary = salary;
    }

    public override double Pay()
    {
        return Salary;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create an employee object
        Employee employee = new Employee(101, "John", "Doe");
        Console.WriteLine($"Employee: {employee.Fullname()}");
        double employeeSalary = employee.Pay();
        Console.WriteLine($"Weekly Salary: ${employeeSalary}");

        Console.WriteLine();

        // Create an executive object
        Executive executive = new Executive(201, "Jane", "Smith", "CEO", 15000);
        Console.WriteLine($"Executive: {executive.Fullname()}");
        Console.WriteLine($"Title: {executive.Title}");
        double executiveSalary = executive.Pay();
        Console.WriteLine($"Weekly Salary: ${executiveSalary}");
    }
}
