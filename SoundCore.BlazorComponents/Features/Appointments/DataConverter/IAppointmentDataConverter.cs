using SoundCore.BlazorComponents.Features.Appointments.SchedulerForAppointments;
using SoundCore.Domain.Entities;
using System.Collections.Generic;

namespace SoundCore.BlazorComponents.Features.Appointments.DataConverter
{
    public interface IAppointmentDataConverter
    {
        IEnumerable<AppointmentData> ConvertAppointmentListToAppointmentData(List<Appointment> appointment);
        AppointmentData ConvertAppointmentToAppointmentData(Appointment appointment);
        Appointment ConvertAppointmentDataToAppointment(AppointmentData appointmentData); 
    }
}