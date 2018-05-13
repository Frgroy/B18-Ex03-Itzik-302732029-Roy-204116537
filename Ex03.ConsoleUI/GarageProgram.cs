using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Ex03.ConsoleUI
{
    public static class GarageProgram
    {
        public static void Run()
        {
            bool isProgramActive = true;
            while (isProgramActive == true)
            {
                PrintGarageMenu();
                HandleKeyPress(Console.ReadLine(), isProgramActive);
            }
        }

        public static void PrintGarageMenu()
        {
            string garageMenu = string.Format(
@"Please choose one of the option below
[1] Enter new vehicle to the garage
[2] Display all license number of vehicles in the garage
[3] Change vehicle status
[4] Inflate wheels to maximum
[5] Fuel vehicle
[6] Charge vehicle
[7] Display vehicle info
[8] Exit");
            Console.WriteLine(garageMenu);
        }

        public static void HandleKeyPress(string i_UserInput, bool i_IsProgramActive)
        {
            if (IsUserInputLegal(i_UserInput) == true)
            {
                int userInput = int.Parse(i_UserInput);
                switch (userInput)
                {
                    case 1:
                        EnterNewVehicleRoutine();
                        break;
                    case 2:
                        DisplayAllLicenseNumberInGarageRoutine();
                        break;
                    case 3:
                        ChangeVehicleStatusRoutine();
                        break;
                    case 4:
                        InflateWheelsToMaxRoutine();
                        break;
                    case 5:
                        FuelVehicleRoutine();
                        break;
                    case 6:
                        ChargeVehicleRoutine();
                        break;
                    case 7:
                        DisplayVehicleInfoRoutine();
                        break;
                    case 8:
                        i_IsProgramActive = false;
                        break;

                }
            }
        }

        private static void InflateWheelsToMaxRoutine()
        {
            string licenseNumber;

            licenseNumber = GetLicenseNumberFromUser();
        }

        private static void FuelVehicleRoutine()
        {
            string licenseNumber;
            string fuelTypeString;
            GasolineEngine.eFuelType fuelType;
            string fuelAmountString;
            float fuelAmount;

            Console.WriteLine("Enter vehicle's license number");
            licenseNumber = Console.ReadLine();
            Console.WriteLine("Enter vehicle's fuel type");
            fuelTypeString = Console.ReadLine();
            fuelType = (GasolineEngine.eFuelType)int.Parse(fuelTypeString);
            Console.WriteLine("Enter gasoline amount to fill");
            fuelAmountString = Console.ReadLine();
            fuelAmount = float.Parse(fuelAmountString);

        }

        private static void ChargeVehicleRoutine()
        {
            string licenseNumber;
            string hoursAmountString;
            float hoursAmount;

            licenseNumber = GetLicenseNumberFromUser();
            Console.WriteLine("Enter hours amount to charge");
            hoursAmountString = Console.ReadLine();
            hoursAmount = float.Parse(hoursAmountString);

        }

        private static void DisplayVehicleInfoRoutine()
        {
            string licenseNumber;

            licenseNumber = GetLicenseNumberFromUser();
            
        }

        private static void ChangeVehicleStatusRoutine()
        {
            Garage.eVehicleStatus newStatus;
            string newStatusString;
            string licenseNumber;

            licenseNumber = GetLicenseNumberFromUser();
            Console.WriteLine("Enter vehicle's new status");
            newStatusString = Console.ReadLine();
            newStatus = (Garage.eVehicleStatus)int.Parse(newStatusString);
        }

        private static void DisplayAllLicenseNumberInGarageRoutine()
        {
            Garage.eVehicleStatus filterChoice;
            string filterChoiceString;
            string displayAllNumbersMessege = string.Format(
@"Please choose your display filter:
[1]All vehicles
[2]Vehicles in repair status
[3]Fixed vehicles
[4]Payed service vehicles");
            Console.WriteLine(displayAllNumbersMessege);
            filterChoiceString = Console.ReadLine();
            filterChoice = (Garage.eVehicleStatus)int.Parse(filterChoiceString);
        }

        private static void EnterNewVehicleRoutine()
        {
            VehicleFactory.eVehicleType vehicleType;
            string vehicleTypeString;
            string licenseNumber;
            string vehicleModel;
            float energyPercentage;
            string energyPercentageString;
            string vehicleTypeMassage = string.Format(
@"Enter vehicle type:
[1] Gasoline car
[2] Electric car
[3] Gasoline motorcycle
[4] Electric motorcycle
[5] Truck");
            Console.WriteLine(vehicleTypeMassage);
            vehicleTypeString = Console.ReadLine();
            vehicleType = (VehicleFactory.eVehicleType)int.Parse(vehicleTypeString);
            Console.WriteLine("Enter vehicle's number license:");
            licenseNumber = Console.ReadLine();
            Console.WriteLine("Enter vehicle's model:");
            vehicleModel = Console.ReadLine();
            Console.WriteLine("Enter vehicle's energy percentage;:");
            energyPercentageString = Console.ReadLine();
            energyPercentage = float.Parse(energyPercentageString);
        }


        public static bool IsUserInputLegal(string i_UserInput)
        {
            bool isLegalInput = false;
            int userInputResult;
            if (int.TryParse(i_UserInput, out userInputResult))
            {
                if (Regex.IsMatch(i_UserInput, "[1-8]")) ;
                {
                    isLegalInput = true;
                }
            }

            return isLegalInput;
        }

        public static string GetLicenseNumberFromUser()
        {
            Console.WriteLine("Enter vehicle's license number");
            return Console.ReadLine();
        }

        public static float GetHoursAmountFromUser()
        {
            string hoursAmountString;

            Console.WriteLine("Enter hours amount to charge");
            hoursAmountString = Console.ReadLine();
            return float.Parse(hoursAmountString);
        }
        
    }
}
