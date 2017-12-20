using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HoloLensRezept
{
    [DataContract]
    public class Owner
    {
        [DataMember(Name ="id")]
        public string Id { get; set; }
        [DataMember(Name = "username")]
        public string Username { get; set; }
        [DataMember(Name = "rank")]
        public int Rank { get; set; }
        [DataMember(Name = "role")]
        public string Role { get; set; }
        [DataMember(Name = "hasAvatar")]
        public bool HasAvatar { get; set; }
        [DataMember(Name = "hasPaid")]
        public bool HasPaid { get; set; }
        [DataMember(Name = "deleted")]
        public bool Deleted { get; set; }
    }
}
