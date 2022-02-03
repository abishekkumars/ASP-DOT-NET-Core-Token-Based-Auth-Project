using System.ComponentModel.DataAnnotations;

namespace ABC_Website.Models
{
    public class UserInfo
    {
        [Key]
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }    
        public string Email { get; set; }   
        public string Password { get; set; }

    }
}
