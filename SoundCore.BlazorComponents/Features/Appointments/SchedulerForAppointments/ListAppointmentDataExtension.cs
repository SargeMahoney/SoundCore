using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundCore.BlazorComponents.Features.Appointments.SchedulerForAppointments
{
    public static class ListAppointmentDataExtension
    {

        public static bool IsSpaceAvailableForAppoinemnt(this List<AppointmentData> appointmentData, AppointmentData newAppointmentData)
        {
            if (newAppointmentData == null)
            {
                return false;
            }

            if (appointmentData == null)
            {
                return false;
            }



            var check = appointmentData.Where(x => newAppointmentData.StartTime >= x.StartTime && newAppointmentData.StartTime < x.EndTime || newAppointmentData.EndTime > x.StartTime && newAppointmentData.StartTime <= x.StartTime);
                                                
            if (check.Count() > 0)
            {
                return false;
            }
            else
            {
                return true;
            }

          
        }
    }
}
