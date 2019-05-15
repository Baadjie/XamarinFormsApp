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
	public partial class ClaimInfomation : ContentPage
	{

        public string em = "";

        public ClaimInfomation ()
		{
			InitializeComponent ();

            em = MainPage.globalUsername;


            GetVehicleByEmail(em);
        }



        public async void GetVehicleByEmail(string email)
        {

            Vehicle vehicle = new Vehicle()
            {
                EmailAddress = email,


            };
            var json = JsonConvert.SerializeObject(vehicle);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpClient client = new HttpClient();


            // var response = await client.GetStringAsync(string.Concat("http://192.168.0.53:45455/Api/Vehicle?EmailAdddress=", email));

            var response = await client.PostAsync(string.Concat("http://192.168.0.53:45455/Api/Vehicle?EmailAdddress=" + email/*, "&Password=" + passwordEntry.Text*/), content);
            var results = response.Content.ReadAsStringAsync().Result;
            var vehicles = JsonConvert.DeserializeObject<List<Vehicle>>(results);

            CliamList.ItemsSource = vehicles;





        }




        private async void ListVehicle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var vehicle = e.SelectedItem as Vehicle;
            int id = vehicle.ClientID;
            //string id = vehicle.Id;

            //await Navigation.PushAsync(new VehiclePage(id, clientEmail));

            await Navigation.PushAsync(new Testing(id));
        }

        private void ListVehicle_ItemTapped(object sender, ItemTappedEventArgs e)
        {


        }
    }
}