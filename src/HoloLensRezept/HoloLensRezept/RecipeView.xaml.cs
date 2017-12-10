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
    public sealed partial class RecipeView : Page
    {
        public RecipeView()
        {
            this.InitializeComponent();

            Recipe result = await GetRecipe(349111120054623);

        }

        public async static Task<Recipe> GetRecipe(int recipeId)
        {
            HttpClient http = new HttpClient();
            String url = String.Format("http://api.chefkoch.de/v2/recipes/{0}", recipeId);
            var response = await http.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Recipe));

            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            Recipe data = (RootObject)serializer.ReadObject(ms);

            return data;

        }
    }
}
