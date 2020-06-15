using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;
using System.IO;


namespace SGRMMI
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        // api: http://api.mtyqx.cn/api/random.php
        private string apiURL;
        private string imageURL;
        private string path;
        private Random rand;
        private HttpClient client;
        private HelpPage helpPage;
        public MainPage()
        {
            this.apiURL = "http://api.mtyqx.cn/api/random.php";
            this.imageURL = "https://i0.hdslb.com/bfs/album/f7ca933dee5f9cdf486b3dd399a8649001261965.jpg";
            this.path = "/storage/emulated/0/DCIM/SGRMMI";
            this.rand = new Random();
            this.client = new HttpClient();
            this.helpPage = new HelpPage();

            if (!Directory.Exists(this.path))
            {
                Directory.CreateDirectory(this.path);
            }
            InitializeComponent();

            DisplayAlert("Sugobet", "欢迎使用SGRMMI(纸片人老婆图片获取器)。使用过程若遇到问题请点击“帮助”按钮\n如果无法保存图片请手动给予本软件'储存空间'权限!", "好的,老哥");
        }

        private async void GetImageButton_Clicked(object sender, EventArgs e)
        {
            Lodingg.IsRunning = true;
            var result = await this.client.GetAsync(this.apiURL);
            this.imageURL = result.RequestMessage.RequestUri.ToString();

            MMImage.Source = this.imageURL;
            Lodingg.IsRunning = false;
        }

        private async void SaveImageButton_Clicked(object sender, EventArgs e)
        {
            string imgName = $"{this.rand.Next(999999999)}.jpg";
            byte[] imgStream = await this.client.GetByteArrayAsync(this.imageURL);
            File.WriteAllBytes($"{this.path}/{imgName}", imgStream);
            await DisplayAlert("Sugobet", $"图片“{imgName}”已保存到相册(/storage/emulated/0/DCIM/SGRMMI/)\n请到相册中查看", "好的,感谢老哥");
        }

        private async void HelpButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(this.helpPage);
        }
    }
}
