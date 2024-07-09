using System.Timers;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Project_Automait.Classes;
using Timer = System.Timers.Timer;

namespace Project_Automait
{
    public partial class NotificationWindow : Window
    {
        private bool isWindowMove = false;
        private bool isClosing = false;
        private Point startPos;
        private TimeSpan currTime;
        private Timer? timer;

        public NotificationWindow()
        {
            InitializeComponent();
            this.Topmost = true;
        }

        private void closeNotification()
        {
            timer?.Stop();
            NotificationManager.RemoveNotification(this);
            this.Close();
        }

        public NotificationWindow(string title, string text, NotificationManager.NotificationType notificationType)
        {
            InitializeComponent();
            notifyTitle.Foreground = NotificationManager.notificationColors.FirstOrDefault(x => x.Key == notificationType).Value;
            notifyTitle.Text = title;
            notifyText.Text = text;

            this.WindowStartupLocation = WindowStartupLocation.Manual;
            this.Left = SystemParameters.WorkArea.Width - (this.Width - 5);
            this.Topmost = true;

            NotificationManager.AddNotification(this);

            timer = new Timer(10);
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
            currTime = DateTime.Now.TimeOfDay;
        }

        private void Timer_Elapsed(object? sender, ElapsedEventArgs e)
        {

            if (TimeSpan.Compare(e.SignalTime.TimeOfDay, currTime.Add(new TimeSpan(0, 0, 5))) == 1)
            {
                Dispatcher.Invoke(() =>
                {
                    closeNotification();
                });
            }
        }

        private void closeBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            isClosing = true;
        }

        private void closeBtn_MouseUp(object sender, MouseButtonEventArgs e)
        {
            closeNotification();
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