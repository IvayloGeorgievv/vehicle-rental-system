using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle_Rental_System.Constants
{
    //This class contains set of constant error messages. They are used troughout the project to provide consistent error feedback
    public static class ErrorMessages
    {
        public const string DateTimeError = "There was an error trying to create the Dates";
        public const string CreateInvoiceError = "There was an error trying to create one of the Invoices";
        public const string PrintInvoiceError = "There was an error trying to print one of the Invoices";
    }
}
