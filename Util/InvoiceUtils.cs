using System;
using Vehicle_Rental_System.Constants;
using Vehicle_Rental_System.Entity;

namespace Vehicle_Rental_System.Util
{
    public class InvoiceUtils
    {
        //Method to generate the rental invoice in the correct format based on provided invoice information
        public void GenerateRentalInvoice(RentalInvoice invoice)
        {
            int reservedRentalDays = (invoice.ReservationEndDate - invoice.ReservationStartDate).Days;
            int actualRentalDays = (invoice.ActualReturnDate - invoice.ReservationStartDate).Days;

            invoice.RentalCostPerDay = CalculateRentalCostPerDay(invoice.RentedVehicle, invoice.ActualReturnDate, invoice.ReservationStartDate);
            invoice.InitialInsurancePerDay = CalculateInsurancePerDay(invoice.RentedVehicle);

            Console.WriteLine();
            Console.WriteLine("XXXXXXXXXX");
            Console.WriteLine($"Date: {invoice.Date.ToString(Formats.DateFormat)}");
            Console.WriteLine($"Customer Name: {invoice.CustomerName}");
            Console.WriteLine($"Rented Vehicle: {invoice.RentedVehicle.VehicleBrand} {invoice.RentedVehicle.VehicleModel}");
            Console.WriteLine();
            Console.WriteLine($"Reservaton start date: {invoice.ReservationStartDate.ToString(Formats.DateFormat)}");
            Console.WriteLine($"Reservation end date: {invoice.ReservationEndDate.ToString(Formats.DateFormat)}");
            Console.WriteLine($"Reserved rental days: {reservedRentalDays} days");
            Console.WriteLine();
            Console.WriteLine($"Actual return date: {invoice.ActualReturnDate.ToString(Formats.DateFormat)}");
            Console.WriteLine($"Actual rental days: {actualRentalDays} days");
            Console.WriteLine();
            Console.WriteLine($"Rental cost per day: ${string.Format(Formats.PriceFormat, invoice.RentalCostPerDay)}");

            //If there is nor addition or discount we just print the insurance per day
            if (!HasInsuranceAdditionOrDiscount(invoice.RentedVehicle, invoice.CustomerAge != 0 ? invoice.CustomerAge : invoice.CustomerDrivingExperience))
            {
                Console.WriteLine($"Insurance per day: ${string.Format(Formats.PriceFormat, invoice.InitialInsurancePerDay)}");
            }

            //If there is addition or discount we print the insurance data accordingly depending on the type of Vehicle 
            if (HasInsuranceAdditionOrDiscount(invoice.RentedVehicle, invoice.CustomerAge != 0 ? invoice.CustomerAge : invoice.CustomerDrivingExperience))
            {
                Console.WriteLine($"Initial insurance per day: ${string.Format(Formats.PriceFormat, invoice.InitialInsurancePerDay)}");
                invoice.InsuranceAdditionOrDiscountPerDay = CalculateInsuranceAdditionOrDiscountPerDay(invoice.RentedVehicle, invoice.InitialInsurancePerDay, invoice.CustomerAge != 0 ? invoice.CustomerAge : invoice.CustomerDrivingExperience);

                double insurancePerDay = 0;

                if (invoice.RentedVehicle is Motorcycle)
                {
                    Console.WriteLine($"Insurance addition per day: ${string.Format(Formats.PriceFormat, invoice.InsuranceAdditionOrDiscountPerDay)}");

                    insurancePerDay = invoice.InitialInsurancePerDay + invoice.InsuranceAdditionOrDiscountPerDay;
                }
                else
                {
                    Console.WriteLine($"Insurance discount per day: ${string.Format(Formats.PriceFormat, invoice.InsuranceAdditionOrDiscountPerDay)}");

                    insurancePerDay = invoice.InitialInsurancePerDay - invoice.InsuranceAdditionOrDiscountPerDay;

                }
                Console.WriteLine($"Insurance per day: ${string.Format(Formats.PriceFormat, insurancePerDay)}");
            }
            Console.WriteLine();

            //If the Vehicle is returned early we print Rent Discount and Insurance Discount
            if(actualRentalDays < reservedRentalDays)
            {
                double rentDiscount = CalculateRentDiscount(reservedRentalDays, actualRentalDays, invoice.RentalCostPerDay);
                double insuranceDiscount = CalculateInsuranceDiscount(reservedRentalDays, actualRentalDays, invoice.RentedVehicle, invoice.InitialInsurancePerDay, invoice.InsuranceAdditionOrDiscountPerDay);

                Console.WriteLine($"Early return discount for rent: ${string.Format(Formats.PriceFormat, rentDiscount)}");
                Console.WriteLine($"Early return discount for insurance: ${string.Format(Formats.PriceFormat, insuranceDiscount)}");
                Console.WriteLine();
            }

            double totalRent = CalculateTotalRent(reservedRentalDays, actualRentalDays, invoice.RentalCostPerDay);
            double totalInsurance = CalculateTotalInsurance(invoice.RentedVehicle, actualRentalDays, invoice.InitialInsurancePerDay, invoice.InsuranceAdditionOrDiscountPerDay);

            Console.WriteLine($"Total rent: ${string.Format(Formats.PriceFormat, totalRent)}");
            Console.WriteLine($"Total insurance: ${string.Format(Formats.PriceFormat, totalInsurance)}");
            Console.WriteLine($"Total: ${string.Format(Formats.PriceFormat, totalRent + totalInsurance)}");
            Console.WriteLine("XXXXXXXXXX");
            Console.WriteLine();
        }

