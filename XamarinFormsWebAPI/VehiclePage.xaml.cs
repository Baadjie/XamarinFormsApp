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
	public partial class VehiclePage : ContentPage
	{

        public string Username;
		public VehiclePage (int id,string email)
		{
			InitializeComponent ();
            Username = email;
            GetVehicleByEmail(id);
        }

        public async void GetVehicleByEmail(int clientId)
        {

            Vehicle vehicle = new Vehicle()
            {
                ClientID = clientId,


            };
            var json = JsonConvert.SerializeObject(vehicle);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpClient client = new HttpClient();


            var response = await client.GetStringAsync(string.Concat("http://192.168.0.53:45455/Api/Vehicle?ClientID=", clientId));

            //var response = await client.GetStringAsync(string.Concat("http://192.168.0.53:45455/Api/Vehicle?EmailAdddress=" + clientId/*, "&Password=" + passwordEntry.Text*/), content);
         //   var results = response.Content.ReadAsStringAsync().Result;
            var vehicles = JsonConvert.DeserializeObject<List<Vehicle>>("["+response+"]");

            listVehicle.ItemsSource = vehicles;



        }

        //https://www.youtube.com/watch?v=szYSHnvnTrk

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {

            var menuItem = sender as ImageButton;
            var selectedItem = menuItem.CommandParameter as Vehicle;
            // await Navigation.PushAsync(new AddClaims());
            await Navigation.PushAsync(new AddClaims(selectedItem.ClientID,Username));

        }

        private async void ListVehicle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //await Navigation.PushAsync(new AddClaims());
        }
    }
}