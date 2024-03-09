using MusteritUygulamasi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MusteritUygulamasi
{
    /// <summary>
    /// MusteriEklemePenceresi.xaml etkileşim mantığı
    /// </summary>
    public partial class MusteriEklemePenceresi : Window
    {
        public MusteriEklemePenceresi()
        {
            InitializeComponent();
        }

        public void Create()
        {

            using (MusteriContext context = new MusteriContext())
            {

                var musteriadi = musteriadiTextBox.Text;
                var musterisoyadi = musterisoyadiTextBox.Text;
                var musteritel = musteritelTextBox.Text;
                var musterieposta = musteriepostaTextBox.Text;

                //if kontrolü yap

                context.Musteriler.Add(new Musteri()
                {
                    MusteriAdi = musteriadi,
                    MusteriSoyadi = musterisoyadi,
                    MusteriTel = musteritel,
                    MusteriEposta = musterieposta
                });

                context.SaveChanges();

              }




        }

        private void musteriyiekle_Click(object sender, RoutedEventArgs e)
        {

             Create();
             this.Close();

        }


    }
}
