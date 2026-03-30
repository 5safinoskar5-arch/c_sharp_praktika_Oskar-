namespace CoffeMachine; //c in variables - coffee
using System;
using System.Buffers;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using c_sharp_praktika_Oskar;

public class Coffee
{
    public string CoffeeType {  get; set; }
    public int CoffeeAvailability { get; set; }
    public decimal CoffeePrice { get; set; }
    public bool NeedForMilk { get; set; }
    public Coffee(string CoffeeType, int CoffeeAvailability, decimal CoffeePrice, bool NeedForMilk)
    {
        if (CoffeePrice < 0) { Console.WriteLine("Price can't be negative"); }
        else
        {
            this.CoffeePrice = CoffeePrice;
        }
        this.CoffeeType = CoffeeType;
        this.CoffeeAvailability = CoffeeAvailability;
        this.NeedForMilk = NeedForMilk;
    }
}
public class Milk
{
    public string MilkType { get; set; }
    public int MilkAvailability { get; set; }
    public decimal MilkPrice { get; set; }
    public Milk(string MilkType, int MilkAvailability, decimal MilkPrice)
    {
        if (MilkPrice < 0) { Console.WriteLine("Price can't be negative"); }
        else
        {
            this.MilkPrice = MilkPrice;
        }
        this.MilkType = MilkType;
        this.MilkAvailability = MilkAvailability;
    }
}
public class Supplement
{
    public string SupplementType { get; set; }
    public int SupplementAvailability { get; set; }
    public decimal SupplementPrice { get; set; }
    public Supplement(string SupplementType, int SupplementAvailability, decimal SupplementPrice)
    {
        if (SupplementPrice < 0) { Console.WriteLine("Price can't be negative"); }
        else
        {
            this.SupplementPrice = SupplementPrice;
        }
        this.SupplementType = SupplementType;
        this.SupplementAvailability = SupplementAvailability;
    }
}
class Program
{
    static List<Coffee> CoffeeArray = new List<Coffee>();
    static List<Milk> MilkArray = new List<Milk>();
    static List<Supplement> SupplementArray = new List<Supplement>();
    static void Main(string[] args)
    {
        CoffeeArray.Add(new Coffee("americano", 35, 5m, false));
        CoffeeArray.Add(new Coffee("latte", 30, 15m, true));
        CoffeeArray.Add(new Coffee("cappuccino", 25, 13m, true));
        MilkArray.Add(new Milk("water", 9999, 0m));
        MilkArray.Add(new Milk("standart", 40, 0m));
        MilkArray.Add(new Milk("coconut", 40, 3m));
        MilkArray.Add(new Milk("oat", 40, 3m));
        SupplementArray.Add(new Supplement("caramel syrup", 50, 1m));
        SupplementArray.Add(new Supplement("vanilla syrup", 50, 1m));
        SupplementArray.Add(new Supplement("sugar", 50, 1m));
        SupplementArray.Add(new Supplement("nothing", 9999, 0m));
        string inputClass = " ";
        string inputType = " ";
        string inputAv = " ";
        decimal balance = 0;
        decimal price = 0;
        decimal replenish = 0;
        int intMilkType = 0;
        string input = " ";
        var ArrayBuffer = CoffeeArray;
        while (true)
        {

            Console.WriteLine("Enter any key to continue.");
            input = Console.ReadLine();
            if (input == "Admin")
            {
                while (true)
                {
                    Console.WriteLine("Admin panel");
                    Console.WriteLine("1 change availability | 2 add new | 3 change characteristic | 4 delete");
                    Console.Write("Choose what you want to do: ");
                    input = Console.ReadLine();
                    if (input == "restart") { continue; }
                    else if (input == "exit") { break; }
                    Console.Write("1 coffee | 2 milk | 3 supplement");
                    if (input == "1")
                    {
                        Console.Write("Choose what product's avaibility you want to change: ");
                        inputClass = Console.ReadLine();
                        for (int i = 0; i < CoffeeArray.Count; i++) { Console.Write($" {i} {CoffeeArray[i].CoffeeType} |"); }
                        Console.Write("Choose coffee's type what you want: ");
                        inputType = Console.ReadLine();
                        Console.Write("enter +av: ");
                        inputAv = Console.ReadLine();
                        switch (inputClass) { }

                    }
                    else if (input == "2")
                    {
                        Console.Write("Choose what product you want to add: ");
                        inputClass = Console.ReadLine();

                    }
                    else if (input == "3") { Console.Write("Choose what product's characteristic you want to change: ");
                        inputClass = Console.ReadLine();
                    }
                    else if (input == "4") { Console.Write("Choose what product you want to delete: ");
                        inputClass = Console.ReadLine();
                    }
                    else { Console.WriteLine("404"); }
                    }
                } ////
                    Console.WriteLine("Hello. Please enter numbers, 'restart' or 'exit' without other symbols.");
                    for (int i = 0; i < CoffeeArray.Count; i++) { Console.Write($" {i} {CoffeeArray[i].CoffeeType} |"); }
                    //Console.WriteLine("1 americano | 2 latte | 3 cappuccino");
                    Console.Write(" Choose coffee type: ");
                    string coffeeType = Console.ReadLine();
                    if (coffeeType == "restart") { continue; }
                    else if (coffeeType == "exit") { break; }
                    ControlWork1.TryParse(coffeeType, out int intCoffeeType);
                    if (CoffeeArray[intCoffeeType].NeedForMilk)
                    {
                        for (int i = 1; i < MilkArray.Count; i++) { Console.Write($" {i} {MilkArray[i].MilkType} |"); }
                        //Console.WriteLine("1 standart | 2 coconut | 3 oat");
                        Console.Write(" Choose coffee milk: ");
                        string typeMilk = Console.ReadLine();
                        if (typeMilk == "restart") { continue; }
                        else if (typeMilk == "exit") { break; }
                        ControlWork1.TryParse(typeMilk, out intMilkType);
                    }
                    for (int i = 0; i < SupplementArray.Count; i++) { Console.Write($" {i} {SupplementArray[i].SupplementType} |"); }
                    //Console.WriteLine("1 caramel syrup | 2 vanilla syrup | 3 sugar | 4 nothing");
                    Console.Write(" Сhoose supplements: ");
                    string supplementType = Console.ReadLine();
                    if (supplementType == "restart") { continue; }
                    else if (supplementType == "exit") { break; }
                    ControlWork1.TryParse(supplementType, out int intSupplementType);
                    Console.WriteLine($"Your order is {CoffeeArray[intCoffeeType].CoffeeType} on {MilkArray[intMilkType].MilkType} with {SupplementArray[intSupplementType].SupplementType}");
                    price = CoffeeArray[intCoffeeType].CoffeePrice + MilkArray[intMilkType].MilkPrice + SupplementArray[intSupplementType].SupplementPrice;
                    Console.WriteLine($"Cost is {price}. Your balance is {balance}");
                    while (balance < price)
                    {
                        Console.WriteLine("Your balance is less than the order cost. Please replenish the balance at least to the order cost.");
                        Console.Write("Replenish balance: ");
                        input = Console.ReadLine();
                        if (supplementType == "restart") { continue; }
                        else if (supplementType == "exit") { break; }
                        replenish = decimal.Parse(input);
                        balance = balance + replenish;
                    }
                    Console.WriteLine("Cooking... *sigma face*");
                    CoffeeArray[intCoffeeType].CoffeeAvailability--;
                    MilkArray[intMilkType].MilkAvailability--;
                    SupplementArray[intSupplementType].SupplementAvailability--;
                    balance = balance - price;
                    Console.WriteLine($"Your coffee is cooked. {CoffeeArray[intCoffeeType].CoffeeAvailability} {MilkArray[intMilkType].MilkAvailability} {SupplementArray[intSupplementType].SupplementAvailability} {balance}");
                }
            }
        }
