using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace BTVN7;
//Bài tập buổi 7 ( bài 1 + 2 )
public class Node
{
    public Node LeftNode { get; set; }
    public Node RightNode { get; set; }
    public int Data { get; set; }
    public int Count { get; set; } = 1;
}

public class BinarySearchTree
{
    public Node Root { get; set; }

    public bool Insert(int value)
    {
        Node before = null, after = this.Root;
        while (after != null)
        {
            before = after;
            if (value < after.Data)
                after = after.LeftNode;
            else if (value > after.Data)
                after = after.RightNode;
            else
            {
                after.Count++; 
                return true;
            }
        }
        Node newNode = new Node { Data = value };
        if (this.Root == null)
            this.Root = newNode;
        else if (value < before.Data)
            before.LeftNode = newNode;
        else
            before.RightNode = newNode;
        return true;
    }

    // Duyệt cây theo thứ tự giữa 
    public void TraverseInOrder(Node parent)
    {
        if (parent != null)
        {
            TraverseInOrder(parent.LeftNode);
            Console.WriteLine($"Giá trị: {parent.Data}  Xuất hiện: {parent.Count} lần");
            TraverseInOrder(parent.RightNode);
        }
    }

    public int CountEdges()
    {
        return CountEdges(this.Root);
    }

    private int CountEdges(Node node)
    {
        if (node == null) return 0;

        int leftEdges = node.LeftNode != null ? 1 + CountEdges(node.LeftNode) : 0;
        int rightEdges = node.RightNode != null ? 1 + CountEdges(node.RightNode) : 0;

        return leftEdges + rightEdges;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Random rand = new Random();
        BinarySearchTree bst = new BinarySearchTree();

        for (int i = 0; i < 10000; i++)
        {
            bst.Insert(rand.Next(0, 10)); 
        }

        Console.WriteLine("Giá trị trong cây nhị phân và số lần xuất hiện:");
        bst.TraverseInOrder(bst.Root);

        Console.WriteLine("\nSố cạnh trong cây: " + bst.CountEdges());
    }
}


//Bài tập chuyển sang MD5
public class Book
{
    public string title;
    public string author;
    public long price;

    public Book(string title, string author, long price)
    {
        this.title = title;
        this.author = author;
        this.price = price;
    }

    public string GetHashedBookInfo()
    {
        string data = $"{title}|{author}|{price}";
        return GenerateMD5Hash(data);
    }

    private string GenerateMD5Hash(string input)
    {
        using (MD5 md5 = MD5.Create())
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            foreach (byte b in hashBytes)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }
    }
}

public class Books
{
    private Dictionary<string, Book> bookCollection = new Dictionary<string, Book>();

    public void Add(string key, Book value)
    {
        bookCollection[key] = value;
    }

    public void Remove(string key)
    {
        bookCollection.Remove(key);
    }

    public Book Items(string key)
    {
        return bookCollection.ContainsKey(key) ? bookCollection[key] : null;
    }

    public void PrintListofBook()
    {
        Console.WriteLine("{0, 10}{1, 50}", "ISBN", "MD5 Hash");
        Console.WriteLine("------------------------------------------------------------");

        foreach (var entry in bookCollection)
        {
            Console.WriteLine("{0, 10}{1, 50}", entry.Key, entry.Value.GetHashedBookInfo());
        }
    }

    public Book FindBook(string keyword)
    {
        foreach (var entry in bookCollection)
        {
            if (entry.Value.title.Contains(keyword))
            {
                return entry.Value;
            }
        }
        return null;
    }

    public void UpdateBook(string key, string title, string authors, long price)
    {
        if (bookCollection.ContainsKey(key))
        {
            bookCollection[key].title = title;
            bookCollection[key].author = authors;
            bookCollection[key].price = price;
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.Clear();
        Book book1 = new Book("C# Programming", "John Doe", 100);
        Book book2 = new Book("Java Programming", "Jane Doe", 200);
        Book book3 = new Book("Python Programming", "Jack Doe", 300);

        Books bookdict = new Books();
        bookdict.Add("ISBN01", book1);
        bookdict.Add("ISBN02", book2);
        bookdict.Add("ISBN03", book3);

        bookdict.PrintListofBook();

        string keyword = "Python";
        Book book = bookdict.FindBook(keyword);
        if (book != null)
            Console.WriteLine("Book with [{0}] Found: {1}, {2}, {3}", keyword, book.title, book.author, book.price);

        bookdict.UpdateBook("ISBN03", "Python Programming 2", "John & Jack Doe", 400);
        bookdict.PrintListofBook();
    }
}
