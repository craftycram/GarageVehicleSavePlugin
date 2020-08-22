using Rage;
using System;

[assembly: Rage.Attributes.Plugin("GarageVehiclePlugin", Description = "Saves the vehicle you leave in the Mission Row police station.", Author = "craftycram")]
namespace GarageVehicleSave
{
    public static class EntryPoint
    {
        public static void Main()
        {
            GameFiber.StartNew(delegate
            {
                Game.DisplayHelp("Hello World!");
                Game.DisplayNotification("This is a notification");
                Game.LogTrivial("GarageVehiclePlugin loaded successfully");

                while (true)
                {
                    GameFiber.Yield();

                    //while (Game.LocalPlayer.Character.CurrentVehicle != null)
                    //{
                    //GameFiber.Yield();
                    Vector3 garageLeft = new Vector3(469.007f, -1013.146f, 0f);
                    Vector3 garageRight = new Vector3();
                    if (Game.LocalPlayer.Character.DistanceTo(garageLeft) < 30f)
                    {
                        Game.DisplayNotification("You're nearby a Garage!");
                        //break;
                    }

                    if (Game.IsKeyDown(System.Windows.Forms.Keys.P))
                    {
                        Game.DisplayNotification(Convert.ToString(Game.LocalPlayer.Character.Position.X) + ", " + Convert.ToString(Game.LocalPlayer.Character.Position.Y) + ", " + Convert.ToString(Game.LocalPlayer.Character.Position.Z));
                        Game.LogTrivial(Convert.ToString(Game.LocalPlayer.Character.Position.X) + ", " + Convert.ToString(Game.LocalPlayer.Character.Position.Y) + ", " + Convert.ToString(Game.LocalPlayer.Character.Position.Z));
                    }
                    //}



                }




            });
        }
    }
}
