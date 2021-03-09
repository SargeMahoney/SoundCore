using Microsoft.AspNetCore.Components;
using SoundCore.Application.Contracts.DataServices;
using SoundCore.BlazorComponents.Features.Appointments.DataConverter;
using SoundCore.Domain.Entities;
using Syncfusion.Blazor.Schedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoundCore.BlazorComponents.Features.Appointments.SchedulerForAppointments
{
    public partial class AppointmentScheduler
    {

        SfSchedule<AppointmentData> Scheduler { get; set; }
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

        public async Task OnActionStarted(ActionEventArgs<AppointmentData> args)
        {
           // args.Cancel = true;
            switch (args.ActionType)
            {
                case ActionType.EventChange:
                    break;
                case ActionType.EventCreate:
                    if (args.AddedRecords[0].Id == Guid.Empty)
                    {
                        return;
                    }
                    var appointmentData = _appointmentConverter.ConvertAppointmentDataToAppointment(args.AddedRecords[0]);                    
                    var addedAppointment = await _appointmentService.AddAsync(appointmentData);
                    var addedAppointmentData = _appointmentConverter.ConvertAppointmentToAppointmentData(addedAppointment);
                    await Scheduler.AddEvent(addedAppointmentData);
                    break;
                case ActionType.EventRemove:
                    break;                      
                default:
                    break;
            }

        }


        public async Task OnPopupOpen(PopupOpenEventArgs<AppointmentData> args)
        {          
            switch (args.Type)
            {
      
                case PopupType.QuickInfo:
               
                    args.Cancel = true;
                    if (args.Data.Id == Guid.Empty)
                    {
                        await Scheduler.OpenEditor(args.Data, CurrentAction.Add);
                    }
                    else
                    {
                        await Scheduler.OpenEditor(args.Data, CurrentAction.EditFollowingEvents);
                    }                 
                    break;              
                default:
                    break;
            }

        }


    }
}
