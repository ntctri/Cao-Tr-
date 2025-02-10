using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        //Câu 1
        int[] arr = { 1, 3, 5, 7, 9, 11, 15, 18, 20, 25 };
        int target = 15;
        //SeqSearch
        MeasureTime(() =>
        {
            int result = SequentialSearch(arr, target);
            Console.WriteLine(result != -1 ? $"Tim thay tai {result}" : "Khong tim thay");
        }, "Sequential Search");
        //RecuSearch
        MeasureTime(() =>
        {
            int result = RecursiveSearch(arr, target, 0);
            Console.WriteLine(result != -1 ? $"Tim thay tai {result}" : "Khong tim thay");
        }, "Recursive Search");
        //SenSearch
        MeasureTime(() =>
        {
            int result = SentinelSearch(arr, target);
            Console.WriteLine(result != -1 ? $"Tim thay tai {result}" : "Khong tim thay");
        }, "Sentinel Search");
        //BinSearch
        MeasureTime(() =>
        {
            int result = BinarySearch(arr, target);
            Console.WriteLine(result != -1 ? $"Tim thay tai {result}" : "Khong tim thay");
        }, "Binary Search");
    }
    //Hàm đo thời gian
    static void MeasureTime(Action searchMethod, string searchName)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        searchMethod();
        stopwatch.Stop();
        Console.WriteLine($"{searchName} thoi gian thuc hien: {stopwatch.ElapsedTicks} ticks\n");
    }
    //SeqSearch
    static int SequentialSearch(int[] arr, int target)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == target)
                return i;
        }
        return -1;
    }
    //RecuSearch
    static int RecursiveSearch(int[] arr, int target, int index)
    {
        if (index >= arr.Length) return -1;
        if (arr[index] == target) return index;
        return RecursiveSearch(arr, target, index + 1);
    }
    //SenSearch
    static int SentinelSearch(int[] arr, int target)
    {
        int last = arr[arr.Length - 1];
        arr[arr.Length - 1] = target;
        int i = 0;
        while (arr[i] != target) i++;
        arr[arr.Length - 1] = last;
        return (i < arr.Length - 1 || arr[arr.Length - 1] == target) ? i : -1;
    }
    //BinSearch
    static int BinarySearch(int[] arr, int target)
    {
        int left = 0, right = arr.Length - 1;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (arr[mid] == target)
                return mid;
            if (arr[mid] < target)
                left = mid + 1;
            else
                right = mid - 1;
        }
        return -1;
    }
    class SinhVien
    {
        public int Id { get; set; }
        public string HoTen { get; set; }
        public double DiemTB { get; set; }
        public SinhVien(int id, string hoten, double diemtb)
        {
            Id = id;
            HoTen = hoten;
            DiemTB = diemtb;
        }
    }
}


