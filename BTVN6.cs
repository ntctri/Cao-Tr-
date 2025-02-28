using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Bài tập 1
namespace buổi7_bt1
{
    class PhoneDirectory
    {
        static Dictionary<string, string> phoneBook = new Dictionary<string, string>();

        static void LoadFromFile(string filePath)
        {
            foreach (var line in File.ReadAllLines(filePath))
            {
                var parts = line.Split(',');
                if (parts.Length == 2)
                {
                    phoneBook[parts[0].Trim()] = parts[1].Trim();
                }
            }
        }

        static void SearchByName(string name)
        {
            if (phoneBook.ContainsKey(name))
                Console.WriteLine($"Số điện thoại của {name}: {phoneBook[name]}");
            else
                Console.WriteLine("Không tìm thấy tên.");
        }

        static void SearchByPhone(string phone)
        {
            foreach (var entry in phoneBook)
            {
                if (entry.Value == phone)
                {
                    Console.WriteLine($"Tên tương ứng với số {phone}: {entry.Key}");
                    return;
                }
            }
            Console.WriteLine("Không tìm thấy số điện thoại.");
        }

        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            string filePath = "sdt.txt";  // File chứa danh sách tên,số điện thoại, mở trong ASUS SOURE BIN 
            LoadFromFile(filePath);

            Console.Write("Nhập tên cần tìm: ");
            string name = Console.ReadLine();
            SearchByName(name);

            Console.Write("Nhập số điện thoại cần tìm: ");
            string phone = Console.ReadLine();
            SearchByPhone(phone);
        }
    }
}


using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

class SpellChecker
{
    static Hashtable dictionary = new Hashtable();

    // Hàm tải từ điển từ file
    static void LoadDictionary(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("Không tìm thấy file từ điển.");
            return;
        }

        foreach (var word in File.ReadAllLines(filePath))
        {
            dictionary[word.Trim().ToLower()] = true;
        }
    }

    // Hàm kiểm tra lỗi chính tả
    static void CheckSpelling(string textFilePath)
    {
        if (!File.Exists(textFilePath))
        {
            Console.WriteLine("Không tìm thấy file văn bản.");
            return;
        }

        string content = File.ReadAllText(textFilePath, Encoding.UTF8);
        string[] words = Regex.Split(content.ToLower(), @"\W+"); // Tách từ bằng dấu cách và dấu câu

        Console.WriteLine("\nCác từ sai chính tả:");
        bool hasErrors = false;

        foreach (var word in words)
        {
            if (!string.IsNullOrWhiteSpace(word) && !dictionary.ContainsKey(word))
            {
                Console.WriteLine($"X {word}");
                hasErrors = true;
            }
        }

        if (!hasErrors)
        {
            Console.WriteLine("Không có lỗi chính tả!");
        }
    }

    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        string dictionaryFile = "kiemtrachinhta.txt"; // File chứa danh sách từ đúng
        string textFile = "kiemtrachinhtasai.txt"; // File chứa nội dung cần kiểm tra

        LoadDictionary(dictionaryFile);

        Console.WriteLine("Nhập nội dung cần kiểm tra chính tả:");
        string userInput = Console.ReadLine();
        File.WriteAllText(textFile, userInput, Encoding.UTF8); // Lưu nội dung vào file

        CheckSpelling(textFile);
    }
}
