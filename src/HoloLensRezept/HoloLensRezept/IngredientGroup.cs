using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace HoloLensRezept
{
    [DataContract]
    public class IngredientGroup
    {
        [DataMember(Name = "header")]
        public string Header{ get; set; }
        [DataMember(Name = "ingredients")]
        public List<Ingredient> Ingredients { get; set; }
    }
}
