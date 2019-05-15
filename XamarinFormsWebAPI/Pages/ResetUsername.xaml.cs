using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApiApplication.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFormsWebAPI.API;
using XamarinFormsWebAPI.Model;

namespace XamarinFormsWebAPI.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ResetUsername : ContentPage
	{
        public string email = "";
        public string otpString="";
        public ResetUsername (string emailAddr)
		{
            email = emailAddr;

           // email= txtRUsername.Text;
            //otpString = otp;
            InitializeComponent();
            btnSendOTP.Clicked += SendOTP_Clicked;
            btnResertUsername.Clicked += btnResertUsername_Clicked;
        }

        //send  an otp
        private async void SendOTP_Clicked(object sender, EventArgs e)
        {
            string num = "0123456789";
            int len = num.Length;
            string otp = string.Empty;
            //number of digit per otp
            int otpdigit = 5;
            string finaldigit;
            int getindex;
            for (int i = 0; i < otpdigit; i++)
            {
                do
                {
                    getindex = new Random().Next(0, len);
                    finaldigit = num.ToCharArray()[getindex].ToString();
                }
                while (otp.IndexOf(finaldigit) != -1);
                otp += finaldigit;
            }
            otpString = otp;
            email = txtRUsername.Text;


            if (txtRUsername.Text != null)
            {
                confirmOTP saveOTP = new confirmOTP()
                {
                EmailAddress = email,
                NewEmail=txtResetUsername.Text,
                OTP = otpString
                };
           
                var json = JsonConvert.SerializeObject(saveOTP);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpClient client = new HttpClient();
                var response = await client.PutAsync("http://192.168.0.53:45455/Api/GetOTP", content);
                if (response.IsSuccessStatusCode)
                {

                    await DisplayAlert("OTP", "OTP was sent successful to "+ txtResetUsername.Text, "OK");
                }
                else
                {
                    await DisplayAlert("Claim", "Fail to send OTP", "Re-try");
                }
            }
            else
            {
                await DisplayAlert("Username", "Username is required", "Try again");
            }

        }

            private async void btnResertUsername_Clicked(object sender, EventArgs e)
            {

                IMyAPI myAPI;

                Client username = new Client();

                myAPI = RestService.For<IMyAPI>("http://192.168.0.53:45455/");
                username.NewEmail = txtResetUsername.Text;
                username.EmailAddress = email;
                username.Password = txtRPassword.Text;

                confirmOTP conf = new confirmOTP
                {
                    EmailAddress = txtResetUsername.Text
                };

                if(txtResetUsername.Text!=email && txtResetUsername.Text!="")
                { 
                    var json = JsonConvert.SerializeObject(conf);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpClient client = new HttpClient();

                    var response = await client.PostAsync(string.Concat(" http://192.168.0.53:45455/Api/GetOTP?EmailAddress=" + txtResetUsername.Text), content);
                    var results = response.Content.ReadAsStringAsync().Result;
                    var otpdata = JsonConvert.DeserializeObject<List<confirmOTP>>(results);
                    var myObject = otpdata[0];


                    if (txtRPassword.Text == txtRConfirmPassword.Text && txtOTP.Text == myObject.OTP /*&& txtResetUsername.Text != myObject.EmailAddress*/)
                    {

                        var result = await myAPI.ResertUser(username);
                        await DisplayAlert("Username", "Reset successful ", "Ok");

                        await Navigation.PushAsync(new MainPage());
                    }
                    else
                    {
                        await DisplayAlert("Username ", "Username do not match", "Re-type");
                    }
                
                }
               else
                {
                    await DisplayAlert("New username","specify your new email address","Try again");
                }
            }
        }
    }