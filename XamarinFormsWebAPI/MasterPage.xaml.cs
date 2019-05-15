using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFormsWebAPI.MenuItems;
using XamarinFormsWebAPI.Pages;

namespace XamarinFormsWebAPI
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MasterPage : MasterDetailPage
	{

        public List<MasterDetailPageItems> menuList { get; set; }
        public string emails;

        public MasterPage()
        {

            InitializeComponent();
        }
        public  MasterPage (string email)
		{
			InitializeComponent ();
            string em = email;

            emails = email;
     

            menuList = new List<MasterDetailPageItems>();
            // Adding menu items to menuList and you can define title ,page and icon
            menuList.Add(new MasterDetailPageItems() { Title = "Home", Icon = "Assets/Hom.png", TargetType = typeof(HomeScreen) });
           // menuList.Add(new MasterDetailPageItems() { Title = "Claims", Icon = "Cliams.png", TargetType = typeof(AddClaims) });
            menuList.Add(new MasterDetailPageItems() { Title = "Client Info", Icon = "Assets/Person.png", TargetType = typeof(ClientInfoPage) });
            
            menuList.Add(new MasterDetailPageItems() { Title = "Vehicle", Icon = "Assets/car2.png", TargetType = typeof(MainVehiclePage) });
            menuList.Add(new MasterDetailPageItems() { Title = "Settings", Icon = "Assets/setting.png", TargetType = typeof(ResetUsername) });
            menuList.Add(new MasterDetailPageItems() { Title = "Logout", Icon = "Assets/Logout.png", TargetType = typeof(LogoutPage) });
            // Setting our list to be ItemSource for ListView in MainPage.xaml
            navigationDrawerList.ItemsSource = menuList;
            // Initial navigation, this can be used for our home page

            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(HomeScreen)));
            //  https://www.c-sharpcorner.com/blogs/xamarinforms-floating-action-button
            //https://www.youtube.com/watch?v=IVvJX4CoLUY

            //https://www.c-sharpcorner.com/article/navigation-menu-with-syncfusion-in-xamarin-forms/

            //https://www.c-sharpcorner.com/article/how-to-display-items-in-card-view-xamarin-forms/
        }


        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
     
            var item = (MasterDetailPageItems)e.SelectedItem;
            Type page = item.TargetType;
            if (item.TargetType == typeof(ClientInfoPage))
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType, emails));
            }
            else if (item.TargetType == typeof(MainVehiclePage))
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType, emails));
            }

            else if (item.TargetType == typeof(HomeScreen))
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType, emails));
            }
            else if (item.TargetType == typeof(Test1))
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            }
            else if (item.TargetType == typeof(ResetUsername))
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType, emails));
            }

            else if (item.TargetType == typeof(LogoutPage))
            {
                 Navigation.PushAsync(new MainPage());
            }
            //else
            //{
            //    Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            //}

            IsPresented = false;
        }
    }
}