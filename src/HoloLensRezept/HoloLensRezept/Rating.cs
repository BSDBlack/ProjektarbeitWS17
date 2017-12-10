using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace HoloLensRezept
{
    [DataContract]
    class Rating
    {
        [DataMember(Name = "rating")]
        double RatingVal { get; set; }
        [DataMember(Name = "numVotes")]
        int NumVotes { get; set; }
    }
}
