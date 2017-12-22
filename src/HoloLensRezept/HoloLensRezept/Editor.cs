using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HoloLensRezept
{
    [DataContract]
    public class Editor
    {
        [DataMember(Name = "id")]
        public string id { get; set; }
        [DataMember(Name = "username")]
        public string username { get; set; }
        [DataMember(Name = "rank")]
        public int rank { get; set; }
        [DataMember(Name = "role")]
        public string role { get; set; }
        [DataMember(Name = "hasAvatar")]
        public bool hasAvatar { get; set; }
        [DataMember(Name = "hasPaid")]
        public bool hasPaid { get; set; }
        [DataMember(Name = "deleted")]
        public bool deleted { get; set; }
    }
}
