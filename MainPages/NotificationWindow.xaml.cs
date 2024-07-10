using System.Diagnostics;
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
        private readonly TimeSpan currTime;
        private readonly Timer? timer;
        private readonly int lifetime;
        public NotificationWindow()
        {
            InitializeComponent();
            this.Topmost = true;
        }

        private void CloseNotification()
        {
            timer?.Stop();
            NotificationManager.RemoveNotification(this);
            this.Close();
        }

        public NotificationWindow(string title = "Title", string text = "Text", NotificationManager.NotificationType notificationType = NotificationManager.NotificationType.Neutral, int lifetime = 5)
        {
            InitializeComponent();
            SolidColorBrush brush = NotificationManager.notificationColors.FirstOrDefault(x => x.Key == notificationType).Value;
            notifyTitle.Foreground = notificationType == NotificationManager.NotificationType.Neutral ? new SolidColorBrush(Color.FromArgb(0xFF, 0xCD, 0x66, 0x07)) : brush;
            border.BorderBrush = brush;
            notifyTitle.Text = title;
            notifyText.Text = text;
            this.lifetime = lifetime;
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

            if (TimeSpan.Compare(e.SignalTime.TimeOfDay, currTime.Add(new TimeSpan(0, 0, lifetime))) == 1)
            {
                Dispatcher.Invoke(() =>
                {
                    CloseNotification();
                });
            }
        }

        private void CloseBtn_MouseUp(object sender, MouseButtonEventArgs e)
        {
            CloseNotification();
        }
        private void ExitBtn_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void CloseBtn_MouseEnter(object sender, MouseEventArgs e)
        {
            SolidColorBrush brush = new(Color.FromArgb(0xFF, 0xFF, 0x7A, 0x00));
            iconClose.Foreground = brush;
        }

        private void CloseBtn_MouseLeave(object sender, MouseEventArgs e)
        {
            SolidColorBrush brush = new(Color.FromArgb(0xFF, 0x88, 0x87, 0x87));
            iconClose.Foreground = brush;
        }
    }
}