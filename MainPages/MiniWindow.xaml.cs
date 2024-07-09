using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using Project_Automait.Classes;

namespace Project_Automait
{

    public partial class MiniWindow : Window
    {
        private bool isWindowMove = false;
        private Point startPos;
        private DateTime startTime;
        private DispatcherTimer? timer;

        public MiniWindow()
        {
            InitializeComponent();

            this.WindowStartupLocation = WindowStartupLocation.Manual;
            this.Left = (SystemParameters.PrimaryScreenWidth / 2) - (this.Width / 2);
            this.Top = 0;

            StartTimer();
        }

        private void StartTimer()
        {
            startTime = DateTime.Now;
            timer = new();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            TimeSpan elapsed = DateTime.Now - startTime;
            txtTimer.Text = string.Format("{0:hh\\:mm\\:ss}", elapsed);
        }

        private void headBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            isWindowMove = true;
            startPos = e.GetPosition(this);
            startPos = PointToScreen(startPos);
            startPos.X -= this.Left;

            Mouse.Capture((UIElement)sender);
        }

        private void headBar_MouseUp(object sender, MouseButtonEventArgs e)
        {
            isWindowMove = false;
            Mouse.Capture(null);
        }

        private void headBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isWindowMove)
                return;
            Point currPos = e.GetPosition(this);
            currPos = PointToScreen(currPos);
            this.Left = currPos.X - startPos.X;
        }

        private void miniBarAction_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is TextBlock textBlock)
                textBlock.Foreground = Helper.colIconActive;
        }

        private void miniBarAction_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is TextBlock textBlock)
                textBlock.Foreground = Helper.colInactive;
        }

        private void miniBarAction_MouseDown(object sender, MouseEventArgs e)
        {

        }
    }
}