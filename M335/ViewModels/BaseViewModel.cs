using M335.Models;
using M335.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace M335.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {        
        protected ItemDatabase _database;
        bool isBusy = false;
        private string name;
        private int? year;
        string title = string.Empty;

        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public int? Year
        {
            get => year;
            set => SetProperty(ref year, value);
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
