using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restaurants.Data.Models
{
    public class Company
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "company name is too long!")]
        public string Name { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "company name is too long!")]
        public string OwnerName { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
        [ForeignKey(nameof(Restaurant))]
        public int RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; }

        public override string ToString()
        {
            string result = "Company:\n";
            result += $"name: {Name}\n";
            result += $"OwnerName: {OwnerName}\n";
            result += $"CreationDate: {CreationDate}";
            result += $"restaurantId: {RestaurantId}";
            return result;
        }
    }
}
