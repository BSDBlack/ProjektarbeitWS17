using System;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// Die Elementvorlage "Leere Seite" wird unter https://go.microsoft.com/fwlink/?LinkId=234238 dokumentiert.

namespace HoloLensRezept
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class RecipeView : Page
    {
        public RecipeView()
        {
            this.InitializeComponent();

        }

        public async void GetRecipe(long recipeId)
        {
            HttpClient http = new HttpClient();
            String url = String.Format("http://api.chefkoch.de/v2/recipes/{0}", recipeId);
            var response = await http.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Recipe));

            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            Recipe data = (Recipe)serializer.ReadObject(ms);

            this.Title_TextBox.Text = data.Title;
            foreach(IngredientGroup ig in data.IngredientsGroups)
            {
                foreach(Ingredient i in ig.Ingredients)
                {
                    this.Ingredients_ListView.Items.Add(String.Concat(i.Amount, i.Unit, " ", i.Name));
                }
            }
            this.Recipe_TextBlock.Text = data.Instructions;

        }

        // Parse passed Data
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            string recipeId = (string) e.Parameter;

            GetRecipe(Int64.Parse(recipeId));
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Search));
        }

        private void SetTimer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ToggleFavorites_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
