using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace HoloLensRezept
{
    public class IngredientGroup
    {
        [DataMember(Name = "header")]
        string Header{ get; set; }
        [DataMember(Name = "ingredients")]
        List<Ingredient> Ingredients { get; set; }
    }
}
