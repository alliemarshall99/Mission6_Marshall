using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Mission6_Marshall.Models
{
    public class Category
    {
        [Key]
        [Required]
        public int CategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; }
    }

}
