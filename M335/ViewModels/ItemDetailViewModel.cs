using M335.Models;
using M335.Services;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace M335.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private int itemId;
        public new int Id { get; set; }

        public int ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(int itemId)
        {
            try
            {
                if (_database == null)
                {
                    _database = await ItemDatabase.Instance;
                }
                var item = await _database.GetItemAsync(itemId);

                Id = item.Id;
                Name = item.Name;
                Title = item.Title;
                Year = item.Year;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
