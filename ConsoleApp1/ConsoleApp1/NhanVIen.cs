using System;


public class NhanVien : Person, IEquatable<NhanVien>
{
    private string _maNV;
    private string _chucVu;
    private double _heSoLuongCB;
    
    public string MaNhanVien
    {
        get { return _maNV; }
        set { _maNV = value; }
    }

    public string ChucVu
    {
        get { return _chucVu; }
        set { _chucVu = value; }
    }

    public double HeSoLuongCoBan
    {
        get { return _heSoLuongCB; }
        set { _heSoLuongCB = value; }
    }

    public NhanVien() { }

    public NhanVien(string maNV, string hoTen, string diaChi, string chucVu, double heSoLuongCB)
    {
        MaNhanVien = maNV;
        HoTen = hoTen;
        DiaChi = diaChi;
        ChucVu = chucVu;
        HeSoLuongCoBan = heSoLuongCB;
    }

    public override void NhapThongTin(string hoTen, string diaChi)
    {
        this.HoTen = hoTen;
        this.DiaChi = diaChi;
    }

    public static double GetHeSoChucVu(string chucVu)
    {
        switch (chucVu?.Trim().ToLower())
        {
            case "giám đốc": return 10;
            case "trưởng phòng":
            case "phó giám đốc": return 6;
            case "phó phòng": return 4;
            default: return 2;
        }
    }
    public override double TinhLuong()
    {
        double heSoChucVu = GetHeSoChucVu(this.ChucVu);
        return (this.HeSoLuongCoBan + heSoChucVu) * 2000000;
    }


    public override string ToString()
        {
            string luongFormatted = TinhLuong().ToString("C0");

           return $"Mã NV: {MaNhanVien}, Họ Tên: {HoTen}, Địa Chỉ: {DiaChi}, Chức Vụ: {ChucVu}, Hệ Số Lương Cơ Bản: {HeSoLuongCoBan}, Lương: {luongFormatted}";
        }
        
        public override bool Equals(object obj)
        {
                   return Equals(obj as NhanVien);
        }
        
        public bool Equals(NhanVien other)
        {
            if(other is null )
                {
                return false;
        }
        if(Object.ReferenceEquals(this, other))
        {
            return true;
        }
        return this.MaNhanVien == other.MaNhanVien;
    }
        public override int GetHashCode()
        {
            return MaNhanVien?.GetHashCode() ?? 0;
    }
}
