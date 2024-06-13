using System;
using Vehicle_Rental_System.Enum;

namespace Vehicle_Rental_System.Entity
{
    //This class represents an invoice that is created for renting a vehicle.
    //It contains details such as customer information, rented vehicle details, reservation dates, actual return date, rental costs and insurance costs
    public class RentalInvoice
    {
        private DateTime date;
        private string customerName;
        private int customerAge;
        private int customerDrivingExperience;
        private Vehicle rentedVehicle;
        private DateTime reservationStartDate;
        private DateTime reservationEndDate;
        private DateTime actualReturnDate;
        private double rentalCostPerDay;
        private double initialInsurancePerDay;
        private double insuranceAdditionOrDiscountPerDay;

        public DateTime Date
        {
            get { return date; }
            set { date = DateTime.Now; }
        }
        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; }
        }
        public int CustomerAge
        {
            get { return customerAge; }
            set { customerAge = value; }
        }
        public int CustomerDrivingExperience
        {
            get { return customerDrivingExperience; }
            set { customerDrivingExperience = value; }
        }
        public Vehicle RentedVehicle
        {
            get { return rentedVehicle; }
            set { rentedVehicle = value; }
        }
        public DateTime ReservationStartDate
        {
            get { return reservationStartDate; }
            set { reservationStartDate = value; }
        }
        public DateTime ReservationEndDate
        {
            get { return reservationEndDate; }
            set { reservationEndDate = value; }
        }
        public DateTime ActualReturnDate
        {
            get { return actualReturnDate; }
            set { actualReturnDate = value; }
        }
        public double RentalCostPerDay
        {
            get { return rentalCostPerDay; }
            set { rentalCostPerDay = value; }
        }
        public double InitialInsurancePerDay
        {
            get { return initialInsurancePerDay; }
            set { initialInsurancePerDay = value; }
        }

        public double InsuranceAdditionOrDiscountPerDay
        {
            get { return insuranceAdditionOrDiscountPerDay; }
            set { insuranceAdditionOrDiscountPerDay = value; }
        }

        //Constructor used when a Client rents a Car
        public RentalInvoice(string customerName, Vehicle rentedVehicle, DateTime reservationStartDate, DateTime reservationEndDate, DateTime actualReturnDate)
        {
            CustomerName = customerName;
            RentedVehicle = rentedVehicle;
            ReservationStartDate = reservationStartDate;
            ReservationEndDate = reservationEndDate;
            ActualReturnDate = actualReturnDate;
        }

        //Constructor used when a Client rents a Motorcycle OR CargoVan
        //Using an Enum for the type of vehicle that is rented we can assign CustomerAge (for a Motorcycle) or CustomerDrivingExperienc (for a CargoVan)
        public RentalInvoice(string customerName, int ageField, Vehicle rentedVehicle, DateTime reservationStartDate, DateTime reservationEndDate, DateTime actualReturnDate, VehicleTypeEnum vehicleType)
        {
            CustomerName = customerName;
            RentedVehicle = rentedVehicle;
            ReservationStartDate = reservationStartDate;
            ReservationEndDate = reservationEndDate;
            ActualReturnDate = actualReturnDate;
            if(vehicleType == VehicleTypeEnum.Motorcycle)
            {
                CustomerAge = ageField;
            }
            if(vehicleType == VehicleTypeEnum.CargoVan)
            {
                CustomerDrivingExperience = ageField;
            }
        }
    }
}
