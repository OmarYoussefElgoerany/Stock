using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockBLL
{
    public class AddItemDto
    {
        [Required]
        [MinLength(2, ErrorMessage = "The field Name minimum length '2'")]
        [MaxLength(50, ErrorMessage = "The field Name maximum length '50'")]
        public string Name { get; set; } = string.Empty;
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        public int StoreId { get; set; }
    }
}
