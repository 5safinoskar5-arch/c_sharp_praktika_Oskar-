using System;
using System.Collections.Generic;
public class Product
{
    private static int nextId = 1;

    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Id { get; private set; }

    public Product(string name, decimal price)
    {
        Name = name;
        Price = price;
        Id = nextId++;
    }
}
public class Receipt
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int[] Date { get; set; }
    public Receipt(string name, decimal price, int[] date)
    {
        Name = name;
        Price = price;
        Date = date;
    }
}

public static class X5
{
    public static decimal Money = 1000;
    public static int[] Today = { 21, 2, 2026 };
    public static List<Product> X5DataBase { get; set; } = new List<Product>
    {
        new Product("milk", 5m),
        new Product("bread", 3m)
    };
    public static string Purchase(int Id)
    {
        Product FindedProduct = X5DataBase.Find(x => x.Id == Id);
        if (FindedProduct == null) { return "404"; }
        if (Money>= FindedProduct.Price)
        {
            Money -= FindedProduct.Price;
        }
        else { return "Недостаточно средств"; }
        Receipt ReadyOrder = new Receipt(FindedProduct.Name, FindedProduct.Price, Today);
        return ($"Заказ на {ReadyOrder.Name} от {ReadyOrder.Date[0]}.{ReadyOrder.Date[1]}.{ReadyOrder.Date[2]} успешно оплачен. Спасибо за покупку.");
    }
}
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(X5.Purchase(1));
    }
}