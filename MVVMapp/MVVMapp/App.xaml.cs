using Xamarin.Forms;
using MVVMapp.Views;

namespace MVVMapp
{
    public partial class App : Application
    {
        public App()
        {
            MainPage = new NavigationPage(new FriendListPage());
        }

        protected override void OnStart()
        { }

        protected override void OnSleep()
        { }

        protected override void OnResume()
        { }
    }
}