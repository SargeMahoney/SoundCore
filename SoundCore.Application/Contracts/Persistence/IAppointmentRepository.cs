using SoundCore.Domain.Entities;

namespace SoundCore.Application.Contracts.Persistence
{
    public interface IAppointmentRepository : IAsyncRepository<Appointment>
    {
    }
}
