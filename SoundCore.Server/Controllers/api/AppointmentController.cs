using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SoundCore.Application.Features.Appointments.Queries.GetAppointmentList;
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

        public AppointmentController(IMediator mediator, ILogger<AppointmentController> logger)
        {
            this._mediator = mediator;
            this._logger = logger;
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
    }
}
