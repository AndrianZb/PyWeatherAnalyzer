using IoT_WeatherStationApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace IoT_WeatherStationApp.Services {
    public class PageDataTemplateSelector : DataTemplateSelector {

        public DataTemplate Page1 { get; set; }
        public DataTemplate Page2 { get; set; }
        public DataTemplate Page3 { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container) {
            switch(((MyText)item).Page) {
                case 1:
                    return Page1;
                case 2:
                    return Page2;
                case 3:
                    return Page3;
                default:
                    return Page1;

            }
        }
    }
}
