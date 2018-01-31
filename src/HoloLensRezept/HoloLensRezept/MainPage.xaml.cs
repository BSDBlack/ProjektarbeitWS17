using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System.Collections.Generic;
using System.IO;

// Die Elementvorlage "Leere Seite" wird unter https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x407 dokumentiert.

namespace HoloLensRezept
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public static Dictionary<string, string> setting = new Dictionary<string, string>();

        public MainPage()
        {
            this.InitializeComponent();
            readSettings();
        }

        private void readSettings()
        {
            Windows.Storage.StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            string filepath = localFolder.Path + "Settings.txt";
            FileStream fileStream = new FileStream(filepath, FileMode.Open);
            if(!File.Exists(filepath))
            {
                File.Create(filepath);
            }
            StreamReader streamReader = new StreamReader(fileStream);
            while( !streamReader.EndOfStream)
            {
                string line = streamReader.ReadLine();
                string[] keyValue = line.Split(' ');
                setting.Add(keyValue[0], keyValue[1]);
            }
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
