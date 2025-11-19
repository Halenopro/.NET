using System;
using System.Collections.Generic;
using System.Text;
public class Program
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        List<string> danhSachBanBe = new List<string>();


        danhSachBanBe.Add("An");
        danhSachBanBe.Add("Bình");
        danhSachBanBe.Add("Cường");

        
        Console.WriteLine($"Tong so ban be: {danhSachBanBe.Count}");
        Console.WriteLine("--------------------");

        
        Console.WriteLine("Danh sach ban be ban dau:");
        foreach (string ten in danhSachBanBe)
        {
            Console.WriteLine(ten);
        }
        Console.WriteLine("--------------------");

        
        danhSachBanBe.Remove("Bình");
        Console.WriteLine("Da xoa 'Binh' khoi danh sach.");
        Console.WriteLine("--------------------");

        
        danhSachBanBe.Sort();
        Console.WriteLine("Da sap xep danh sach.");
        Console.WriteLine("--------------------");

        Console.WriteLine("Danh sach ban be cuoi cung:");
        foreach (string ten in danhSachBanBe)
        {
            Console.WriteLine(ten);
        }

        
        Console.ReadKey();
    }
}