using SoundCore.Application.Contracts.DataServices;
using SoundCore.Application.Contracts.Persistence;
using SoundCore.Application.Models.Results;
using SoundCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
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
            try
            {

                var entityJson =
                new StringContent(JsonSerializer.Serialize(entity), Encoding.UTF8, "application/json");

            
                var response = await _httpClient.PostAsync($"api/rooms/create", entityJson);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<Room>();
                    return result;
                }

                return null;


            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public async Task<BaseResult> DeleteAsync(Room entity)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/rooms/{entity.Id.ToString()}");

                if (response.IsSuccessStatusCode)
                {
                    return new BaseResult();
                }
                else
                {
                    return new BaseResult(message: "errore", success: false);
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
           
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

        public async Task<BaseResult> UpdateAsync(Room entity)
        {
            try
            {

                var entityJson =
                new StringContent(JsonSerializer.Serialize(entity), Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync($"api/rooms/update", entityJson);

                if (response.IsSuccessStatusCode)
                {
                    return await JsonSerializer.DeserializeAsync<BaseResult>(await response.Content.ReadAsStreamAsync());
                }

                return null;


            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
    }
}
