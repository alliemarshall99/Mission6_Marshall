using System.ComponentModel.DataAnnotations;

namespace Mission6_Marshall.Models
{
    public class Film
    {
        [Key]
        [Required]
        public int MovieId { get; set; }

        public int? CategoryId { get; set; }

        [Required]
        public required string Title { get; set; }

        [Required]
        public required int Year { get; set; }

        public string? Director { get; set; }
        public string? Rating { get; set; }

        [Required]
        public int Edited { get; set; }

        public string? LentTo { get; set; }

        [Required]
        public int CopiedToPlex { get; set; }

        public string? Notes { get; set; }

        public Category? Category { get; set; }
    }
}
