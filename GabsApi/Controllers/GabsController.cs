using System;
using System.Collections.Generic;
using AutoMapper;
using GabsApi.Model;
using GabsApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GabsApi.Controllers
{
    /// <summary>
    /// A Gabs controller.
    /// </summary>
    [ApiController]
    [Route("api/gabs")]
    public class GabsController : ControllerBase
    {
        private readonly IGabsRepository _repository;
        private readonly IMapper _mapper;

        /// <summary>
        /// A Gabs controller.
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public GabsController(IGabsRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Get a list of Gabs containing all the Gabs.
        /// </summary>
        /// <returns>An Action Result type.</returns>
        /// <response code="200">Returns a Gabs Collection.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetGabss()
        {
            var getGabss = _repository.GetGabss();
            return Ok(_mapper.Map<IEnumerable<GabsDto>>(getGabss));
        }

        /// <summary>
        /// Get a Gabs by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>An Action Result type.</returns>
        /// <response code="200">Returns a Gabs by id.</response>
        [HttpGet("{id}")]
        public IActionResult GetGabs(int id)
        {
            var getGabs = _repository.GetGabs(id);
            return Ok(_mapper.Map<GabsDto>(getGabs));
        }
    }
}