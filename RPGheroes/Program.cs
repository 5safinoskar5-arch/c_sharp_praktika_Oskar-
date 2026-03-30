using System;
public abstract class Hero
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int Attack { get; set; }
    public abstract void DisplayInfo();
}
public class Warrior : Hero
{
    public string WeaponName { get; set; }
    public override void DisplayInfo()
    {
        Console.WriteLine($"Воин: {Name} | Здоровье: {Health} | Атака: {Attack} | Оружие: {WeaponName}");
    }
}
public class Mage : Hero
{
    public int Mana { get; set; }
    public override void DisplayInfo()
    {
        Console.WriteLine($"Маг: {Name} | Здоровье: {Health} | Атака: {Attack} | Мана: {Mana}");
    }
}
public class Archer : Hero
{
    public int ShotDistance { get; set; }
    public override void DisplayInfo()
    {
        Console.WriteLine($"Лучник: {Name} | Здоровье: {Health} | Атака: {Attack} | Дальность стрельбы: {ShotDistance}");
    }
}
public interface INameStep<T> where T : Hero
{
    IHealthStep<T> SetName(string name);
}
public interface IHealthStep<T> where T : Hero
{
    IAttackStep<T> SetHealth(int health);
}
public interface IAttackStep<T> where T : Hero
{
    IUniqueFieldStep<T> SetAttack(int attack);
}
public interface IUniqueFieldStep<T> where T : Hero
{
    IBuildStep<T> SetUniqueField(object value);
}
public interface IBuildStep<T> where T : Hero
{
    T Build();
}
public class HeroBuilder<T> : INameStep<T>, IHealthStep<T>, IAttackStep<T>, IUniqueFieldStep<T>, IBuildStep<T> where T : Hero, new()
{
    private T _hero = new T();
    private HeroBuilder() { }
    public static INameStep<T> Create()
    {
        return new HeroBuilder<T>();
    }
    public IHealthStep<T> SetName(string name)
    {
        _hero.Name = name;
        return this;
    }
    public IAttackStep<T> SetHealth(int health)
    {
        _hero.Health = health;
        return this;
    }
    public IUniqueFieldStep<T> SetAttack(int attack)
    {
        _hero.Attack = attack;
        return this;
    }
    public IBuildStep<T> SetUniqueField(object value)
    {
        if (_hero is Warrior warrior && value is string weaponName)
        {
            warrior.WeaponName = weaponName;
        }
        else if (_hero is Mage mage && value is int mana)
        {
            mage.Mana = mana;
        }
        else if (_hero is Archer archer && value is int shotDistance)
        {
            archer.ShotDistance = shotDistance;
        }
        else
        {
            throw new ArgumentException("Вот-те нате арбуз покрасьте. Это ещё что за чудо-юдо?");
        }
        return this;
    }
    public T Build()
    {
        return _hero;
    }
}
class Program
{
    static void Main()
    {
        var warrior = HeroBuilder<Warrior>.Create().SetName("Нонак").SetHealth(200).SetAttack(50).SetUniqueField("Экскалибр").Build();
        warrior.DisplayInfo();
        var mage = HeroBuilder<Mage>.Create().SetName("Поттер").SetHealth(50).SetAttack(10).SetUniqueField(100).Build();
        mage.DisplayInfo();
        var archer = HeroBuilder<Archer>.Create().SetName("Хантер").SetHealth(100).SetAttack(100).SetUniqueField(200).Build();
        archer.DisplayInfo();
        //var modul = HeroBuilder<Warrior>.Create().SetHealth(100);
    }
}