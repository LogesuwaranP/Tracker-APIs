using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tracker.API.RequestModels;
using Tracker.Data.Entities;
using Tracker.Domain.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tracker.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class PipelineController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public PipelineController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("/all")]
        public async Task<IActionResult> GetAll()
        {
            var categoryList = await _categoryRepository.GetAllData();

            return Ok(categoryList);
        }

        [HttpGet]
        [Route("/category")]
        public async Task<IActionResult> GetAllCategories()
        {
            var categoryList = await _categoryRepository.GetAllCategories();

            return Ok(categoryList);
        }

        // GET api/<PipelineController>/5
        [HttpGet]
        [Route("/category/{id}")]
        public async Task<IActionResult> GetCategory(Guid id)
        {
            var category = await _categoryRepository.GetCategoryById(id);

            return Ok(category);
        }

        // POST api/<PipelineController>
        [HttpPost]
        [Route("/category")]
        public async Task<OkObjectResult> PostCategoryAsync([FromBody] CategoryRequest request)
        {

            await _categoryRepository.AddCategory(_mapper.Map<Category>(request));

            return Ok("added successfully");
        }

        // PUT api/<PipelineController>/5
        [HttpPut]
        [Route("/category/{id}")]
        public async Task<OkObjectResult> Put(int id, [FromBody] CategoryRequest request)
        {
            await _categoryRepository.UpdateCategory(_mapper.Map<Category>(request));

            return Ok("Updated successfully");
        }

        // DELETE api/<PipelineController>/5
        [HttpDelete]
        [Route("/category/{id}")]
        public void DeleteCategory(int id)
        {
        }
    }
}
