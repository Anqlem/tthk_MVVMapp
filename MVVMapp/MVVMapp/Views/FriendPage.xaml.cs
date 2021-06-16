using MVVMapp.Models;
using MVVMapp.ViewModels;
using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MVVMapp.Views
{
    public partial class FriendPage : ContentPage
    {
        public FriendPage()
        {
            InitializeComponent();
        }

        private void SaveFriend(object sender, EventArgs e)
        {
            var friend = (Friend)BindingContext;
            if (!String.IsNullOrEmpty(friend.Name))
            {
                App.Database.SaveItem(friend);
            }
            this.Navigation.PopAsync();
        }
        private void DeleteFriend(object sender, EventArgs e)
        {
            var friend = (Friend)BindingContext;
            App.Database.DeleteItem(friend.Id);
            this.Navigation.PopAsync();
        }
        private void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }
        public FriendViewModel ViewModel { get; private set; }
        public FriendPage(FriendViewModel vm)
        {
            InitializeComponent();
            ViewModel = vm;
            this.BindingContext = ViewModel;
        }

        private async void SmsFriend(object sender, EventArgs e)
        {
            var friend = (Friend)BindingContext;
            await Sms.ComposeAsync(new SmsMessage { Body = "", Recipients = new List<string> { friend.Phone } });
        }

        private void CallFriend(object sender, EventArgs e)
        {
            var friend = (Friend)BindingContext;
            PhoneDialer.Open(friend.Phone);
        }
        private async void MailFriend(object sender, EventArgs e)
        {
            var friend = (Friend)BindingContext;
            await Email.ComposeAsync("", friend.Mail);
        }
    }
}