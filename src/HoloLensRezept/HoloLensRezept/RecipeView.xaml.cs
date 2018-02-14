using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Die Elementvorlage "Leere Seite" wird unter https://go.microsoft.com/fwlink/?LinkId=234238 dokumentiert.

namespace HoloLensRezept
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class RecipeView : Page
    {
        string path = Windows.Storage.ApplicationData.Current.LocalFolder.Path + @"\MyRecipes.txt";

        List<string> list = new List<string>();
        string recipeId;
        bool myRecipe;

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

        public async void GetFile()
        {

            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
            {
                StreamReader streamReader = new StreamReader(fileStream);

                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();
                    list.Add(line);

                }

                if (list.Contains(recipeId))
                {
                    myRecipe = true;
                    this.MeineRezepte_Button.Background = new SolidColorBrush(Colors.LightGray);
                }
            }
        }

        // Parse passed Data
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            recipeId = (string) e.Parameter;

            GetRecipe(Int64.Parse(recipeId));
            GetFile();
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
            if(myRecipe)
            {
                list.Remove(recipeId);
                File.Delete(path);

                using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
                {
                    StreamWriter streamWriter = new StreamWriter(fileStream);

                    for(int i = 0; i < list.Count; ++i)
                    {
                        streamWriter.WriteLine(list[i]);
                    }

                    streamWriter.Flush();
                    fileStream.Flush();
                    myRecipe = false;
                    this.MeineRezepte_Button.Background = new SolidColorBrush(Colors.DarkGray);
                }
            }
            else
            {
                list.Add(recipeId);

                using (FileStream fileStream = new FileStream(path, FileMode.Append))
                {
                    StreamWriter streamWriter = new StreamWriter(fileStream);

                    streamWriter.WriteLine(recipeId);
                    streamWriter.Flush();
                    fileStream.Flush();

                    myRecipe = true;
                    this.MeineRezepte_Button.Background = new SolidColorBrush(Colors.LightGray);
                }
            }

        }
    }
}
