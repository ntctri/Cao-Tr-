using System;
using System.Collections.Generic;

public class Program
{
    //Bài tập 3 slide
    static void Main()
    {
        LinkedList<string> names = new LinkedList<string>();

        LinkedListNode<string> node1 = new LinkedListNode<string>("Tri");
        names.AddFirst(node1);

        LinkedListNode<string> node2 = new LinkedListNode<string>("Trong");
        names.AddAfter(node1, node2);

        LinkedListNode<string> node3 = new LinkedListNode<string>("Ha");
        names.AddAfter(node2, node3);

        Console.WriteLine("Danh sach lien ket:");
        foreach (var name in names)
        {
            Console.WriteLine(name);
        }

        names.Remove("Trong");
        Console.WriteLine("\nDanh sach sau khi xoa 'Trong':");
        foreach (var name in names)
        {
            Console.WriteLine(name);
        }
    }
}


//Bài tập tương tự (LinkedList) đối với Doubly LinkedList
public class DoublyNode
{
    public object Element;
    public DoublyNode Prev;
    public DoublyNode Next;

    public DoublyNode(object element)
    {
        Element = element;
        Prev = null;
        Next = null;
    }
}

public class DoublyLinkedList
{
    private DoublyNode head;
    private DoublyNode tail;

    public DoublyLinkedList()
    {
        head = tail = null;
    }

    public void Append(object element)
    {
        DoublyNode newNode = new DoublyNode(element);
        if (head == null)
        {
            head = tail = newNode;
        }
        else
        {
            tail.Next = newNode;
            newNode.Prev = tail;
            tail = newNode;
        }
    }

    public void InsertAfter(object newElement, object afterElement)
    {
        DoublyNode current = Find(afterElement);
        if (current != null)
        {
            DoublyNode newNode = new DoublyNode(newElement);
            newNode.Next = current.Next;
            newNode.Prev = current;

            if (current.Next != null)
                current.Next.Prev = newNode;
            else
                tail = newNode;

            current.Next = newNode;
        }
    }

    public void Remove(object element)
    {
        DoublyNode current = Find(element);
        if (current == null) return;

        if (current.Prev != null)
            current.Prev.Next = current.Next;
        else
            head = current.Next;

        if (current.Next != null)
            current.Next.Prev = current.Prev;
        else
            tail = current.Prev;
    }

    private DoublyNode Find(object element)
    {
        DoublyNode current = head;
        while (current != null && !current.Element.Equals(element))
            current = current.Next;
        return current;
    }

    public int FindMax()
    {
        if (head == null)
            throw new InvalidOperationException("Danh sach rong");

        int max = int.Parse(head.Element.ToString());
        DoublyNode current = head.Next;

        while (current != null)
        {
            int value = int.Parse(current.Element.ToString());
            if (value > max)
                max = value;
            current = current.Next;
        }
        return max;
    }

    public int Sum()
    {
        int sum = 0;
        DoublyNode current = head;
        while (current != null)
        {
            sum += int.Parse(current.Element.ToString());
            current = current.Next;
        }
        return sum;
    }

    public int Count()
    {
        int count = 0;
        DoublyNode current = head;
        while (current != null)
        {
            count++;
            current = current.Next;
        }
        return count;
    }

    public void PrintForward()
    {
        DoublyNode current = head;
        Console.Write("Danh sach xuoi: ");
        while (current != null)
        {
            Console.Write(current.Element + " ");
            current = current.Next;
        }
        Console.WriteLine();
    }

    public void PrintBackward()
    {
        DoublyNode current = tail;
        Console.Write("Danh sach nguoc: ");
        while (current != null)
        {
            Console.Write(current.Element + " ");
            current = current.Prev;
        }
        Console.WriteLine();
    }
}

public class Program1
{
    public static void Main()
    {
        Console.Clear();

        DoublyLinkedList list = new DoublyLinkedList();
        list.Append(10);
        list.Append(20);
        list.Append(5);
        list.Append(30);
        list.InsertAfter(15, 10); 
        list.InsertAfter(25, 20);
        list.PrintForward();
        list.PrintBackward();

        Console.WriteLine("Max: " + list.FindMax());
        Console.WriteLine("Sum: " + list.Sum());
        Console.WriteLine("Count: " + list.Count());

        list.Remove(20);
        Console.Write("Sau khi xoa 20 thi ");
        list.PrintForward();
    }
}

