using Microsoft.EntityFrameworkCore;
using MusteritUygulamasi.Model;
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

namespace MusteritUygulamasi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Musteri> DatabaseMusteriler { get; private set; } = null!;

        public MainWindow()
        {
            InitializeComponent();

        }

        private void Musteri_Click(object sender, EventArgs e)
        {
            Hide();
            new MusteriEklemePenceresi().ShowDialog();
            ShowDialog();

        }


        public void Read()
        {

            using(MusteriContext context = new MusteriContext())
            {
                DatabaseMusteriler = context.Musteriler.ToList();
                MusteriList.ItemsSource = DatabaseMusteriler;
            }
        }

        private void musterigetir_Click(object sender, RoutedEventArgs e)
        {
            Read();
        }
    }

}
