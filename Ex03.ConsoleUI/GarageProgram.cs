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
            Garage garage = new Garage();
            while (isProgramActive == true)
            {
                PrintGarageMenu();
                HandleKeyPress(Console.ReadLine(), garage, isProgramActive);
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

        public static void HandleKeyPress(string i_UserInput, Garage i_Garage, bool i_IsProgramActive)
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

            licenseNumber = GetLicenseNumber();
        }

        private static void FuelVehicleRoutine()
        {
            string licenseNumber;
            GasolineEngine.eFuelType fuelType;
            float fuelAmount;

            licenseNumber = GetLicenseNumber();
            fuelType = GetFuelType();
            fuelAmount = GetFuelAmount();
        }

        private static void ChargeVehicleRoutine()
        {
            string licenseNumber;
            float hoursAmount;

            licenseNumber = GetLicenseNumber();
            hoursAmount = GetHoursAmount();
        }

        private static void DisplayVehicleInfoRoutine()
        {
            string licenseNumber;

            licenseNumber = GetLicenseNumber();

        }

        private static void ChangeVehicleStatusRoutine()
        {
            Garage.eVehicleStatus newStatus;
            string licenseNumber;

            licenseNumber = GetLicenseNumber();
            newStatus = GetStatus();
        }

        private static void DisplayAllLicenseNumberInGarageRoutine()
        {
            Garage.eVehicleStatus filterChoice;

            filterChoice = GetFilter();
        }

        private static void EnterNewVehicleRoutine()
        {
            VehicleEntranceForm vehicleForm = new VehicleEntranceForm();
            bool isFoundInGarage = false;

            vehicleForm.LicenseNumber = GetLicenseNumber();
            isFoundInGarage = Garage.FindLicenseInGarage();

            if (isFoundInGarage)
            {
                Console.WriteLine("Vehicle is already in garage");
                Garage.ChangeVehicleStatus();
            }
            else
            {
                vehicleForm.VehicleType = GetVehicleType();
                vehicleForm.VehicleModel = GetVehicleModel();
                GetSpecificVehicleInfo(vehicleForm);
                GetEngineInfo(vehicleForm);
                GetWheelsInfo(vehicleForm);
            }
        }

        public static void GetSpecificVehicleInfo(VehicleEntranceForm i_VehicleEnranceForm)
        {
            
            if (i_VehicleEnranceForm.VehicleType == VehicleFactory.eVehicleType.ElectricCar
                      || i_VehicleEnranceForm.VehicleType == VehicleFactory.eVehicleType.GasolineCar)
            {
                i_VehicleEnranceForm.CarColor = GetCarColor();
                i_VehicleEnranceForm.CarDoorsNumber = GetCarDoorsNumber();
            }

            else if (i_VehicleEnranceForm.VehicleType == VehicleFactory.eVehicleType.ElectricMotorcycle
                 || i_VehicleEnranceForm.VehicleType == VehicleFactory.eVehicleType.GasolineMotorcycle)
            {
                i_VehicleEnranceForm.MotorcycleEngineCapacity = GetMotorcycleEngineCapacity();
                i_VehicleEnranceForm.MotorcycleLicenseType = GetMotorcycleLicenseType();
            }

            else
            {
                i_VehicleEnranceForm.TruckTrunkCapacity = GetTruckTrunkCapacity();
                i_VehicleEnranceForm.IsTruckTrunkCool = GetCoolTruckTrunkSatus();
            }
        }

        public static void GetEngineInfo(VehicleEntranceForm i_VehicleEnranceForm)
        {
            if (i_VehicleEnranceForm.VehicleType == VehicleFactory.eVehicleType.ElectricCar
                      || i_VehicleEnranceForm.VehicleType == VehicleFactory.eVehicleType.ElectricMotorcycle)
            {
                i_VehicleEnranceForm.RemainingBatteryHours = GetRemainingBatteryHours();
            }

            else
            {
                i_VehicleEnranceForm.CurrentFuelAmount = GetCurrentFuelAmount();
                i_VehicleEnranceForm.FuelType = GetFuelType();
            }
        }

        public static void GetWheelsInfo(VehicleEntranceForm i_VehicleEnranceForm)
        {
            i_VehicleEnranceForm.WheelManufacturer = GetWheelsManufacturer();
            i_VehicleEnranceForm.WheelCurrentAirPressure = GetWheelsAirPressure();
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

        public static string GetLicenseNumber()
        {
            Console.WriteLine("Enter vehicle's license number");

            return Console.ReadLine();
        }

        public static float GetHoursAmount()
        {
            Console.WriteLine("Enter hours amount to charge");
            string hoursAmountString = Console.ReadLine();

            return float.Parse(hoursAmountString);
        }

        public static Garage.eVehicleStatus GetStatus()
        {
            Console.WriteLine("Enter vehicle's new status");
            string newStatusString = Console.ReadLine();

            return (Garage.eVehicleStatus)int.Parse(newStatusString);
        }

        public static GasolineEngine.eFuelType GetFuelType()
        {
            Console.WriteLine("Enter vehicle's fuel type");
            string fuelTypeString = Console.ReadLine();

            return (GasolineEngine.eFuelType)int.Parse(fuelTypeString);
        }

        public static float GetFuelAmount()
        {
            Console.WriteLine("Enter gasoline amount to fill");
            string fuelAmountString = Console.ReadLine();

            return float.Parse(fuelAmountString);
        }

        public static string GetVehicleModel()
        {
            Console.WriteLine("Enter vehicle's model:");

            return Console.ReadLine();
        }

        public static Garage.eVehicleStatus GetFilter()
        {
            string displayAllNumbersMessege = string.Format( //move msg to logic
@"Please choose your display filter:
[1]All vehicles
[2]Vehicles in repair status
[3]Fixed vehicles
[4]Payed service vehicles");
            Console.WriteLine(displayAllNumbersMessege);
            string filterChoiceString = Console.ReadLine();

            return (Garage.eVehicleStatus)int.Parse(filterChoiceString);
        }

        public static VehicleFactory.eVehicleType GetVehicleType()
        {
            foreach (var name in Enum.GetNames(typeof(VehicleFactory.eVehicleType)))
            {
                Console.WriteLine("{0,3:D}     0x{0:X}     {1}",
                                  Enum.Parse(typeof(SignMagnitude), name),
                                  name);
                string vehicleTypeMassage = string.Format( //move msg to logic
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

        public static Car.eCarColor GetCarColor()
        {
            string carColorMessege = string.Format(
 @"Choose your car's color:
[1]Grey
[2]Blue
[3]White
[4]Black");
            Console.WriteLine(carColorMessege);
            string colorString = Console.ReadLine();

            return (Car.eCarColor)int.Parse(colorString);
    }

        public static int GetCarDoorsNumber()
        {
            Console.WriteLine("Enter number of doors: ");
            string doorNumberString = Console.ReadLine();

            return int.Parse(doorNumberString);
        }

        public static int GetMotorcycleEngineCapacity()
        {
            Console.WriteLine("Enter engine capacity: ");
            string engineCapacityString = Console.ReadLine();

            return int.Parse(engineCapacityString);
        }

        public static Motorcycle.eLicenseType GetMotorcycleLicenseType()
        {
            string motorcycleLicenseTypeMessege = string.Format(
 @"Choose your license type:
[1]A
[2]A1
[3]B1
[4]B2");
            Console.WriteLine(motorcycleLicenseTypeMessege);
            string motorcycleLicenseTypeString = Console.ReadLine();

            return (Motorcycle.eLicenseType)int.Parse(motorcycleLicenseTypeString);
        }

        public static float GetRemainingBatteryHours()
        {
            Console.WriteLine("Enter remaining battery hours: ");
            string remainingBatteryHoursString = Console.ReadLine();

            return float.Parse(remainingBatteryHoursString);
        }

        public static float GetCurrentFuelAmount()
        {
            Console.WriteLine("Enter current fuel amount: ");
            string currentFuelAmountString = Console.ReadLine();

            return float.Parse(currentFuelAmountString);
        }

        public static string GetWheelsManufacturer()
        {
            Console.WriteLine("Enter wheels manufacturer's name: ");

            return Console.ReadLine();
        }

        public static float GetWheelsAirPressure()
        {
            Console.WriteLine("Enter wheels air pressure: ");
            string wheelsAirPressureString = Console.ReadLine();

            return float.Parse(wheelsAirPressureString);
        }

        public static int GetTruckTrunkCapacity()
        {
            Console.WriteLine("Enter trunk's truck capacity: ");
            string TruckTrunkCapacityString = Console.ReadLine();

            return int.Parse(TruckTrunkCapacityString);
        }

        public static bool GetCoolTruckTrunkSatus()
        {
            bool isCool = false;
            string TruckTrunkCoolMessege = string.Format(
 @"Is your turck's trunk cool?
[1]Yes
[2]No");
            Console.WriteLine(TruckTrunkCoolMessege);
            string TruckTrunkCapacityString = Console.ReadLine();
            if (int.Parse(TruckTrunkCapacityString) == 1)
                isCool = true;

            return isCool;
        }




    }
}
