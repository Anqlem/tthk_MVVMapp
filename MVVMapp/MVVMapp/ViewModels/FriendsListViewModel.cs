using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.ComponentModel;
using MVVMapp.Views;
using MVVMapp.Models;
using Xamarin.Essentials;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMapp.ViewModels
{

    public class FriendsListViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<FriendViewModel> Friends { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand CreateFriendCommand { protected set; get; }
        public ICommand DeleteFriendCommand { protected set; get; }
        public ICommand SaveFriendCommand { protected set; get; }
        public ICommand SmsCommand { protected set; get; }
        public ICommand CallCommand { protected set; get; }
        public ICommand MailCommand { protected set; get; }
        public ICommand BackCommand { protected set; get; }
        FriendViewModel selectedFriend;

        public INavigation Navigation { get; set; }
        public Friend Friend { get; private set; }

        public FriendsListViewModel()
        {
            Friends = new ObservableCollection<FriendViewModel>(); 
            CreateFriendCommand = new Command(CreateFriend);
            DeleteFriendCommand = new Command(DeleteFriend);
            SaveFriendCommand = new Command(SaveFriend);
            SmsCommand = new Command(SmsFriend);
            MailCommand = new Command(MailFriend);
            CallCommand = new Command(CallFriend);
            BackCommand = new Command(Back);
            Friend = new Friend();
        }

        public FriendViewModel SelectedFriend
        {
            get { return selectedFriend; }
            set
            {
                if (selectedFriend != value)
                {
                    FriendViewModel tempFriend = value;
                    selectedFriend = null;
                    OnPropertyChanged("SelectedFriend");
                    Navigation.PushAsync(new FriendPage(tempFriend));
                }
            }
        }
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        private void CreateFriend()
        {
            Navigation.PushAsync(new FriendPage(new FriendViewModel() { ListViewModel = this }));
        }
        private void Back()
        {
            Navigation.PopAsync();
        }
        private void SaveFriend(object friendObject)
        {
            FriendViewModel friend = friendObject as FriendViewModel;
            if (friend != null && friend.IsValid && !Friends.Contains(friend))
            {
                Friends.Add(friend);
            }
            Back();
        }
        private void DeleteFriend(object friendObject)
        {
            FriendViewModel friend = friendObject as FriendViewModel;
            if (friend != null)
            {
                Friends.Remove(friend);
            }
            Back();
        }


        private async void SmsFriend(object friendObject)
        {
            FriendViewModel friend = friendObject as FriendViewModel;
            await Sms.ComposeAsync(new SmsMessage { Body = "", Recipients = new List<string> { friend.Phone } });
        }

        private async void MailFriend(object friendObject)
        {
            FriendViewModel friend = friendObject as FriendViewModel;
            await Email.ComposeAsync("", friend.Mail);
        }

        private void CallFriend(object friendObject)
        {
            FriendViewModel friend = friendObject as FriendViewModel;
            PhoneDialer.Open(friend.Phone);
        }


    }
}