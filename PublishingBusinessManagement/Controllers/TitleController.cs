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
    public class TitleController : ControllerBase
    {
        private ITitleService _titleService;

        public TitleController(ITitleService titleService)
        {
            this._titleService = titleService;
        }

        [HttpGet]
        [Authorize(Roles = AppRole.Admin)]
        public async Task<IActionResult> GetAllTitles()
        {
            var titles = await _titleService.GetAllTittlesAsync();
            return Ok(titles);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = AppRole.Admin)]
        public async Task<IActionResult> GetTitleById(string id)
        {
            var title = await _titleService.GetTitlleByIdAsync(id);
            if (title == null)
            {
                return NotFound();
            }
            return Ok(title);
        }

        [HttpPost]
        [Authorize(Roles = AppRole.Admin)]
        public async Task<IActionResult> CreateTitle(Title title)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _titleService.AddTitleAsync(title);      
            return CreatedAtAction(nameof(GetTitleById), new { id = title.TitleId}, title);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = AppRole.Admin)]
        public async Task<IActionResult> UpdateTitle(string id, [FromBody] Title title)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            title.TitleId = id;
            await _titleService.UpdateTitleAsync(title);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = AppRole.Admin)]
        public async Task<IActionResult> DeleteTitle(string id)
        {
            await _titleService.DeleteTitleAsync(id);
            return NoContent();
        }
    }
}
