using System.Windows.Controls;
using System.Windows.Media;
using Material.Icons.WPF;

namespace Project_Automait
{

    public partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            InitializeComponent();
        }



        private void btnRegister_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            //var mainWindow = Application.Current.MainWindow as MainWindow;

            //AimbotPage aimbotPage = new();
            //MainNavPage mainNavPage = new();
            //mainWindow?.navFrame.Navigate(mainNavPage);
            //mainWindow?.mainFrame.Navigate(aimbotPage);
            //mainWindow.isLogged = true;
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
