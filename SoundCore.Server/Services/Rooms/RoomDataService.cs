using SoundCore.Application.Contracts.Persistence;
using SoundCore.Application.Models.Results;
using SoundCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace SoundCore.Server.Services.Rooms
{
    public class RoomDataService : IRoomsDataService
    {
        private readonly HttpClient _httpClient;

        public RoomDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public  async Task<Room> AddAsync(Room entity)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResult> DeleteAsync(Room entity)
        {
            throw new NotImplementedException();
        }

        public Task<Room> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Room>> ListAllAsync()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Room>>
                (await _httpClient.GetStreamAsync($"api/rooms/all"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public Task<BaseResult> UpdateAsync(Room entity)
        {
            throw new NotImplementedException();
        }
    }
}
