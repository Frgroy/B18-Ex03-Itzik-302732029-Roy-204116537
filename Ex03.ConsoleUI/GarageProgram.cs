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
            GasolineEngine.eFuelType fuelType;
            float fuelAmount;

            licenseNumber = GetLicenseNumberFromUser();
            fuelType = GetFuelTypeFromUser();
            fuelAmount = GetFuelAmountFromUser();

        }

        private static void ChargeVehicleRoutine()
        {
            string licenseNumber;
            float hoursAmount;

            licenseNumber = GetLicenseNumberFromUser();
            hoursAmount = GetHoursAmountFromUser();

        }

        private static void DisplayVehicleInfoRoutine()
        {
            string licenseNumber;

            licenseNumber = GetLicenseNumberFromUser();
            
        }

        private static void ChangeVehicleStatusRoutine()
        {
            Garage.eVehicleStatus newStatus;
            string licenseNumber;

            licenseNumber = GetLicenseNumberFromUser();
            newStatus = GetStatusFromUser();
        }

        private static void DisplayAllLicenseNumberInGarageRoutine()
        {
            Garage.eVehicleStatus filterChoice;
           
            filterChoice = GetFilterFromUser();
        }

        private static void EnterNewVehicleRoutine()
        {
            VehicleEntranceForm vehicleForm = new VehicleEntranceForm();
            bool isFoundInGarage = false;
            
            vehicleForm.LicenseNumber = GetLicenseNumberFromUser();
            isFoundInGarage = Garage.FindLicenseInGarage();
            
            if(isFoundInGarage)
            {
                Console.WriteLine("Vehicle is already in garage");
                Garage.ChangeVehicleStatus();
            }
            else
            {
                vehicleForm.VehicleType = GetVehicleTypeFromUser();
                vehicleForm.VehicleModel = GetVehicleModelFromUser();
                vehicleForm. = GetVehicleEnergyPercentage();
            }
        }

        public static bool IsUserInputLegal(string i_UserInput)
        {
            bool isLegalInput = false;
            int userInputResult;
            if (int.TryParse(i_UserInput, out userInputResult))
            {
                if (Regex.IsMatch(i_UserInput, "[1-8]"))
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
            Console.WriteLine("Enter hours amount to charge");
            string hoursAmountString = Console.ReadLine();

            return float.Parse(hoursAmountString);
        }
        
        public static Garage.eVehicleStatus GetStatusFromUser()
        {
            Console.WriteLine("Enter vehicle's new status");
            string newStatusString = Console.ReadLine();

            return (Garage.eVehicleStatus)int.Parse(newStatusString);
        }

        public static GasolineEngine.eFuelType GetFuelTypeFromUser()
        {
            Console.WriteLine("Enter vehicle's fuel type");
            string fuelTypeString = Console.ReadLine();

            return (GasolineEngine.eFuelType)int.Parse(fuelTypeString);
        }

        public static float GetFuelAmountFromUser()
        {
            Console.WriteLine("Enter gasoline amount to fill");
            string fuelAmountString = Console.ReadLine();

            return float.Parse(fuelAmountString);
        }

        public static string GetVehicleModelFromUser()
        {
            Console.WriteLine("Enter vehicle's model:");

            return Console.ReadLine();
        }

        public static Garage.eVehicleStatus GetFilterFromUser()
        {
            string displayAllNumbersMessege = string.Format(
@"Please choose your display filter:
[1]All vehicles
[2]Vehicles in repair status
[3]Fixed vehicles
[4]Payed service vehicles");
            Console.WriteLine(displayAllNumbersMessege);
            string filterChoiceString = Console.ReadLine();

            return (Garage.eVehicleStatus)int.Parse(filterChoiceString);
        }

        public static VehicleFactory.eVehicleType GetVehicleTypeFromUser()
        {
            string vehicleTypeMassage = string.Format(
@"Enter vehicle type:
[1] Gasoline car
[2] Electric car
[3] Gasoline motorcycle
[4] Electric motorcycle
[5] Truck");
            Console.WriteLine(vehicleTypeMassage);
            string vehicleTypeString = Console.ReadLine();

            return (VehicleFactory.eVehicleType)int.Parse(vehicleTypeString);
        }
    }
}
