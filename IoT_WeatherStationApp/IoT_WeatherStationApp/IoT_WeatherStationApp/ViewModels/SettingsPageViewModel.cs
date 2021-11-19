using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace IoT_WeatherStationApp.ViewModels {
    public class SettingsPageViewModel : ViewModelBase {

        private bool darkTheme;

        public bool DarkTheme {
            get => darkTheme;
            set {
                SetProperty(ref darkTheme, value);
                SwitchAppTheme(darkTheme);
            }
        }

        private void SwitchAppTheme(bool enableDarkTheme) {
            if(enableDarkTheme) {
                Application.Current.UserAppTheme = OSAppTheme.Dark;
            } else {
                Application.Current.UserAppTheme = OSAppTheme.Light;
            }
        }

        public SettingsPageViewModel() {
            DarkTheme = false;
        }

    }
}
