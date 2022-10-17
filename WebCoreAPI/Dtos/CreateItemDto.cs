using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebCoreAPI.Dtos
{
    public record CreateItemDto
    {
        [Required]
        public string Name { get; init; }
        [Required]
        [Range(1, 1000)]
        public int Price { get; init; }
    }
}
