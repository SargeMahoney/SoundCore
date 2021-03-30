using SoundCore.Application.Models.Results;
using SoundCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SoundCore.BlazorComponents.Features.Rooms.Services
{
    public interface IRoomsManagementService
    {
        Task<IEnumerable<Room>> GetRooms();

        Task<DataResult<Room>> AddRoom(Room newRoom);

        Task<DataResult<Room>> UpdateRoom(Room updatedRoom, Guid roomId);
    }
}