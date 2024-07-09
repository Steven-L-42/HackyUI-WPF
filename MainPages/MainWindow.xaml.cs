using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Project_Automait
{

    public partial class MainWindow : Window
    {
        private bool isWindowMove = false;
        private bool isClosing = false;
        public bool isLogged = false;
        Point startPos;

        public MainWindow()
        {
            InitializeComponent();

            MiniWindow miniWindow = new();
            miniWindow.Show();
        }
        Dictionary<int, string> test = new()
        {
                {0, "Steven" },
                {1, "Svenja" },
                {2, "Heiko" }
        };

        private void closeBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            isClosing = true;
        }

        private void closeBtn_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (isLogged)
            {
                navFrame.Source = new Uri("pack://application:,,,/Project_Automait;component/NavPages/LoginNavPage.xaml", UriKind.Absolute);
                mainFrame.Source = new Uri("pack://application:,,,/Project_Automait;component/MainPages/LoginPage.xaml", UriKind.Absolute);

                isLogged = false;
                isClosing = false;
                txtClose.Text = "CLOSE";
                iconClose.Kind = Material.Icons.MaterialIconKind.CloseBox;
                return;
            }

            this.Close();
        }

        private void closeBtn_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            SolidColorBrush brush = new(Color.FromArgb(0xFF, 0xFF, 0x7A, 0x00));
            txtClose.Foreground = iconClose.Foreground = brush;
        }

        private void closeBtn_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            SolidColorBrush brush = new(Color.FromArgb(0xFF, 0x88, 0x87, 0x87));
            txtClose.Foreground = iconClose.Foreground = brush;
        }

        private void headBar_MouseDown(object sender, MouseButtonEventArgs e)
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

        private void headBar_MouseUp(object sender, MouseButtonEventArgs e)
        {
            isWindowMove = false;
            isClosing = false;
            this.Opacity = 1;
            Mouse.Capture(null);
        }

        private void headBar_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
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