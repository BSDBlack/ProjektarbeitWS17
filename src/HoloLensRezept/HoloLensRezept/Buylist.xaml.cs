using System;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// Die Elementvorlage "Leere Seite" wird unter https://go.microsoft.com/fwlink/?LinkId=234238 dokumentiert.

namespace HoloLensRezept
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class Buylist : Page
    {
        Windows.Storage.StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
        private static ObservableCollection<string> itemList = new ObservableCollection<string>();

        public Buylist()
        {
            this.InitializeComponent();
            this.BuyListView.ItemsSource = itemList;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private async void Add_Click(object sender, RoutedEventArgs e)
        {
            String itemname = String.Empty;
            var dialog = new Buylist_AddItemDialog();
            ContentDialogResult cdr = await dialog.ShowAsync();

            if (cdr == ContentDialogResult.Primary)
            {
                itemname = dialog.Text;
                itemList.Add(itemname);
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (this.BuyListView.SelectedItem != null)
            {
                itemList.Remove(this.BuyListView.SelectedItem.ToString());
            }
        }
    }
}
