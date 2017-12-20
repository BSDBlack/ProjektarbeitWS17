using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HoloLensRezept
{
    [DataContract]
    class RecipeList
    {
        [DataMember(Name = "count")]
        public int Count { get; set; }
        [DataMember(Name = "results")]
        public List<Recipe> Results { get; set; }
    }
}
