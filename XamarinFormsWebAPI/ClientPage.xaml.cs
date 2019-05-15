using Newtonsoft.Json;
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
	public partial class ClientPage : ContentPage
	{
		public ClientPage ()
		{
			InitializeComponent ();

            GetClient();

        }


        //Get Client info

        private async void GetClient()
        {


            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("http://192.168.0.53:45455/Api/ClientInfo");

            var login = JsonConvert.DeserializeObject<List<tblUser>>(response);

            ClientListView.ItemsSource = login;
        }

        private void ClientListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var login = e.SelectedItem as tblUser;

            //txtID.Text = login.Id.ToString();
            //txtName.Text = login.FirstName;
            //txtSurname.Text = login.LastName;

        }



    }
}