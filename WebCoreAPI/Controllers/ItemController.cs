using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCoreAPI.Dtos;
using WebCoreAPI.Entities;
using WebCoreAPI.Repositories;

namespace WebCoreAPI.Controllers
{   [ApiController]
    [Route("item")]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository itemRepository;

        public ItemController(IItemRepository repository)
        {
            this.itemRepository = repository;
        }

        // GET /items
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<ItemDto>>> GetItemsAsync()
        {
            return Ok((await itemRepository.GetItemsAsync()).Select(item => item.AsDto()));
        }

        // GET /Items/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDto>> GetItemAsync(Guid id)
        {
            var result = await this.itemRepository.getItemAsync(id);
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result.AsDto());
        }

        [HttpPost]
        public async Task<ActionResult<ItemDto>> CreateItemAsync(CreateItemDto itemDto)
        {
            var item = new Item()
            {
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
                Price = itemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };

            await this.itemRepository.CreateItemAsync(item);

            return CreatedAtAction(nameof(GetItemAsync), new { id = item.Id }, item.AsDto());
        }

        // PUT /item/{Id}
        [HttpPut("{Id}")]
        public async Task<ActionResult> UpdateItemAsync(Guid Id, UpdateItemDto updateItemDto)
        {
            Item item = await this.itemRepository.getItemAsync(Id);

            if (item is null)
            {
                return NotFound();
            }

            Item newItem = item with
            {
                Name = updateItemDto.Name,
                Price = updateItemDto.Price
            };

            await this.itemRepository.UpdateItemAsync(newItem);

            return NoContent();
        }

        // DELETE /item/{Id}
        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteItemAsync( Guid Id )
        {
            Item item = await this.itemRepository.getItemAsync(Id);

            if( item is null )
            {
                return NotFound();
            }

            await this.itemRepository.DeleteItemAsync(item.Id);

            return NoContent();
        }
    }
}
