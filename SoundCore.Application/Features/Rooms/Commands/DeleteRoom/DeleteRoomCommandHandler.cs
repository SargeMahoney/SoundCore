using AutoMapper;
using MediatR;
using SoundCore.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SoundCore.Application.Features.Rooms.Commands.DeleteRoom
{
    public class DeleteRoomCommandHandler : IRequestHandler<DeleteRoomCommand>
    {
        private readonly IMapper _mapper;
        private readonly IRoomsRepository _roomsRepository;

        public DeleteRoomCommandHandler(IMapper mapper, IRoomsRepository roomsRepository)
        {
            this._mapper = mapper;
            this._roomsRepository = roomsRepository;
        }
        public async Task<Unit> Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
        {
            var roomToDelete = await this._roomsRepository.GetByIdAsync(request.RoomId);

            if (roomToDelete == null)
            {
                throw new Exception();
            }

            await this._roomsRepository.DeleteAsync(roomToDelete);

            return Unit.Value;
        }
    }
}
