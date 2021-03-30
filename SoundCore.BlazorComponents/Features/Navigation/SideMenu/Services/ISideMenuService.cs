using SoundCore.BlazorComponents.Features.Navigation.SideMenu.Models;
using System;
using System.Threading.Tasks;

namespace SoundCore.BlazorComponents.Features.Navigation.SideMenu.Services
{
    public interface ISideMenuService : IDisposable
    {
        enumButtonState HomeButton { get; set; }
        enumButtonState SchedulerButton { get; set; }

        enumButtonState RoomsButton { get; set; }

        Task HomeButtonClicked();
        Task ScheduleButtonClicked();

        Task RoomsButtonClicked();
    }
}