using SoundCore.BlazorComponents.Features.Appointments.SchedulerForAppointments;
using SoundCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundCore.BlazorComponents.Features.Appointments.DataConverter
{
    public class AppointmentDataConverter : IAppointmentDataConverter
    {

        public AppointmentDataConverter()
        {

        }


        public AppointmentData ConvertAppointmentToAppointmentData(Appointment appointment)
        {

            return new AppointmentData()
            {
                Id = appointment.Id,
                CategoryColor = string.Empty,
                Description = string.Empty,
                EndTime = appointment.End,
                IsAllDay = false,
                Location = string.Empty,
                RecurrenceException = string.Empty,
                RecurrenceID = null,
                RecurrenceRule = string.Empty,
                StartTime = appointment.Start,
                Subject = appointment.Owner,
                RoomId = appointment.RoomId
            };
        }

        public Appointment ConvertAppointmentDataToAppointment(AppointmentData appointmentData)
        {
            try
            {
                return new Appointment()
                {
                    Id = appointmentData.Id,
                    CreationDate = DateTime.Now,
                    End = appointmentData.EndTime,
                    Start = appointmentData.StartTime,
                    Owner = appointmentData.Subject,
                    RoomId = appointmentData.RoomId
                };
            }
            catch (Exception ex)
            {

                throw;
            }


        }

        public IEnumerable<AppointmentData> ConvertAppointmentListToAppointmentData(List<Appointment> appointment)
        {
            List<AppointmentData> data = new List<AppointmentData>();
            foreach (var item in appointment)
            {
                var app =  new AppointmentData()
                {
                    Id = item.Id,
                    CategoryColor = string.Empty,
                    Description = string.Empty,
                    EndTime = item.End,
                    IsAllDay = false,
                    Location = string.Empty,
                    RecurrenceException = string.Empty,
                    RecurrenceID = null,
                    RecurrenceRule = string.Empty,
                    StartTime = item.Start,
                    Subject = item.Owner,
                    RoomId = item.RoomId
                };

                data.Add(app);
            }

            return data;

        }
    }
}
