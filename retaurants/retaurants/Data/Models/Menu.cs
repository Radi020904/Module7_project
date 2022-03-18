using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restaurants.Data.Models
{
    public class Menu
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        [Key]
        public int Id { get; set; }
        [Required]
        [Range(typeof(double), "1.00", "10.00")]
        public double Rating { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "menu type is too long!")]
        public string Type { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "menu language is too long")]
        public string Language { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "menu link is too long")]
        public string Link { get; set; }
        public override string ToString()
        {
            string result = "Menu:\n";
            result += $"rating: {Rating}\n";
            result += $"type: {Type}\n";
            result += $"language: {Language}\n";
            result += $"link: {Link}";
            return result;
        }
    }
}
