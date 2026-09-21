using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UTB.Eshop.Domain.Validations;

namespace UTB.Eshop.Domain.Entities
{
    [Table(nameof(Product))]
    public class Product : Entity<int>
    {
        [Required]
        [StringLength(70)]
        [FirstLetterUppercase]
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public string? ImageSrc { get; set; }
    }
}
