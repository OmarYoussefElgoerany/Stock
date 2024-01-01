using System.ComponentModel.DataAnnotations;

namespace StockBLL.Dtos.StoreDto
{
    public class AddStoreDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "The field Name minimum length '3'")]
        [MaxLength(50, ErrorMessage = "The field Name maximum length '50'")]
        public string Name { get; set; } = string.Empty;
        [MinLength(3, ErrorMessage = "The field Address minimum length of '3'")]
        [MaxLength(100, ErrorMessage = "The field Address maximum length '50'")]
        public string? Address { get; set; }
    }
}
