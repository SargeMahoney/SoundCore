using SoundCore.Application.Contracts.DataServices;
using SoundCore.Application.Models.Results;
using SoundCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace SoundCore.Server.Services.Appointments
{
    public class AppointmentDataService : IAppointmentDataService
    {
        private readonly HttpClient _httpClient;


        public AppointmentDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public Task<Appointment> AddAsync(Appointment entity)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResult> DeleteAsync(Appointment entity)
        {
            throw new NotImplementedException();
        }

        public Task<Appointment> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Appointment>> ListAllAsync()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Appointment>>
                (await _httpClient.GetStreamAsync($"api/appointment/all"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public Task<BaseResult> UpdateAsync(Appointment entity)
        {
            throw new NotImplementedException();
        }
    }
}
