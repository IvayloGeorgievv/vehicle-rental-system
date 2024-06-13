using System;
using Vehicle_Rental_System.Constants;
using Vehicle_Rental_System.Entity;
using Vehicle_Rental_System.Util;

namespace Vehicle_Rental_System
{
    public class Program
    {
        static void Main(string[] args)
        {
            DateTime rentalStart;
            DateTime rentalEnd;
            DateTime actualRentalEnd;

            //Initialize Rental Dates and handle any Exceptions
            try
            {
                rentalStart = new DateTime(2024, 6, 3);
                rentalEnd = new DateTime(2024, 6, 13);
                actualRentalEnd = new DateTime(2024, 6, 13);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ErrorMessages.DateTimeError);
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                return;
            }

            RentalInvoice invoice1;
            RentalInvoice invoice2;
            RentalInvoice invoice3;

            //Create Rental Invoices and handle any Exceptions
            try
            {
                invoice1 = new RentalInvoice("Stoqn Kolev", new Car("Subaru", "Impreza", 15000, 3), rentalStart, rentalEnd, actualRentalEnd);
                invoice2 = new RentalInvoice("Ivan Kolev", 20, new Motorcycle("Kawasaki", "Ninja 300", 10000), rentalStart, rentalEnd, actualRentalEnd, Enum.VehicleTypeEnum.Motorcycle);
                invoice3 = new RentalInvoice("Petur Kolev", 8, new CargoVan("Renault", "Traffic", 20000),  rentalStart, new DateTime(2024, 6, 18), actualRentalEnd, Enum.VehicleTypeEnum.CargoVan);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ErrorMessages.CreateInvoiceError);
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                return;
            }

            //Generate Rental Invoices and handle any Exceptions
            try
            {
                InvoiceUtils invoiceUtils = new InvoiceUtils();
                invoiceUtils.GenerateRentalInvoice(invoice1);
                invoiceUtils.GenerateRentalInvoice(invoice2);
                invoiceUtils.GenerateRentalInvoice(invoice3);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ErrorMessages.PrintInvoiceError);
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                return;
            }
        }
    }
}
