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
                //Game.DisplayHelp("Hello World!");

                Game.DisplayNotification("GarageVehiclePlugin loaded successfully");
                Game.LogTrivial("GarageVehiclePlugin loaded successfully");
                
                Vector3 garageRight = new Vector3(462.6767f, -1014.554f, 28.0658f);
                Vector3 garageMiddle = new Vector3(463.0877f, -1016.823f, 28.08117f);
                Vector3 garageLeft = new Vector3(463.2594f, -1019.51f, 28.10522f);
                
                Vector3 parkingLot = new Vector3(446.0237f, -1025.801f, 27.95778f);
                // float parkingLotHeading = 5.635557f;

                Vehicle savedVehicleLeft = null;
                Vehicle savedVehicleRight = null;

                if(Config.SpawnVehicleLeftOnLoad)
                {
                    savedVehicleLeft = new Vehicle(Config.SpawnVehicleNameLeft, garageLeft, 90f);
                }
                if (Config.SpawnVehicleRightOnLoad)
                {
                    savedVehicleRight = new Vehicle(Config.SpawnVehicleNameRight, garageRight, 90f);
                }
                if (Config.SpawnVehicleParkingLotOnLoad)
                {
                    savedVehicleRight = new Vehicle(Config.SpawnVehicleNameParkingLot, parkingLot, 0f);
                }

                while (true)
                {
                    GameFiber.Yield();
                    //while (Game.LocalPlayer.Character.CurrentVehicle != null)
                    //{
                    //GameFiber.Yield();

                    // Vehicle LEFT
                    if (Game.LocalPlayer.Character.DistanceTo(garageLeft) < 2f)
                    {
                        if (Game.LocalPlayer.Character.CurrentVehicle != null)
                        {
                            Game.DisplayNotification("Vehicle saved to left garage!");
                            savedVehicleLeft = Game.LocalPlayer.Character.CurrentVehicle;
                            savedVehicleLeft.MakePersistent();
                        }
                        //break;
                    }

                    if(savedVehicleLeft != null)
                    {
                        if (savedVehicleLeft.DistanceTo(garageLeft) < 2f)
                        {
                            savedVehicleLeft.MakePersistent();
                        }
                    }

                    // Vehicle Right
                    if (Game.LocalPlayer.Character.DistanceTo(garageRight) < 2f)
                    {
                        if (Game.LocalPlayer.Character.CurrentVehicle != null)
                        {
                            Game.DisplayNotification("Vehicle saved to right garage!");
                            savedVehicleRight = Game.LocalPlayer.Character.CurrentVehicle;
                            savedVehicleRight.MakePersistent();
                        }
                        //break;
                    }

                    if (savedVehicleRight != null)
                    {
                        if (savedVehicleRight.DistanceTo(garageRight) < 2f)
                        {
                            savedVehicleRight.MakePersistent();
                        }
                    }

                    // Clean vehicles
                    if (Game.LocalPlayer.Character.DistanceTo(garageMiddle) > 20f && Game.LocalPlayer.Character.DistanceTo(garageMiddle) < 50f)
                    {
                        if (savedVehicleLeft != null && savedVehicleLeft.DistanceTo(garageLeft) < 2f)
                        {
                            if (Game.LocalPlayer.Character.CurrentVehicle != savedVehicleLeft)
                            {
                                savedVehicleLeft.Repair();
                                savedVehicleLeft.Wash();
                            }
                        }
                        if (savedVehicleRight != null && savedVehicleRight.DistanceTo(garageRight) < 2f)
                        {
                            if (Game.LocalPlayer.Character.CurrentVehicle != savedVehicleRight)
                            {
                                savedVehicleRight.Repair();
                                savedVehicleRight.Wash();
                            }
                        }
                    }

                    if (Game.IsKeyDown(System.Windows.Forms.Keys.Enter))
                    {
                        Game.DisplayNotification(Convert.ToString(Game.LocalPlayer.Character.Position.X) + ", " + Convert.ToString(Game.LocalPlayer.Character.Position.Y) + ", " + Convert.ToString(Game.LocalPlayer.Character.Position.Z) + ", " + Convert.ToString(Game.LocalPlayer.Character.Heading));
                        Game.LogTrivial(Convert.ToString(Game.LocalPlayer.Character.Position.X) + "f, " + Convert.ToString(Game.LocalPlayer.Character.Position.Y) + "f, " + Convert.ToString(Game.LocalPlayer.Character.Position.Z) + "f" + ", " + Convert.ToString(Game.LocalPlayer.Character.Heading) + "f");
                    }
                    //}

                }
            });
        }
    }
}