class SinhVien
{
    //Câu 2
    public int Id { get; set; }
    public string HoTen { get; set; }
    public double DiemTB { get; set; }
    public SinhVien(int id, string hoten, double diemtb)
    {
        Id = id;
        HoTen = hoten;
        DiemTB = diemtb;
    }
}
class Program
{
    static void Main()
    {
        SinhVien[] svList = {
            new SinhVien(101, "Nguyen Van A", 7.5),
            new SinhVien(102, "Nguyen Thi B", 8.0),
            new SinhVien(103, "phan Van C", 6.5),
            new SinhVien(104, "Pham Thi D", 9.0),
            new SinhVien(105, "Tran Van E", 7.2)
        };
        int targetId = 103;
        //SeqSearch
        MeasureTime(() =>
        {
            int result = SequentialSearch(svList, targetId);
            Console.WriteLine(result != -1 ? $"Tim thay tai {result}" : "Khong tim thay");
        }, "Sequential Search");
        //RecuSearch
        MeasureTime(() =>
        {
            int result = RecursiveSearch(svList, targetId, 0);
            Console.WriteLine(result != -1 ? $"Tim thay tai {result}" : "Khong tim thay");
        }, "Recursive Search");
        //SenSearch
        MeasureTime(() =>
        {
            int result = SentinelSearch(svList, targetId);
            Console.WriteLine(result != -1 ? $"Tim thay tai {result}" : "Khong tim thay");
        }, "Sentinel Search");
        //BinSearch
        Array.Sort(svList, (a, b) => a.Id.CompareTo(b.Id));
        MeasureTime(() =>
        {
            int result = BinarySearch(svList, targetId);
            Console.WriteLine(result != -1 ? $"Tim thay tai {result}" : "Khong tim thay");
        }, "Binary Search");
    }
    //Hàm đo thời gian
    static void MeasureTime(Action searchMethod, string searchName)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        searchMethod();
        stopwatch.Stop();
        Console.WriteLine($"{searchName} thoi gian thuc hien: {stopwatch.ElapsedTicks} ticks\n");
    }
    // SeqSearch
    static int SequentialSearch(SinhVien[] svList, int targetId)
    {
        for (int i = 0; i < svList.Length; i++)
        {
            if (svList[i].Id == targetId)
                return i;
        }
        return -1;
    }
    // RecuSearch
    static int RecursiveSearch(SinhVien[] svList, int targetId, int index)
    {
        if (index >= svList.Length) return -1;
        if (svList[index].Id == targetId) return index;
        return RecursiveSearch(svList, targetId, index + 1);
    }
    // SenSearch
    static int SentinelSearch(SinhVien[] svList, int targetId)
    {
        int last = svList[svList.Length - 1].Id;
        svList[svList.Length - 1].Id = targetId;
        int i = 0;
        while (svList[i].Id != targetId) i++;
        svList[svList.Length - 1].Id = last;
        return (i < svList.Length - 1 || svList[svList.Length - 1].Id == targetId) ? i : -1;
    }
    // BinSearch
    static int BinarySearch(SinhVien[] svList, int targetId)
    {
        int left = 0, right = svList.Length - 1;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (svList[mid].Id == targetId)
                return mid;
            if (svList[mid].Id < targetId)
                left = mid + 1;
            else
                right = mid - 1;
        }
        return -1;
    }
}


using System;
public class Program
{
    static int SeqSearch(int[] arr, int value)
    {
        int i = 0;
        while (i < arr.Length && arr[i] != value)
            i++;
        return (i < arr.Length) ? i : -1;
    }
    static int RecuSearch(int[] arr, int from, int value)
    {
        if (from >= arr.Length) return -1;
        if (arr[from] == value) return from;
        return RecuSearch(arr, from + 1, value);
    }
    //Bài tập 1: Cài đặt SenSearch bằng đệ quy (Github)
    static int SenSearchRecursive(int[] arr, int index, int value)
    {
        if (index >= arr.Length - 1)
            return (arr[index] == value) ? index : -1;
        if (arr[index] == value)
            return index;
        return SenSearchRecursive(arr, index + 1, value);
    }
    static int SenSearch(int[] arr, int value)
    {
        int last = arr[arr.Length - 1];
        arr[arr.Length - 1] = value;
        int result = SenSearchRecursive(arr, 0, value);
        return result;
    }
    // Bài tập 2: Cài đặt BinSearch bằng đệ quy (Github)
    static int BinSearchRecursive(int[] sarr, int value, int left, int right)
    {
        if (left > right) return -1;
        int mid = (left + right) / 2;
        if (sarr[mid] == value)
            return mid;
        if (sarr[mid] < value)
            return BinSearchRecursive(sarr, value, mid + 1, right);
        return BinSearchRecursive(sarr, value, left, mid - 1);
    }
    static int BinSearch(int[] sarr, int value)
    {
        return BinSearchRecursive(sarr, value, 0, sarr.Length - 1);
    }
    public static void Main(string[] args)
    {
        Console.Clear();
        int[] arr = { 3, 9, 2, 5, 6 };
        int value = 6;
        // SeqSearch
        int index = SeqSearch(arr, value);
        Console.WriteLine($"[SeqSearch] Gia tri {value} o vi tri: {index}");
        // RecuSearch
        index = RecuSearch(arr, 0, value);
        Console.WriteLine($"[RecuSearch] Gia tri {value} o vi tri: {index}");
        // SenSearch 
        index = SenSearch(arr, value);
        Console.WriteLine($"[SenSearch] Gia tri {value} o vi tri: {index}");
        // BinSearch
        int[] sarr = { 2, 3, 5, 6, 9 };
        index = BinSearch(sarr, value);
        Console.WriteLine($"[BinSearch] Gia tri {value} o vi tri: {index}");
    }
}


