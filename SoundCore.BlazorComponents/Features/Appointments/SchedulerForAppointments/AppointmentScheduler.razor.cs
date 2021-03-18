using AutoMapper;
using Microsoft.AspNetCore.Components;
using SoundCore.Application.Contracts.DataServices;
using SoundCore.BlazorComponents.Features.Appointments.DataConverter;
using SoundCore.Domain.Entities;
using Syncfusion.Blazor.Schedule;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace SoundCore.BlazorComponents.Features.Appointments.SchedulerForAppointments
{
    public partial class AppointmentScheduler
    {

        SfSchedule<AppointmentData> Scheduler { get; set; }
        public DateTime CurrentDate { get; set; } = DateTime.Now;

        public List<AppointmentData> AppointmentData { get; set; }

        public IEnumerable<Room> RoomsData { get; set; }

        [Inject]
        public IAppointmentDataService _appointmentService { get; set; }


        [Inject]
        public IRoomsDataService _roomsDataService { get; set; }


        [Inject]
        public IAppointmentDataConverter _appointmentConverter { get; set; }

        [Inject]
        public IMapper _mapper { get; set; }



        public string[] Resources { get; set; } = { "Rooms" };

        protected  async override Task OnInitializedAsync()
        {
            var data = await _appointmentService.ListAllAsync();
            AppointmentData = _appointmentConverter.ConvertAppointmentListToAppointmentData(data.ToList()).ToList();

            var rooms = await _roomsDataService.ListAllAsync();
            RoomsData = rooms;

        }

        public async Task OnActionStarted(ActionEventArgs<AppointmentData> args)
        {
           // args.Cancel = true;
            switch (args.ActionType)
            {
                case ActionType.EventChange:
                    var modifiedAppointment = args.ChangedRecords[0];
                    args.Cancel = true;
                    await ChangeAppointment(modifiedAppointment);
                    break;
                case ActionType.EventCreate:
                    var newAppointment = args.AddedRecords[0];
                    args.Cancel = true;          
                    await AddAppointment(newAppointment);   
                    break;
                case ActionType.EventRemove:
                    var deletedAppointment = args.DeletedRecords[0];
                    args.Cancel = true;
                    await DeleteAppointment(deletedAppointment);
                    break;                      
                default:
                    break;
            }

        }

        private async Task ChangeAppointment(AppointmentData appointment)
        {

            if (appointment.Id == Guid.Empty)
            {
                return;
            }

             var check = AppointmentData.IsSpaceAvailableForAppoinemnt(appointment);

            if (check)
            {
                var appointmentData = _appointmentConverter.ConvertAppointmentDataToAppointment(appointment);
                var result = await _appointmentService.UpdateAsync(appointmentData);
                if (result.Success)
                {
                    var x = AppointmentData.FirstOrDefault(x => x.Id == appointmentData.Id);
                    AppointmentData.Remove(x);
                    AppointmentData.Add(appointment);


                }


                Scheduler.CloseEditor();
                await Scheduler.RefreshEvents();
                await InvokeAsync(StateHasChanged);
            }
               
            
     
       
        }

        private async Task DeleteAppointment(AppointmentData appointment)
        {

            if (appointment.Id == Guid.Empty)
            {
                return;
            }
            var appointmentData = _appointmentConverter.ConvertAppointmentDataToAppointment(appointment);
            var result = await _appointmentService.DeleteAsync(appointmentData);
            if (result.Success)
            {
                var changedAppointmentInsideCollection = AppointmentData.FirstOrDefault(x => x.Id == appointmentData.Id);
                AppointmentData.Remove(changedAppointmentInsideCollection);

            }


            Scheduler.CloseEditor();
            await Scheduler.RefreshEvents();

        }




        private async Task AddAppointment(AppointmentData appointment)
        {
          
            if (appointment.Id == Guid.Empty)
            {
                return;
            }

            var Availability = true;
            Availability = await Scheduler.IsSlotAvailable(appointment);

            if (Availability)
            {
                var appointmentData = _appointmentConverter.ConvertAppointmentDataToAppointment(appointment);
                var addedAppointment = await _appointmentService.AddAsync(appointmentData);
                var addedAppointmentData = _appointmentConverter.ConvertAppointmentToAppointmentData(addedAppointment);
                AppointmentData.Add(addedAppointmentData);
                Scheduler.CloseEditor();
                await Scheduler.RefreshEvents();
            }

         
        }

        private async Task UpdateAppointment(AppointmentData appointment)
        {
            if (appointment.Id == Guid.Empty)
            {
                return;
            }
            var appointmentData = _appointmentConverter.ConvertAppointmentDataToAppointment(appointment);
            var addedAppointment = await _appointmentService.UpdateAsync(appointmentData);
            var changedAppointmentInsideCollection = AppointmentData.FirstOrDefault(x => x.Id == appointmentData.Id);
            changedAppointmentInsideCollection = appointment;
             await Scheduler.RefreshEvents();
        }

        public async Task OnPopupOpen(PopupOpenEventArgs<AppointmentData> args)
        {

    
            switch (args.Type)
            {
      
                case PopupType.QuickInfo:
               
                    args.Cancel = true;

                    /*
                    if (args.Data.Id == Guid.Empty)
                    {
                        await Scheduler.OpenEditor(args.Data, CurrentAction.Add);
                    }
                    else
                    {
                        await Scheduler.OpenEditor(args.Data, CurrentAction.EditFollowingEvents);
                    }                 
                    */
                    break;              
                default:
                    break;
            }

        }

        public void SingleClickCell(CellClickEventArgs args)
        {

            args.Cancel = true;
        }





    }
}
