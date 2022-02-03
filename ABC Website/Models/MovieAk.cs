using System.ComponentModel.DataAnnotations;

namespace ABC_Website.Models
{
    public class MovieAk
    {
        [Key]
        public int Id { get; set; }
        public string MovieName { get; set; }

        public string Descriptions { get; set; }

        public string Movie_Type { get; set; }

        public string Languages { get; set; }
    }
}
