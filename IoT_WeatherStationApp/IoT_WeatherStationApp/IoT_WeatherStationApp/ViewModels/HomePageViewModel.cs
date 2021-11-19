using IoT_WeatherStationApp.Models;
using Microcharts;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace IoT_WeatherStationApp.ViewModels {
    public class HomePageViewModel : ViewModelBase {

        public Chart LineChart { get; set; }
        public Chart BarChart { get; set; }
        public Chart PieChart { get; set; }

        public ObservableCollection<MyText> CarouselPages { get; set; }

        public AsyncCommand RefreshCommand { get; }

        public HomePageViewModel() {
            RefreshCommand = new AsyncCommand(Refresh);

            CarouselPages = new ObservableCollection<MyText>();
            CarouselPages.Add(new MyText { LabelText = "Page1", Page = 1 });
            CarouselPages.Add(new MyText { LabelText = "Page2", Page = 2 });
            CarouselPages.Add(new MyText { LabelText = "Page3", Page = 3 });

            ReloadChartData();
        }

        public void ReloadChartData() {
            SKColor backgroundColor = SKColor.Empty;
            SKColor textColor = SKColor.Empty;
            if(Application.Current.UserAppTheme == OSAppTheme.Dark) {
                backgroundColor = SKColor.Parse("#616161");
                textColor = SKColor.Parse("#FFFFFF");
            }

            LineChart = new LineChart() { Entries = GetMockData(), LabelOrientation = Orientation.Horizontal, ValueLabelOrientation = Orientation.Horizontal, LabelTextSize = 24, BackgroundColor = backgroundColor, LabelColor = textColor };
            BarChart = new BarChart() { Entries = GetMockData(), LabelOrientation = Orientation.Horizontal, ValueLabelOrientation = Orientation.Horizontal, LabelTextSize = 24, BackgroundColor = backgroundColor, LabelColor = textColor };
            PieChart = new PieChart() { Entries = GetMockData(), LabelTextSize = 24, BackgroundColor = backgroundColor, LabelColor = textColor };

            OnPropertyChanged("LineChart");
            OnPropertyChanged("BarChart");
            OnPropertyChanged("PieChart");
        }

        private async Task Refresh() {
            IsBusy = true;

            await Task.Delay(1000);

            ReloadChartData();

            IsBusy = false;
        }

        private ChartEntry[] GetMockData() {
            var entries = new[] {
            new ChartEntry(0)
                {
                    Label = "1PM",
                    ValueLabel = "0",
                    Color = SKColor.Parse("#2c3e50")
                },
                new ChartEntry(4)
                {
                    Label = "2PM",
                    ValueLabel = "4",
                    Color = SKColor.Parse("#77d065")
                },
                new ChartEntry(10)
                {
                    Label = "3PM",
                    ValueLabel = "10",
                    Color = SKColor.Parse("#b455b6")
                },
                new ChartEntry(6)
                {
                    Label = "4PM",
                    ValueLabel = "6",
                    Color = SKColor.Parse("#3498db")
                },
                new ChartEntry(11)
                {
                    Label = "5PM",
                    ValueLabel = "11",
                    Color = SKColor.Parse("#3498db")
                },
                new ChartEntry(7)
                {
                    Label = "6PM",
                    ValueLabel = "7",
                    Color = SKColor.Parse("#3498db")
                },
                new ChartEntry(9)
                {
                    Label = "7PM",
                    ValueLabel = "9",
                    Color = SKColor.Parse("#3498db")
                },
                new ChartEntry(9)
                {
                    Label = "8PM",
                    ValueLabel = "9",
                    Color = SKColor.Parse("#3498db")
                },
                new ChartEntry(12)
                {
                    Label = "9PM",
                    ValueLabel = "12",
                    Color = SKColor.Parse("#3498db")
                },
                new ChartEntry(7)
                {
                    Label = "10PM",
                    ValueLabel = "7",
                    Color = SKColor.Parse("#3498db")
                },
                new ChartEntry(4)
                {
                    Label = "11PM",
                    ValueLabel = "4",
                    Color = SKColor.Parse("#3498db")
                },
                new ChartEntry(3)
                {
                    Label = "12AM",
                    ValueLabel = "3",
                    Color = SKColor.Parse("#3498db")
                },
                new ChartEntry(5)
                {
                    Label = "1AM",
                    ValueLabel = "5",
                    Color = SKColor.Parse("#3498db")
                },
                new ChartEntry(1)
                {
                    Label = "2AM",
                    ValueLabel = "1",
                    Color = SKColor.Parse("#3498db")
                },
            };

            return entries;
        }
    }
}
