
namespace Vehicle_Rental_System.Entity
{
    //This abstract class represents general vehicle with common properties. It is inteded to be a base class for the specific types of vehicles
    public abstract class Vehicle
    {
        private string vehicleBrand;
        private string vehicleModel;
        private double vehicleValue;

        public string VehicleBrand
        {
            get { return vehicleBrand; }
            set { vehicleBrand = value; }
        }
        public string VehicleModel
        {
            get { return vehicleModel; }
            set { vehicleModel = value; }
        }
        public double VehicleValue
        {
            get { return vehicleValue; }
            set { vehicleValue = value; }
        }

        public Vehicle(string vehicleBrand, string vehicleModel, double vehicleValue)
        {
            VehicleBrand = vehicleBrand;
            VehicleModel = vehicleModel;
            VehicleValue = vehicleValue;
        }
    }
}
