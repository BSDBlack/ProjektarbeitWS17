using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HoloLensRezept
{
    [DataContract]
    class ResultRecipe
    {
        [DataMember(Name = "score")]
        public double score { get; set; }
        [DataMember(Name = "recipe")]
        public Recipe recipe { get; set; }
    }
}
