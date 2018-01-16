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
        int rowcount = 0;
        RecipeList recipes;
        public Search()
        {
            this.InitializeComponent();
        }

        /* Function for retrieving List of searched Recipes */
        public async void GetRecipeList(string recipe)
        {
            HttpClient http = new HttpClient();
            String url = String.Format("http://api.chefkoch.de/v2/recipes?query={0}", recipe);
            var response = await http.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(RecipeList));

            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            RecipeList data = (RecipeList)serializer.ReadObject(ms);

            if(data.Count > 2)
            {
                rowcount = ((data.Count - 2) / 4) + ((data.Count - 2) % 4);
            }
            for(int i = 0; i < rowcount; ++i)
            {
                RowDefinition rd = new RowDefinition();
                rd.Height = new GridLength(240);
                ResultGrid.RowDefinitions.Add(rd);
            }
            int recipecounter = 0;
            int rowcounter = 0;

            foreach(ResultRecipe r in data.Results)
            {
                Button button = new Button();
                StackPanel stackPanel = new StackPanel();
                Image image = new Image();
                TextBlock textBlock = new TextBlock();
                textBlock.Text = r.recipe.Title;
                textBlock.TextWrapping = TextWrapping.Wrap;

                stackPanel.Children.Add(image);
                stackPanel.Children.Add(textBlock);

                button.Content = stackPanel;
                button.Click += RecipeSelect_Click;
                button.DataContext = r.recipe.Id;

                ResultGrid.Children.Add(button);
                Grid.SetColumn(button, (recipecounter + 2) % 4);
                Grid.SetRow(button, rowcounter);

                ++recipecounter;
                if(((recipecounter - 2) % 4) == 0)
                {
                    rowcounter++;
                }
            }

            //Frame.Navigate(typeof(RecipeView), data.Results.First().recipe.Id);

        }

        /* Function for navigation to MainPage page */
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void RecipeSelect_Click(object sender, RoutedEventArgs e)
        {
            
            string recipeId;
            recipeId = (e.OriginalSource as FrameworkElement).DataContext.ToString();

            Frame.Navigate(typeof(RecipeView), recipeId);
        }

        public async void Search_Click(object sender, RoutedEventArgs e)
        {
            Search_RequestDialog search_RequestDialog = new Search_RequestDialog();
            string request;

            ContentDialogResult cdr = await search_RequestDialog.ShowAsync();

            if (cdr == ContentDialogResult.Primary)
            {
                request = search_RequestDialog.Text;
                GetRecipeList(request);
            }

            
        }

    }
}
