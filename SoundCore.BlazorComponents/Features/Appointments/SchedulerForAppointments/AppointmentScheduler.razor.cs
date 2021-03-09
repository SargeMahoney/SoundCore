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

        public IEnumerable<AppointmentData> AppointmentData { get; set; }

        public IEnumerable<Room> RoomsData { get; set; }

        [Inject]
        public IAppointmentDataService _appointmentService { get; set; }


        [Inject]
        public IRoomsDataService _roomsDataService { get; set; }


        [Inject]
        public IAppointmentDataConverter _appointmentConverter { get; set; }

        public string[] Resources { get; set; } = { "Rooms" };

        protected  async override Task OnInitializedAsync()
        {
            var data = await _appointmentService.ListAllAsync();
            AppointmentData = _appointmentConverter.ConvertAppointmentListToAppointmentData(data.ToList());

            var rooms = await _roomsDataService.ListAllAsync();
            RoomsData = rooms;



        }

    }
}
