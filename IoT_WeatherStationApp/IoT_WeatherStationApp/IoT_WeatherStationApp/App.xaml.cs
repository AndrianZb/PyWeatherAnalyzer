
using IoT_WeatherStationApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IoT_WeatherStationApp {
    public partial class App : Application {

        public App() {
            InitializeComponent();

            MainPage = new AppShell();

            Device.SetFlags(new string[] { "AppTheme_Experimental" });
        }

        protected override void OnStart() {
        }

        protected override void OnSleep() {
        }

        protected override void OnResume() {
        }
    }
}
