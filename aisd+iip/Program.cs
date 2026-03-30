namespace App1.Node__;

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
    public void Add(int num)
    {
        var newNode = new Node(num);
        newNode.NextNode = firstNode;
        firstNode = newNode;
    }
}