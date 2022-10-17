using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCoreAPI.Dtos;
using WebCoreAPI.Entities;

namespace WebCoreAPI
{
    public static class Extension
    {
        public static ItemDto AsDto(this Item item)
        {
            return new ItemDto()
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                CreatedDate = item.CreatedDate
            };
        }
    }
}
