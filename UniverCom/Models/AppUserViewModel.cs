using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace UniverCom.Models
{
    public class AppUserViewModel
    {
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Secondname { get; set; }
        public Guid? GroupId { get; set; }
        [JsonIgnore]
        public Group Group { get; set; }
    }
}
