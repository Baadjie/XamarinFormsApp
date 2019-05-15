using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Plugin.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinFormsWebAPI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Test1 : ContentPage
    {

        private MediaFile mediaFile;
        FileData file;
        public Test1()
        {
            InitializeComponent();
        }
        private void MakeCallClicked(object sender, EventArgs e)
        {

            var phoneCallTask = CrossMessaging.Current.PhoneDialer;
            if (phoneCallTask.CanMakePhoneCall)
            {
                phoneCallTask.MakePhoneCall("+27821620000", "Xinix Insurance");
            }

        }

        public string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }



        //pick a file eg pdf or doc
        private async void PickFile_Clicked(object sender, EventArgs e)
        {
            file = await CrossFilePicker.Current.PickFile();

            if (file != null)
            {
                LocalPathLabel.Text = file.FileName;
                fileImage.Source = ImageSource.FromStream(() =>

                {
                    return file.GetStream();

                });
            }
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            this.DisplayAlert(" Image Button", "You clicked the FAB!", "Awesome!");
        }


        private async void PickPhoto_Clicked(object sender, EventArgs e)
        {
            //https://github.com/xamarin/XamarinComponents#popular-plugins
            //https://www.c-sharpcorner.com/article/how-to-create-file-picker-in-xamarin-forms/
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {

                await DisplayAlert("No PickPhoto", ": ( No PickPhoto available.", "Ok");
            }
            mediaFile = await CrossMedia.Current.PickPhotoAsync();
            if (mediaFile == null)
                return;

            LocalPathLabel.Text = mediaFile.Path;
            fileImage.Source = ImageSource.FromStream(() =>

            {
                return mediaFile.GetStream();

            });

        }


        private async void Take_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {

                await DisplayAlert("No Camera", ":(No Camera available.", "OK");
                return;
            }
            mediaFile = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
            {
                Directory = "Sample",
                Name = "myImage.jpg"
            });
            if (mediaFile == null)
                return;
            LocalPathLabel.Text = mediaFile.Path;
            fileImage.Source = ImageSource.FromStream(() =>
            {

                return mediaFile.GetStream();
            });

        }





        private async void Button_Clicked(object sender, EventArgs e)
        {
            var content = new MultipartFormDataContent();
            //content.Add(new StreamContent(mediaFile.GetStream()),
            //"\"file\"",
            //$"\"{mediaFile.Path}\"");

            content.Add(new StreamContent(file.GetStream()),
                "\"file\"",
                $"\"{file.FilePath}\"");
            var httpClient = new HttpClient();
            var uploadServiceBaseAddress = "http://192.168.0.53:45455/Api/Upload";
            var httpResponseMessage = await httpClient.PostAsync(uploadServiceBaseAddress, content);
            RemotePathLabel.Text = await httpResponseMessage.Content.ReadAsStringAsync();

        }
    }
}