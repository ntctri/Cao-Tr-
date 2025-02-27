using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selection_đệ_qui
{
    internal class Program
    {
        static void SapXepChonDeQuy(int[] arr, int batDau=0 )
        {
            if (batDau >= arr.Length - 1)
                return;

            int chiMucMin = batDau;
            for (int i = batDau + 1; i < arr.Length; i++)
            {
                if (arr[i] < arr[chiMucMin])
                    chiMucMin = i;
            }

            int temp = arr[batDau];
            arr[batDau] = arr[chiMucMin];
            arr[chiMucMin] = temp;
            SapXepChonDeQuy(arr, batDau + 1);
        }

        static void Main()
        {
            Console.OutputEncoding=Encoding.UTF8;
            int[] arr = { 64, 25, 12, 22, 11 };
            SapXepChonDeQuy(arr);
            Console.WriteLine("Mảng đã sắp xếp: " + string.Join("   ", arr));
        }
    }
}
