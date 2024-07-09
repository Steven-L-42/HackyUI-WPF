using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace Project_Automait
{
    /// <summary>
    /// Interaktionslogik für AimbotPage.xaml
    /// </summary>
    public partial class AimbotPage : Page
    {
        public AimbotPage()
        {
            InitializeComponent();
        }

        private void CheckBox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Grid grid && grid.Children.Count > 0 && grid.Children[0] is CheckBox chBox)
                chBox.IsChecked = !chBox.IsChecked;
        }

        private void FOV_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (sender is Slider slider)
                txtFOV.Text = Convert.ToInt32(slider.Value).ToString();
        }

    }
}
