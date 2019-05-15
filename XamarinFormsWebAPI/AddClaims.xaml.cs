using Newtonsoft.Json;
using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFormsWebAPI.Model;

namespace XamarinFormsWebAPI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddClaims : ContentPage
    {

        public int idClient=0;

        public string username;

        public string select;


        private MediaFile mediaFile;
        FileData file;




        public AddClaims()
        {

            InitializeComponent();
        }
        public AddClaims(int clientId,string email)
        {
            InitializeComponent();
            //GetClaimType();
            //idClient = clientId;
            //txtClientID.Text = clientId.ToString();
             idClient = clientId;
            username = email;
            //Claims claim = new Claims()
            //{
            //    IDClient = idClient,
            //    Status1 = txtStatus1.SelectedItem.ToString(),
            //    //TypeOfClaim = txtTypeOfClaim.SelectedItem.ToString(),
            //    //Status1 = txtStat.Text,
            //    //TypeOfClaim = txtTypeOfCl.Text,
            //    ClaimNo = txtClaimNo.Text,
            //    Month1 = txtMonth.Text,
            //    Year1 = txtYear.Text,

            //    Comments = txtYear.Text + " /" + txtMonth.Text + " - " + txtClientID.Text + " - " + txtComment.Text,
            //    UserName = txtUsername.Text
            //};
        }

        
        //Add a Claim
        private async void btnClaim_clicked(object sender, EventArgs e)
        {
            
            var GetStatus = txtStatus.SelectedItem as Retention;
            string Status = ""; 


            if (GetStatus != null && Status != null)
            {

                Status = GetStatus.RetentionStatus.ToString();
                DateTime today = DateTime.Now;

                Claims claim = new Claims()
                {
                    IDClient = idClient,
                    UnpaidReason = txtStatus1.SelectedItem.ToString(),



                    Status1 = Status,
                    //Status1 = txtStat.Text,
                    //TypeOfClaim = txtTypeOfCl.Text,
                    //ClaimNo = txtClaimNo.Text,
                    //Month1 = txtMonth.Text,
                    //Year1 = txtYear.Text,

                    Comments = idClient + " " + today + " " + txtComment.Text,
                    // UnpaidReason = txtUnpaidReason.Text
                };



                // GetClaimType(txtStatus1.SelectedItem.ToString());

                var json = JsonConvert.SerializeObject(claim);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpClient client = new HttpClient();
                var response = await client.PostAsync("http://192.168.0.53:45455/Api/Claim", content);
                if (response.IsSuccessStatusCode)
                {
                    await DisplayAlert("Claim", "Your claim was succesful", "Ok");
                }
                else
                {
                    await DisplayAlert("Claim", "Your claim was not succesful", "Re-try");
                }



            }
            else
            {



                 await DisplayAlert("Claim", "Select status", "Ok");
            }
            
        }


        async void OnSubStatusChosen(object sender, EventArgs e)
        {

            HttpClient client = new HttpClient();
            Retention retention = new Retention()
            {
                
                RetentionType = txtStatus1.SelectedItem.ToString()
               
            };

            

            var json = JsonConvert.SerializeObject(retention);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

       

            var response = await client.PostAsync(string.Concat("http://192.168.0.53:45455/Api/Retention?RetentionType=" + txtStatus1.SelectedItem.ToString()), content);
            var results = response.Content.ReadAsStringAsync().Result;
            var retentionStatus = JsonConvert.DeserializeObject<List<Retention>>(results);
            //listClaims.ItemsSource = currentUser;

            txtStatus.ItemsSource = retentionStatus;

            



        }

        //Take a Picture


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

        //


        //pick a file eg pdf or doc
        private async void PickFile_Clicked(object sender, EventArgs e)
        {
            file = await CrossFilePicker.Current.PickFile();

            if (file != null)
            {
                LocalPathLabel.Text = file.FileName;
       
            }
        }

        


        private async void PhotoUploadClicked(object sender, EventArgs e)
        {
            var content = new MultipartFormDataContent();
           
            if (mediaFile != null)
            {


                content.Add(new StreamContent(file.GetStream()),
                "\"file\"",
                $"\"{mediaFile.Path}\"");
                var httpClient = new HttpClient();
                var uploadServiceBaseAddress = "http://192.168.0.53:45455/Api/UploadImage";
                var httpResponseMessage = await httpClient.PostAsync(uploadServiceBaseAddress, content);
                RemotePathLabel.Text = await httpResponseMessage.Content.ReadAsStringAsync();

            }
            else
            {

                await DisplayAlert("Error", "Please take a Photo an click Upload Photo", "Ok");
            }

        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            var content = new MultipartFormDataContent();
            if (file != null)
            {

                content.Add(new StreamContent(file.GetStream()),
               "\"file\"",
               $"\"{file.FilePath}\"");
                var httpClient = new HttpClient();
                var uploadServiceBaseAddress = "http://192.168.0.53:45455/Api/Upload";
                var httpResponseMessage = await httpClient.PostAsync(uploadServiceBaseAddress, content);
                RemotePathLabel.Text = await httpResponseMessage.Content.ReadAsStringAsync();


            }

            else
            {
                await DisplayAlert("Error", "Please Pick a File and click Upload", "Ok");


            }

           

        }





    }
}