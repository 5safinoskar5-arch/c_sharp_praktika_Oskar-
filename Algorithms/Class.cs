using System;
namespace App1.Node__;
class LinkedNode
{
    public int Info;
    public LinkedNode PrevNode;
    public LinkedNode NextNode;
    public LinkedNode(int value)
    {
        Info=value;
    }
}
public class LinkedList
{
    private LinkedNode firstNode;
    public LinkedList(int value)
    { firstNode = new LinkedNode(value); }
    public void AddToStart(int value)
    {

        if (firstNode == null) { firstNode = new LinkedNode(value); return; }
        LinkedNode newNode = new LinkedNode(value); //новый узел
        newNode = firstNode; //смотрим на старый первый
        firstNode.PrevNode = newNode;
        firstNode = newNode;
    }
    public void RemoveFromStart()
    {

        if (firstNode == null) { Console.WriteLine("List is already empty."); return; }
        firstNode = firstNode.NextNode;
        if (firstNode != null) { firstNode.PrevNode = null; return; }
    }
    public void AddLast(int value)
    {
        if (firstNode == null)
        {
            firstNode = new LinkedNode(value); return;
        }
        LinkedNode temp = firstNode;
        while (temp.NextNode != null)
        {
            temp = temp.NextNode;
        }
        temp.NextNode = new LinkedNode(value); ;
        temp.NextNode.PrevNode = temp; //новый последний узел
    }
    public void RemoveAt(int index)
    {
        int count = 1;
        LinkedNode temp = firstNode;
        while (temp != null)
        {
            if (count == index - 1)
            {
                temp.NextNode = temp.NextNode.NextNode;
                temp.NextNode.NextNode.PrevNode = temp;
            }
            count++;
            temp = temp.NextNode;
        }
    }
}