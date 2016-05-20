using System.ComponentModel.DataAnnotations;

namespace OrderManagementSystem.Data.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }        
        public string Description { get; set; }
    }
}