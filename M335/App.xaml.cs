using M335.Services;
using M335.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace M335
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();

            //MainPage = new ItemsPage();
            //MainPage = new AboutPage();
            //MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
