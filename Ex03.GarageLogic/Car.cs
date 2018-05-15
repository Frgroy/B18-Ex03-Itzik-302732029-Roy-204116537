using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
     public class Car : Vehicle
     {
          private const int k_NumberOfWheelsInCar = 4;
          private const int k_MaximumAirPressure = 32;
          private const GasolineEngine.eFuelType k_CarFuelType = GasolineEngine.eFuelType.Octan98;
          private const float k_CarVolumeOfFuelTank = 45;
          private const float k_MaximumBatteryLifeHours = 3.2f;
          private readonly eCarColor r_Color;
          private readonly int r_DoorsNumber;

          public eCarColor Color
          {
               get { return r_Color; }
          }

          public int DoorsNumber
          {
               get { return r_DoorsNumber; }
          }

          public enum eCarColor
          {
               Grey = 1,
               Blue,
               White,
               Black
          }

          public enum eCarDoors
          {
               Two = 2,
               Three,
               Four,
               Five
          }

          public Car(VehicleEntranceForm i_VehicleEntranceForm)
               : base(i_VehicleEntranceForm.VehicleModel, i_VehicleEntranceForm.LicenseNumber)
          {
               r_Color = i_VehicleEntranceForm.CarColor;
               r_DoorsNumber = i_VehicleEntranceForm.CarDoorsNumber;

               if (i_VehicleEntranceForm.VehicleType == VehicleFactory.eVehicleType.ElectricMotorcycle)
               {
                    Engine = new ElectricEngine(i_VehicleEntranceForm.RemainingBatteryHours, k_MaximumBatteryLifeHours);
               }
               else
               {
                    Engine = new GasolineEngine(k_CarFuelType, i_VehicleEntranceForm.CurrentFuelAmount, k_CarVolumeOfFuelTank);
               }

               for (int i = 0; i < k_NumberOfWheelsInCar; i++)
               {
                    Wheel WheelToAdd = new Wheel(
                         i_VehicleEntranceForm.WheelManufacturer, 
                         i_VehicleEntranceForm.WheelCurrentAirPressure, 
                         k_MaximumAirPressure);
                    Wheels.Add(WheelToAdd);
               }
          }

          public override string ToString()
          {
               StringBuilder str = new StringBuilder();
               str.AppendLine(base.ToString());
               str.AppendLine("Car Properties:");
               str.AppendFormat("Number of Doors: {0}{1}", r_DoorsNumber, Environment.NewLine);
               str.AppendFormat("Car Color: {0}{1}", r_Color, Environment.NewLine);
               return str.ToString();
          }

          public override List<string> GetSpecificInfo()
          {
               List<string> infoArray = new List<string>();
               infoArray.Add(r_Color.ToString());
               infoArray.Add(r_DoorsNumber.ToString());
               return infoArray;
          }
     }
}
