/*using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using App1;
using App1.Node__;

class Program
{
    static void Main()
    {
        CustomList cl1 = new CustomList(1);
        cl1.Print();
        cl1.RemoveLast();
        cl1.Print();
        cl1.RemoveLast();

        CustomList cl2 = new CustomList(new[] { 1, 2, 3, 4, 5 });
        cl2.Print();
        cl2.RemoveLast();
        cl2.Print();d

    }
}*/
namespace App1.Node__
{
    /// Узел линейного списка [6]
    public class Node
    {
        public int Info;
        public Node NextNode;

        public Node(int info)
        {
            Info = info;
        }
    }

    public class CustomList
    {
        private Node firstNode;

        // Конструкторы из исходного файла [7]
        public CustomList(int num)
        {
            firstNode = new Node(num);
        }

        public CustomList(int[] nums)
        {
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                Add(nums[i]);
            }
        }

        /// Добавление в начало (из файла) [7]
        public void Add(int num)
        {
            var newNode = new Node(num);
            newNode.NextNode = firstNode;
            firstNode = newNode;
        }

        /// Добавление в конец (с доски) [8]
        public void AddToEnd(int someValue)
        {
            if (firstNode == null)
            {
                Add(someValue); // Вызов добавления в начало (на доске AddToStart)
                return;
            }

            // 1 Созд. новый узел
            Node newNode = new Node(someValue);

            Node tempNode = firstNode;
            while (tempNode.NextNode != null)
            {
                tempNode = tempNode.NextNode;
            }
            tempNode.NextNode = newNode;
        }

        /// Удаление с конца (в файле называлось RemoveLast, код совмещен с доской) [1, 2, 7, 9]
        public void DeleteFromEnd()
        {
            if (firstNode == null)
            {
                Console.WriteLine("Список пуст. Удаление невозможно.");
                return;
            }

            if (firstNode.NextNode == null)
            {
                firstNode = null;
                return;
            }

            // 1 Созд. указатель д/прохода по списку
            Node tempNode = firstNode;

            // 2 Доходим до предпосл.
            while (tempNode.NextNode.NextNode != null)
            {
                tempNode = tempNode.NextNode;
            }

            // 3 Удаляем
            tempNode.NextNode = null;
        }

        /// Удаление по позиции (с доски) [3, 4, 10, 11]
        public void DeleteByPos(int pos)
        {
            if (firstNode == null)
            {
                Console.WriteLine("Список пуст");
                return;
            }

            if (pos == 1)
            {
                // Удаление первого элемента
                firstNode = firstNode.NextNode;
                return;
            }

            // 1 Созд. указатель д/прохода по списку
            Node tempNode = firstNode;

            // 2 Доходим с пом. tempNode до pos-1
            int currentPosition = 1;
            while (currentPosition != pos - 1)
            {
                tempNode = tempNode.NextNode;
                currentPosition++;

                if (tempNode == null)
                {
                    Console.WriteLine("Сообщение: Позиция вне диапазона");
                    return;
                }
            }

            // 3-4 Удаляем (Ур. из середины)
            if (tempNode.NextNode != null)
            {
                tempNode.NextNode = tempNode.NextNode.NextNode;
            }
        }

        /// Вставка по позиции (с доски) [5, 12]
        public void AddToPos(int someValue, int pos)
        {
            // общий случай
            // 1 Новый узел
            Node newNode = new Node(someValue);

            // 2 Созд. указатель д/прохода по списку
            Node tempNode = firstNode;

            // 3 Доходим до узла pos-1, после к-го б. вставлять
            int currentPos = 1;
            while (currentPos != pos - 1)
            {
                tempNode = tempNode.NextNode;
                currentPos++;

                if (tempNode == null)
                {
                    Console.WriteLine("Сообщ: Список короче");
                    return;
                }
            }

            // Вставка нового узла (логика с графической схемы) [13]
            newNode.NextNode = tempNode.NextNode;
            tempNode.NextNode = newNode;
        }

        /// Вывод списка (из файла) [9]
        public void Print()
        {
            if (firstNode == null)
            {
                Console.WriteLine("Список пустой!");
                return;
            }

            Node tempNode = firstNode;
            while (tempNode != null)
            {
                Console.Write($"{tempNode.Info} " + (tempNode.NextNode == null ? "" : "-> "));
                tempNode = tempNode.NextNode;
            }
            Console.WriteLine();
        }
    }
}

class Program
{
    // Тестирование из файла Program.txt [14]
    static void Main()
    {
        App1.Node__.CustomList cl1 = new App1.Node__.CustomList(1);
        cl1.Print();
        cl1.DeleteFromEnd(); // Заменено с RemoveLast() для совпадения с доской
        cl1.Print();
        cl1.DeleteFromEnd();

        App1.Node__.CustomList cl2 = new App1.Node__.CustomList(new[] { 1, 2, 3, 4, 5 });
        cl2.Print();
        cl2.DeleteFromEnd();
        cl2.Print();
    }
}