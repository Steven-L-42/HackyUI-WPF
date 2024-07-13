using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Project_Automait
{
    public partial class AimbotPage : Page
    {
        public AimbotPage()
        {
            InitializeComponent();
        }

        private void CheckBox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is TextBlock txtBlock)
                sender = txtBlock.Parent;
            if (sender is Grid grid && grid.Children.Count > 0 && grid.Children[0] is CheckBox chBox)
            {
                chBox.IsChecked = !chBox.IsChecked;
                return;
            }
        }

        private void FOV_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (sender is Slider slider)
                txtFOV.Text = Convert.ToInt32(slider.Value).ToString();
        }

    }
}