        //Method to calculate Rental Cost Per Day
        private double CalculateRentalCostPerDay(Vehicle vehicle, DateTime actualReturnDate, DateTime reservationStartDate)
        {
            if ((actualReturnDate - reservationStartDate).Days <= 7)
            {
                switch (vehicle)
                {
                    case Car car:
                        return 20;
                    case Motorcycle motorcycle:
                        return 15;
                    case CargoVan cargoVan:
                        return 50;
                    default:
                        throw new Exception("Invalid Vehicle Type!");
                }
            }
            switch (vehicle)
            {
                case Car car:
                    return 15;
                case Motorcycle motorcycle:
                    return 10;
                case CargoVan cargoVan:
                    return 40;
                default:
                    throw new Exception("Invalid Vehicle Type!");
            }
        }

        //Method to calculate Insurance Cost Per Day
        private double CalculateInsurancePerDay(Vehicle vehicle)
        {
            switch (vehicle)
            {
                case Car car:
                    return car.VehicleValue * 0.0001;
                case Motorcycle motorcycle:
                    return motorcycle.VehicleValue * 0.0002;
                case CargoVan cargoVan:
                    return cargoVan.VehicleValue * 0.0003;
                default:
                    throw new Exception("Invalid Vehicle Type!");
            }
        }

        //Method to check if there is Addition or Discount to the Insurance price per day
        private bool HasInsuranceAdditionOrDiscount(Vehicle rentedVehicle, int ageField)
        {
            switch (rentedVehicle)
            {
                case Car car:
                    if (car.CarSafetyRating > 3)
                    {
                       return true;
                    }
                    return false;
                case Motorcycle motorcycle:
                    if (ageField < 25)
                    {
                        return true;
                    }
                    return false;

                case CargoVan cargoVan:
                    if (ageField > 5)
                    {
                        return true;
                    }
                    return false;
                default:
                    return false;
            }
        }

        //Method to calculate the Insurance Addition or Discount depending on the Vehicle type
        private double CalculateInsuranceAdditionOrDiscountPerDay(Vehicle rentedVehicle, double insurcanePerDay, int ageField)
        {
            switch (rentedVehicle)
            {
                case Car car:
                    if (car.CarSafetyRating > 3)
                    {
                        return insurcanePerDay * 0.1;
                    }
                    return 0;
                case Motorcycle motorcycle:
                    if (ageField < 25)
                    {
                       return insurcanePerDay * 0.2;
                    }
                    return 0;
                case CargoVan cargoVan:
                    if (ageField > 5)
                    {
                       return insurcanePerDay * 0.15;
                    }
                    return 0;
                default:
                    return 0;
            }
        }

        //Method to calculate Total Rent Price using the provided business logic
        //(The client pays Rent at full price for the days of usage and pays half the price for the days left from the reservation)
        private double CalculateTotalRent(int reservedRentalDays, int actualRentalDays, double rentalPerDay)
        {
            double result = actualRentalDays * rentalPerDay;

            if (reservedRentalDays > actualRentalDays)
            {
                int remainingDays = reservedRentalDays - actualRentalDays;
                result += remainingDays * (rentalPerDay / 2);
            }
            return result;
        }

        //Method to calculate what is the Discount on Rent for Early return of the Vehicle
        private double CalculateRentDiscount(int reservedRentalDays, int actualRentalDays, double rentalPerDay)
        {
           return ((reservedRentalDays - actualRentalDays) * rentalPerDay) / 2;
        }

        //Method to calculate Total Insurance Price using the provided business logic
        //(The client only pays Insurance for the days he used the vehicle)
        private double CalculateTotalInsurance(Vehicle rentedVehicle, int actualRentalDays, double insurancePerDay, double insuranceAdditionOrDiscountPerDay)
        {
            if (rentedVehicle is Motorcycle)
            {
                return actualRentalDays * (insurancePerDay + insuranceAdditionOrDiscountPerDay);
            }
            return actualRentalDays * (insurancePerDay - insuranceAdditionOrDiscountPerDay);
        }

        //Method to calculate what is the Discount on Insurance for Early return of the Vehicle
        private double CalculateInsuranceDiscount(int reservedRentalDays, int actualRentalDays, Vehicle rentedVehicle, double insurancePerDay, double insuranceAdditionOrDiscountPerDay)
        {
            if(rentedVehicle is Motorcycle)
            {
                return (reservedRentalDays - actualRentalDays) * (insurancePerDay + insuranceAdditionOrDiscountPerDay);
            }
            return (reservedRentalDays - actualRentalDays) * (insurancePerDay - insuranceAdditionOrDiscountPerDay);
        }
    }
}
