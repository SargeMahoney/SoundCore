using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SoundCore.Application.Features.Rooms.Queries.GetRoomsList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoundCore.Server.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<RoomsController> _logger;

        public RoomsController(IMediator mediator, ILogger<RoomsController> logger)
        {
            this._mediator = mediator;
            this._logger = logger;
        }

        [HttpGet("all", Name = "GetAllCategories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<RoomListVm>>> GetAllRooms()
        {
            try
            {
                var dtos = await _mediator.Send(new GetRoomListQuery());
                //throw new Exception("prova");
                return Ok(dtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
      
        }
    }
}
