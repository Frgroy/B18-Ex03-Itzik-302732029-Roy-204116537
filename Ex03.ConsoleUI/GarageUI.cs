using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
     public class GarageUI
     {
          Garage m_Garage = new Garage();
          public void Run()
          {
               bool isProgramActive = true;
               while (isProgramActive == true)
               {
                    PrintGarageMenu();
                    try
                    {
                         HandleKeyPress(Console.ReadLine(), ref isProgramActive);
                    }
                    catch (FormatException ex)
                    {
                         Console.WriteLine(ex.Message.ToString());
                    }
                    catch (Exception ex)
                    {
                         Console.WriteLine(ex.Message.ToString());
                    }
               }
          }

          private void PrintGarageMenu()
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

          private void HandleKeyPress(string i_UserInput, ref bool i_IsProgramActive)
          {
               int userChoice = int.Parse(i_UserInput);
               if (Enum.IsDefined(typeof(eFunctionOption), userChoice))
               {
                    switch (userChoice)
                    {
                         case (int)eFunctionOption.EnterNewVehicle:
                              EnterNewVehicleRoutine();
                              break;
                         case (int)eFunctionOption.DisplayLicenseNumberInfo:
                              DisplayAllLicenseNumberInGarageRoutine();
                              break;
                         case (int)eFunctionOption.ChangeStatus:
                              ChangeVehicleStatusRoutine();
                              break;
                         case (int)eFunctionOption.Inflate:
                              InflateWheelsToMaxRoutine();
                              break;
                         case (int)eFunctionOption.Fuel:
                              FuelVehicleRoutine();
                              break;
                         case (int)eFunctionOption.Charge:
                              ChargeVehicleRoutine();
                              break;
                         case (int)eFunctionOption.DisplayVehiclesInfo:
                              DisplayVehicleInfoRoutine();
                              break;
                         case (int)eFunctionOption.Exit:
                              i_IsProgramActive = false;
                              break;
                    }
               }
               else
               {
                    throw new ValueOutOfRangeException((int)eFunctionOption.EnterNewVehicle, (int)eFunctionOption.Exit);
               }
          }

          private void PrintErrorMassage()
          {
               Console.WriteLine("Illegal input. Please try again.");
          }

          private void InflateWheelsToMaxRoutine()
          {
               string licenseNumber;

               licenseNumber = GetLicenseNumber();
               while (!m_Garage.IsExistInGarage(licenseNumber))
               {
                    PrintErrorMassage();
                    licenseNumber = GetLicenseNumber();
               }

               m_Garage.InflateWheelsToMax(licenseNumber);
          }

          private void FuelVehicleRoutine()
          {
               string licenseNumber;
               GasolineEngine.eFuelType fuelType;
               float fuelAmount;

               licenseNumber = GetLicenseNumber();
               while (!m_Garage.IsExistInGarage(licenseNumber))
               {
                    PrintErrorMassage();
                    licenseNumber = GetLicenseNumber();
               }

               fuelType = GetFuelType();
               fuelAmount = GetFuelAmount();

               try
               {
                    m_Garage.Fuel(licenseNumber, fuelType, fuelAmount);
               }
               catch (ArgumentException ex)
               {
                    Console.WriteLine(ex.Message);
               }
               catch (ValueOutOfRangeException ex)
               {
                    Console.WriteLine(ex.Message);
               }
          }

          private void ChargeVehicleRoutine()
          {
               string licenseNumber;
               float hoursAmount;

               licenseNumber = GetLicenseNumber();
               while (!m_Garage.IsExistInGarage(licenseNumber))
               {
                    PrintErrorMassage();
                    licenseNumber = GetLicenseNumber();
               }

               hoursAmount = GetHoursAmount();

               try
               {
                    m_Garage.Charge(licenseNumber, hoursAmount);
               }
               catch (ValueOutOfRangeException ex)
               {
                    Console.WriteLine(ex.Message);
               }
          }

          private void DisplayVehicleInfoRoutine()
          {
               string licenseNumber;
               licenseNumber = GetLicenseNumber();
               while (!m_Garage.IsExistInGarage(licenseNumber))
               {
                    PrintErrorMassage();
                    licenseNumber = GetLicenseNumber();
               }

               Console.WriteLine(m_Garage.GetSpecificVehicleInfo(licenseNumber));
          }

          private void ChangeVehicleStatusRoutine()
          {
               Garage.eVehicleStatus newStatus;
               string licenseNumber;

               licenseNumber = GetLicenseNumber();
               while (!m_Garage.IsExistInGarage(licenseNumber))
               {
                    PrintErrorMassage();
                    licenseNumber = GetLicenseNumber();
               }

               newStatus = GetStatus();
               m_Garage.ChangeVehicleStatus(licenseNumber, newStatus);
          }

          private void EnterNewVehicleRoutine()
          {
               VehicleEntranceForm vehicleForm = new VehicleEntranceForm();
               bool isFoundInGarage = false;

               string licenseNumber = GetLicenseNumber();
               isFoundInGarage = m_Garage.FindLicenseInGarage(licenseNumber);

               if (isFoundInGarage)
               {
                    Console.WriteLine("Vehicle is already in garage, changing status to In Repair");
                    m_Garage.ChangeVehicleStatus(vehicleForm.LicenseNumber, Garage.eVehicleStatus.InRepair);
               }
               else
               {
                    VehicleFactory.eVehicleType vehicleType = GetVehicleType();
                    Vehicle newVehicleToInsert = VehicleFactory.CreateNewVehicle(licenseNumber, vehicleType);
                    vehicleForm.VehicleModel = GetVehicleModel();
                    GetSpecificVehicleInfo(vehicleForm);
                    GetEngineInfo(vehicleForm);
                    GetWheelsInfo(vehicleForm);
                    GetOwnerInfo(vehicleForm);
                    newVehicleToInsert.FulfillVehicleDetails(vehicleForm);
                    m_Garage.EnterNewVehicle(newVehicleToInsert, vehicleForm);
               }
          }

          private void GetSpecificVehicleInfo(VehicleEntranceForm i_VehicleEnranceForm)
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

          private void GetEngineInfo(VehicleEntranceForm i_VehicleEnranceForm)
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

          private void GetWheelsInfo(VehicleEntranceForm i_VehicleEnranceForm)
          {
               i_VehicleEnranceForm.WheelManufacturer = GetWheelsManufacturer();
               i_VehicleEnranceForm.WheelCurrentAirPressure = GetWheelsAirPressure();
          }

          private void GetOwnerInfo(VehicleEntranceForm i_VehicleEnranceForm)
          {
               i_VehicleEnranceForm.OwnerName = GetOwnerName();
               i_VehicleEnranceForm.OwnerPhone = GetOwnerPhone();
          }

          private string GetOwnerPhone()
          {
               Console.WriteLine("Enter owner's phone:");
               string ownerPhone = Console.ReadLine();

               return ownerPhone;
          }

          private string GetOwnerName()
          {
               Console.WriteLine("Enter owner's name:");
               string ownerName = Console.ReadLine();

               return ownerName;
          }

          private string GetLicenseNumber()
          {
               Console.WriteLine("Enter vehicle's license number");
               string licenseNumber = Console.ReadLine();

               return licenseNumber;
          }

          private float GetHoursAmount()
          {
               Console.WriteLine("Enter hours amount to charge");
               string hoursAmountString = Console.ReadLine();
               float hoursAmount;
               while (!float.TryParse(hoursAmountString, out hoursAmount))
               {
                    PrintErrorMassage();
                    hoursAmountString = Console.ReadLine();
               }

               return hoursAmount;
          }

          private Garage.eVehicleStatus GetStatus()
          {
               Console.WriteLine("Enter vehicle's new status:");
               PrintEnumOptions<Garage.eVehicleStatus>();

               return (Garage.eVehicleStatus)GetEnumInput<Garage.eVehicleStatus>();
          }

          private void PrintEnumOptions<T>()
          {
               foreach (var value in Enum.GetValues(typeof(T)))
               {
                    Console.WriteLine("[{0}] {1}", (int)value, (T)value);
               }
          }

          private int GetEnumInput<T>()
          {
               string userInput = Console.ReadLine();
               bool isLegalInput = false;

               while (!isLegalInput)
               {
                    if (!Enum.IsDefined(typeof(T), int.Parse(userInput)))
                    {
                         PrintErrorMassage();
                         userInput = Console.ReadLine();
                    }
                    else
                    {
                         isLegalInput = true;
                    }
               }

               return int.Parse(userInput);
          }

          private GasolineEngine.eFuelType GetFuelType()
          {
               Console.WriteLine("Enter vehicle's fuel type");
               PrintEnumOptions<GasolineEngine.eFuelType>();

               return (GasolineEngine.eFuelType)GetEnumInput<GasolineEngine.eFuelType>();
          }

          private float GetFuelAmount()
          {
               Console.WriteLine("Enter gasoline amount to fill");
               string fuelAmountString = Console.ReadLine();
               float fuelAmount;

               while (!float.TryParse(fuelAmountString, out fuelAmount))
               {
                    PrintErrorMassage();
                    fuelAmountString = Console.ReadLine();
               }

               return fuelAmount;
          }

          private string GetVehicleModel()
          {
               Console.WriteLine("Enter vehicle's model:");

               return Console.ReadLine();
          }

          private Garage.eFilter GetFilter()
          {
               Console.WriteLine("Enter requested filter");
               PrintEnumOptions<Garage.eFilter>();

               return (Garage.eFilter)GetEnumInput<Garage.eFilter>();
          }

          private void DisplayAllLicenseNumberInGarageRoutine()
          {
               Garage.eFilter filterChoice;
               string listToPrint;
               filterChoice = GetFilter();

               if (filterChoice == Garage.eFilter.All)
               {
                    listToPrint = m_Garage.DisplayAllLicenseNumberOfVehicles();
               }
               else
               {
                    listToPrint = m_Garage.DisplayLicenseNumberOfVehiclesByStatus((Garage.eVehicleStatus)filterChoice);
               }

               Console.WriteLine(listToPrint);
          }

          private VehicleFactory.eVehicleType GetVehicleType()
          {
               Console.WriteLine("Enter your vehicle type:");
               PrintEnumOptions<VehicleFactory.eVehicleType>();

               return (VehicleFactory.eVehicleType)GetEnumInput<VehicleFactory.eVehicleType>();
          }

          private Car.eCarColor GetCarColor()
          {
               Console.WriteLine("Choose your car color:");
               PrintEnumOptions<Car.eCarColor>();

               return (Car.eCarColor)GetEnumInput<Car.eCarColor>();
          }

          private int GetCarDoorsNumber()
          {
               Console.WriteLine("Choose your car numbers of doors: ");
               PrintEnumOptions<Car.eCarDoors>();

               return GetEnumInput<Car.eCarDoors>();
          }

          private int GetMotorcycleEngineCapacity()
          {
               Console.WriteLine("Enter engine capacity: ");
               string engineCapacityString = Console.ReadLine();
               int engineCapacity;

               while (!int.TryParse(engineCapacityString, out engineCapacity))
               {
                    PrintErrorMassage();
                    engineCapacityString = Console.ReadLine();
               }

               return engineCapacity;
          }

          private Motorcycle.eLicenseType GetMotorcycleLicenseType()
          {
               Console.WriteLine("Choose your license type:");
               PrintEnumOptions<Motorcycle.eLicenseType>();

               return (Motorcycle.eLicenseType)GetEnumInput<Motorcycle.eLicenseType>();
          }

          private float GetRemainingBatteryHours()
          {
               Console.WriteLine("Enter remaining battery hours: ");
               string remainingBatteryHoursString = Console.ReadLine();
               float remainingBatteryHours;

               while (!float.TryParse(remainingBatteryHoursString, out remainingBatteryHours))
               {
                    PrintErrorMassage();
                    remainingBatteryHoursString = Console.ReadLine();
               }

               return remainingBatteryHours;
          }

          private float GetCurrentFuelAmount()
          {
               Console.WriteLine("Enter current fuel amount: ");
               string currentFuelString = Console.ReadLine();
               float currentFuelAmount;

               while (!float.TryParse(currentFuelString, out currentFuelAmount))
               {
                    PrintErrorMassage();
                    currentFuelString = Console.ReadLine();
               }

               return currentFuelAmount;
          }

          private string GetWheelsManufacturer()
          {
               Console.WriteLine("Enter wheels manufacturer's name: ");
               string wheelsManufacturer = Console.ReadLine();

               return wheelsManufacturer;
          }

          private float GetWheelsAirPressure()
          {
               Console.WriteLine("Enter wheels air pressure: ");
               string wheelsAirPressureString = Console.ReadLine();
               float wheelsAirPressure;

               while (!float.TryParse(wheelsAirPressureString, out wheelsAirPressure))
               {
                    PrintErrorMassage();
                    wheelsAirPressureString = Console.ReadLine();
               }

               return wheelsAirPressure;
          }

          private int GetTruckTrunkCapacity()
          {
               Console.WriteLine("Enter trunk's truck capacity: ");
               string trunkCapacityString = Console.ReadLine();
               int trunkCapacity;

               while (!int.TryParse(trunkCapacityString, out trunkCapacity))
               {
                    PrintErrorMassage();
                    trunkCapacityString = Console.ReadLine();
               }

               return trunkCapacity;
          }

          private bool GetCoolTruckTrunkSatus()
          {
               bool isTruckTrunkCool = false;
               string TruckTrunkCoolMessege = string.Format(
@"Is your turck's trunk cool?
[1]Yes
[2]No");
               Console.WriteLine(TruckTrunkCoolMessege);
               string TruckTrunkCapacityString = Console.ReadLine();
               if (int.Parse(TruckTrunkCapacityString) == 1)
               {
                    isTruckTrunkCool = true;
               }

               return isTruckTrunkCool;
          }

          private enum eFunctionOption
          {
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
