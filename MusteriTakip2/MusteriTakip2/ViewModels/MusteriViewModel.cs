using MusteriTakip2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity.Validation;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MusteriTakip2.ViewModels
{
    public class MusteriViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }

        private ObservableCollection<Musteriler> _lstmusteri;

        public ObservableCollection<Musteriler> LstMusteri
        {
            get { return _lstmusteri; }
            set { _lstmusteri = value; OnPropertyChanged(nameof(LstMusteri)); }
        }


        private Musteriler _musteriler = new Musteriler();

        public Musteriler Musteriler
        {
            get { return _musteriler; }
            set { _musteriler = value; OnPropertyChanged(nameof(Musteriler)); }
        }

        //----------------------------------------------------------------------------//


        MusteriEntities musterientities;

        public MusteriViewModel()
        {
            musterientities = new MusteriEntities();
            LoadMusteri();
            DeleteCommand = new Command((s) => true, Delete);
            AddMusteriCommand = new Command((s) => true, AddMusterii);
        }

        private void AddMusterii(object obj)
        {
            Musteriler.MusteriId = musterientities.Musterilers.Count();
            musterientities.Musterilers.Add(Musteriler);
            musterientities.SaveChanges();
           
            LstMusteri.Add(Musteriler);
            Musteriler = new Musteriler();
        }

        private void Delete(object obj)
        {
            var mst = obj as Musteriler;
            musterientities.Musterilers.Remove(mst);
            musterientities.SaveChanges();
            LstMusteri.Remove(mst);
        }

        private void LoadMusteri()
        {
            LstMusteri = new ObservableCollection<Musteriler>(musterientities.Musterilers);
        }
        public ICommand DeleteCommand { get; set; }

        public ICommand AddMusteriCommand { get; set; }

        class Command : ICommand
        {
            public Command(Func<object, bool> methodCanExecute, Action<object> methodExecute)
            {
                MethodCanExecute = methodCanExecute;
                MethodExecute = methodExecute;
            }

            Action<object> MethodExecute;
            Func<object, bool> MethodCanExecute;
            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                return MethodExecute != null && MethodCanExecute.Invoke(parameter);
            }

            public void Execute(object parameter)
            {
                MethodExecute(parameter);
            }
        }

    }



}