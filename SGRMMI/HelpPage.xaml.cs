using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SGRMMI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HelpPage : ContentPage
    {
        public HelpPage()
        {
            InitializeComponent();
        }

        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private async void JoinQQGroup_Clicked(object sender, EventArgs e)
        {
            await Browser.OpenAsync("https://jq.qq.com/?_wv=1027&k=Jmd9pg4o", BrowserLaunchMode.SystemPreferred);
        }

        private async void ConAuthor_Clicked(object sender, EventArgs e)
        {
            await Browser.OpenAsync("http://wpa.qq.com/msgrd?v=1&uin=321355478", BrowserLaunchMode.SystemPreferred);
        }
    }
}