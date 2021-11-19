using IoT_WeatherStationApp.ViewModels;
using Microcharts;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IoT_WeatherStationApp.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage {

        public HomePageViewModel viewModel { get; set; }

        public HomePage() {
            InitializeComponent();
        }

        protected override void OnAppearing() {
            base.OnAppearing();
            if(viewModel == null) {
                viewModel = new HomePageViewModel();
                BindingContext = viewModel;
            }

            viewModel.ReloadChartData();
        }

    }
}