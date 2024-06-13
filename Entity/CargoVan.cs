
namespace Vehicle_Rental_System.Entity
{
    //This class represents a Cargo van and inherits Vehicle class
    public class CargoVan : Vehicle
    {
        public CargoVan(string vehicleBrand, string vehicleModel, double vehicleValue)
                : base(vehicleBrand, vehicleModel, vehicleValue)
        {
        }
    }
}
