using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Array.ApplicationServices.EntityServices;
using Array.Repository.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
namespace Array.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdeaController : ControllerBase
    {
        #region fields
        private readonly IIdeaService _ideaService;
        private readonly ILogger<IdeaController> _logger;
        #endregion
        #region constructor
        public IdeaController(IIdeaService ideaService, ILogger<IdeaController> logger)
        {
            _ideaService = ideaService;
            _logger = logger;
        }
        #endregion
        #region methods
        [HttpGet("[action]")]
        [Produces(typeof(int))]
        public async Task<IActionResult> Count(Func<Idea, bool> predicate)
        {
            try
            {
                var resp = await _ideaService.Count(predicate);
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPost("[action]")]
        [Produces(typeof(void))]
        public async Task<IActionResult> Create(Idea model)
        {
            try
            {
                await _ideaService.Create(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpDelete("[action]")]
        [Produces(typeof(void))]
        public async Task<IActionResult> Delete(Idea model)
        {
            try
            {
                await _ideaService.Delete(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet("[action]")]
        [Produces(typeof(IEnumerable<Idea>))]
        public async Task<IActionResult> Get(long[] Ids)
        {
            try
            {
                var resp = await _ideaService.Get(Ids);
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet("GetAll")]
        [Produces(typeof(IEnumerable<Idea>))]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _ideaService.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet("GetById")]
        [Produces(typeof(Idea))]
        public async Task<IActionResult> Get(long Id)
        {
            try
            {
                return Ok(await _ideaService.Get(Id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPost("[action]")]
        [Produces(typeof(void))]
        public async Task<IActionResult> Update(Idea model)
        {
            try
            {
                await _ideaService.Update(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        #endregion
    }
}