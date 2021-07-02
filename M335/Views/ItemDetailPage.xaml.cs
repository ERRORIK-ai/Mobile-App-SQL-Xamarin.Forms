using M335.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace M335.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}