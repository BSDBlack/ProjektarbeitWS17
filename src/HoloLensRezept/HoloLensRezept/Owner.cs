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
        int Id { get; set; }
        [DataMember(Name = "username")]
        string Username { get; set; }
        [DataMember(Name = "rank")]
        int Rank { get; set; }
        [DataMember(Name = "role")]
        string Role { get; set; }
        [DataMember(Name = "hasAvatar")]
        bool HasAvatar { get; set; }
        [DataMember(Name = "hasPaid")]
        bool HasPaid { get; set; }
        [DataMember(Name = "deleted")]
        bool Deleted { get; set; }
    }
}
