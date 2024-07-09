
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Project_Automait.Classes;

namespace Project_Automait
{
    /// <summary>
    /// Interaktionslogik für LoginNavPage.xaml
    /// </summary>
    public partial class LoginNavPage : Page
    {
        private int activeMenu = 0;

        public LoginNavPage()
        {
            InitializeComponent();
            ChangeMenuColor(Helper.colIconActive, Helper.colTxtActive, activeMenu);
        }

        private void ChangeMenuColor(SolidColorBrush colIcon, SolidColorBrush colTxt, int focusedMenu)
        {

            switch (focusedMenu)
            {
                case 0:
                    txtLogin.Foreground = colTxt; iconLogin.Foreground = colIcon;
                    break;
                case 1:
                    txtRegister.Foreground = colTxt; iconRegister.Foreground = colIcon;
                    break;
                case 2:
                    txtPayment.Foreground = colTxt; iconPayment.Foreground = colIcon;
                    break;
                case 3:
                    txtDiscord.Foreground = colTxt; iconDiscord.Foreground = colIcon;
                    break;
                case 4:
                    txtSettings.Foreground = colTxt; iconSettings.Foreground = colIcon;
                    break;
                default:
                    break;
            }
        }

        private void NavMenu_MouseDown(object sender, MouseEventArgs e)
        {
            Grid? menu = sender as Grid;

            try
            {
                int focusedMenu = Convert.ToInt32(menu?.DataContext);
                if (activeMenu == focusedMenu)
                    return;
                if (Application.Current.MainWindow is not MainWindow mainWindow)
                    return;
                string fullUri;
                switch (focusedMenu)
                {
                    case 0:
                        fullUri = "pack://application:,,,/Project_Automait;component/MainPages/LoginPage.xaml";
                        break;
                    case 1:
                        fullUri = "pack://application:,,,/Project_Automait;component/MainPages/RegisterPage.xaml";
                        break;
                    case 2:
                        fullUri = "pack://application:,,,/Project_Automait;component/MainPages/PaymentPage.xaml";
                        break;
                    case 3:
                        return;


                    default:
                        return;
                }

                ChangeMenuColor(Helper.colInactive, Helper.colInactive, activeMenu);
                activeMenu = focusedMenu;
                mainWindow.mainFrame.Source = new Uri(fullUri, UriKind.Absolute);
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Error navigating to page {ex.Message}");
            }
        }

        private void NavMenu_MouseEnter(object sender, MouseEventArgs e)
        {
            Grid? menu = sender as Grid;
            int focusedMenu = Convert.ToInt32(menu?.DataContext);
            ChangeMenuColor(Helper.colIconActive, Helper.colTxtActive, focusedMenu);
        }

        private void NavMenu_MouseLeave(object sender, MouseEventArgs e)
        {
            Grid? menu = sender as Grid;
            int focusedMenu = Convert.ToInt32(menu?.DataContext);
            if (focusedMenu == activeMenu)
                return;
            ChangeMenuColor(Helper.colInactive, Helper.colInactive, focusedMenu);
        }

        private void symbHead_MouseEnter(object sender, MouseEventArgs e)
        {
            txtSymb.Foreground = Helper.colIconActive;
        }

        private void symbHead_MouseLeave(object sender, MouseEventArgs e)
        {
            txtSymb.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0xE0, 0xE0, 0xE0));
        }

        private void symbHead_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
