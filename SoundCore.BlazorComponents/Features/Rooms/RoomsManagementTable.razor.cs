using AutoMapper;
using Microsoft.AspNetCore.Components;
using SoundCore.Application.Contracts.DataServices;
using SoundCore.Application.Features.Rooms.Models;
using SoundCore.BlazorComponents.Features.Rooms.Services;
using SoundCore.Domain.Entities;
using Syncfusion.Blazor.Grids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundCore.BlazorComponents.Features.Rooms
{
    public partial class RoomsManagementTable : IDisposable
    {

        [Inject]
        protected  IRoomsManagementService _roomsService { get; set; }

        [Inject]
        protected IMapper _mapper { get; set; }


        List<RoomModel> RoomsView { get; set; }

     
        SfGrid<RoomModel> RoomDatagrid { get; set; }

        protected async override Task OnInitializedAsync()
        {

            RoomsView = _mapper.Map<List<RoomModel>>((await _roomsService.GetRooms()).ToList());
            
        }

        void IDisposable.Dispose()
        {
            RoomsView.Clear();
        }


        public async void ActionBegin(ActionEventArgs<RoomModel> arg)
        {
            if (arg.RequestType.Equals(Syncfusion.Blazor.Grids.Action.Save))
            {
                if (arg.Action.Equals("Add"))
                {
                    arg.Cancel = true;                    
                    await RoomsCreation(arg.Data);

                }
                else
                {
                    await RoomsUpdate(arg.Data);
                   // await ModificaEquipment(arg);
                }
            }
        }

        private async Task RoomsCreation(RoomModel room)
        {
            var addedRoom = await _roomsService.AddRoom(_mapper.Map<Room>(room));
            room.Id = addedRoom.Data.Id;
            room.CreationDate = DateTime.Today;
            RoomsView.Add(room);
            await DatagridRefreshAfterDialogAction();
        }

        private async Task RoomsUpdate(RoomModel room)
        {
            var updatedRoomResult = await _roomsService.UpdateRoom(_mapper.Map<Room>(room),room.Id);
            var oldRoom = RoomsView.FirstOrDefault(r => r.Id == room.Id);
            RoomsView.Remove(oldRoom);
            RoomsView.Add(room);
            await DatagridRefreshAfterDialogAction();
        }



        private async Task DatagridRefreshAfterDialogAction()
        {
            await RoomDatagrid.CloseEdit();
            RoomDatagrid.Refresh();
        }
    }
}
