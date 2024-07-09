using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using Gma.System.MouseKeyHook;

namespace Project_Automait
{

    public partial class MainWindow : Window
    {
        private bool isWindowMove = false;
        private bool isClosing = false;
        public bool isLogged = false;
        Point startPos;
        private IKeyboardMouseEvents? m_GlobalHook;

        public MainWindow()
        {
            InitializeComponent();
            Subscribe();


            //MiniWindow miniWindow = new();

            //miniWindow.Show();


        }
        Dictionary<int, string> test = new()
        {
                {0, "Steven" },
                {1, "Svenja" },
                {2, "Heiko" }
        };

        public void Subscribe()
        {
            m_GlobalHook = Hook.GlobalEvents();

            var combinations = new Dictionary<Combination, Action>
            {
                { Combination.TriggeredBy(Keys.F9), () => GlobalHookKeyFPress(Keys.F9) },
                { Combination.TriggeredBy(Keys.F10), () => GlobalHookKeyFPress(Keys.F10) },
                { Combination.TriggeredBy(Keys.F11), () => GlobalHookKeyFPress(Keys.F11) }
            };

            m_GlobalHook.OnCombination(combinations);

        }




        private void GlobalHookKeyFPress(Keys key)
        {



            //Debug.WriteLine(key);
        }
        //public void Unsubscribe()
        //{

        //    m_GlobalHook.KeyPress -= GlobalHookKeyPress;

        //    m_GlobalHook.Dispose();
        //}


        private void closeBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            isClosing = true;
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
            Mouse.Capture((UIElement)sender);
        }

        private void headBar_MouseUp(object sender, MouseButtonEventArgs e)
        {
            isWindowMove = false;
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