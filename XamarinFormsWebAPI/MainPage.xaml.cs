using Acr.UserDialogs;
using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinFormsWebAPI.API;
using XamarinFormsWebAPI.Model;
using XamarinFormsWebAPI.Pages;

namespace XamarinFormsWebAPI
{
    public partial class MainPage : ContentPage
    {

        public static string globalUsername ;

        public MainPage()
        {
            InitializeComponent();
            //GetLogin();
            ForgotPassword();

            //btnLogin.Clicked += BtnLogin_Clicked;
            // LoginListView_ItemSelected();

            btnSignIn.Clicked += BtnSignIn_Clicked;
           // btnSignUp.Clicked += BtnSignUp_Clicked;
          }


      
        //private async void BtnSignUp_Clicked(object sender, EventArgs e)
        //{
        // //  await NavigationPage
        //}

        //async void Animate()
        //{

        //    var progressAnimation = new Animation(v => cpb.Progress = v, 0, 100);

        //    progressAnimation.Commit(this, "CircularProgressAnimation", 16, 5000, Easing.CubicInOut, null, () => false);

        //    await Task.WhenAll(
        //        cpb.ColorTo(Color.Aqua, Color.Blue, c => cpb.StrokeColor = c, 5000));
        //}

        private async void BtnSignUp_Clicked_1(object sender, EventArgs e)
        {

           // using(IProgressDialog progress = UserDialogs.Instance.Progress("Progress", null, null, true, MaskType.Black))
            {

                for(int i=0;i < 100; i++)
                {

                  //  progress.PercentComplete = i;
                    await Task.Delay(60);
             


                }
                using (UserDialogs.Instance.Loading("Loading", null, null, true, MaskType.Black))
                {

                    await Task.Delay(5000);
                    await Navigation.PushAsync(new RegisterPage());

                }
               

            }
            

            //base.OnAppearing();
            //await Task.Delay(8000);
            //await Navigation.ReplaceRoot(new ShellPage());
        
            // await Navigation.PushAsync(new RegisterPage());

          

        }
        //reset password
        public void ForgotPassword()
        {

            lblForgotPassword.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                    Navigation.PushAsync(new ResertPassword());

                })


            });
        }

        private async void BtnSignIn_Clicked(object sender, EventArgs e)
        {
            //nb   https://www.c-sharpcorner.com/article/xamarin-android-create-login-with-web-api-using-azure-sql-server-part-two/
           // int clientId = 0;

            tblUser user = new tblUser()
            {
                EmailAddress = usernameEntry.Text,
                Password = passwordEntry.Text,
               
            };

            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpClient client = new HttpClient();

            var response = await client.PostAsync(string.Concat("http://192.168.0.53:45455/Api/ClientLogin?EmailAdddress=" + usernameEntry.Text/*, "&Password=" + passwordEntry.Text*/), content);
            var results = response.Content.ReadAsStringAsync().Result;
            var UserInfo = JsonConvert.DeserializeObject<tblUser>(results);



           
            if (UserInfo.Id > 0)
            {
                           
              //using (IProgressDialog progress = UserDialogs.Instance.Progress("Progress", null, null, true, MaskType.Black)) {

                var client_post_hash_password = Convert.ToBase64String(
                        SaltPassword.saltHashPassword(
                        Encoding.ASCII.GetBytes(passwordEntry.Text),
                        Convert.FromBase64String(UserInfo.Salt)));
                        if (client_post_hash_password.Equals(UserInfo.Password))
                        {
                           
                            if (UserInfo.Roles == "Admin")
                            {
                                    for (int i = 0; i < 100; i++)
                                    {

                                      //  progress.PercentComplete = i;
                                        await Task.Delay(60);



                                    }
                                    using (UserDialogs.Instance.Loading("Loading", null, null, true, MaskType.Black))
                                    {
                                        
                                        await Task.Delay(5000);
                                        await Navigation.PushAsync(new HomePage());
                                    }

                            
                            }
                            else if (UserInfo.Roles == "User")
                            {
                                for (int i = 0; i < 100; i++)
                                {

                                   // progress.PercentComplete = i;
                                    await Task.Delay(60);



                                }
                                using (UserDialogs.Instance.Loading("Loading", null, null, true, MaskType.Black))
                                {

                                    await Task.Delay(5000);
                                        await Navigation.PushAsync(new MasterPage(UserInfo.EmailAddress/*,UserInfo.ClientID*/));

                                   globalUsername = UserInfo.EmailAddress;

                            //  await Navigation.PushAsync(new TestCode(UserInfo.EmailAddress/*,UserInfo.ClientID*/));
                        }

                                                      

                            }
                        }
                        else
                        {
                            await DisplayAlert("Login Failed", "Error: Password is incorrect", "Ok");
                        }

                }

                        //else
                     //return JsonConvert.SerializeObject("Wrong Password");
            //}
            else
            {
                await DisplayAlert("Login Failed", "Error: Username is incorrect", "Ok");
                //return JsonConvert.SerializeObject("User not Existing in Database");
            }





            // IMyAPI myAPI;
            // //int userId = 0; ;
            // myAPI = RestService.For<IMyAPI>("http://192.168.0.53:45455");
            // tblUser user = new tblUser();
            // user.UserName = usernameEntry.Text;
            // user.Password = passwordEntry.Text;
            //// user.Id = userId;
            // var results = await myAPI.LoginUser(user);

            // int userId = 2;
            // //userId= Convert.ToInt32(usernameEntry.Text);

            // //if (results.Contains("Success"))

            // //string roles ="User";
            // // {

            // user.Roles = "";

            // if (results.Contains("Pass"))
            //     {
            //         await DisplayAlert("Login", "You have succesful Login", "Ok");
            //         await Navigation.PushAsync(new HomePage());

            //     }

            //     else  if (results.Contains("User"))
            //     {
            //         await DisplayAlert("Login", "You have succesful Login", "Ok");
            //         await Navigation.PushAsync(new UserTabbedPage(userId));

            //     }


            // //}
            // else
            // {

            //     await DisplayAlert("Login", "Failed", "Ok");
            // }

        }




        //private void LoginListView_ItemSelected(object sender,SelectedItemChangedEventArgs e)
        //{

        //    var login = e.SelectedItem as Login;
        //       //Id = Convert.ToInt32(EntID.Text),
        //       // Username = usernameEntry.Text,
        //       // Password = passwordEntry.Text

        //        EntID.Text = login.Id.ToString();
        //    usernameEntry.Text = login.Username;
        //    passwordEntry.Text = login.Password;
        //}

        //private async void GetLogin()
        //{


        //    HttpClient client = new HttpClient();
        //     var response=  await client.GetStringAsync("http://192.168.0.53:45455/Api/Login");


        //    //var response = await client.GetStringAsync("http://10.0.2.2:57757/Api/Login");
        //    var login = JsonConvert.DeserializeObject<List<Login>>(response);
        //    LoginListView.ItemsSource = login;
        //}

        //async void BtnLogin_Clicked(object sender, EventArgs e)
        //{
        //    IMyAPI myAPI;

        //    tblUser user = new tblUser();


        //    myAPI = RestService.For<IMyAPI>("http://192.168.0.53:45455");

        //    user.UserName = usernameEntry.Text;
        //    user.Password = passwordEntry.Text;

        //    var results = await myAPI.RegisterUser(user);
        //    ClearText();

        //    await DisplayAlert("Register", "You have succesful Registered", "Ok");

        //}

        //private async void BtnUpdate_Clicked(object sender, EventArgs e)
        //{

        //    Login login = new Login()
        //    {
        //       // Id = Convert.ToInt32(EntID.Text),
        //        Username = usernameEntry.Text,
        //        Password = passwordEntry.Text
        //    };

        //    var json = JsonConvert.SerializeObject(login);
        //    var content = new StringContent(json, Encoding.UTF8, "application/json");

        //    HttpClient client = new HttpClient();
        //    var results = await client.PutAsync(string.Concat("http://192.168.0.53:45455/Api/Login/", EntID.Text), content);
        //    ClearText();
        //    if (results.IsSuccessStatusCode)
        //    {

        //        await DisplayAlert("Update", "Upadted Succeful", "OK");
        //    }

        //}


        private void ClearText()
        {
            usernameEntry.Text = "";
            passwordEntry.Text = "";
        }
        //private async void BtnDelete_Clicked(object sender, EventArgs e)
        //{
        //    Login login = new Login()
        //    {
        //        // Id = Convert.ToInt32(EntID.Text),
        //        Username = usernameEntry.Text,
        //        Password = passwordEntry.Text
        //    };

        //    var json = JsonConvert.SerializeObject(login);
        //    var content = new StringContent(json, Encoding.UTF8, "application/json");

        //    HttpClient client = new HttpClient();
        //    var results = await client.PutAsync(string.Concat("http://192.168.0.53:45455/Api/Delete/", EntID.Text), content);
        //    ClearText();
        //    //string action = await DisplayActionSheet("Are you sure you want to: Delete?", "Cancel", null, "Delete");
        //    //Debug.WriteLine("Action: " + action);
        //    if (results.IsSuccessStatusCode)
        //    {

        //        await DisplayAlert("Delete", "Deleted Succeful", "OK");
        //    }
        //}

     
        //private void LoginListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        //{

        //}
    }
}
