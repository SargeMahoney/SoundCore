using AutoMapper;
using MediatR;
using SoundCore.Application.Contracts.Persistence;
using SoundCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SoundCore.Application.Features.Rooms.Commands.UpdateRoom
{
    public class UpdateRoomCommandHandler : IRequestHandler<UpdateRoomCommand, Room>
    {

        private readonly IMapper _mapper;
        private readonly IRoomsRepository _roomRepository;
        public UpdateRoomCommandHandler(IMapper mapper, IRoomsRepository roomRepository)
        {
            this._roomRepository = roomRepository;
            this._mapper = mapper;
        }
        public async Task<Room> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
        {
            var modifiedRoom = this._mapper.Map<Room>(request);
            var updateRoomResult = await this._roomRepository.UpdateAsync(modifiedRoom);

            if (updateRoomResult.Success)
            {
                return modifiedRoom;
            }
            else
            {
                return new Room();
            }
        }
    }
}
