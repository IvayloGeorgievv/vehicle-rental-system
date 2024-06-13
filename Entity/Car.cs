
namespace Vehicle_Rental_System.Entity
{
    //This class represents a Car and extends the Vehicle abstract class by adding a Car safety rating property
    public class Car : Vehicle
    {
        private int carSafetyRating;
        public int CarSafetyRating
        {
            get { return carSafetyRating; }
            set { carSafetyRating = value; }
        }

        public Car(string vehicleBrand, string vehicleModel, double vehicleValue, int carSafetyRating)
                : base(vehicleBrand, vehicleModel, vehicleValue)
        {
            CarSafetyRating = carSafetyRating;
        }
    }
}
