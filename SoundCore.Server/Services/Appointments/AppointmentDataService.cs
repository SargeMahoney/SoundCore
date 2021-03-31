using AutoMapper;
using SoundCore.Application.Contracts.DataServices;
using SoundCore.Application.Contracts.Infrastructure;
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
        private readonly ISearchService _searchService;

        public AppointmentDataService(HttpClient httpClient, IMapper mapper, ISearchService searchService)
        {
            _httpClient = httpClient;
            this._mapper = mapper;
            this._searchService = searchService;
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

        public async Task<BaseResult> DeleteAsync(Appointment entity)
        {
            try
            {

           

                var response = await _httpClient.DeleteAsync($"api/appointment/{entity.Id.ToString()}");

                if (response.IsSuccessStatusCode)
                {
                    return new BaseResult();
                }
                else
                {
                    return new BaseResult(message: "errore",success:false);
                }

         


            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public Task<Appointment> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Appointment>> ListAllAsync()
        {
            var result = await JsonSerializer.DeserializeAsync<IEnumerable<Appointment>>
                (await _httpClient.GetStreamAsync($"api/appointment/all"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            await _searchService.AddDocumentAppointmentList(result.ToList());
            return result;

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
