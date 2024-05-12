using AutoMapper;
using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Tracker.API.RequestModels;
using Tracker.API.ResponseModels;
using Tracker.Data.Entities;
using Tracker.Domain.UseCase;

namespace Tracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DueController : Controller
    {

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public DueController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Returns all the dues and goals.
        /// </summary>
        [HttpGet]
        //[Route("{loanId}/condition")]
        public async Task<IActionResult> GetLoanConditionsByLoanId()
        {
            try
            {
                var dues = await _mediator.Send(new GetAllDuesRequest { Id = 3 });

                if (dues == null)
                {
                    return new NoContentResult();
                }

                return Ok(dues);

            }
            catch (ArgumentException err)
            {
                return StatusCode(StatusCodes.Status400BadRequest, err.Message);
            }
            catch (KeyNotFoundException err)
            {
                return StatusCode(StatusCodes.Status404NotFound, err.Message);
            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, err.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Details(Guid id)
        {
            try
            {
                var dues = await _mediator.Send(new GetDueByIdRequest { Id = id });

                if (dues == null)
                {
                    return new NoContentResult();
                }

                return Ok(dues);

            }
            catch (ArgumentException err)
            {
                return StatusCode(StatusCodes.Status400BadRequest, err.Message);
            }
            catch (KeyNotFoundException err)
            {
                return StatusCode(StatusCodes.Status404NotFound, err.Message);
            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, err.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddDue([FromBody] AddDueRequest request)
        {
            try
            {
                var dues = await _mediator.Send(new AddDueCommand { dueRequst = _mapper.Map<Due>(request) });

                if (dues == null)
                {
                    return new NoContentResult();
                }

                return Ok(dues);

            }
            catch (ArgumentException err)
            {
                return StatusCode(StatusCodes.Status400BadRequest, err.Message);
            }
            catch (KeyNotFoundException err)
            {
                return StatusCode(StatusCodes.Status404NotFound, err.Message);
            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, err.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(Guid id, [FromBody] AddDueRequest request)
        {
            try
            {
                var dues = await _mediator.Send(new UpdateCommand { Id = id,  DueData = _mapper.Map<Due>(request) });

                if (dues == null)
                {
                    return new NoContentResult();
                }

                return Ok(dues);

            }
            catch (ArgumentException err)
            {
                return StatusCode(StatusCodes.Status400BadRequest, err.Message);
            }
            catch (KeyNotFoundException err)
            {
                return StatusCode(StatusCodes.Status404NotFound, err.Message);
            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, err.Message);
            }
        }

        // POST: DueController/Delete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var dues = await _mediator.Send(new DeleteCommand { Id = id });

                if (dues == null)
                {
                    return new NoContentResult();
                }

                return Ok(dues);

            }
            catch (ArgumentException err)
            {
                return StatusCode(StatusCodes.Status400BadRequest, err.Message);
            }
            catch (KeyNotFoundException err)
            {
                return StatusCode(StatusCodes.Status404NotFound, err.Message);
            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, err.Message);
            }
        }
    }
}
