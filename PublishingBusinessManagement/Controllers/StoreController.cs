using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PublishingBusinessManagement.Helpers;
using PublishingBusinessManagement.Models;
using PublishingBusinessManagement.Repositories.UnitOfWork;
using PublishingBusinessManagement.Services;

namespace PublishingBusinessManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStoreService _storeService;

        public StoreController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        [HttpGet]
        [Authorize(Roles = AppRole.Admin)]
        public async Task<IActionResult> GetAllStores()
        {
            var stores = await _storeService.GetAllStoresAsync();
            return Ok(stores);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = AppRole.Admin)]
        public async Task<IActionResult> GetStoreById(string id)
        {
            var store = await _storeService.GetStoreByIdAsync(id);
            if (store == null)
            {
                return NotFound();
            }
            return Ok(store);
        }

        [HttpPost]
        [Authorize(Roles = AppRole.Admin)]
        public async Task<IActionResult> CreateStore([FromBody] Store store)
        {
            if (!ModelState.IsValid)
            {             
                return BadRequest(ModelState);
            }
            await _storeService.AddStoreAsync(store);
            return CreatedAtAction(nameof(GetStoreById), new { id = store.StorId }, store);
        }
    

        [HttpPut("{id}")]
        [Authorize(Roles = AppRole.Admin)]
        public async Task<IActionResult> UpdateStore(string id, [FromBody]  Store store)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            store.StorId = id;
            await _storeService.UpdateStoreAsync(store);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = AppRole.Admin)]
        public async Task<IActionResult> DeleteStore(string id)
        {
            await _storeService.DeleteStoreAsync(id);
            return NoContent();
        }

    }
}
