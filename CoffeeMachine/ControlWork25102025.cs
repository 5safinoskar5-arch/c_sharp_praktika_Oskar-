namespace c_sharp_praktika_Oskar;
using System;
using System.Globalization;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class ControlWork1
{
    public static int Pervoe(int[] mas)
    {
        if (mas == null) { throw new ArgumentNullException(nameof(mas), "ƒанные не могут быть null."); }
        if (mas.Length == 0) { throw new ArgumentException("массив не должен быть пустым", nameof(mas)); }
        int min = mas[0];
        for (int i = 0; i < mas.Length; i++) { if (mas[i] < min) { min = mas[i]; } }
        return min;
    }
    public static int Vtoroe(string stroka)
    {
        if (stroka == null) { throw new ArgumentNullException(nameof(stroka), "ƒанные не могут быть null."); }
        if (stroka.Length == 0) { throw new ArgumentException("массив не должен быть пустым", nameof(stroka)); }
        int k = 0;
        for (int i = 0; i < stroka.Length; i++)
        {
            if (Char.IsLower(stroka[i])) { k += 1; }
        }
        return k;
    }
    public static char Tretie(string stroka)
    {
        if (stroka == null) { throw new ArgumentNullException(nameof(stroka), "ƒанные не могут быть null."); }
        if (stroka.Length == 0) { throw new ArgumentException("массив не должен быть пустым", nameof(stroka)); }
        return stroka[stroka.Length - 3]; }
    public static bool IsPalindrome(int x)
    {
        if (x == null) { throw new ArgumentNullException(nameof(x), "ƒанные не могут быть null."); }
        string sx = x.ToString();
        int len = sx.Length;
        for (int i = 0; i <= len / 2; i++)
        {
            if (sx[i] != sx[len - 1 - i]) { return false; }
        }
        return true;
    }
    public static int[] RunningSum(int[] mas)
    {
        if (mas == null) { throw new ArgumentNullException(nameof(mas), "ƒанные не могут быть null."); }
        if (mas.Length == 0) { throw new ArgumentException("массив не должен быть пустым", nameof(mas)); }
        int[] sum = new int[mas.Length];
        sum[0] = mas[0];
        for (int i = 1; i < mas.Length; i++) { sum[i] = sum[i - 1] + mas[i - 1]; }
        return sum;
    }
    public static bool TryParse(string stroka, out int num)
    {
        int i1 = 0;
        num = -1;
        if (stroka.Length == 0 || stroka == null) { throw new ArgumentNullException(nameof(stroka), "ƒанные не могут быть null."); }
        if (stroka[0] == '-') { i1++; }
        for (int i=i1; i < stroka.Length; i++)
        {
            char ch = stroka[i];
            if (!(char.IsDigit(ch))) { return false; }
        }
        num = int.Parse(stroka);
        return true;
    }
}
/*int[] nums = [3, 15, 1, 14];
        Console.WriteLine($"1) {Pervoe(nums)}");
        Console.WriteLine($"2) {Vtoroe("BananaRama")}");
        Console.WriteLine($"3) {Tretie("ABCDEFG")}");
        Console.WriteLine($"4) {Chetvyortoe(45)} {Chetvyortoe(5)} {Chetvyortoe(131)} {Chetvyortoe(5555)} {Chetvyortoe(55545)}");
        int[] pyatoemas = [0, 3, 14, 8, 2, 94];
        for (int i = 0; i < pyatoemas.Length; i++) { Console.WriteLine($"5.{i}) {Pyatoe(pyatoemas)[i]}"); }
        int num4267 = 1;
        int num426 = 2;
        Console.WriteLine($"6) {Shestoe("4267", out num4267)} {Shestoe("42shestsem", out num426)}");
        Console.WriteLine($"{num4267}, {num426}");*/