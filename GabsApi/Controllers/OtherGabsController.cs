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
    /// Other Gabs controller.
    /// </summary>
    [ApiController]
    [Route("api/gabs/{gabsId}/othergabs")]
    public class OtherGabsController : ControllerBase
    {
        private readonly IGabsRepository _repository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Other Gabs controller.
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public OtherGabsController(IGabsRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Get other Gabs by id.
        /// </summary>
        /// <param name="gabsId"></param>
        /// <param name="id"></param>
        /// <returns>An IAction result type.</returns>
        /// <response code="200">Returns a Gabs by id.</response>
        [HttpGet("{id}", Name = "GetOtherGabs")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetOtherGabs(int gabsId, int id)
        {
            var getOtherGabs = _repository.GetOtherGabs(gabsId, id);
            return Ok(_mapper.Map<OtherGabsDto>(getOtherGabs));
        }

        /// <summary>
        /// Get a "other Gabs" list.
        /// </summary>
        /// <returns>An IAction Result type.</returns>
        /// <response code="200">Returns a "GetOtherGabs" Collection.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetOtherGabss()
        {
            var getOtherGabss = _repository.GetOtherGabss();
            return Ok(_mapper.Map<IEnumerable<OtherGabsDto>>(getOtherGabss));
        }

        /// <summary>
        /// Post a new Gabs.
        /// </summary>
        /// <param name="gabsId"></param>
        /// <param name="otherGabsDto"></param>
        /// <returns>An IAction result type.</returns>
        /// <response code="201">Returns the newly created Gabs.</response>
        /// <response code="404">Returns Not Found if Gabs doesn't exists.</response>
        /// <response code="400">Returns a Bad Request if the description is equal to name.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult PostNewGabs(int gabsId, [FromBody] OtherGabsDto otherGabsDto)
        {
            if (!_repository.GabsExists(gabsId))
            {
                return NotFound();
            }

            if (otherGabsDto.Name == otherGabsDto.Description)
            {
                ModelState.AddModelError("Description", "The description must be different from the name, sorry :(");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entityToDto = _mapper.Map<OtherGabs>(otherGabsDto);
            _repository.AddNewGabs(gabsId, entityToDto);
            _repository.Save();
            var dtoToEntity = _mapper.Map<OtherGabsDto>(entityToDto);
            return CreatedAtRoute("GetOtherGabs", new { gabsId, id = otherGabsDto.Id }, dtoToEntity);
        }

        /// <summary>
        /// Update an existing Gabs.
        /// </summary>
        /// <param name="gabsId"></param>
        /// <param name="id"></param>
        /// <param name="gabsDto"></param>
        /// <returns>An IAction Result type.</returns>
        /// <response code="204">Returns an updated Gabs.</response>
        /// <response code="404">Returns Not Found if Gabs doesn't exists.</response>
        /// <response code="400">Returns a Bad Request if the description is equal to name.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateGabs(int gabsId, int id, [FromBody] OtherGabsDto gabsDto)
        {
            if (gabsDto.Name == gabsDto.Description)
            {
                ModelState.AddModelError("description", "The description must be different from the name, sorry :(");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_repository.GabsExists(id))
            {
                return NotFound();
            }
            var validateGabs = _repository.GetOtherGabs(gabsId, id);

            if (validateGabs == null)
            {
                NotFound();
            }

            _mapper.Map(gabsDto, validateGabs);
            _repository.Save();
            return NoContent();
        }
    }
}