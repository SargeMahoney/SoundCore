using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SoundCore.Application.Features.Appointments.Commands.AddAppointment;
using SoundCore.Application.Features.Appointments.Commands.UpdateAppointment;
using SoundCore.Application.Features.Appointments.Queries.GetAppointmentList;
using SoundCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoundCore.Server.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<AppointmentController> _logger;
        private readonly IMapper _mapper;

        public AppointmentController(IMediator mediator, ILogger<AppointmentController> logger, IMapper map)
        {
            this._mediator = mediator;
            this._logger = logger;
            this._mapper = map;
        }

        [HttpGet("all", Name = "GetAllAppointments")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<AppointMentListVm>>> GetAllAppointments()
        {
            try
            {
                var dtos = await _mediator.Send(new GetAppointmentListQuery());
                //throw new Exception("prova");
                return Ok(dtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }

        }



        [HttpPost("create",Name = "AddAppointment")]
        public async Task<ActionResult<Appointment>> AddAppointment([FromBody] Appointment appointment)
        {

            var createEventCommand = _mapper.Map<AddAppointmentCommand>(appointment);
            var id = await _mediator.Send(createEventCommand);
            appointment.Id = id;
            return Created("appointment", appointment);
        }


        [HttpPost("update", Name = "UpdateAppointment")]
        public async Task<ActionResult<Appointment>> UpdateAppointment([FromBody] Appointment appointment)
        {

            var UpdateAppointment = _mapper.Map<UpdateAppointmentCommand>(appointment);
            var modifiedAppointment = await _mediator.Send(UpdateAppointment);           
            return Ok(modifiedAppointment);
        }

    }
}
