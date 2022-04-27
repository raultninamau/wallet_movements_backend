using Microsoft.AspNetCore.Mvc;
using Movements.Domain;
using Movements.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Movements.Rest.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovementsController : ControllerBase
    {
        private readonly IMovementsService movementsService;

        public MovementsController(IMovementsService movementsService)
        {
            this.movementsService = movementsService;
        }

        [HttpGet("GetMovements")]
        public IActionResult GetMovements()
        {
            return Ok(this.movementsService.getMovements());
        }

        [HttpGet("GetMovement")]
        public IActionResult GetMovement(Guid id)
        {
            return Ok(this.movementsService.getMovement(id));
        }

        [HttpPost("SaveMovement")]
        public IActionResult SaveMovement([FromBody]Movement movement)
        {
            this.movementsService.saveMovement(movement);
            return Ok();
        }

        [HttpDelete("DeleteMovement")]
        public IActionResult DeleteMovement(Guid id)
        {
            this.movementsService.deleteMovement(id);
            return Ok();
        }

        [HttpPut("UpdateMovement")]
        public IActionResult PutMovement([FromBody]Movement movement, Guid id)
        {
            this.movementsService.updateMovement(movement, id);
            return Ok();
        }
    }
}