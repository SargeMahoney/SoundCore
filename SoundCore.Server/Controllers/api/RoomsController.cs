using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SoundCore.Application.Features.Rooms.Commands.CreateRoom;
using SoundCore.Application.Features.Rooms.Queries.GetRoomsList;
using SoundCore.Domain.Entities;
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
        private readonly IMapper _mapper;

        public RoomsController(IMediator mediator, ILogger<RoomsController> logger, IMapper mapper)
        {
            this._mediator = mediator;
            this._logger = logger;
            this._mapper = mapper;
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

        [HttpPost("create", Name = "AddRoom")]
        public async Task<ActionResult<Appointment>> AddRoom([FromBody] Room room)
        {

            var createRoomCommand = _mapper.Map<CreateRoomCommand>(room);
            var response = await _mediator.Send(createRoomCommand);
            room.Id = response.Room.Id;
            return Created("room", room);
        }

    }
}
