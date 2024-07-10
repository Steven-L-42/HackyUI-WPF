
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Project_Automait.Classes;

namespace Project_Automait
{
    /// <summary>
    /// Interaktionslogik für MainNavPage.xaml
    /// </summary>
    public partial class MainNavPage : Page
    {
        private int activeMenu = 0;

        public MainNavPage()
        {
            InitializeComponent();
            ChangeMenuColor(Helper.colIconActive, Helper.colTxtActive, activeMenu);

        }

        private void ChangeMenuColor(SolidColorBrush colIcon, SolidColorBrush colTxt, int focusedMenu)
        {
            switch (focusedMenu)
            {
                case 0:
                    txtAimbot.Foreground = colTxt; iconAimbot.Foreground = colIcon;
                    break;
                case 1:
                    txtVisual.Foreground = colTxt; iconVisual.Foreground = colIcon;
                    break;
                case 2:
                    txtMisc.Foreground = colTxt; iconMisc.Foreground = colIcon;
                    break;
                case 3:
                    txtSkins.Foreground = colTxt; iconSkins.Foreground = colIcon;
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
                        fullUri = "pack://application:,,,/Project_Automait;component/MainPages/AimbotPage.xaml";
                        break;
                    case 1:
                        fullUri = "pack://application:,,,/Project_Automait;component/MainPages/VisualsPage.xaml";
                        break;
                    case 2:
                        fullUri = "pack://application:,,,/Project_Automait;component/MainPages/MiscsPage.xaml";
                        break;
                    case 3:
                        return;
                        //fullUri = "pack://application:,,,/Project_Automait;component/MainPages/SkinsPage.xaml";
                        //break;
                    case 4:
                        return;
                        //fullUri = "pack://application:,,,/Project_Automait;component/MainPages/SettingsPage.xaml";
                        //break;
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
