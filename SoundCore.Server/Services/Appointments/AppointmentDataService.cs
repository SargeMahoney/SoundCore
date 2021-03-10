using AutoMapper;
using SoundCore.Application.Contracts.DataServices;
using SoundCore.Application.Features.Appointments.Commands.AddAppointment;
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

namespace SoundCore.Server.Services.Appointments
{
    public class AppointmentDataService : IAppointmentDataService
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;

        public AppointmentDataService(HttpClient httpClient, IMapper mapper)
        {
            _httpClient = httpClient;
            this._mapper = mapper;
        }
        public async Task<Appointment> AddAsync(Appointment entity)
        {
            try
            {

                var entityJson =
                new StringContent(JsonSerializer.Serialize(entity), Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync($"api/appointment/create", entityJson);

                if (response.IsSuccessStatusCode)
                {
                   var result = await  response.Content.ReadFromJsonAsync<Appointment>();
                    return result;
                }

                return null;

             
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
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

        public async Task<BaseResult> UpdateAsync(Appointment entity)
        {
            try
            {

                var entityJson =
                new StringContent(JsonSerializer.Serialize(entity), Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync($"api/appointment/update", entityJson);

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
