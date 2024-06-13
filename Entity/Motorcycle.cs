
namespace Vehicle_Rental_System.Entity
{
    //This class represents a Motorcycle and inherits Vehicle class
    public class Motorcycle : Vehicle
    {
        public Motorcycle(string vehicleBrand, string vehicleModel, double vehicleValue)
                : base(vehicleBrand, vehicleModel, vehicleValue)
        {
        }
    }
}
