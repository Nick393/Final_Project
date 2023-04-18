using Hello_World.Services;
using Hello_World.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hello_World
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
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
