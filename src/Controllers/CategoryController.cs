using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using user.src.Services;
using user.src.Utils;
using static user.src.DTO.CategoryDTO;

namespace user.src.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CategoryController : ControllerBase
    {
        protected readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService service)
        {
            _categoryService = service;
        }


        // create
        [HttpPost]
        public async Task<ActionResult<CategoryReadDto>> CreateOneController([FromBody] CategoryCreateDto createDto)
        {
            var categoryCreated = await _categoryService.CreateOneAsync(createDto);
            return Ok(categoryCreated);
        }

        // get all 
        // [Authorize]
        // using Microsoft.AspNetCore.Authorization;

        [HttpGet]
        public async Task<ActionResult<List<CategoryReadDto>>> GetAllAsync([FromQuery] PaginationOptions paginationOptions)
        {
            var categoryList = await _categoryService.GetAllAsync(paginationOptions);
            return Ok(categoryList);
        }

        // id
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CategoryReadDtoPro>> GetByIdAsync([FromRoute] Guid id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            return Ok(category);
        }

        // id:guid => type of guid
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<bool>> DeleteOneAsync([FromRoute] Guid id)
        {
            var isDeleted = await _categoryService.DeleteOneASync(id);
            return Ok(isDeleted);
        }

        // put
        [HttpPut]
        public async Task<ActionResult<CategoryReadDto>> CreateOneAsync([FromRoute] Guid id, [FromBody] CategoryUpdateDto updateDto)
        {
            var categoryUpdated = await _categoryService.UpdateOneAsync(id, updateDto);
            return Ok(categoryUpdated);
            // return Created($"api/categories/{categoryUpdated.Id}", categoryUpdated);

        }
    }
}