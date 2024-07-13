using System.Diagnostics;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;



namespace Project_Automait.Classes
{
    
    public class TextBox : System.Windows.Controls.TextBox
    {
        private string passwordText = string.Empty;

        static TextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TextBox), new FrameworkPropertyMetadata(typeof(TextBox)));

        }


        // CornerRadius Dependency Property
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(TextBox), new PropertyMetadata(new CornerRadius(0)));

        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        // ShowText Dependency Property
        public static readonly DependencyProperty ShowTextProperty =
             DependencyProperty.Register("ShowText", typeof(bool), typeof(TextBox), new PropertyMetadata(true));

        public bool ShowText
        {
            get { return (bool)GetValue(ShowTextProperty); }
            set { SetValue(ShowTextProperty, value); }
        }

        // IsPassword Dependency Property
        public static readonly DependencyProperty IsPasswordProperty =
             DependencyProperty.Register("IsPassword", typeof(bool), typeof(TextBox), new PropertyMetadata(false));

        public bool IsPassword
        {
            get { return (bool)GetValue(IsPasswordProperty); }
            set { SetValue(IsPasswordProperty, value); }
        }


        // IsEmpty Dependency Property Key
        public static readonly DependencyPropertyKey IsEmptyPropertyKey =
            DependencyProperty.RegisterReadOnly("IsEmpty", typeof(bool), typeof(TextBox), new PropertyMetadata(true));

        public static readonly DependencyProperty IsEmptyProperty = IsEmptyPropertyKey.DependencyProperty;

        public bool IsEmpty
        {
            get { return (bool)GetValue(IsEmptyProperty); }
            set { SetValue(IsEmptyPropertyKey, value); }
        }

        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            Password = new string('*', Text.Length);
            IsEmpty = string.IsNullOrEmpty(Text);

        }

        // Placeholder Dependency Property
        public static readonly DependencyProperty PlaceholderProperty =
            DependencyProperty.Register("Placeholder", typeof(string), typeof(TextBox), new PropertyMetadata(string.Empty));

        public string Placeholder
        {
            get { return (string)GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }

        // Password Dependency Property
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register("Password", typeof(string), typeof(TextBox), new PropertyMetadata(string.Empty));

        public string Password
        {
            get { return (string)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }


        // Padding Dependency Property
        public static readonly new DependencyProperty PaddingProperty =
            DependencyProperty.Register("Padding", typeof(Thickness), typeof(TextBox), new PropertyMetadata(new Thickness(7, 0, 7, 0)));

        public new Thickness Padding
        {
            get { return (Thickness)GetValue(PaddingProperty); }
            set { SetValue(PaddingProperty, value); }
        }


        // BorderThickness Dependency Property
        public static readonly new DependencyProperty BorderThicknessProperty =
            DependencyProperty.Register("BorderThickness", typeof(Thickness), typeof(TextBox), new PropertyMetadata(new Thickness(1)));

        public new Thickness BorderThickness
        {
            get { return (Thickness)GetValue(BorderThicknessProperty); }
            set { SetValue(BorderThicknessProperty, value); }
        }


        // BorderBrush Dependency Property
        public static readonly new DependencyProperty BorderBrushProperty =
            DependencyProperty.Register("BorderBrush", typeof(Brush), typeof(TextBox), new PropertyMetadata(new SolidColorBrush(Color.FromArgb(0x7F, 0x40, 0x40, 0x40))));

        public new Brush BorderBrush
        {
            get { return (Brush)GetValue(BorderBrushProperty); }
            set { SetValue(BorderBrushProperty, value); }
        }


        // PlaceholderForeground Dependency Property
        public static readonly DependencyProperty PlaceholderForegroundProperty =
            DependencyProperty.Register("PlaceholderForeground", typeof(Brush), typeof(TextBox), new PropertyMetadata(new SolidColorBrush(Color.FromArgb(0xFF, 0x88, 0x87, 0x87))));

        public Brush PlaceholderForeground
        {
            get { return (Brush)GetValue(PlaceholderForegroundProperty); }
            set { SetValue(PlaceholderForegroundProperty, value); }
        }


        // Background Dependency Property
        public static readonly new DependencyProperty BackgroundProperty =
            DependencyProperty.Register("Background", typeof(Brush), typeof(TextBox), new PropertyMetadata(new SolidColorBrush(Color.FromArgb(0xFF, 0x15, 0x15, 0x15))));

        public new Brush Background
        {
            get { return (Brush)GetValue(BackgroundProperty); }
            set { SetValue(BackgroundProperty, value); }
        }


        // HoveredForeground Dependency Property
        public static readonly DependencyProperty HoveredForegroundProperty =
            DependencyProperty.Register("HoveredForeground", typeof(Brush), typeof(TextBox), new PropertyMetadata(new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0x7A, 0x00))));

        public Brush HoveredForeground
        {
            get { return (Brush)GetValue(HoveredForegroundProperty); }
            set { SetValue(HoveredForegroundProperty, value); }
        }


        // UnCheckColor Dependency Property
        public static readonly DependencyProperty UnCheckColorProperty =
            DependencyProperty.Register("UnCheckColor", typeof(Brush), typeof(TextBox), new PropertyMetadata(new SolidColorBrush(Color.FromArgb(0xFF, 0xCD, 0x66, 0x07))));

        public Brush UnCheckColor
        {
            get { return (Brush)GetValue(UnCheckColorProperty); }
            set { SetValue(UnCheckColorProperty, value); }
        }


    }
}
