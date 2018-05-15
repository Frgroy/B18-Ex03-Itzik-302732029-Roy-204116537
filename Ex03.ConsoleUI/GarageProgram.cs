using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
                    HandleKeyPress(Console.ReadLine(), garage, ref isProgramActive);
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

          public static void HandleKeyPress(string i_UserInput, Garage i_Garage, ref bool i_IsProgramActive)
          {
               int userChoice = int.Parse(i_UserInput); // maybe try-catch
               if (Enum.IsDefined(typeof(eFunctionOption), userChoice))
               {
                    switch (userChoice)
                    {
                         case (int)eFunctionOption.EnterNewVehicle:
                              EnterNewVehicleRoutine(i_Garage);
                              break;
                         case (int)eFunctionOption.DisplayLicenseNumberInfo:
                              DisplayAllLicenseNumberInGarageRoutine(i_Garage);
                              break;
                         case (int)eFunctionOption.ChangeStatus:
                              ChangeVehicleStatusRoutine(i_Garage);
                              break;
                         case (int)eFunctionOption.Inflate:
                              InflateWheelsToMaxRoutine(i_Garage);
                              break;
                         case (int)eFunctionOption.Fuel:
                              FuelVehicleRoutine(i_Garage);
                              break;
                         case (int)eFunctionOption.Charge:
                              ChargeVehicleRoutine(i_Garage);
                              break;
                         case (int)eFunctionOption.DisplayVehiclesInfo:
                              DisplayVehicleInfoRoutine(i_Garage);
                              break;
                         case (int)eFunctionOption.Exit:
                              i_IsProgramActive = false;
                              break;
                    }
               }
               else
               {
                    PrintErrorMassage();
               }
          }

          public static void PrintErrorMassage()
          {
               Console.WriteLine("Illegal input. Please try again.");
          }

          public static void InflateWheelsToMaxRoutine(Garage i_Garage)
          {
               string licenseNumber;

               licenseNumber = GetLicenseNumber();
               while (!i_Garage.IsExistInGarage(licenseNumber))
               {
                    PrintErrorMassage();
                    licenseNumber = GetLicenseNumber();
               }
               i_Garage.InflateWheelsToMax(licenseNumber);
               
          }

          public static void FuelVehicleRoutine(Garage i_Garage)
          {
               string licenseNumber;
               GasolineEngine.eFuelType fuelType;
               float fuelAmount;

               licenseNumber = GetLicenseNumber();
               while (!i_Garage.IsExistInGarage(licenseNumber))
               {
                    PrintErrorMassage();
                    licenseNumber = GetLicenseNumber();
               }

               fuelType = GetFuelType();
               fuelAmount = GetFuelAmount();

               try
               {
                    i_Garage.Fuel(licenseNumber, fuelType, fuelAmount);//exepction

               }
               catch (Exception ex)
               {

               }
               
          }

          public static void ChargeVehicleRoutine(Garage i_Garage)
          {
               string licenseNumber;
               float hoursAmount;

               licenseNumber = GetLicenseNumber();
               hoursAmount = GetHoursAmount();
               i_Garage.Charge(licenseNumber, hoursAmount);
          }

          public static void DisplayVehicleInfoRoutine(Garage i_Garage)
          {
               string licenseNumber;

               licenseNumber = GetLicenseNumber();
               i_Garage.GetSpecificVehicleInfo(licenseNumber);
          }

          public static void ChangeVehicleStatusRoutine(Garage i_Garage)
          {
               Garage.eVehicleStatus newStatus;
               string licenseNumber;

               licenseNumber = GetLicenseNumber();
               newStatus = GetStatus();
               i_Garage.ChangeVehicleStatus(licenseNumber, newStatus);
          }

          public static void EnterNewVehicleRoutine(Garage i_Garage)
          {
               VehicleEntranceForm vehicleForm = new VehicleEntranceForm();
               bool isFoundInGarage = false;

               vehicleForm.LicenseNumber = GetLicenseNumber();
               isFoundInGarage = i_Garage.FindLicenseInGarage(vehicleForm.LicenseNumber);

               if (isFoundInGarage)
               {
                    Console.WriteLine("Vehicle is already in garage");
                    i_Garage.ChangeVehicleStatus(vehicleForm.LicenseNumber, Garage.eVehicleStatus.InRepair);
               }
               else
               {
                    vehicleForm.VehicleType = GetVehicleType();
                    vehicleForm.VehicleModel = GetVehicleModel();
                    GetSpecificVehicleInfo(vehicleForm);
                    GetEngineInfo(vehicleForm);
                    GetWheelsInfo(vehicleForm);
                    GetOwnerInfo(vehicleForm);
                    Vehicle newVehicleToInsert = VehicleFactory.CreateNewVehicle(vehicleForm);
                    i_Garage.EnterNewVehicle(newVehicleToInsert, vehicleForm);
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

               else if (i_VehicleEnranceForm.VehicleType == VehicleFactory.eVehicleType.Truck)
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
               }
          }

          public static void GetWheelsInfo(VehicleEntranceForm i_VehicleEnranceForm)
          {
               i_VehicleEnranceForm.WheelManufacturer = GetWheelsManufacturer();
               i_VehicleEnranceForm.WheelCurrentAirPressure = GetWheelsAirPressure();
          }

          public static void GetOwnerInfo(VehicleEntranceForm i_VehicleEnranceForm)
          {
               i_VehicleEnranceForm.OwnerName = GetOwnerName();
               i_VehicleEnranceForm.OwnerPhone = GetOwnerPhone();
          }

          public static string GetOwnerPhone()
          {
               Console.WriteLine("Enter owner's phone:");
               string ownerPhone = Console.ReadLine();
               while (!Regex.IsMatch(ownerPhone, @"/^[0-9]{0,10}$/"))
               {
                    PrintErrorMassage();
                    ownerPhone = Console.ReadLine();
               }

               return ownerPhone;
          }

          public static string GetOwnerName()
          {
               Console.WriteLine("Enter owner's name:");
               string ownerName = Console.ReadLine();
               while (!Regex.IsMatch(ownerName, @"/^[A-Z,a-z,' ']{0,20}$/"))
               {
                    PrintErrorMassage();
                    ownerName = Console.ReadLine();
               }

               return ownerName;
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
               string licenseNumber = Console.ReadLine();
               while (!Regex.IsMatch(licenseNumber, @"/^[A-Z,a-z,0-9]{0,20}$/"))
               {
                    PrintErrorMassage();
                    licenseNumber = Console.ReadLine();
               }

               return licenseNumber;
          }

          public static float GetHoursAmount()
          {
               Console.WriteLine("Enter vehicle's license number");
               string hoursAmountString = Console.ReadLine();
               while (!Regex.IsMatch(hoursAmountString, @"/^[0-9]$/") || IsValueInRange(float.Parse(hoursAmountString, )
                         {
                    PrintErrorMassage();
                    licenseNumber = Console.ReadLine();
               }

               return licenseNumber;

               Console.WriteLine("Enter hours amount to charge");

               return float.Parse(hoursAmountString);
          }

          public static Garage.eVehicleStatus GetStatus()
          {
               Console.WriteLine("Enter vehicle's new status");
               foreach (var value in Enum.GetValues(typeof(Garage.eVehicleStatus)))
               {
                    Console.WriteLine("[{0}] {1}",
                                      (int)value,
                                      (Garage.eVehicleStatus)value);
               }
               string filterChoiceString = Console.ReadLine();

               return (Garage.eVehicleStatus)int.Parse(filterChoiceString);
          }

          public static GasolineEngine.eFuelType GetFuelType()
          {
               bool isLegalFuelType = false;
               Console.WriteLine("Enter vehicle's fuel type");
               string fuelTypeString = Console.ReadLine();

               while (!isLegalFuelType)
               {
                    if (!Enum.IsDefined(typeof(GasolineEngine.eFuelType), fuelTypeString))
                    {
                         PrintErrorMassage();
                    }
                    else
                    {
                         isLegalFuelType = true;
                    }
               }

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

          public static Garage.eFilter GetFilter()
          {
               foreach (var value in Enum.GetValues(typeof(Garage.eFilter)))
               {
                    Console.WriteLine("[{0}] {1}",
                                      (int)value,
                                      (Garage.eFilter)value);
               }
               string filterChoiceString = Console.ReadLine();

               return (Garage.eFilter)int.Parse(filterChoiceString);
          }

          public static void DisplayAllLicenseNumberInGarageRoutine(Garage i_Garage)
          {
               Garage.eFilter filterChoice;
               List<string> listToPrint = new List<string>();
               filterChoice = GetFilter();

               if (filterChoice == Garage.eFilter.All)
               {
                    listToPrint = i_Garage.DisplayAllLicenseNumberOfVehicles();
               }
               else
               {
                    listToPrint = i_Garage.DisplayLicenseNumberOfVehiclesByStatus((Garage.eVehicleStatus)filterChoice);
               }

               Console.WriteLine(listToPrint);
          }

          public static VehicleFactory.eVehicleType GetVehicleType()
          {
               Console.WriteLine("Enter your vehicle type:");
               foreach (var value in Enum.GetValues(typeof(VehicleFactory.eVehicleType)))
               {
                    Console.WriteLine("[{0}] {1}",
                                      (int)value,
                                      (VehicleFactory.eVehicleType)value);
               }
               string vehicleTypeString = Console.ReadLine();

               return (VehicleFactory.eVehicleType)int.Parse(vehicleTypeString);
          }

          public static Car.eCarColor GetCarColor()
          {
               Console.WriteLine("Choose your car color:");
               foreach (var value in Enum.GetValues(typeof(Car.eCarColor)))
               {
                    Console.WriteLine("[{0}] {1}",
                                      (int)value,
                                      (Car.eCarColor)value);
               }
               string colorString = Console.ReadLine();

               return (Car.eCarColor)int.Parse(colorString);
          }

          public static int GetCarDoorsNumber()
          {
               Console.WriteLine("Choose your car numbers of doors: ");
               foreach (var value in Enum.GetValues(typeof(Car.eCarDoors)))
               {
                    Console.WriteLine("[{0}] {1}",
                                      (int)value,
                                      (Car.eCarDoors)value);
               }
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
               Console.WriteLine("Choose your license type:");
               foreach (var value in Enum.GetValues(typeof(Motorcycle.eLicenseType)))
               {
                    Console.WriteLine("[{0}] {1}",
                                      (int)value,
                                      (Motorcycle.eLicenseType)value);
               }
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

          public enum eFunctionOption
          {
               [Description("Efdjsakfsdj;asdjf;lskd")]
               EnterNewVehicle = 1,
               DisplayLicenseNumberInfo,
               ChangeStatus,
               Inflate,
               Fuel,
               Charge,
               DisplayVehiclesInfo,
               Exit
          }
     }
}
