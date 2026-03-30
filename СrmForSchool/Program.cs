namespace CrmForSchool;
using System;
using System.Globalization;
using System.Xml.Linq;
public class Tools
{
    private static string adminpassword="1234";
    public static bool CheckPassword(string trypassword)
    {
        if (trypassword==adminpassword) { return true; }
        return false;
    }
    public static void EditAdminPassword(string password)
    {
        Console.Write("Enter password: ");
        string trypassword = Console.ReadLine();
        if (trypassword == password)
        {
            Console.Write("Enter new password: ");
            adminpassword = Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Password is wrong.");
        }
    }
    public static bool TryParse(string stroka, out int num)
    {
        int i1 = 0;
        num = 0;
        if (stroka.Length == 0 || stroka == null) { throw new ArgumentNullException(nameof(stroka), "Данные не могут быть null."); }
        if (stroka[0] == '-') { i1++; }
        for (int i = i1; i < stroka.Length; i++)
        {
            char ch = stroka[i];
            if (!(char.IsDigit(ch))) { return false; }
        }
        num = int.Parse(stroka);
        return true;
    }
    public static void ViewEmployee(Employee worker)
    {
        if (worker is Manager) { Console.WriteLine($"ID: {worker.GetId()} | Position: Manager | Fullname: {worker.GetFullName()} | Salary: {worker.GetSalary().ToCurrencyFormat()} "); }
        else if (worker is Developer) { Console.WriteLine($"ID: {worker.GetId()} | Position: Developer | Fullname: {worker.GetFullName()} | Salary: {worker.GetSalary().ToCurrencyFormat()}"); }
        else if (worker is Intern) { Console.WriteLine($"ID: {worker.GetId()} | Position: Intern | Fullname: {worker.GetFullName()} | Salary: {worker.GetSalary().ToCurrencyFormat()}"); }
        else { Console.WriteLine($"ID: {worker.GetId()} | Position: Employee | Fullname: {worker.GetFullName()} | Salary: {worker.GetSalary().ToCurrencyFormat()}"); }

    }
}
public static class DecimalExtensions
{
    public static string ToCurrencyFormat(this decimal salary)
    {
        string moneyformat = $"{Math.Truncate(salary)},{Math.Round(salary, 2, MidpointRounding.ToZero) %1} ₽";
        return moneyformat;
    }
}
class IdGenerator
{
    private static int id = 1000;
    public static int GenerateNewId()
    {
        int buffer = id;
        id++;
        return buffer;
    }
}
public class Employee
{
    public decimal salary { get; set; }
    public int id { get; private set; }
    public string fullname { get; protected set; }
    public Employee(string fullname, decimal salary)
    {
        if (salary <= 0) { throw new ArgumentOutOfRangeException("salary"); }
        this.salary = salary;
        this.id = IdGenerator.GenerateNewId();
        this.fullname = fullname;
    }
    public decimal GetSalary() { return salary; }
    public int GetId() { return id; }
    public string GetFullName() { return fullname; }
    public void EditFullName(string password, string newfullname) 
    {
        if (Tools.CheckPassword(password))
            {
            if (!string.IsNullOrEmpty(newfullname))
            {
                fullname = newfullname;
            }
            else { Console.WriteLine("Full name can't be empty."); }
        }
        else { Console.WriteLine("Password is wrong."); }
    }
    public virtual decimal CalculateBonus() { return salary + salary * 0.0m; }
}
public class Manager : Employee
{
    public int ManagedTeamSize { get; set; }
    public Manager(string fullname, decimal salary, int ManagedTeamSize) : base(fullname, salary) { this.ManagedTeamSize = ManagedTeamSize; }
    public virtual decimal CalculateBonus() { return salary + salary * 0.15m; }
}
public class Developer : Employee
{
    public int ProjectComplexityScore { get; set; }
    public Developer(string fullname, decimal salary, int ProjectComplexityScore) : base(fullname, salary) { this.ProjectComplexityScore = ProjectComplexityScore; }
    public virtual decimal CalculateBonus() { return (salary + salary * 0.05m) + (salary * 0.01m * ProjectComplexityScore); }
}
public class Intern : Employee
{
    public string schoolname { get; set; }
    public Intern(string fullname, decimal salary, string schoolname) : base(fullname, salary) { this.schoolname = schoolname; }
}
class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        string input = "why are you here?";
        List<Employee> database = new List<Employee>();
        database.Add(new Manager("Ivan I", 50000, 100));
        database.Add(new Manager("Ivan I", 40000, 100));
        database.Add(new Manager("Ivan I", 30000, 100));
        database.Add(new Developer("Olga E", 20000, 100));
        Console.WriteLine("Enter the command. Enter 'help' to view all comands. Enter 'exit' to quit.");
        while (input != "exit" && input != "Exit") {
            Console.Write("Enter the command: ");
            input = Console.ReadLine();
            switch (input) {
                case "exit": break;
                case "help":
                    Console.WriteLine("vieaw all - view all employees");
                    Console.WriteLine("view - view employee");
                    Console.WriteLine("add - add new employee");
                    Console.WriteLine("edit - edit employee's data");
                    Console.WriteLine("exit - finish the program");
                    break;
                case "view all": 
                    for(int i=0; i<database.Count; i++) { Tools.ViewEmployee(database[i]); }
                    break;
                case "view":
                    Console.Write("Enter name od ID:");
                    string nameorid=Console.ReadLine();
                    if (Tools.TryParse(nameorid, out int id)) {
                        var searchresult = database.FirstOrDefault(e => e.id == id);
                        Tools.ViewEmployee(searchresult);
                    }
                    else {
                        var searchresult = database.Where(e => e.fullname == nameorid).ToList();
                        foreach (var i in searchresult)
                        {
                            Tools.ViewEmployee(i);
                        }
                    }
                    break;
                case "edit":
                    Console.Write("Enter password: ");
                    string trypassword = Console.ReadLine();
                    if (Tools.CheckPassword(trypassword))
                    {
                        Console.Write("Enter name or ID: ");
                        nameorid = Console.ReadLine();
                        if (Tools.TryParse(nameorid, out id))
                        {
                            var searchresult = database.FirstOrDefault(e => e.id == id);
                            Tools.ViewEmployee(searchresult);
                            Console.Write("Enter what you need edit: ");
                            input = Console.ReadLine();
                            if (input == "fullname" || input == "name")
                            { 
                                Console.Write("Enter what you need edit: "); 
                                input=Console.ReadLine();
                                searchresult.fullname=input;
                            }
                        }
                        else
                        {
                            var searchresult = database.Where(e => e.fullname == nameorid).ToList();
                            foreach (var i in searchresult)
                            {
                                Tools.ViewEmployee(i);
                            }
                        }
                    }
                    break;
                default: Console.WriteLine($"The '{input}' command does not exist in this program.");
                    break;
            }
        }
        Console.WriteLine("End of Line");
    }
}