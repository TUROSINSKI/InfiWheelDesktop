using InfiWheelDesktop.model;
using InfiWheelDesktop.services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace InfiWheelDesktop.viewModel
{
    public class ProfilePageViewModel : INotifyPropertyChanged
    {
        private UserModel userModel;
        public string Username => userModel?.username;
        public string Email => userModel?.email;

        public ProfilePageViewModel()
        {
            LoadUserProfile();
        }

        private async void LoadUserProfile()
        {
            userModel = await UserService.GetUserProfile();
            OnPropertyChanged(nameof(Username));
            OnPropertyChanged(nameof(Email));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
