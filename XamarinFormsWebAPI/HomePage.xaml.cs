using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinFormsWebAPI
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage
	{
		public HomePage ()
		{
			InitializeComponent ();
        
            GetLogin();

            //https://www.youtube.com/watch?v=dOU0Qei3Qlk
        }

        //Menu
 

        private void Add_Clicked(object sender, EventArgs e)
        {
            //var menuitem = sender as MenuItem;
            //if (menuitem != null)
            //{
            //    var name = menuitem.BindingContext as string;
            //    DisplayAlert("Alert", "Add " + name, "Ok");
            //}
        }

        private async void Delete_Clicked(object sender, EventArgs e)
        {
            var result=await this.DisplayAlert("Alert!", "Do you really want to Delete", "Yes", "No");

            if (result)
            {

                var menuitem = sender as MenuItem;
                string name = menuitem.BindingContext as string;
                
            }
            //var menuitem = sender as MenuItem;
            //if (menuitem != null)
            //{
            //    var Username = menuitem.BindingContext as string;
            //  await  DisplayAlert("Alert!", "Do you really want to Delete" ,"Yes", "No");
            //}
        }

        private void Edit_Clicked(object sender, EventArgs e)
        {
            //var menuitem = sender as MenuItem;
            //if (menuitem != null)
            //{
            //    var name = menuitem.BindingContext as string;
            //    DisplayAlert("Alert", "Edit " + name, "Ok");
            //}
        }
        //

        private async void GetLogin()
        {


            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("http://192.168.0.53:4545/Api/Login");


            //var response = await client.GetStringAsync("http://10.0.2.2:57757/Api/Login");
            var login = JsonConvert.DeserializeObject<List<Login>>(response);

            LoginListView.ItemsSource = login;
        }

        private async void BtnUpdate_Clicked(object sender, EventArgs e)
        {

            Login login = new Login()
            {
                // Id = Convert.ToInt32(EntID.Text),
                Username = usernameEntry.Text,
                Password = passwordEntry.Text
            };

            var json = JsonConvert.SerializeObject(login);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpClient client = new HttpClient();
            var results = await client.PutAsync(string.Concat("http://192.168.0.53:45455/Api/Login/", EntID.Text), content);
            ClearText();
            if (results.IsSuccessStatusCode)
            {

                await DisplayAlert("Update", "Upadted Succeful", "OK");
            }

       

           
        }

        private void LoginListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var login = e.SelectedItem as Login;
            //Id = Convert.ToInt32(EntID.Text),
            // Username = usernameEntry.Text,
            // Password = passwordEntry.Text

            EntID.Text = login.Id.ToString();
            usernameEntry.Text = login.Username;
            passwordEntry.Text = login.Password;
        }


        private void ClearText()
        {
            usernameEntry.Text = "";
            passwordEntry.Text = "";
        }


        private async void BtnDelete_Clicked(object sender, EventArgs e)
        {
            Login login = new Login()
            {
                // Id = Convert.ToInt32(EntID.Text),
                Username = usernameEntry.Text,
                Password = passwordEntry.Text
            };

            var json = JsonConvert.SerializeObject(login);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpClient client = new HttpClient();
            var results = await client.PutAsync(string.Concat("http://192.168.0.53:45455/Api/Delete/", EntID.Text), content);
            ClearText();
            //string action = await DisplayActionSheet("Are you sure you want to: Delete?", "Cancel", null, "Delete");
            //Debug.WriteLine("Action: " + action);
            if (results.IsSuccessStatusCode)
            {

                await DisplayAlert("Delete", "Deleted Succeful", "OK");
            }
        }
    }
}