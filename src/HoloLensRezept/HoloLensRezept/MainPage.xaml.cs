using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Data.Common;
using Windows.UI.ViewManagement;
using Windows.Foundation;

// Die Elementvorlage "Leere Seite" wird unter https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x407 dokumentiert.

namespace HoloLensRezept
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public MainPage()
        {
            this.InitializeComponent();

            ApplicationView.PreferredLaunchViewSize = new Size(853, 480);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
        }

        /* Function for navigation to MyRecieps page */
        private void MyRecieps_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MyRecieps));
        }

        /* Function for navigation to Settings page */
        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Settings));
        }

        /* Function for navigation to Search page */
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Search));
        }

        private void Buylist_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Buylist));
        }
    }
}
