using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InfiWheelDesktop.viewModel
{
    public class LandingViewModel : INotifyPropertyChanged  // Make the class public
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public class MessageItem
        {
            public string Message { get; set; }
            public string ImagePath { get; set; }

            public MessageItem(string message, string imagePath)
            {
                Message = message;
                ImagePath = imagePath;
            }
        }

        private List<MessageItem> messages = new List<MessageItem>
        {
            new MessageItem("A peer-to-peer carsharing platform where you can rent or share cars conveniently and affordably.", "E:\\Projekty\\WPF\\projectwpf\\InfiWheelDesktop\\InfiWheelDesktop\\assets\\landing_1.jpg"),
            new MessageItem("Sign up today and start sharing your vehicle!", "E:\\Projekty\\WPF\\projectwpf\\InfiWheelDesktop\\InfiWheelDesktop\\assets\\landing_2.jpg"),
            new MessageItem("Easily find cars available near you and book in minutes.", "E:\\Projekty\\WPF\\projectwpf\\InfiWheelDesktop\\InfiWheelDesktop\\assets\\landing_3.jpg")
        };

        private int currentIndex = 0;
        private MessageItem currentMessageItem;

        public LandingViewModel()
        {
            CurrentMessageItem = messages[currentIndex];
            ChangeMessageCommand = new RelayCommand(ChangeMessage);
        }

        public MessageItem CurrentMessageItem
        {
            get => currentMessageItem;
            set
            {
                if (currentMessageItem != value)
                {
                    currentMessageItem = value;
                    OnPropertyChanged(nameof(CurrentMessageItem));
                }
            }
        }

        public ICommand ChangeMessageCommand { get; private set; }

        public void ChangeMessage()
        {
            currentIndex = (currentIndex + 1) % messages.Count;
            CurrentMessageItem = messages[currentIndex];
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // RelayCommand implementation
        public class RelayCommand : ICommand
        {
            private Action _execute;
            public RelayCommand(Action execute) => _execute = execute;

            public event EventHandler CanExecuteChanged
            {
                add { CommandManager.RequerySuggested += value; }
                remove { CommandManager.RequerySuggested -= value; }
            }

            public bool CanExecute(object parameter) => true;
            public void Execute(object parameter) => _execute();
        }
    }
}
