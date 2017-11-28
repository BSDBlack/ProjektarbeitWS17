using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Die Elementvorlage "Leere Seite" wird unter https://go.microsoft.com/fwlink/?LinkId=234238 dokumentiert.

namespace HoloLensRezept
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class Buylist : Page
    {
        public Buylist()
        {
            this.InitializeComponent();


            BuyListView.Items.Add("Kartoffeln");
            BuyListView.Items.Add("Kekse");
            BuyListView.Items.Add("Mehl");
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Tools));
        }

        private async void Add_Click(object sender, RoutedEventArgs e)
        {
            String itemname = String.Empty;
            var dialog = new Buylist_AddItemDialog();
            ContentDialogResult cdr = await dialog.ShowAsync();

            if (cdr == ContentDialogResult.Primary)
            {
                itemname = dialog.Text;
                this.BuyListView.Items.Add(itemname);
            }

            

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            this.BuyListView.Items.Remove(this.BuyListView.SelectedItem);
        }
    }
}
