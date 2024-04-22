using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tracker.API.RequestModels;
using Tracker.Data.Entities;
using Tracker.Domain.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tracker.API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class PipelineController : ControllerBase
    {
        private readonly IGroupRepository _groupRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public PipelineController(IGroupRepository groupRepository, ICategoryRepository categoryRepository, IMapper mapper)
        {
            _groupRepository = groupRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> GetAllByGroup()
        {
            var categoryList = await _groupRepository.GetAllGroups();

            return Ok(categoryList);
        }

        [HttpGet]
        [Route("groups")]
        public async Task<IActionResult> GetAllExpenses()
        {
            var categoryList = await _groupRepository.GetAllGroups();
            
            return Ok(categoryList);
        }

        // GET api/<PipelineController>/5
        [HttpGet("/group/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var category = await _groupRepository.GetGroupById(id);

            return Ok(category);
        }

        // POST api/<PipelineController>
        [HttpPost]
        [Route("/group")]
        public async Task<OkObjectResult> PostAsync([FromBody] GroupRequest request)
        {

            await _groupRepository.AddGroup(_mapper.Map<Group>(request));

            return Ok("added successfully");
        }

        // PUT api/<PipelineController>/5
        [HttpPut("/group/{id}")]
        public async Task<OkObjectResult> Put(int id, [FromBody] GroupRequest request)
        {
            await _groupRepository.UpdateGroup(_mapper.Map<Group>(request));

            return Ok("Updated successfully");
        }

        // DELETE api/<PipelineController>/5
        [HttpDelete("/group/{id}")]
        public void Delete(int id)
        {
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
