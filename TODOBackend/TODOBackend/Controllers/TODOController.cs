using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using TODOBackend.Repo;


namespace TODOBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TODOController : ControllerBase
    {

        Repo.ITODORepo TODORepo { get; }
        IMapper Mapper { get; }
        ILogger Logger { get; }

        public TODOController(ITODORepo toDoRepo, IMapper mapper, ILogger<TODOController> logger)
        {
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            TODORepo = toDoRepo ?? throw new ArgumentNullException(nameof(toDoRepo));
        }

        /// <summary>
        /// Get all products
        /// </summary>
        /// <response code="200">List of all products</response>
        [HttpGet]
        public IEnumerable<Dto.TODOItemModel> Get()
        {
            return TODORepo.Get().Select(Mapper.Map<Dto.TODOItemModel>);
        }

        /// <summary>
        /// Get a product by id
        /// </summary>
        /// <param name="id">A product id</param>
        [ProducesResponseType(typeof(Dto.TODOItemModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        [Route("{id}")]
        public Dto.TODOItemModel GetById(string id)
        {
            return Mapper.Map<Dto.TODOItemModel>(TODORepo.GetById(id));
        }

        /// <summary>
        /// Create a new product
        /// </summary>
        /// <param name="id">A new product id</param>
        /// <param name="newTodoItemDto">New product data</param>
        /// <response code="201">The created product</response>
        [ProducesResponseType(typeof(Dto.TODOItemModel), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public IActionResult Create(string id, [FromBody]Dto.UpdateTODOItem newTodoItemDto)
        {
            var newTODOItem = new Model.TODOItemModel(id);
            Mapper.Map(newTodoItemDto, newTODOItem);
            TODORepo.Create(newTODOItem);

            var createdTODOItem = TODORepo.GetById(newTODOItem.Id);

            Logger.LogInformation("New product was created: {@TODOItemModel}", createdTODOItem);

            return Created($"{id}", Mapper.Map<Dto.TODOItemModel>(createdTODOItem));
        }

        /// <summary>
        /// Update a product
        /// </summary>
        /// <param name="id">Id of the product to update</param>
        /// <param name="todoItemDto">Product data</param>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(string id, [FromBody]Dto.UpdateTODOItem todoItemDto)
        {
            var todoItem = TODORepo.GetById(id);
            Mapper.Map(todoItemDto, todoItem);
            TODORepo.Update(todoItem);
            return Ok();
        }

        /// <summary>
        /// Delete a product
        /// </summary>
        /// <param name="id">Id of the product to delete</param>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(string id)
        {
            TODORepo.Delete(id);
            return Ok();
        }

        /// <summary>
        /// Example of an exception handling
        /// </summary>
        [HttpGet("ThrowAnException")]
        public IActionResult ThrowAnException()
        {
            throw new Exception("Example exception");
        }

    }
}
