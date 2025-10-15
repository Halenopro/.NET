using System;

public abstract class Person
{
    private string _hoTen;
    private string _diaChi;

    public string HoTen
    {
        get { return _hoTen; }
        set { _hoTen = value; }
    }

    public string DiaChi
    {
        get { return _diaChi; }
        set { _diaChi = value; }
    }

    public abstract void NhapThongTin(string hoTen, string diaChi);
    public abstract double TinhLuong();

    public void HienThiThongTin()
    {
        Console.WriteLine($"Họ Tên: {HoTen}");
        Console.WriteLine($"Địa Chỉ: {DiaChi}");
    }

}