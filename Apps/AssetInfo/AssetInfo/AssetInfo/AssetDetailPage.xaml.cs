using AssetInfo.Models;
using AssetInfo.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AssetInfo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AssetDetailPage : ContentPage
    {
        IEnumerable<Asset> _assets;
        public AssetDetailPage(IEnumerable<Asset> assets)
        {
            InitializeComponent();

            AssetInfoView.ItemsSource = assets;
            _assets = assets;
        }

        private async void Download_Button_Clicked(object sender, EventArgs e)
        {
            var message = JsonConvert.SerializeObject(_assets);

            DependencyService.Get<IFileService>().CreateFile("AssetInfo.txt", message);

            DependencyService.Get<IFileService>().ZipFile("Asset.zip");

            await DisplayAlert("File Downloaded", $"Path:", "OK");
        }
    }
}