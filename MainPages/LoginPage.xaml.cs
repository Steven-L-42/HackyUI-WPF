using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;


namespace Project_Automait
{

    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void btnLogin_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (Application.Current.MainWindow is not MainWindow mainWindow)
                return;
            AimbotPage aimbotPage = new();
            MainNavPage mainNavPage = new();
            mainWindow.navFrame.Navigate(mainNavPage);
            mainWindow.mainFrame.Navigate(aimbotPage);
            mainWindow.isLogged = true;
            mainWindow.txtClose.Text = "LOGOUT";
            mainWindow.iconClose.Kind = Material.Icons.MaterialIconKind.LogoutVariant;

        }

    }
}
