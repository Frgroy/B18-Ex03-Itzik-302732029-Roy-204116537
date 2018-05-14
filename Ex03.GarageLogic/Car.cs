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
          private const int k_FamilyCarWithTrunkDoors = 5;
          private const int k_FamilyCarDoors = 4;
          private const int k_MiniCarWithTrunkDoors = 3;
          private const int k_MiniCarDoors = 2;
          private eCarColor m_Color;
          private int m_DoorsNumber;

          public eCarColor Color
          {
               get { return m_Color; }
               set { m_Color = value; }
          }

          public int DoorsNumber
          {
               get { return m_DoorsNumber; }
               set { m_DoorsNumber = value; }
          }

          public enum eCarColor
          {
               Grey = 1,
               Blue,
               White,
               Black
          }

          public Car(VehicleEntranceForm i_VehicleEntranceForm)
               : base(i_VehicleEntranceForm.VehicleModel,
                      i_VehicleEntranceForm.LicenseNumber)
          {
               m_Color = i_VehicleEntranceForm.CarColor;
               m_DoorsNumber = i_VehicleEntranceForm.CarDoorsNumber;

               if (i_VehicleEntranceForm.VehicleType == VehicleFactory.eVehicleType.ElectricMotorcycle)
               {
                    Engine = new ElectricEngine(
                         i_VehicleEntranceForm.RemainingBatteryHours,
                         k_MaximumBatteryLifeHours);
               }
               else
               {
                    Engine = new GasolineEngine(
                         i_VehicleEntranceForm.FuelType,
                         i_VehicleEntranceForm.CurrentFuelAmount,
                         k_CarVolumeOfFuelTank);
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
     }
}
