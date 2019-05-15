using Newtonsoft.Json;
using Rg.Plugins.Popup.Services;
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
    public partial class UserTabbedPage : TabbedPage
    {
        public UserTabbedPage(string email,int clientId)
        {
            InitializeComponent();
          // GetClient();
           GetClientById(email);
           GetVehicleInfo(clientId);
            //int Id = clientID;
        }
        public UserTabbedPage()
        {
            InitializeComponent();
         
         
        }

        public int clientID=1;
        private async void GetClient()
        {


            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("http://192.168.0.53:45455/Api/ClientInfo");

            var login = JsonConvert.DeserializeObject<List<tblUser>>(response);




            ClientListView.ItemsSource = login;



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

        //Pass information from Listview to ClientView popup
        private void ClientListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var login = e.SelectedItem as tblUser;
           
            int id = login.Id;
            PopupNavigation.Instance.PushAsync(new ClientView(id));

            //clientId = login.ClientID
            //  PopupNavigation.Instance.PushAsync(new ClientView(clientId);

            //string firstName= login.FirstName;
            //string lastName = login.LastName;
            //bool gender =login.IsMale;
            //int title = login.TitleId;
            //DateTime dateOfBirth = login.DateOfBirth;
            //int txtMaritalStatus = login.MaritalStatusId;
            //string homeSurburb = login.HomeSurburb;
            //string homeAddress = login.HomeAddress;
            //string idNumber = login.IdentityNo;
            //int clientID = login.Id;
            //string emailAdress = login.EmailAddress;

            //string postalCode = login.HomePostalCode;
            //string postalPhone = login.BusinessPhone;
            //string mobilePhone = login.MobilePhone;
            //bool itcCheck = login.ITCCheck;
            //string occupation = login.Occupation;
            //string category = login.Category;
            //bool sequestratedOrLiquidated = login.SequestratedOrLiquidated;

            //string city = login.City;
            //string comment = login.Comment;
            //int clientStatusId = login.ClientStatusId;
            //string companyName = login.CompanyName;
            //string PassportNumber = login.PassportNumber;
            //bool underDebtReview = login.UnderDebtReview;

            //PopupNavigation.Instance.PushAsync(new ClientView(emailAdress,clientID,firstName, lastName, gender, title, dateOfBirth,
            //    txtMaritalStatus, idNumber, homeAddress, homeSurburb, postalCode, postalPhone,
            //    mobilePhone, itcCheck, occupation, category, sequestratedOrLiquidated, city, comment,clientStatusId, companyName, PassportNumber,underDebtReview));
        }

        private void ShowPopup(object o, EventArgs e)
        {

            //PopupNavigation.Instance.PushAsync(new ClientView(txtName.Text));
        }


        private async void GetVehicleInfo(int id)
        {
            HttpClient client = new HttpClient();
            // int id = 2;
            var response = await client.GetStringAsync(string.Concat("http://192.168.0.53:45455/Api/Vehicle/", id));
            var currentUser = JsonConvert.DeserializeObject<List<Vehicle>>(response);
            listVehicle.ItemsSource = currentUser;

        }

        //private void listVehicle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        //{
        //    var vehicle = e.SelectedItem as Vehicle;

        //    int clientID = vehicle.ClientID;
        //    string make = vehicle.Make;
        //    string licensePlate = vehicle.LicensePlate;
        //    string year = vehicle.Year;
        //    string variant = vehicle.Variant;
        //    string model = vehicle.Model;
        //    decimal accessoriesValue = vehicle.AccessoriesValue;
        //    string mmcode = vehicle.MMCode;
        //    string engineNumber = vehicle.EngineNumber;
        //    string vinNumber = vehicle.VINNumber;

        //    PopupNavigation.Instance.PushAsync(new Pages.VehicleView(clientID, make, licensePlate, year, variant, model, accessoriesValue, mmcode, engineNumber, vinNumber));
        //    listVehicle.IsPullToRefreshEnabled = true;
        //}



      
    }
}