using SoundCore.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundCore.Application.Features.Rooms.Models
{
    public class RoomModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage ="Name is Required!")]
        public string Name { get; set; }
        public string Description { get; set; }

        [Range(minimum:1,maximum:int.MaxValue,ErrorMessage ="Room State cant be not defined")]
        public RoomState State { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
