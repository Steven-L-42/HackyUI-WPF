using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Project_Automait
{

    public partial class DialogWindow : Window
    {
        private bool isWindowMove = false;
        private bool isClosing = false;
        Point startPos;

        public DialogWindow()
        {
            InitializeComponent();
            this.Topmost = true;
        }

        private void closeBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            isClosing = true;
        }

        private void closeBtn_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
        private void exitBtn_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void closeBtn_MouseEnter(object sender, MouseEventArgs e)
        {
            SolidColorBrush brush = new(Color.FromArgb(0xFF, 0xFF, 0x7A, 0x00));
            txtClose.Foreground = iconClose.Foreground = brush;
        }

        private void closeBtn_MouseLeave(object sender, MouseEventArgs e)
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

        private void headBar_MouseMove(object sender, MouseEventArgs e)
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