public class LinkedList
{
    public Node Head;
    public LinkedList()
    {
        Node newNode = new Node(value);
        if (Head == null)
        {
            Head = newNode;
        } else {
            Node runner = Head;
            while ( runner.Next != null )
            {
                runner = runner.Next;
            }
            runner.Next = newNode;
        }
    }
}