using SoundCore.Application.Models.Searchs;
using SoundCore.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SoundCore.Application.Contracts.Infrastructure
{
    public interface ISearchService
    {
        Task<IEnumerable<SearchResult>> Search(string stringToSearch);
        Task AddDocumentAppointmentList(List<Appointment> myObject);
        Task AddDocumentList<T>(List<T> myObject);
        Task AddDocument<T>(T myObject);

        Task AddDocumentRoomList(List<Room> myObject);
    }
}