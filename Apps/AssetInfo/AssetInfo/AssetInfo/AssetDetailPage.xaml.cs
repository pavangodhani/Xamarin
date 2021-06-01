using AssetInfo.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AssetInfo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AssetDetailPage : ContentPage
    {
        public AssetDetailPage(IEnumerable<Asset> assets)
        {
            InitializeComponent();

            AssetInfoView.ItemsSource = assets;
        }
    }
}