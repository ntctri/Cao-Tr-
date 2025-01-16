//using System;
//using System.Collections.Generic;
//namespace BTVN2
//{
//// Câu 1:
//    public class MonHoc
//    {
//        private string tenmonhoc;
//        private int[] diemSo;
//        public MonHoc(string tenmonhoc, int[] diemSo)
//        {
//            this.tenmonhoc = tenmonhoc;
//            this.diemSo = diemSo;
//        }
//        public double TinhDiemTrungBinh()
//        {
//            int tong = 0;
//            foreach (int diem in diemSo)
//            {
//                tong += diem;
//            }
//            return (double)tong / diemSo.Length;
//        }
//        public int TimDiemCaoNhat()
//        {
//            int max = diemSo[0];
//            foreach (int diem in diemSo)
//            {
//                if (diem > max) max = diem;
//            }
//            return max;
//        }
//        public int TimDiemThapNhat()
//        {
//            int min = diemSo[0];
//            foreach (int diem in diemSo)
//            {
//                if (diem < min) min = diem;
//            }
//            return min;
//        }
//        public void HienThiThongTin()
//        {
//            Console.WriteLine($"Mon hoc: {tenmonhoc}");
//            Console.WriteLine($"Điem: {string.Join(", ", diemSo)}");
//            Console.WriteLine($"Điem trung binh: {TinhDiemTrungBinh():F2}");
//            Console.WriteLine($"Điem cao nhat: {TimDiemCaoNhat()}");
//            Console.WriteLine($"Điem thap nhat: {TimDiemThapNhat()}");
//        }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            int[] diemToan = { 6, 7, 8, 9, 10 };
//            MonHoc monToan = new MonHoc("Toan", diemToan);
//            monToan.HienThiThongTin();
//            Console.ReadKey();
//        }
//    }
//}
////Câu 2:
//using System;
//using System.Collections.Generic;
//public class MonHoc
//{
//    private string tenmonhoc;
//    private int[] diemSo;
//    public MonHoc(string tenmonhoc, int[] diemSo)
//    {
//        this.tenmonhoc = tenmonhoc;
//        this.diemSo = diemSo;
//    }
//    public double TinhDiemTrungBinh()
//    {
//        int tong = 0;
//        foreach (int diem in diemSo)
//        {
//            tong += diem;
//        }
//        return (double)tong / diemSo.Length;
//    }
//    public int TimDiemCaoNhat()
//    {
//        int max = diemSo[0];
//        foreach (int diem in diemSo)
//        {
//            if (diem > max) max = diem;
//        }
//        return max;
//    }
//    public int TimDiemThapNhat()
//    {
//        int min = diemSo[0];
//        foreach (int diem in diemSo)
//        {
//            if (diem < min) min = diem;
//        }
//        return min;
//    }
//    public void HienThiThongTin()
//    {
//        Console.WriteLine($"Mon hoc: {tenmonhoc}");
//        Console.WriteLine($"Diem: {string.Join(", ", diemSo)}");
//        Console.WriteLine($"Diem trung binh: {TinhDiemTrungBinh():F2}");
//        Console.WriteLine($"Diem cao nhat: {TimDiemCaoNhat()}");
//        Console.WriteLine($"Diem thap nhat: {TimDiemThapNhat()}");
//        Console.WriteLine();
//    }
//}
//class Program
//{
//    static void Main(string[] args)
//    {
//        List<MonHoc> danhSachMonHoc = new List<MonHoc>();
//        danhSachMonHoc.Add(new MonHoc("Toan", new int[] { 6, 7, 8, 9, 10 }));
//        danhSachMonHoc.Add(new MonHoc("Ly", new int[] { 7, 3, 9, 6, 8 }));
//        danhSachMonHoc.Add(new MonHoc("Hoa", new int[] { 8, 7, 9, 5, 6 }));
//        Console.WriteLine("Thong tin cac mon hoc:");
//        foreach (MonHoc monHoc in danhSachMonHoc)
//        {
//            monHoc.HienThiThongTin();
//        }
//        Console.ReadKey();
//    }
//}
//// Câu 3:
//using System;
//using System.Collections.Generic;
//public class MonHoc
//{
//    private string tenMonHoc;
//    private List<int> diemSo;
//    public MonHoc(string tenMonHoc, List<int> diemSo)
//    {
//        this.tenMonHoc = tenMonHoc;
//        this.diemSo = diemSo;
//    }
//    public double TinhDiemTrungBinh()
//    {
//        int tong = 0;
//        foreach (int diem in diemSo)
//        {
//            tong += diem;
//        }
//        return (double)tong / diemSo.Count;
//    }
//    public int TimDiemCaoNhat()
//    {
//        int max = diemSo[0];
//        foreach (int diem in diemSo)
//        {
//            if (diem > max) max = diem;
//        }
//        return max;
//    }
//    public int TimDiemThapNhat()
//    {
//        int min = diemSo[0];
//        foreach (int diem in diemSo)
//        {
//            if (diem < min) min = diem;
//        }
//        return min;
//    }
//    public void HienThiThongTin()
//    {
//        Console.WriteLine($"Mon hoc: {tenMonHoc}");
//        Console.WriteLine($"Diem: {string.Join(", ", diemSo)}");
//        Console.WriteLine($"Diem trung binh: {TinhDiemTrungBinh():F2}");
//        Console.WriteLine($"Diem cao nhat: {TimDiemCaoNhat()}");
//        Console.WriteLine($"Diem thap nhat: {TimDiemThapNhat()}");
//        Console.WriteLine();
//    }
//}
//class Program
//{
//    static void Main(string[] args)
//    {
//        List<int> diemToan = new List<int> { 4, 7, 10, 9, 10 };
//        MonHoc monToan = new MonHoc("Toan", diemToan);
//        monToan.HienThiThongTin();
//        Console.WriteLine("Them diem moi vao danh sach:");
//        diemToan.Add(9);
//        monToan.HienThiThongTin();
//        Console.ReadKey();
//    }
//}
//// Câu 4:
//using System;
//using System.Collections.Generic;
//public class MonHoc
//{
//    private string tenmonhoc;
//    private List<int> diemSo;
//    public MonHoc(string tenmonhoc, List<int> diemSo)
//    {
//        this.tenmonhoc = tenmonhoc;
//        this.diemSo = diemSo;
//    }
//    public void ThemDiem(int diem)
//    {
//        diemSo.Add(diem);
//    }
//    public double TinhDiemTrungBinh()
//    {
//        int tong = 0;
//        foreach (int diem in diemSo)
//        {
//            tong += diem;
//        }
//        return diemSo.Count > 0 ? (double)tong / diemSo.Count : 0;
//    }
//    public int TimDiemCaoNhat()
//    {
//        int max = diemSo[0];
//        foreach (int diem in diemSo)
//        {
//            if (diem > max) max = diem;
//        }
//        return max;
//    }
//    public int TimDiemThapNhat()
//    {
//        int min = diemSo[0];
//        foreach (int diem in diemSo)
//        {
//            if (diem < min) min = diem;
//        }
//        return min;
//    }
//    public void HienThiThongTin()
//    {
//        Console.WriteLine($"Mon hoc: {tenmonhoc}");
//        Console.WriteLine($"Điem: {string.Join(", ", diemSo)}");
//        Console.WriteLine($"Điem trung binh: {TinhDiemTrungBinh():F2}");
//        Console.WriteLine($"Điem cao nhat: {TimDiemCaoNhat()}");
//        Console.WriteLine($"Điem thap nhat: {TimDiemThapNhat()}");
//    }
//}
//class Program
//{
//    static void Main(string[] args)
//    {
//        List<int> diemToan = new List<int> { 6, 7, 8, 9, 10 };
//        MonHoc monToan = new MonHoc("Toan", diemToan);
//        monToan.HienThiThongTin();
//        monToan.ThemDiem(3);
//        Console.WriteLine("\nSau khi them điem:");
//        monToan.HienThiThongTin();
//        Console.ReadKey();
//    }
//}
//// Câu 5:
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Diagnostics;
//class Program
//{
//    static void Main(string[] args)
//    {
//        int soPhanTu = 1000000;
//        // 1. Mảng (int[])
//        Stopwatch stopwatch = new Stopwatch();
//        stopwatch.Start();
//        int[] mang = new int[soPhanTu];
//        for (int i = 0; i < soPhanTu; i++)
//        {
//            mang[i] = i;
//        }
//        stopwatch.Stop();
//        Console.WriteLine($"Thoi gian thuc thi cua mang (int[]): {stopwatch.ElapsedMilliseconds} ms");
//        // 2. List<int>
//        stopwatch.Restart();
//        List<int> danhSach = new List<int>();
//        for (int i = 0; i < soPhanTu; i++)
//        {
//            danhSach.Add(i);
//        }
//        stopwatch.Stop();
//        Console.WriteLine($"Thoi gian thuc thi cua List<int>: {stopwatch.ElapsedMilliseconds} ms");
//        // 3. ArrayList
//        stopwatch.Restart();
//        ArrayList arrayList = new ArrayList();
//        for (int i = 0; i < soPhanTu; i++)
//        {
//            arrayList.Add(i);
//        }
//        stopwatch.Stop();
//        Console.WriteLine($"Thoi gian thuc thi cua ArrayList: {stopwatch.ElapsedMilliseconds} ms");
//        Console.ReadKey();
//    }
//}






