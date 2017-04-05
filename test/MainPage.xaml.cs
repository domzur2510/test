using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace test
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 


    public sealed partial class MainPage : Page
    {
        UICommand yesCommand = new UICommand("Yes");
        
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new MessageDialog("kontent", "tytul");
            dialog.Options = MessageDialogOptions.None;
            dialog.Commands.Add(yesCommand);
            dialog.DefaultCommandIndex = 0;
            dialog.CancelCommandIndex = 0;
            var command = await dialog.ShowAsync();
            if(command==yesCommand)
            {
                var city = "katowice";
                
                string info = string.Concat("http://api.openweathermap.org/data/2.5/weather?q=", city, "&APPID=3359dc05f9bc2f3661d3f68662b9771a");
                HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(info);
                myRequest.Method = "GET";
                //WebResponse myResponse = myRequest.GetResponse();
                //StreamReader sr = new StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.UTF8);
               // string result = sr.ReadToEnd();
                //sr.Close();
                //myResponse.Close();
                var request = WebRequest.CreateHttp(info);
                
                textBox.Text=request.ToString();
                
            }
        }

        
    }
}
