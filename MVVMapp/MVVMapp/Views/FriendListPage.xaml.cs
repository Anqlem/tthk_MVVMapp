using Xamarin.Forms;
using MVVMapp.ViewModels;

namespace MVVMapp.Views
{
    public partial class FriendListPage : ContentPage
    {
        public FriendListPage()
        {
            InitializeComponent();
            BindingContext = new FriendsListViewModel() { Navigation = this.Navigation };
        }
    }
}