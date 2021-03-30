using SoundCore.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SoundCore.BlazorComponents.Features.Rooms.Services
{
    public interface IRoomsManagementService
    {
        Task<IEnumerable<Room>> GetRooms();
    }
}