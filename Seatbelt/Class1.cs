using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTA;
using System.Windows.Forms;
using System.IO;
using KeyEventArgs = GTA.KeyEventArgs;


namespace Seatbelt
{
    public class Seatbelt : Script
    {
        SettingsFile config = SettingsFile.Open("Seatbelt.ini");
        Keys SeatbeltOn;
        Keys SeatbeltOff;
        public Seatbelt()
        {
            
            SeatbeltOn = config.GetValueKey("SeatbeltOn", "Keys", Keys.G);
            SeatbeltOff = config.GetValueKey("SeatbeltOff", "Keys", Keys.K);

            KeyDown += OnKeydown;
        
        }

   



        private void OnKeydown(object sender, KeyEventArgs e)
        {
            if (e.Key == SeatbeltOn)
            {
                if (Game.LocalPlayer.Character.isInVehicle())
                {
                    Game.LocalPlayer.Character.WillFlyThroughWindscreen = false;
                    Game.DisplayText("Seatbelt enabled");
                }
            }
                

            if (e.Key == SeatbeltOff)
            {
                if (Game.LocalPlayer.Character.isInVehicle())
                {
                    Game.LocalPlayer.Character.WillFlyThroughWindscreen = true;
                    Game.DisplayText("Seatbelt disabled");
                }
            }
            
        }
      
    


    }

}