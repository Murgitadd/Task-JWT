using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProniaOnionAlpha.Application.Abstractions.Services;
using ProniaOnionAlpha.Application.DTOs.Author;
using ProniaOnionAlpha.Application.DTOs.Authors;
using ProniaOnionAlpha.Application.DTOs.Department;
using ProniaOnionAlpha.Persistence.Implementations.Services;
using System.Text.Json;

namespace ProniaOnionAlpha.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _service;
        private readonly JwtService _token;

        public AuthorsController(IAuthorService service, JwtService token)
        {
            _service = service;
            _token = token;
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Get(int page = 1, int take = 3)
        {
            return Ok(await _service.GetAllAsync(page, take));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);

            return StatusCode(StatusCodes.Status200OK, await _service.GetAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] AuthorCreateDto authorCreateDto)
        {
            await _service.CreateAsync(authorCreateDto);

            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] AuthorUpdateDto authorUpdateDto)
        {
            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);
            await _service.UpdateAsync(id, authorUpdateDto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);
            await _service.SoftDeleteAsync(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }

        [HttpGet("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromQuery] LoginDto dto)
        { 
            var data = await _token.LogIn(dto);
        var request = JsonSerializer.Serialize(data);

            return Ok(request);
        }
}
}
