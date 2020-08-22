using Rage;

namespace GarageVehicleSave
{
    internal static class Config
    {
        public static readonly InitializationFile INIFile = new InitializationFile(@"Plugins\GarageVehicleSave.ini");

        public static readonly bool SpawnVehicleLeftOnLoad = INIFile.ReadBoolean("General", "SpawnVehicleLeftOnLoad", false);
        public static readonly bool SpawnVehicleRightOnLoad = INIFile.ReadBoolean("General", "SpawnVehicleRightOnLoad", false);

        public static readonly string SpawnVehicleNameLeft = INIFile.ReadString("General", "SpawnVehicleNameLeft", "");
        public static readonly string SpawnVehicleNameRight = INIFile.ReadString("General", "SpawnVehicleNameRight", "");

        public static readonly bool SpawnVehicleParkingLotOnLoad = INIFile.ReadBoolean("General", "SpawnVehicleParkingLotOnLoad", false);
        public static readonly string SpawnVehicleNameParkingLot = INIFile.ReadString("General", "SpawnVehicleNameParkingLot", "");

    }
}
