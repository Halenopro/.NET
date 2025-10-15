using System;
using System.Globalization;
using System.Text;
public class Program
{
    static List<NhanVien> danhSachNhanVien = new List<NhanVien>();
    public static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        TaoDulieu();

        bool Running = true;
        while (Running)
        {
            Console.Clear();
            Console.WriteLine("======================================");
            Console.WriteLine("1. Thêm nhân viên mới");
            Console.WriteLine("2. Hiển thị danh sách nhân viên");
            Console.WriteLine("3. Sắp xếp danh sách theo Tên và Lương");
            Console.WriteLine("4. Thoát chương trình");
            Console.WriteLine("======================================");
            Console.WriteLine("Nhap chuc nang");

            string choose = Console.ReadLine();
            switch (choose)
            {
                case "1":
                    ThemNhanVien();
                    break;
                case "2":
                    HienThiDanhSach(danhSachNhanVien,"Danh sach nhan vien");
                    break;
                case "3":
                    SapXepDanhSach();
                    break;
                case "4":
                    Running = false;
                    Console.WriteLine("Thoat chuong trinh");
                    break;
                default:
                    Console.WriteLine("Nhap chuc nang khong hop le!");
                    break;
            }
            if (Running)
            {
                Console.WriteLine("Nhan phim bat ky de tiep tuc...");
                Console.ReadKey();
            }
        }

    }

    

    static void ThemNhanVien()
    {
        Console.Clear();
        Console.WriteLine("Them Nhan vien moi");

        Console.WriteLine("Nhap ma nhan vien: ");
        string maNV = Console.ReadLine();

        if (danhSachNhanVien.Any(nv => nv.MaNhanVien.Equals(maNV, StringComparison.OrdinalIgnoreCase)))
        {
            Console.WriteLine($"Error: ma nhan vien '{maNV}' exist ");
            return;
        }
        Console.WriteLine("Nhap ho ten: ");
        string hoTen = Console.ReadLine();
        Console.WriteLine("Nhap dia chi: ");
        string diaChi = Console.ReadLine();
        Console.WriteLine("Nhap chuc vu: ");
        string chucVu = Console.ReadLine();

        double heSoLuongCB = 0;
        while (true)
        {
            Console.WriteLine("Nhap he so luong co ban");
            if (double.TryParse(Console.ReadLine(), out heSoLuongCB) && heSoLuongCB > 0)
            {
                break;
            }
            Console.WriteLine("He so khong hop le ");
        }
        NhanVien nvNew = new NhanVien(maNV, hoTen, diaChi, chucVu, heSoLuongCB);
        danhSachNhanVien.Add((nvNew));

        Console.WriteLine("Them thanh cong");
    }

    private static void HienThiDanhSach(List<NhanVien> ds, string Field)
    {
        Console.Clear();
        Console.WriteLine($"---{Field}---");
        Console.WriteLine("{0,-10}\t{1,-25}\t{2,-20}\t{3,-15}\t{4,-10}\t{5,-10}\t{6,-15}",
                                 "Mã NV", "Họ Tên", "Địa Chỉ", "Chức Vụ", "HS Chức Vụ", "HS Lương", "Lương (VNĐ)");
        Console.WriteLine(new string('-', 120));

        CultureInfo cul = new CultureInfo("vi-VN");
        foreach (var nv in ds)
        {
            double heSoChucVu = NhanVien.GetHeSoChucVu(nv.ChucVu);
            string luongFormatted = nv.TinhLuong().ToString("N0", cul);
            Console.WriteLine("{0,-10}\t{1,-25}\t{2,-20}\t{3,-15}\t{4,-10}\t{5,-10}\t{6,-15}",
                              nv.MaNhanVien, nv.HoTen, nv.DiaChi, nv.ChucVu, nv.HeSoLuongCoBan, luongFormatted);


        }
    }
        static void SapXepDanhSach()
    {
        if (!danhSachNhanVien.Any())
        {
            Console.WriteLine("Danh Sach Trong");
            return;
        }
        var danhSachDaSapXep = danhSachNhanVien.OrderBy(nv => nv.HoTen).ThenBy(nv => nv.HeSoLuongCoBan).ToList();
    }


        static void TaoDulieu()
        {
            danhSachNhanVien.Add(new NhanVien("NV001", "Nguyễn Văn A", "Hà Nội", "Giám Đốc", 5.0));
            danhSachNhanVien.Add(new NhanVien("NV002", "Trần Thị B", "Hồ Chí Minh", "Trưởng Phòng", 4.0));
            danhSachNhanVien.Add(new NhanVien("NV003", "Lê Văn C", "Đà Nẵng", "Phó Giám Đốc", 4.5));
            danhSachNhanVien.Add(new NhanVien("NV004", "Phạm Thị D", "Hải Phòng", "Phó Phòng", 3.5));
            danhSachNhanVien.Add(new NhanVien("NV005", "Hoàng Văn E", "Cần Thơ", "Nhân Viên", 2.5));
        }
    }
