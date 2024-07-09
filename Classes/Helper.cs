using System.Windows.Input;
using System.Windows.Media;

namespace Project_Automait.Classes
{
    public static class Helper
    {
        public static readonly SolidColorBrush colInactive = new(Color.FromArgb(0xFF, 0x88, 0x87, 0x87));
        public static readonly SolidColorBrush colIconActive = new(Color.FromArgb(0xFF, 0xFF, 0x7A, 0x00));
        public static readonly SolidColorBrush colTxtActive = new(Colors.GhostWhite);


        public static void updatePrioKeys(int[] prioIndex)
        {
            prioKeys = new Dictionary<int, Key>()
            {
                {prioIndex[0], Key.D1},
                {prioIndex[1], Key.D2},
                {prioIndex[2], Key.D3},
                {prioIndex[3], Key.D4},
            };
        }

        public static Dictionary<int, Key> prioKeys = new()
        {
            {0, Key.D1},
            {1, Key.D2},
            {2, Key.D3},
            {3, Key.D4},
        };

        

       
        

    }
}
