# Vehicle Rental System
## Overview
This application generates rental invoices for different types of vehicles based on specified rental periods and vehicle details. It calculates rental costs, insurance costs and generates formatted invoices for display.
## Approach
The solution employs an Object-Oriented approach. In my solution I have used inheritance, abstraction and encapsulation. I chose to divide the logic into a few folders for better readability and managment. Down below I will explain each of the folders aims.
### 1.Entities
Here In seperate files I keep all of the entities needed to complete the task.
#### 1.1. Vehicle Hierarchy:
The hierarchy utilizes inheritance to represent different vehicle types with shared and specific properties. The parent class Vehicle is abstract complying with the task's condition. Each vehicle has the same properties so that way the hierarchy facilitates code reusability.
#### 1.2. RentalInvoice class:
This class represents the invoice. It keeps all the needed data for a single invoice. 
### 2. Utils
Having in mind the big volume of the task I tought it is better to separate the methods needed for calculation of costs and invoice printing in a separate file. That way the code is easier to read and mentain. This folder contains only one file in which are stored all the methods needed to print out and calculate all cost for an invoice.
### 3. Constants
#### 3.1. ErrorMessages:
Here I keep as constants all the error messages an user can encounter.
#### 3.2. Formats:
During the creation of this solution I have encountered two formats that are widely used in the code. One for the costs and one for the dates. In this file I keep them as constants. That way if a change of format is needed it would be easier and faster to do.
### 4. Enumerators
During the creation of the solution I encountered an interesting problem. For creation of an invoice for Motorcycle and CargoVan you need to get different properties value but in the same type(integer - for 'ClientAge' and 'ClientDrivingExperience') I used Enumerator to handle that problem. Using the enumerator I can use one constructor to get the needed integer value and populate the correct property depending on the Vehicle type.
## Error Handling:
I have implemented try-catch block to manage potential errors during date handling, invoice creation and invoice printing. This way I ensured robustness in handling of unexpected scenarios such as invalid date formats or calculation errors. 

## Main application: 
The Main method plays the role of an entry point where the user initializes the rental dates('rentalStart''rentalEnd' and 'actualRentalEnd'), create instances of 'RentalInvoice' with specific customer details and rental parameters and utilize the 'InvoiceUtils' class to calculate all costs and print out the invoice in the task given format.
