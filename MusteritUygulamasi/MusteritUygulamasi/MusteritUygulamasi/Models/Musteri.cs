using Microsoft.EntityFrameworkCore;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace MusteritUygulamasi.Models
{
    public class Musteri : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        [AutoIncrement]
        private int musterid { get; set; }
        private string musteriadi { get; set; } = string.Empty;
        private string musterisoyadi { get; set; } = string.Empty;
        private string musteritel { get; set; } = string.Empty;
        private string musterieposta { get; set; } = string.Empty;

        public int MusteriId
        {
            get { return musterid; }
            set { musterid = value; OnPropertyChanged("MusteriId"); }
        }

        public string MusteriAdi
        {
            get { return musteriadi; }
            set { musteriadi = value; OnPropertyChanged("MusteriAdi"); }
        }

        public string MusteriSoyadi
        {
            get { return musterisoyadi; }
            set { musterisoyadi = value; OnPropertyChanged("MusteriSoyadi"); }
        }

        public string MusteriTel
        {
            get { return musteritel; }
            set { musteritel = value; OnPropertyChanged("MusteriTel"); }
        }

        public string MusteriEposta
        {
            get { return musterieposta; }
            set { musterieposta = value; OnPropertyChanged("MusteriEposta"); }
        }


    }
}
