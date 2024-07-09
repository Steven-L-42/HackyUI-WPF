using System.Windows.Controls;
using System.Windows.Input;
using Project_Automait.Classes;
using TextBox = System.Windows.Controls.TextBox;
namespace Project_Automait
{

    public partial class VisualsPage : Page
    {
        private bool isHandlingTextChange = false;
        private string oldKey = "";

        public VisualsPage()
        {
            InitializeComponent();
        }



        private void prioKey_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is not TextBox tBox || isHandlingTextChange)
                return;

            isHandlingTextChange = true;

            if (!int.TryParse(tBox.Text, out _))
                tBox.Text = oldKey;

            isHandlingTextChange = false;
        }

        private void prioKey_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (sender is not TextBox tBox || isHandlingTextChange)
                return;

            isHandlingTextChange = true;

            oldKey = tBox.Text;
            tBox.Text = "";

            isHandlingTextChange = false;
        }

        private void btnStart_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtOutput.Text = "";
            int[] prioIndex = { 0, 1, 2, 3 };
            TextBox[] textFields = { key0, key1, key2, key3 };


            // konvertiere text in zahl, typ sicherer als Convert.To
            for (int i = 0; i < prioIndex.Length; i++)
            {
                if (int.TryParse(textFields[i].Text, out int output))
                    prioIndex[i] = output;
                else
                {
                    txtOutput.Text = "not a number!";
                    return;
                }
            }

            // vergleiche den inhalt mit aussortierter liste. == findet hier nur eine referenz da es sich um ein Enumerable handelt
            if (!prioIndex.SequenceEqual(prioIndex.Distinct()))
            {
                txtOutput.Text = "prioIndex enthält duplikate!";
                return;
            }

            Helper.updatePrioKeys(prioIndex);

            // sortiere prioKeys und iteriere
            foreach (KeyValuePair<int, Key> keys in Helper.prioKeys.OrderBy(x => x.Key))
            {
                txtOutput.Text += keys.Key + " = " + keys.Value + "\n";
            }
        }
    }
}
