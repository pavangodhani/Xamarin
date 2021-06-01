using AssetInfo.Models;
using AssetInfo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AssetInfo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AssetOverViewPage : ContentPage
    {
        public AssetOverViewPage()
        {
            InitializeComponent();
        }

        private async void Save_Button_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("", "Your Asset Successfully Added", "OK");

            await Navigation.PushAsync(new ActionOverViewPage());
        }
    }
}