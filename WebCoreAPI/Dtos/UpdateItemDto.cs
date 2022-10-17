using System.ComponentModel.DataAnnotations;

namespace WebCoreAPI.Controllers
{
    public record UpdateItemDto
    {
        [Required]
        public string Name { get; init; }
        [Required]
        [Range(1, 1000)]
        public int Price { get; init; }
    }
}