using System.Collections.ObjectModel;
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

namespace Bai9_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {   
        public ObservableCollection<string> AvailableBooks { get; set; } 
        public ObservableCollection<string> ChosenBooks { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            AvailableBooks = new ObservableCollection<string>
            {
                "Công nghệ thực tại ảo",
                "Đảm bảo chất lượng phần mềm",
                "Giải thuật di truyền và ứng dụng",
                "Hệ chuyên gia",
                "Lập trình căn bản",
                "Lập trình hướng đối tượng",
                "Lập trình mạng",
                "Lập trình trên Windows",
                "Một số phương pháp tính toán mềm",
                "Nhập môn tin học",
                "Phân tích thiết kế hệ thống",
                "Phân tích và thống kê số liệu",
                "Thiết kế Cơ sở dữ liệu",
                "Thiết kế trang Web",
                "Tin Văn Phòng"
            };
            ChosenBooks = new ObservableCollection<string>();
            this.DataContext = this;
        }

      
        private void MoveSelectedToChoose_Click(object sender, RoutedEventArgs e)
        {
            var selectedItems = lbDanhSach.SelectedItems.Cast<string>().ToList();
            foreach (var item in selectedItems)
            {
                AvailableBooks.Remove(item);
                ChosenBooks.Add(item);
            }
        }

        private void MoveAllToChoose_Click(object sender, RoutedEventArgs e)
        {
            var allItems = AvailableBooks.ToList();
            foreach (var item in allItems)
            {
                AvailableBooks.Remove(item);
                ChosenBooks.Add(item);
            }
        }

        private void MoveSelectedToList_Click(object sender, RoutedEventArgs e)
        {
            var selectedItems = lbChosenBooks.SelectedItems.Cast<string>().ToList();
            foreach (var item in selectedItems)
            {
                ChosenBooks.Remove(item);
                AvailableBooks.Add(item);
            }
        }
        private void MoveAllToList_Click(object sender, RoutedEventArgs e)
        {
            var allItems = ChosenBooks.ToList();
            foreach (var item in allItems)
            {
                ChosenBooks.Remove(item);
                AvailableBooks.Add(item);
            }
        }
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}