using System;
class Program
{
    //BT1
    static int SequentialSearchNthOccurrence(int[] arr, int target, int occurrence)
    {
        int count = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == target)
            {
                count++;
                if (count == occurrence)
                    return i;
            }
        }
        return -1;
    }
    static void Main()
    {
        int[] arr = { 1, 2, 3, 2, 4, 2, 5 };
        int target = 2;
        int occurrence = 2;
        int result = SequentialSearchNthOccurrence(arr, target, occurrence);
        Console.WriteLine($"Lan xuat hien thu {occurrence} cua {target} nam o vi tri: {result}");
    }
}


using System;
class Program
{
    //BT2
    static int SequentialSearchLastOccurrence(int[] arr, int target)
    {
        int lastIndex = -1;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == target)
                lastIndex = i;
        }
        return lastIndex;
    }
    static void Main()
    {
        int[] arr = { 3, 5, 2, 7, 5, 9, 5 };
        int target = 5;
        int result = SequentialSearchLastOccurrence(arr, target);
        Console.WriteLine($"Lan xuat hien cuoi cung cua {target} nam o vi tri: {result}");
    }
}


using System;
class Program
{
    //BT3
    static int BinarySearch(int[] arr, int value)
    {
        int L = 0, R = arr.Length - 1;
        while (L <= R)
        {
            int mid = (L + R) / 2;
            if (arr[mid] == value)
                return mid;
            else if (arr[mid] < value)
                L = mid + 1;
            else
                R = mid - 1;
        }
        return -1;
    }
    static void Main()
    {
        int[] arr = { 9, 3, 7, 1, 5, 2 };
        int target = 5;
        int result = BinarySearch(arr, target);
        Console.WriteLine($"Ket qua tim kiem nhi phan tren mang khong sap xep: {result}");
    }
}


using System;
class CArray
{
    //BT4
    public int[] arr;
    public int compCount;
    public CArray(int size)
    {
        arr = new int[size];
        compCount = 0;
        Random rand = new Random();
        for (int i = 0; i < size; i++)
            arr[i] = rand.Next(1, 10000);
    }
    public int SeqSearch(int target)
    {
        compCount = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            compCount++;
            if (arr[i] == target)
                return i;
        }
        return -1;
    }
    public int BinSearch(int target)
    {
        compCount = 0;
        Array.Sort(arr);
        int L = 0, R = arr.Length - 1;
        while (L <= R)
        {
            compCount++;
            int mid = (L + R) / 2;
            if (arr[mid] == target)
                return mid;
            else if (arr[mid] < target)
                L = mid + 1;
            else
                R = mid - 1;
        }
        return -1;
    }
}
class Program
{
    static void Main()
    {
        CArray array = new CArray(1000);
        int target = 738;
        int seqResult = array.SeqSearch(target);
        int seqComparisons = array.compCount;
        Console.WriteLine($"Sequential Search: {seqResult}, So lan so sanh: {seqComparisons}");
        int binResult = array.BinSearch(target);
        int binComparisons = array.compCount;
        Console.WriteLine($"Binary Search: {binResult}, So lan so sanh: {binComparisons}");
    }
}
