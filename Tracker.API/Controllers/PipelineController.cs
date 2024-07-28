using AutoMapper;
using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tracker.API.RequestModels;
using Tracker.Data.Entities;
using Tracker.Domain.Repository;
using Tracker.Domain.UseCase;
using Tracker.Domain.UseCase.Mails;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tracker.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class PipelineController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public PipelineController(ICategoryRepository categoryRepository, IMapper mapper, IMediator mediator)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _mediator = mediator;
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
            List<Category> categoryList = await _categoryRepository.GetAllCategories();

            return Ok(categoryList);
        }

        // GET api/<PipelineController>/5
        [HttpGet]
        [Route("/category/{id}")]
        public async Task<IActionResult> GetCategory(Guid id)
        {
            Category category = await _categoryRepository.GetCategoryById(id);

            if (category == null)
            {
                throw new KeyNotFoundException($"Category Not Found for id {id}");
            }

            return Ok(category);
        }

        // POST api/<PipelineController>
        [HttpPost]
        [Route("/category")]
        public async Task<OkObjectResult> PostCategoryAsync([FromBody] CategoryRequest request)
        {

            await _categoryRepository.AddCategory(_mapper.Map<Category>(request));

            return Ok(request);
        }

        // PUT api/<PipelineController>/5
        [HttpPut]
        [Route("/category/{id}")]
        public async Task<OkObjectResult> Put(int id, [FromBody] CategoryRequest request)
        {
            await _categoryRepository.UpdateCategory(_mapper.Map<Category>(request));

            return Ok(request);
        }

        [HttpPatch]
        [Route("/category/{id}")]
        public async Task<OkObjectResult> Patch(Guid id, [FromBody] CategoryRequest request)
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

        [HttpPost]
        [Route("/mails")]
        public async Task<OkObjectResult> AddExpenseMail([FromBody] List<EmailDto> request)
        {
            await _mediator.Send(new AddMailsCommand { ExpenseMails = _mapper.Map<List<ExpenseMail>>(request) });

            return Ok("Updated successfully");
        }
    }
}
