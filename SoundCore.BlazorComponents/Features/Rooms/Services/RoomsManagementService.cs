using SoundCore.Application.Contracts.DataServices;
using SoundCore.Application.Models.Results;
using SoundCore.Domain.Entities;
using System;
using System.Collections.Generic;
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

        public async Task<DataResult<Room>> AddRoom(Room newRoom)
        {
            try
            {
                var result = await _roomsDataService.AddAsync(newRoom);

                if (result == null)
                {
                    return new DataResult<Room>(success: false, message: "Error while creating the new Room");
                }

                if (result.Id == Guid.Empty)
                {
                    return new DataResult<Room>(success: false, message: "Error while creating the new Room");
                }

                return new DataResult<Room>(data: result);
            }
            catch (Exception ex)
            {

                throw;
            }
    
        }

        public async Task<IEnumerable<Room>> GetRooms()
        {
            return await this._roomsDataService.ListAllAsync();
        }

        public Task<DataResult<Room>> UpdateRoom(Room updatedRoom, Guid roomId)
        {
            throw new NotImplementedException();
        }
    }
}
