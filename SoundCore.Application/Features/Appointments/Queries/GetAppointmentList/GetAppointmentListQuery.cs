using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundCore.Application.Features.Appointments.Queries.GetAppointmentList
{
    public class GetAppointmentListQuery : IRequest<List<AppointMentListVm>>
    {
    }
}
