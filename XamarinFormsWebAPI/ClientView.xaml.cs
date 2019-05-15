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
	public partial class ClientView 
	{

        //Receive information if you want to update

        //public ClientView (string emailAdress,int clientId,string firtname,string lastName,bool gender,
        //          int title,DateTime dateOfBirth,int maritalStatus,string idNumber,string homeAdress,string homeSuburb
        //          ,string postalCode,string postalPhone, string mobilePhone,bool itcCheck,string occupation
        //          ,string category,bool sequestratedOrLiquidated,string city,
        //          string comment, int clientStatusId, string companyName, string PassportNumber,bool underDebtReview)

        public ClientView (int id)
		{
			InitializeComponent ();

            int clientID = id;

            GetVehicleInfo(clientID);
            //txtEmailAddress.Text = emailAdress.ToString();
            //EntID.Text = clientId.ToString();
            //txtFirstName.Text = firtname;
            //txtLastName.Text = lastName;
            //txtGender.Text = gender.ToString();
            //txtTitle.Text = title.ToString();
            //txtDateOfBirth.Text = dateOfBirth.ToString();
            //txtMaritalStatus.Text = maritalStatus.ToString();
            //txtIdNumber.Text = idNumber.ToString();
            //txtHomeAdress.Text = homeAdress.ToString();
            //txtHomeSuburg.Text = homeSuburb.ToString();

            //txtHomePostalCode.Text = postalCode.ToString();
            //txtBusinessPhone.Text = postalPhone.ToString();
            //txtMobilePhone.Text = mobilePhone.ToString();
            //txtITCCheck.Text = itcCheck.ToString();
            //txtOccupation.Text = occupation.ToString();
            //txtCategory.Text = category.ToString();
            //txtSequestratedOrLiquidated.Text = sequestratedOrLiquidated.ToString();

            //txtCity.Text = city.ToString();
            //txtComment.Text = comment.ToString();
            //txtClientStatusId.Text = clientStatusId.ToString();
            //txtCompanyName.Text = companyName.ToString();
            //txtPassportNumber.Text = PassportNumber.ToString();
            //txtUnderDebtReview.Text = underDebtReview.ToString();

        }

        void Handle_Clicked(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PopAsync(true);
        }



        private async void GetVehicleInfo(int id)
        {
            HttpClient client = new HttpClient();
            // int id = 2;
            var response = await client.GetStringAsync(string.Concat("http://192.168.0.53:45455/Api/Vehicle/", id));
            var currentUser = JsonConvert.DeserializeObject<List<Vehicle>>(response);
            listVehicle.ItemsSource = currentUser;
            await Navigation.PushAsync(new UserTabbedPage());

        }

        private async void BtnUpdate_Clicked(object sender, EventArgs e)
        {

            //tblUser clientinfo = new tblUser()
            //{
            //    // Id = Convert.ToInt32(EntID.Text),
            //    //Username = usernameEntry.Text,
            //    //Password = passwordEntry.Text

            //    IsMale = Convert.ToBoolean(txtGender.Text),
            //    TitleId = Convert.ToInt32(txtTitle.Text),
            //    MaritalStatusId = Convert.ToInt32(txtMaritalStatus.Text),
            //    DateOfBirth = Convert.ToDateTime(txtDateOfBirth.Text),
            //    IdentityNo = txtIdNumber.Text,
            //    HomeAddress = txtHomeAdress.Text,
            //    HomeSurburb = txtHomeSuburg.Text,

            //    HomePostalCode = txtHomePostalCode.Text,
            //    BusinessPhone = txtBusinessPhone.Text,
            //    MobilePhone = txtMobilePhone.Text,
            //    ITCCheck = Convert.ToBoolean(txtITCCheck.Text),
            //    Occupation = txtOccupation.Text,
            //    Category = txtCategory.Text,
            //    SequestratedOrLiquidated = Convert.ToBoolean(txtSequestratedOrLiquidated.Text),

            //    City = txtCity.Text,
            //    Comment = txtComment.Text,
            //    CompanyName = txtCompanyName.Text,
            //    ClientStatusId = Convert.ToInt32(txtClientStatusId.Text),
            //    PassportNumber = txtPassportNumber.Text,
            //    UnderDebtReview = Convert.ToBoolean(txtUnderDebtReview.Text)
          

            //};

            //var json = JsonConvert.SerializeObject(clientinfo);
            //var content = new StringContent(json, Encoding.UTF8, "application/json");

            //HttpClient client = new HttpClient();
            //var results = await client.PutAsync(string.Concat("http://192.168.0.53:45455/Api/ClientInfo/", EntID.Text), content);
            ////ClearText();
            //if (results.IsSuccessStatusCode)
            //{

            //    await DisplayAlert("Update", "Upadted Succeful", "OK");
            //}




        }





        //public ClientView(string name,string surname)
        //{

        //    txtClientID.Text = name;
        //    txtMake.Text = surname;
        //}
    }
}