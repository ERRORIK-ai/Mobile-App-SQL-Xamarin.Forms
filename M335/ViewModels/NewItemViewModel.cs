using M335.Models;
using M335.Services;
using M335.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace M335.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(Title)
                && !String.IsNullOrWhiteSpace(Name)
                && !Year.Equals(null)
                && Year >= 1980 && Year < 10000;
        }


        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            try
            {
                Item newItem = new Item()
                {
                    Id = 0,
                    Title = Title,
                    Name = Name,
                    Year = Year.HasValue ? (int)Year : 0
                };

                if (_database == null)
                {
                    _database = await ItemDatabase.Instance;
                }
                var item = await _database.SaveItemAsync(newItem);

                //await DataStore.AddItemAsync(newItem);

                // This will pop the current page off the navigation stack
                await Shell.Current.GoToAsync("..");

            }
            catch (Exception ex)
            {               
                await DisplayAlert("Fehler", $"Es ist ein Fehler aufgetreten.{ Environment.NewLine}{ex.Message}", "Ok");
            }
        }
    }
}
