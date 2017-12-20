using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization.Json;
using System.Text;
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
    public sealed partial class Search : Page
    {
        public Search()
        {
            this.InitializeComponent();
        }

        /* Function for retrieving List of searched Recipes */
        public async void GetRecipeList(string recipe)
        {
            HttpClient http = new HttpClient();
            String url = String.Format("http://api.chefkoch.de/v2/recipes/{0}", recipeId);
            var response = await http.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Recipe));

            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            Recipe data = (Recipe)serializer.ReadObject(ms);

            this.Recipe_TextBlock.Text = data.Instructions;

        }

        /* Function for navigation to MainPage page */
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void RecipeSelect_Click(object sender, RoutedEventArgs e)
        {
            string recipeId;
            recipeId = "";

            Frame.Navigate(typeof(RecipeView), recipeId);
        }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            GetRecipeList(this.SearchTextBox.Text);
        }
    }
}
