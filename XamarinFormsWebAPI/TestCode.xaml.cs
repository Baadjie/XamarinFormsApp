
//using Plugin.Messaging;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Xamarin.Essentials;
//using Xamarin.Forms;
//using Xamarin.Forms.Xaml;
//using XamarinFormsWebAPI.Model;

//namespace XamarinFormsWebAPI
//{
//	[XamlCompilation(XamlCompilationOptions.Compile)]
//	public partial class TestCode : ContentPage
//	{
//        public string emailAdress;
//		public TestCode (string email)
//		{

//            emailAdress = email;

//            InitializeComponent ();
//		}
//        public TestCode( )
//        {

          

//            InitializeComponent();
//        }

//        private async void ImageButton_Clicked(object sender, EventArgs e)
//        {


//            var phoneCallTask = CrossMessaging.Current.PhoneDialer;
//            if (phoneCallTask.CanMakePhoneCall)
//            {
//                phoneCallTask.MakePhoneCall("+27821620000", "Xinix Insurance");
//            }

//        }
//        private async void AddCliam_Clicked(object sender, EventArgs e)
//        {

//            var menuItem = sender as ImageButton;
//           var selectedItem = menuItem.CommandParameter as Vehicle;
//            // await Navigation.PushAsync(new AddClaims());
//            await DisplayAlert("Test", "button Clicked ", "");

//        }
        

//         private async void Location_Clicked(object sender, EventArgs e)
//        {

//            var menuItem = sender as ImageButton;
//           var selectedItem = menuItem.CommandParameter as Vehicle;
 

//            var location = new Location(-26.06320, 27.97080);
//            var options = new MapLaunchOptions { Name = "Olivedale Office park" };

//            await Map.OpenAsync(location, options);
//        }



//    }
//}