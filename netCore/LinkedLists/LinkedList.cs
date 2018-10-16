using System;

public class LinkedList
{
    public Node Head;
    public LinkedList()
    {
        Head = null;
    }

    public void Add ( int value )
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

    public void Remove ()
    {
        Node runner = Head;
        while ( runner.Next != null)
        {
            runner = runner.Next;
        }
        runner = null;
    }

    public void Print (LinkedList myList)
    {
        Node runner = Head;
        while ( runner.Next != null )
        {
            Console.WriteLine(runner);
        }
    }

    public Node Find ( int val )
    {
        Node runner = Head;
        while (runner.Next != null)
        {
            if ( runner.Value == val )
            {
                return runner;
            }
            runner = runner.Next;
        }
        return null; 
    }

    public LinkedList RemoveAt (int val)
    {
        Node runner = Head;
        int index = 1;
        if ( val == 0 )
        {
            Head = runner.Next;
        } 
        while (runner != null)
        {
            Node currNode = runner;
            Node nextNode = runner.Next;
            if (index == (val - 1))
            {
                Node toBeDeleted = runner.Next;
                runner.Next = toBeDeleted.Next;
                return this;
            }
            index ++;
        }
        return this;
    }

}