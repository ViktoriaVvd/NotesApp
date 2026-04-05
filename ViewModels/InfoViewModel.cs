using System;
using System.Collections.Generic;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace NoteApp.ViewModels
{
    public partial class InfoViewModel: ObservableObject
    {
        [ObservableProperty]
        private string deviceInfoModel = DeviceInfo.Current.Model;

        [ObservableProperty]
        private string deviceInfoPlatform = DeviceInfo.Current.Platform.ToString();

        [ObservableProperty]
        private string deviceInfoVersion = DeviceInfo.Current.VersionString;

        [ObservableProperty]
        private double deviceInfoBattery = Math.Round(Battery.Default.ChargeLevel * 100);

        [ObservableProperty]
        private string netInfo = Connectivity.Current.NetworkAccess.ToString();

        [RelayCommand]
        private async Task GoBack()
        {
            await Shell.Current.GoToAsync("//MainPage");
        }

    }


    }

