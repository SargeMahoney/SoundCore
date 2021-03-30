using SoundCore.Application.Contracts.DataServices;
using SoundCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundCore.BlazorComponents.Features.Rooms.Services
{
    public class RoomsManagementService : IRoomsManagementService
    {
        private readonly IRoomsDataService _roomsDataService;




        public RoomsManagementService(IRoomsDataService roomsDataService)
        {
            this._roomsDataService = roomsDataService;
        }



        public async Task<IEnumerable<Room>> GetRooms()
        {
            return await _roomsDataService.ListAllAsync();
        }
    }
}
