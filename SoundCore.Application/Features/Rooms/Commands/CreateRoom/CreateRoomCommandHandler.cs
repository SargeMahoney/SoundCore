using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SoundCore.Application.Contracts.Persistence;
using SoundCore.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace SoundCore.Application.Features.Rooms.Commands.CreateRoom
{
    public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, CreateRoomCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<CreateRoomCommandHandler> _logger;
        private readonly IRoomsRepository _roomsRepository;

        public CreateRoomCommandHandler(IMapper mapper,ILogger<CreateRoomCommandHandler> logger,  IRoomsRepository roomsRepository)
        {
            this._mapper = mapper;
            this._logger = logger;
            this._roomsRepository = roomsRepository;
        }

        public async Task<CreateRoomCommandResponse> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateRoomCommandResponse();
            
            var room = this._mapper.Map<Room>(request);
            room = await this._roomsRepository.AddAsync(room);

            response.Room = this._mapper.Map<CreateRoomDto>(room);
            _logger.LogInformation(request.ToString());
            return response;

        }
    }
}
