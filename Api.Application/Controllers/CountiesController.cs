using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Dtos.County;
using Api.Domain.Interfaces.Services.County;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountiesController : ControllerBase
    {
        private readonly ICountyService _service;
        public CountiesController(ICountyService service)
        {
            _service = service;
        }

        [Authorize("Bearer")]
        [HttpGet]
        public async Task<ActionResult> GetAll() 
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _service.GetAll());
            }
            catch (ArgumentException e)
            {
                return StatusCode ((int) HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpGet]
        [Route("{id}", Name = "GetCountyWithId")]
        public async Task<ActionResult> Get(Guid id) 
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.Get(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (ArgumentException e)
            {
                return StatusCode ((int) HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CountyDtoCreate dto) 
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.Post(dto);
                if (result != null) 
                {
                    return Created(new Uri(Url.Link("GetCountyWithId", new {id = result.Id})), result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (ArgumentException e)
            {
                return StatusCode ((int) HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] CountyDtoUpdate dto) 
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.Put(dto);
                if (result == null)
                    return BadRequest();

                return Ok(result);
            }
            catch (ArgumentException e)
            {
                return StatusCode ((int) HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(Guid id) 
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _service.Delete(id));
            }
            catch (ArgumentException e)
            {
                return StatusCode ((int) HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpGet]
        [Route("findByIBGE/{ibge}")]
        public async Task<ActionResult> FindCompleteByIBGE(int ibge) 
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _service.FindCompleteByIBGE(ibge));
            }
            catch (ArgumentException e)
            {
                return StatusCode ((int) HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpGet]
        [Route("findByName/{name}")]
        public async Task<ActionResult> FindCompleteByName(string name) 
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _service.FindCompleteByName(name));
            }
            catch (ArgumentException e)
            {
                return StatusCode ((int) HttpStatusCode.InternalServerError, e.Message);
            }
        }

    }
}