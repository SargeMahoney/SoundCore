using AutoMapper;
using MediatR;
using SoundCore.Application.Contracts.Persistence;
using SoundCore.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace SoundCore.Application.Features.Rooms.Commands.CreateRoom
{
    public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, CreateRoomCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRoomsRepository _roomsRepository;

        public CreateRoomCommandHandler(IMapper mapper, IRoomsRepository roomsRepository)
        {
            this._mapper = mapper;
            this._roomsRepository = roomsRepository;
        }

        public async Task<CreateRoomCommandResponse> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateRoomCommandResponse();
            
            var room = this._mapper.Map<Room>(request);
            room = await this._roomsRepository.AddAsync(room);

            response.Room = this._mapper.Map<CreateRoomDto>(room);

            return response;

        }
    }
}
