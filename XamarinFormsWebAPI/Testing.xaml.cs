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
	public partial class Testing : ContentPage
	{
		public Testing (int id )
		{
			InitializeComponent ();

            GetVehicleByEmail(id);

        }



        public async void GetVehicleByEmail(int clientId)
        {

            Retention vehicle = new Retention()
            {
                IDClient = clientId,


            };
            var json = JsonConvert.SerializeObject(vehicle);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpClient client = new HttpClient();


            var response = await client.GetStringAsync(string.Concat("http://192.168.0.53:45455/Api/Retention?ClientID=", clientId));

            //var response = await client.GetStringAsync(string.Concat("http://192.168.0.53:45455/Api/Vehicle?EmailAdddress=" + clientId/*, "&Password=" + passwordEntry.Text*/), content);
            //   var results = response.Content.ReadAsStringAsync().Result;
            var vehicles = JsonConvert.DeserializeObject<List<Retention>>("[" + response + "]");

            ListCliam.ItemsSource = vehicles;



        }
    }
}