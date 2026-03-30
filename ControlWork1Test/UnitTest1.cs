using c_sharp_praktika_Oskar;
using NUnit.Framework;
using System;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static c_sharp_praktika_Oskar.ControlWork1;
namespace ControlWork1Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void Test1() {
            int[] mas1 = { 1000, 9999, 1001 };
            int[] mas2 = { -1000, -9999, -1001 };
            int ans1 = 1000, ans2 = -9999;
            Assert.That(ControlWork1.Pervoe(mas1), Is.EqualTo(ans1));
            Assert.That(ControlWork1.Pervoe(mas2), Is.EqualTo(ans2)); }
            [Test]
            public void Test1Null()
            {
                int[] mas3 = null;
                Assert.Throws<ArgumentNullException>(() => ControlWork1.Pervoe(mas3));
            }
            [Test]
            public void Test1Hollow()
            {
                int[] mas4 = { };
                Assert.Throws<ArgumentException>(() => ControlWork1.Pervoe(mas4));
            }
        [Test]
        public void Test2() {
            string str1 = "LLLL", str2 = "asdfk", str3 = "LjjL";
            int ans1 = 0, ans2 = 5, ans3 = 2;
            Assert.That(ControlWork1.Vtoroe(str1), Is.EqualTo(ans1));
            Assert.That(ControlWork1.Vtoroe(str2), Is.EqualTo(ans2));
            Assert.That(ControlWork1.Vtoroe(str3), Is.EqualTo(ans3)); }
            [Test]
            public void Test2Null()
            {
                string str4 = null;
                Assert.Throws<ArgumentNullException>(() => ControlWork1.Vtoroe(str4));
            }
            [Test]
            public void Test2Hollow()
            {
                string str5 = "";
                Assert.Throws<ArgumentException>(() => ControlWork1.Vtoroe(str5));
            }
        [Test]
        public void Test3() {
            Assert.That(ControlWork1.Tretie("abcdefg"), Is.EqualTo('e')); }
            [Test]
            public void Test3Null()
            {
                string str2 = null;
                Assert.Throws<ArgumentNullException>(() => ControlWork1.Tretie(str2));
            }
            [Test]
            public void Test3Hollow()
            {
                string str3 = "";
                Assert.Throws<ArgumentException>(() => ControlWork1.Tretie(str3));
            }
        [Test]
        public void Test4() {
            Assert.That(ControlWork1.IsPalindrome(67677), Is.EqualTo(false));
            Assert.That(ControlWork1.IsPalindrome(6767), Is.EqualTo(false));
            Assert.That(ControlWork1.IsPalindrome(5555), Is.EqualTo(true));
            Assert.That(ControlWork1.IsPalindrome(55555), Is.EqualTo(true));
            /*int x4 = null;
            var exception4 = Assert.Throws<ArgumentNullException>(() => ControlWork1.IsPalindrome(x4));
            Assert.That(exception4.ParamName, Is.EqualTo("str4"));
            Assert.That(exception4.Message, Does.Contain("Данные не могут быть null"));*/
        }
        [Test]
        public void Test5() {
            int[] mas1 = [0, 3, 14, 8, 2, 94];
            int[] ans1 = [0, 0, 3, 17, 25, 27];
            Assert.That(ControlWork1.RunningSum(mas1), Is.EqualTo(ans1)); }
        [Test]
        public void Test5Null()
        {
            int[] mas2 = null;
            Assert.Throws<ArgumentNullException>(() => ControlWork1.RunningSum(mas2));
        }
            [Test]
        public void Test5Hollow() {
            int[] mas3 = { };
            Assert.Throws<ArgumentException>(() => ControlWork1.RunningSum(mas3));
        }
        [Test]
        public void Test6() {
            int test1 = 999, test2 = 999, test3 = 999, test4 = 999;
            Assert.That(ControlWork1.TryParse("42", out test1), Is.EqualTo(true));
            Assert.That(ControlWork1.TryParse("-67", out test2), Is.EqualTo(true));
            Assert.That(ControlWork1.TryParse("67v67", out test3), Is.EqualTo(false));
            Assert.That(test1, Is.EqualTo(42));
            Assert.That(test2, Is.EqualTo(-67));
            Assert.That(test3, Is.EqualTo(0));
            /*int x4 = null;
            var exception4 = Assert.Throws<ArgumentNullException>(() => ControlWork1.TryParse(x4));
            Assert.That(exception4.ParamName, Is.EqualTo("x4"));
            Assert.That(exception4.Message, Does.Contain("Данные не могут быть null"));*/
        }
    }
}