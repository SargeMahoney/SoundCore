using Microsoft.AspNetCore.Components;
using SoundCore.Application.Contracts.DataServices;
using SoundCore.BlazorComponents.Features.Rooms.Services;
using SoundCore.Domain.Entities;
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


        List<Room> RoomsView { get; set; }

     

        protected async override Task OnInitializedAsync()
        {

            RoomsView = (await _roomsService.GetRooms()).ToList();
            
        }

        void IDisposable.Dispose()
        {
            RoomsView.Clear();
        }
    }
}
