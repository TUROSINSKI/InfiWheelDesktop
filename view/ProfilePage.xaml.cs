using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using InfiWheelDesktop.viewModel;

namespace InfiWheelDesktop
{
    /// <summary>
    /// Logika interakcji dla klasy ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        public ProfilePage()
        {
            InitializeComponent();
            DataContext = new ProfilePageViewModel();
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CarListPage());
        }
    }
}
