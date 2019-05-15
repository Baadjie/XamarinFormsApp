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
	public partial class ClientInfoPage : ContentPage
	{
		public ClientInfoPage (string email)
		{
			InitializeComponent ();
            GetClientById(email);
        }
        public async void GetClientById(string email)
        {

            tblUser user = new tblUser()
            {
                EmailAddress = email,


            };
            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpClient client = new HttpClient();


            // var response = await client.GetStringAsync(string.Concat("http://192.168.0.53:45455/Api/ClientInfo?EmailAdddress=", email));

            var response = await client.PostAsync(string.Concat("http://192.168.0.53:45455/Api/ClientInfo?EmailAdddress=" + email/*, "&Password=" + passwordEntry.Text*/), content);
            var results = response.Content.ReadAsStringAsync().Result;
            var login = JsonConvert.DeserializeObject<List<tblUser>>(results);

            ClientListView.ItemsSource = login;



        }
    }
}