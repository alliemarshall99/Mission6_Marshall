using System.ComponentModel.DataAnnotations;

namespace Mission6_Marshall.Models
{
    public class Film
    {

        [Key]
        [Required]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public int Year { get; set; }
        public string Rating { get; set; }
        public bool Edited { get; set; }
        public string LentTo { get; set; }
        [Range(0, 25)]
        public string Notes { get; set; }
        
    }

}
