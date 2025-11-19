using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        List<NhanVien> danhSachNV = new List<NhanVien>();
        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            if (isKiemTra())
            {
                NhanVien nvMoi = new NhanVien();
                nvMoi.MaNV = int.Parse(txtMaNV.Text);
                nvMoi.HoTen = txtHoTen.Text;
                nvMoi.NgaySinh = Convert.ToDateTime(dpNgaySinh.SelectedDate);

                if (rbNam.IsChecked == true)
                {
                    nvMoi.GioiTinh = "Nam";
                }
                else
                {
                    nvMoi.GioiTinh = "Nữ";
                }
                nvMoi.PhongBan = cboPhongBan.Text;
                nvMoi.HeSoLuong = double.Parse(txtHeSoLuong.Text);

                danhSachNV.Add(nvMoi);
                dtgNhanVien.ItemsSource = null;
                dtgNhanVien.ItemsSource = danhSachNV; 
            }

        }

        private void btnWindow2_Click(object sender, RoutedEventArgs e)
        {
            int tuoiMax= danhSachNV[0].Tuoi;
            for(int i = 1; i < danhSachNV.Count; i++)
            {
                if(danhSachNV[i].Tuoi > tuoiMax)
                {
                    tuoiMax = danhSachNV[i].Tuoi;
                }
            }
            List<NhanVien> dsTuoiMax = new List<NhanVien>();
            foreach(var item in danhSachNV)
            {
                if(item.Tuoi == tuoiMax)
                {
                    dsTuoiMax.Add(item);
                }
            }
            Window2 myWindow = new Window2();
            myWindow.dtgTuoiMax.ItemsSource = dsTuoiMax;
            myWindow.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dpNgaySinh.SelectedDate = DateTime.Now;
        }
        private bool isKiemTra()
        {
            if (txtMaNV.Text == "")
            {
                MessageBox.Show("Chưa nhập mã nhân viên", "Lỗi dữ liệu", MessageBoxButton.OK, MessageBoxImage.Error);
                txtMaNV.Focus();
                return false;
            }
            if (txtHoTen.Text == "")
            {
                MessageBox.Show("Chưa nhập tên nhân viên", "Lỗi dữ liệu", MessageBoxButton.OK, MessageBoxImage.Error);
                txtHoTen.Focus();
                return false;
            }
            if (txtHeSoLuong.Text == "")
            {
                MessageBox.Show("Chưa nhập hệ số lương", "Lỗi dữ liệu", MessageBoxButton.OK, MessageBoxImage.Error);
                txtHeSoLuong.Focus();
                return false;
            }
            try
            {
                double.Parse(txtHeSoLuong.Text);
            }
            catch(Exception)
            {
                MessageBox.Show("Nhập số thực", "Lỗi dữ liệu", MessageBoxButton.OK, MessageBoxImage.Error);
                txtHeSoLuong.SelectAll();
                txtHeSoLuong.Focus();
                return false;
            }
            int tuoi = DateTime.Now.Year - dpNgaySinh.SelectedDate.Value.Year;
            if (tuoi < 18)
            {
                MessageBox.Show("Tuổi phải lớn hơn 18", "Lỗi dữ liệu", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
    }
}