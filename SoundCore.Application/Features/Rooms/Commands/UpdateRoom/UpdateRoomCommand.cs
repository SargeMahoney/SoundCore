using MediatR;
using SoundCore.Domain.Entities;
using SoundCore.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundCore.Application.Features.Rooms.Commands.UpdateRoom
{
    public class UpdateRoomCommand : IRequest<Room>
    {
        public Guid Id { get; set; }
  
        public string Name { get; set; }
        public string Description { get; set; }

        public RoomState State { get; set; }
    }
}
