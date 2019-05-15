using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFormsWebAPI.API;
using XamarinFormsWebAPI.Model;

namespace XamarinFormsWebAPI
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegisterPage : ContentPage
	{
		public RegisterPage ()
		{
			InitializeComponent ();


            btnRegister.Clicked += BtnRegister_Clicked1;


        }


        private async void BtnRegister_Clicked1(object sender, EventArgs e)
        {
            IMyAPI myAPI;

            tblUser user = new tblUser();


            myAPI = RestService.For<IMyAPI>("http://192.168.0.53:45455");

            user.EmailAddress = txtname.Text;
            user.Password = txtpassword.Text;
            user.FirstName = txtFirstname.Text;

            bool gender;
            if (txtGender.SelectedItem.ToString() == "Male")
            {
                gender = true;
            }
            else
            {
                gender = false;
            }


            user.IsMale =gender;
        
            user.LastName = txtLastname.Text;

            if (txtpassword.Text == txtConfirmpassword.Text)
            {
                var results = await myAPI.RegisterUser(user);
                await DisplayAlert("Register", "You have succesful Registered", "Ok");
                await Navigation.PushAsync(new MainPage());
            }
            else
            {
                await DisplayAlert("Password", "Password do not match", "Re-type Password");
            }
        }

     
    }
}