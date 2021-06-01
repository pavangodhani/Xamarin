using AssetInfo.Models;
using AssetInfo.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AssetInfo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActionOverViewPage : ContentPage
    {
        public IMockAssetInfoService _assetInfoService;
       
        public ActionOverViewPage()
        {
            InitializeComponent();
            _assetInfoService = new MockAssetInfoService();
        } 

        private async void GetAssets_Button_Clicked(object sender, EventArgs e)
        {
            var assets = _assetInfoService.GetAssets();

            await Navigation.PushAsync(new AssetDetailPage(assets));
        }

        private async void GetAssetsForMachineType_Button_Clicked(object sender, EventArgs e)
        {
            string machineType = await DisplayPromptAsync("Enter Machine Type", "");

            if (!String.IsNullOrEmpty(machineType))
            {
                var assetsForMachineType =
                    _assetInfoService.GetAssetsForMachineType(machineType);

                if (assetsForMachineType.Count() != 0)
                {
                    await Navigation.PushAsync(new AssetDetailPage(assetsForMachineType));
                }
            }
        }

        private async void GetAssetsWithLatestSeriesNo_Button_Clicked(object sender, EventArgs e)
        {
            var assetsWithLatestSeriesNo = 
                _assetInfoService.GetAssetsWithLatestSeriesNo();

            await Navigation.PushAsync(new AssetDetailPage(assetsWithLatestSeriesNo));
        }

        private async void GetMachinesForAsset_Button_Clicked(object sender, EventArgs e)
        {
            string assetName = await DisplayPromptAsync("Enter Asset's Name", "");

            if (!String.IsNullOrEmpty(assetName))
            {
                var machinesForAsset =
                    _assetInfoService.GetMachinesForAsset(assetName);

                if (machinesForAsset.Count() != 0)
                {
                    await Navigation.PushAsync(new AssetDetailPage(machinesForAsset));
                }
            }
        }

        private async void AddAsset_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AssetOverViewPage());
        }

        private async void Download_Button_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("", "Zip Downloaded", "OK");
        }
    }
}