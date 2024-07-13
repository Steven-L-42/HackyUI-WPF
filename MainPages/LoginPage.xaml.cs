using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Material.Icons.WPF;
using Project_Automait.Classes;


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
            {
                NotificationWindow notification = new("Logged In", "Successfully logged in.", NotificationManager.NotificationType.Info);
                notification.Show();
            }
            {
                MiniWindow miniWindow = new();
                miniWindow.Show();
            }
        }

        private void IconPassword_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (sender is Border border)
            {
                sender = border.Parent;
                if (border.Child is MaterialIcon icon)
                {
                    icon.Kind = Material.Icons.MaterialIconKind.Eye;
                    icon.Foreground = new SolidColorBrush(Color.FromRgb(0xCD, 0x66, 0x07));
                }
                if (sender is StackPanel stackPanel && stackPanel.Children.Count > 1 && stackPanel.Children[1] is Classes.TextBox txtBox)
                {
                    txtBox.ShowText = true;
                    txtBox.IsPassword = false;
                }
            }
        }

        private void IconPassword_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (sender is Border border)
            {
                sender = border.Parent;
                if (border.Child is MaterialIcon icon)
                {
                    icon.Kind = Material.Icons.MaterialIconKind.EyeLock;
                    icon.Foreground = new SolidColorBrush(Color.FromRgb(0xE0, 0xE0, 0xE0));
                }
                if (sender is StackPanel stackPanel && stackPanel.Children.Count > 1 && stackPanel.Children[1] is Classes.TextBox txtBox)
                {
                    txtBox.ShowText = false;
                    txtBox.IsPassword = true;
                }
            }
        }
    }
}
