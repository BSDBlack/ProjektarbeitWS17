using System;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.ApplicationModel.Contacts;
using Windows.ApplicationModel.Email;
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

        private async void Email_Click(object sender, RoutedEventArgs e)
        {

            if(App.setting.ContainsKey("email"))
            {

                string result;
                App.setting.TryGetValue("email", out result);

                string messageBody = String.Empty;

                foreach (string s in itemList)
                {
                    messageBody = String.Concat(messageBody, s, "\n");
                }

                var emailMessage = new Windows.ApplicationModel.Email.EmailMessage();
                emailMessage.Body = messageBody;
                var emailRecipient = new Windows.ApplicationModel.Email.EmailRecipient(result);
                emailMessage.To.Add(emailRecipient);
                emailMessage.Subject = "BuyList";

                await Windows.ApplicationModel.Email.EmailManager.ShowComposeNewEmailAsync(emailMessage);
            }
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
