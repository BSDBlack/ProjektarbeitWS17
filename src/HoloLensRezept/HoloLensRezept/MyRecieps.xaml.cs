using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

// Die Elementvorlage "Leere Seite" wird unter https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x407 dokumentiert.

namespace HoloLensRezept
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class MyRecieps : Page
    {
        public List<string> myRecipes = new List<string>();
        int rowcount = 0;


        public MyRecieps()
        {
            this.InitializeComponent();

            readMyRecipes();

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

        private async void readMyRecipes()
        {
            string path = Windows.Storage.ApplicationData.Current.LocalFolder.Path + @"\MyRecipes.txt";
            using (FileStream recipeFileStream = new FileStream(path, FileMode.OpenOrCreate))
            {
                StreamReader recipeFileStreamReader = new StreamReader(recipeFileStream);

                while (!recipeFileStreamReader.EndOfStream)
                {
                    string line = recipeFileStreamReader.ReadLine();
                    myRecipes.Add(line);
                }
            }


            GetRecipeList();
        }

        /* Function for retrieving List of searched Recipes */
        public async void GetRecipeList()
        {
            HttpClient http = new HttpClient();
            int recipecounter = 0;
            int rowcounter = 0;

            // If any old recipes, remove them
            for (int i = ResultGrid.Children.Count - 1; i > 1; --i)
            {
                ResultGrid.Children.RemoveAt(i);
            }

            // If any old unneeded rows, remove them
            for (int i = ResultGrid.RowDefinitions.Count - 1; i > 0; --i)
            {
                ResultGrid.RowDefinitions.RemoveAt(i);
            }

            foreach (string recipeId in myRecipes)
            {
                int recipeCount = myRecipes.Count;


                Button button = new Button();
                StackPanel stackPanel = new StackPanel();
                Image image = new Image();
                TextBlock textBlock = new TextBlock();

                String url = String.Format("http://api.chefkoch.de/v2/recipes/{0}", recipeId);
                var response = await http.GetAsync(url);

                var result = await response.Content.ReadAsStringAsync();
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Recipe));

                var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
                Recipe data = (Recipe)serializer.ReadObject(ms);

                // Calculate amount of needed rows
                if (recipeCount > 2)
                {
                    rowcount = ((recipeCount - 1) / 4) + ((recipeCount - 1) % 4);
                }

                // Create all new rows
                for (int i = 0; i < rowcount; ++i)
                {
                    RowDefinition rd = new RowDefinition();
                    rd.Height = new GridLength(240);
                    ResultGrid.RowDefinitions.Add(rd);
                }

                textBlock.Text = data.Title;
                textBlock.TextWrapping = TextWrapping.Wrap;

                image.Source = new BitmapImage(new Uri("ms-appx:///Assets/ExamplePiktogramm.png", UriKind.Absolute));
                image.Height = 162;

                stackPanel.Children.Add(image);
                stackPanel.Children.Add(textBlock);

                button.Content = stackPanel;
                button.Click += RecipeSelect_Click;
                button.DataContext = data.Id;
                button.Width = 188;

                ResultGrid.Children.Add(button);
                Grid.SetColumn(button, (recipecounter + 1) % 4);
                Grid.SetRow(button, rowcounter);

                ++recipecounter;
                if (((recipecounter - 2) % 4) == 0)
                {
                    rowcounter++;
                }
            }

        }

    }
}
