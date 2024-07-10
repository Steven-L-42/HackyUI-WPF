using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Project_Automait.Classes;

namespace Project_Automait
{
    public partial class MainWindow : Window
    {
        DialogWindow? dialogWindow;
        private bool isWindowMove = false;
        private bool isClosing = false;
        public bool isLogged = false;
        Point startPos;

        public MainWindow()
        {
            InitializeComponent();
            this.Title = RandomTitleGenerator();
            txtTitle.Text = this.Title;
            
            {
                NotificationWindow notification = new("Welcome to HackUI",
                    "This tool provides a sleek and intuitive interface for all your hacking needs.\nHappy hacking!",
                   lifetime: 15);
                notification.Show();
            }
        }

        private static string RandomTitleGenerator()
        {
            char[] chars = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'];
            int minChars = Random.Shared.Next(10, 20);

            StringBuilder sb = new();
            for (int i = 0; i < minChars; i++)
            {
                if (Random.Shared.Next(0, 101) % 2 == 0)
                    sb.Append(chars[Random.Shared.Next(0, chars.Length)].ToString().ToUpper());
                else
                    sb.Append(chars[Random.Shared.Next(0, chars.Length)]);
            }

            return sb.ToString();
        }

        private void CloseBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            isClosing = true;
        }

        private void CloseBtn_MouseUp(object sender, MouseButtonEventArgs e)
        {
            dialogWindow?.Close();

            if (isLogged)
            {

                navFrame.Source = new Uri("pack://application:,,,/Project_Automait;component/NavPages/LoginNavPage.xaml", UriKind.Absolute);
                mainFrame.Source = new Uri("pack://application:,,,/Project_Automait;component/MainPages/LoginPage.xaml", UriKind.Absolute);

                isLogged = false;
                isClosing = false;
                txtClose.Text = "CLOSE";
                iconClose.Kind = Material.Icons.MaterialIconKind.CloseBox;
                {
                    NotificationWindow notification = new("Logged Out", "You're now logged out.", NotificationManager.NotificationType.Warning);
                    notification.Show();
                }
                return;
            }
            dialogWindow = new();
            dialogWindow.Show();
            {
                NotificationWindow notification = new("Time to say good bye", "Are you willing to leave us?", NotificationManager.NotificationType.Error);
                notification.Show();
            }

        }

        private void CloseBtn_MouseEnter(object sender, MouseEventArgs e)
        {
            SolidColorBrush brush = new(Color.FromArgb(0xFF, 0xFF, 0x7A, 0x00));
            txtClose.Foreground = iconClose.Foreground = brush;
        }

        private void CloseBtn_MouseLeave(object sender, MouseEventArgs e)
        {
            SolidColorBrush brush = new(Color.FromArgb(0xFF, 0x88, 0x87, 0x87));
            txtClose.Foreground = iconClose.Foreground = brush;
        }

        private void HeadBar_MouseDown(object sender, MouseButtonEventArgs e)
        {

            if (isClosing)
                return;

            isWindowMove = true;
            startPos = e.GetPosition(this);
            startPos = PointToScreen(startPos);
            startPos.X -= this.Left;
            startPos.Y -= this.Top;
            this.Opacity = 0.4;
            Mouse.Capture((UIElement)sender);
        }

        private void HeadBar_MouseUp(object sender, MouseButtonEventArgs e)
        {
            isWindowMove = false;
            isClosing = false;
            this.Opacity = 1;
            Mouse.Capture(null);
        }

        private void HeadBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isWindowMove)
                return;
            Point currPos = e.GetPosition(this);
            currPos = PointToScreen(currPos);
            this.Left = currPos.X - startPos.X;
            this.Top = currPos.Y - startPos.Y;
        }
    }
}