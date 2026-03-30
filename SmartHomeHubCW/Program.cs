namespace SmartHomeHubCW;

using System;
using System.Buffers;
using System.ComponentModel;
using System.Linq;

public class DeviceBase
{
    public virtual bool IsOn { get; protected set; }
    public string Name { get; set; }
    public string Protocole { get; set; }
    public DeviceBase(string Name, bool IsOn, string Protocole) {
        if (Name == null) { throw new ArgumentNullException(nameof(Name), "Var can not be null."); }
        if (IsOn == null) { throw new ArgumentNullException(nameof(IsOn), "Var can not be null."); }
        if (Protocole == null) { throw new ArgumentNullException(nameof(Protocole), "Var can not be null."); }
        this.Name = Name;
        this.IsOn = IsOn;
        this.Protocole = Protocole;
    }
    public void Toggle() { IsOn = !IsOn; }
    public void PrintDevice()
    {
        Console.WriteLine($"Name: {Name} | Is on: {IsOn} | Protocole: {Protocole}");
    }
}
public class Light : DeviceBase
{
    public int brightness { get; set; }

    public Light(string Name, bool IsOn, string Protocole, int brightness=10) : base(Name, IsOn, Protocole)
    {
        if (brightness == null) { throw new ArgumentNullException(nameof(brightness), "Var can not be null."); }
        this.brightness = brightness;
        if (brightness <= 0) { IsOn = false; }
    }
    public void EditBrightness(int newBrightness) 
    {
        brightness = newBrightness; 
        if  (brightness <= 0) { IsOn=false; }
    }
    public void PrintDevice()
    {
        Console.WriteLine($"Name: {Name} | Is on: {IsOn} | Protocole: {Protocole} | brightness: {brightness}");
    }
}

public class Thermostat : DeviceBase
{
    public double temperature { get; set; }
    public Thermostat(string Name, bool IsOn, string Protocole, int temperature = 22) : base(Name, IsOn, Protocole)
    {
        if (temperature == null) { throw new ArgumentNullException(nameof(temperature), "Var can not be null."); }
        this.temperature = temperature;
    }
    public void EditTemperature(int newTemperature)
    {
        if (temperature == null) { throw new ArgumentNullException(nameof(temperature), "Var can not be null."); }
        temperature = newTemperature;
    }
    public new void Toggle() { temperature = 22; }
    public void PrintDevice()
    {
        Console.WriteLine($"Name: {Name} | Is on: {IsOn} | Protocole: {Protocole} | Temperature: {temperature}");
    }
}
public class DoorLock : DeviceBase
{
    public string pinCode { get; set; }
    public override bool IsOn { get; protected set; }
    public DoorLock(string Name, bool IsOn, string Protocole, string pinCode) : base(Name, IsOn, Protocole)
    {
        if (pinCode == null) { throw new ArgumentNullException(nameof(pinCode), "Var can not be null."); }
        this.pinCode = pinCode;
    }
    public void Toggle(string oldPinCode)
    {
        if (oldPinCode == null) { throw new ArgumentNullException(nameof(oldPinCode), "Var can not be null."); }
        if (oldPinCode == pinCode)
        {
            IsOn = !IsOn;
            switch (IsOn)
            {
                case true:
                    Console.WriteLine("Door lock is locked");
                    break;
                case false:
                    Console.WriteLine("Door lock is unlocked");
                    break;
            }
        }
        else { throw new ArgumentException("Password is nnot right.", nameof(oldPinCode)); }
    }
    public void EditPinCode(string oldPinCode, string newPinCode)
    {
        if (oldPinCode == null) { throw new ArgumentNullException(nameof(oldPinCode), "Var can not be null."); }
        if (newPinCode == null) { throw new ArgumentNullException(nameof(newPinCode), "Var can not be null."); }
        if (oldPinCode == pinCode) 
        { 
            newPinCode = pinCode;
            Console.WriteLine("Password is changed.");
        }
        else { throw new ArgumentException("Password is nnot right.", nameof(oldPinCode)); }
    }
}
class Program
{
    static List<DeviceBase> hub = new List<DeviceBase>();

    static void Main(string[] args)
    {
        hub.Add(new Light("L", true, "Wi-fi", 22));
        hub.Add(new Thermostat("T", true, "Wi-fi", 0));
        hub.Add(new DoorLock("D", true, "ZigBee", "password"));
        for (int i = 0; i < hub.Count; i++)
        {
            var device = hub[i];
            device.PrintDevice();
        }
    }
}