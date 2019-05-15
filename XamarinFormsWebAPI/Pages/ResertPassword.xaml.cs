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
	public partial class ResertPassword : ContentPage
	{
        //public string emailAddr = "";
        //public string otpString="";
		public ResertPassword (/*string otp,string email*/)
		{
            //emailAddr = email;
            //otpString = otp;
            InitializeComponent ();
            btnSendOTP.Clicked += SendOTP_Clicked;
            btnResertPassword.Clicked += btnResertPassword_Clicked;
        }

        //send otp
        public string emailOTP = "";
        public string email = "";
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
            emailOTP = otp;
            email = txtRUsername.Text;
            //await Navigation.PushAsync(new ResertPassword(emailOTP, email));

            confirmOTP saveOTP = new confirmOTP()
            {
                EmailAddress = email,
                OTP = emailOTP
            };

            var json = JsonConvert.SerializeObject(saveOTP);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpClient client = new HttpClient();
            var response = await client.PutAsync("http://192.168.0.53:45455/Api/OTP", content);
            if (response.IsSuccessStatusCode)
            {

                await DisplayAlert("OTP", "OTP sent successful", "Ok");
            }
            else
            {
                await DisplayAlert("Claim", "Fail to send OTP", "Re-try");
            }

        }



        private async void btnResertPassword_Clicked(object sender, EventArgs e)
        {

            IMyAPI myAPI;

            Client user = new Client();

            myAPI = RestService.For<IMyAPI>("http://192.168.0.53:45455/");

            user.EmailAddress = email;
            user.Password = txtRPassword.Text;


            confirmOTP conf = new confirmOTP
            {
                EmailAddress = email
            };

            var json = JsonConvert.SerializeObject(conf);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpClient client = new HttpClient();

            var response = await client.PostAsync(string.Concat(" http://192.168.0.53:45455/Api/GetOTP?EmailAddress=" + email), content);
            var results = response.Content.ReadAsStringAsync().Result;
            var otpdata = JsonConvert.DeserializeObject<List<confirmOTP>>(results);
            var myObject = otpdata[0];

            if (txtRPassword.Text == txtRConfirmPassword.Text && txtOTP.Text == myObject.OTP)
                {
                    var result = await myAPI.ResertPass(user);
                    await DisplayAlert("Password", "Reset successful ", "Ok");
                
                    await Navigation.PushAsync(new MainPage());
                }
                else
                {
                    await DisplayAlert("Password ", "password do not match", "Re-type");
                }
            
        }

      
    }
}