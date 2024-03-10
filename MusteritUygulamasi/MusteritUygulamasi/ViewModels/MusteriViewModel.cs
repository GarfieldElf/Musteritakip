using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using MusteritUygulamasi.Models;
using MusteritUygulamasi.Commands;
using System.Collections.ObjectModel;

namespace MusteritUygulamasi.ViewModels
{
    public class MusteriViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

            }
        }

        MusteriService ObjMusteriService;
        public MusteriViewModel()
        {
            ObjMusteriService = new MusteriService();
            LoadData();
            CurrentMusteri = new Musteri();
            saveCommand = new RelayCommand(Save);
        }

        private ObservableCollection<Musteri> musterilerList;

        public ObservableCollection<Musteri> MusterilerList
        {
            get { return musterilerList; }
            set { musterilerList = value; OnPropertyChanged("MusterilerList"); }
        }

        private void LoadData()
        {
            MusterilerList = new ObservableCollection<Musteri>(ObjMusteriService.GetAll());
        }

        //------------------------------------------------------------------------------------//

        private Musteri? currentMusteri;

        public Musteri? CurrentMusteri
        {
            get { return currentMusteri; }
            set { currentMusteri = value; OnPropertyChanged("CurrentMusteri"); }
        }
        private string message;

        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged("Message"); }
        }


        private RelayCommand saveCommand;

        public RelayCommand SaveCommand
        {
            get { return saveCommand; }
        }

        public void Save()
        {
            try
            {
                var isSaved = ObjMusteriService.Add(CurrentMusteri);
                LoadData();
                if(isSaved)
                    Message = "Musteri Kaydedildi.";
                else
                    Message = "Musteri Kaydedilemedi.";


            }

            catch(Exception ex)
            {
                Message = ex.Message;
            }
        }



    }
}
