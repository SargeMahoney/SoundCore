using SoundCore.BlazorComponents.Features.Navigation.SideMenu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundCore.BlazorComponents.Features.Navigation.SideMenu.Services
{
    public class SideMenuService : ISideMenuService
    {
        public enumButtonState HomeButton { get; set; } = enumButtonState.Selected;
        public enumButtonState SchedulerButton { get; set; } = enumButtonState.Active;
        public enumButtonState RoomsButton { get; set; } = enumButtonState.Active;


        public void ResetButtonState()
        {
            HomeButton = enumButtonState.Active;
            SchedulerButton = enumButtonState.Active;
            RoomsButton = enumButtonState.Active;
        }

        public async Task ScheduleButtonClicked()
        {

            await Task.Delay(50);
            ResetButtonState();
            SchedulerButton = enumButtonState.Selected;
 
        }

        public async Task HomeButtonClicked()
        {

            await Task.Delay(50);
            ResetButtonState();        
            HomeButton = enumButtonState.Selected;
        }

        public async Task RoomsButtonClicked()
        {

            await Task.Delay(50);
            ResetButtonState();
            RoomsButton = enumButtonState.Selected;
        }

        public void Dispose()
        {
            ResetButtonState();    
        }
    }
}
