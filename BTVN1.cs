using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApp4
{
    internal class BTVN
    {
        static void Swap<T>(ref T v1, ref T v2)
        {
            T temp = v1;
            v1 = v2;
            v2 = temp;
        }
        static T Sum<T>(T a, T b, T c)
        {
            return (dynamic)a + (dynamic)b + (dynamic)c;
        }
        static void demthoigian<T>(T[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
                for (int j = i + 1; j < arr.Length; j++)
                    if (arr[i].ToString().CompareTo(arr[j].ToString()) > 0)
                        Swap<T>(ref arr[i], ref arr[j]);
        }
        public static void Main(string[] args)
        {
            Console.Clear();
            // Yêu cầu 1: Hàm Sum
            Console.WriteLine("Sum<int>: " + Sum<int>(10, 12, 18));
            Console.WriteLine("Sum<string>: " + Sum<string>("Toi", " la", " Tri"));
            // Yêu cầu 2: Max Min
            int[] arr = new int[1000];
            Random random = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(1, 10001);
            }
            int min, max;
            minmax(arr, out min, out max);
            Console.WriteLine($"Min : {min}, Max : {max}");
            // Đo thời gian chạy
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            demthoigian<int>(arr);
            stopwatch.Stop();
            Console.WriteLine("Thời gian sắp xếp mảng: " + stopwatch.ElapsedMilliseconds + " ms");
        }
        static void minmax(int[] arr, out int min, out int max)
        {
            min = arr[0];
            max = arr[0];
            foreach (int num in arr)
            {
                if (num < min) min = num;
                else if (num > max) max = num;
            }
        }
    }
}
