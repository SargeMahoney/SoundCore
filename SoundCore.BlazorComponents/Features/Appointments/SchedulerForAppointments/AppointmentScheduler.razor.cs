using Microsoft.AspNetCore.Components;
using SoundCore.Application.Contracts.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SoundCore.Domain.Entities;
using System.Threading.Tasks;
using SoundCore.BlazorComponents.Features.Appointments.DataConverter;

namespace SoundCore.BlazorComponents.Features.Appointments.SchedulerForAppointments
{
    public partial class AppointmentScheduler
    {
        public DateTime CurrentDate { get; set; } = DateTime.Now;

        public IEnumerable<AppointmentData> Data { get; set; }

        [Inject]
        public IAppointmentDataService _appointmentService { get; set; }


        [Inject]
        public IAppointmentDataConverter _appointmentConverter { get; set; }

        protected  async override Task OnInitializedAsync()
        {
            var data = await _appointmentService.ListAllAsync();
            Data = _appointmentConverter.ConvertAppointmentListToAppointmentData(data.ToList());
            

        }

    }
}
