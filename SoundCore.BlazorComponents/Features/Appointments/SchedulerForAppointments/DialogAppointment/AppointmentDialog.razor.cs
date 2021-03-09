using Microsoft.AspNetCore.Components;
using SoundCore.Domain.Entities;
using System.Collections.Generic;

namespace SoundCore.BlazorComponents.Features.Appointments.SchedulerForAppointments.DialogAppointment
{
    public partial class AppointmentDialog
    {

        [Parameter]
        public IEnumerable<Room> Rooms { get; set; }


 

        [Parameter]
        public AppointmentData Appointment 
        {
            get => this._appointmentData;
            set
            {
                if (this._appointmentData == value)
                {
                    return;
                }

                this._appointmentData = value;
                AppointmentChanged.InvokeAsync(value);
            }
        }
        private AppointmentData _appointmentData;
        [Parameter]
        public EventCallback<AppointmentData> AppointmentChanged { get; set; }
    }
}
