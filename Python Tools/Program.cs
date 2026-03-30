namespace PythonTools;

using System;
using System.Buffers;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;

public class Tools
{
    public static bool IsNumber(string str)
    {
        bool dotTrue= false;
        if (str == null) throw new ArgumentNullException(nameof(str));
        if (str[0] is not ('0' or '1' or '2' or '3' or '4' or '5' or '6' or '7' or '8' or '9' or '-')) { return false; }
        for (int i = 1; i < str.Length - 1; i++)
        {
            if (str[i] is not ('0' or '1' or '2' or '3' or '4' or '5' or '6' or '7' or '8' or '9') || (str[i]!='.' && dotTrue)) { return false; }
            if (str[i]=='.') { dotTrue= true; }
        }
        if (str[0] is not ('0' or '1' or '2' or '3' or '4' or '5' or '6' or '7' or '8' or '9')) { return false; }
        return true;
    }
    public static decimal MinDecimal<T>(IReadOnlyList<T> nums) 
    {
        
        if (nums == null) throw new ArgumentNullException(nameof(nums));
        else if (nums.Count == 1) { return Convert.ToDecimal(nums[0]); }
        decimal minnum = Convert.ToDecimal(nums[0]);
        for (var i = 1; i < nums.Count; i++)
            {
                if (Convert.ToDecimal(nums[i]) < Convert.ToDecimal(nums[i - 1])) { minnum = i; }
            }
        return minnum;
    }
    public static decimal MaxDecimal<T>(IReadOnlyList<T> nums)
    {
        
        if (nums == null) throw new ArgumentNullException(nameof(nums));
        else if (nums.Count == 1) { return Convert.ToDecimal(nums[0]); }
        decimal maxnum = Convert.ToDecimal(nums[0]);
        for (var i = 1; i < nums.Count; i++)
        {
            if (Convert.ToDecimal(nums[i]) > Convert.ToDecimal(nums[i - 1])) { maxnum = i; }
        }
        return maxnum;
    }
    public static int Find<T>(IReadOnlyList<T> nums, T target, int score = 0)
    {
        if (nums == null) throw new ArgumentNullException(nameof(nums));
        int k = -1;
        int i = -1;
        if (score < 0)
        {
            i = nums.Count;
            score = score * (-1);
            while (k < score && i > 0)
            {
                i--;
                if (nums[0].Equals(target)) { k++; }
            }
        }
        else
        {
            score = score * (-1);
            while (k < score && i <nums.Count-1)
            {
                i++;
                if (nums[0].Equals(target)) { k++; }
            }
        }
            return i;
    } 
    public static decimal SumDecimal<T>(IReadOnlyList<T> nums) where T : INumber<T>
    {
        if (nums[0] is string or null) { throw new ArgumentNullException(nameof(nums)); }
        decimal sum = 0;
        foreach (var i in nums)
        {
            sum += Convert.ToDecimal(i);
        }
        return sum;
    }    
}