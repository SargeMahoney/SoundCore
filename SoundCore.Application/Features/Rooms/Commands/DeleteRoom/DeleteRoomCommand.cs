using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundCore.Application.Features.Rooms.Commands.DeleteRoom
{
    public class DeleteRoomCommand : IRequest
    {
        public Guid RoomId { get; set; }
    }
}
