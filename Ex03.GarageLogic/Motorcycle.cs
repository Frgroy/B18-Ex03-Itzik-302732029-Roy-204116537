using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
     public class Motorcycle : Vehicle
     {
          private const int k_NumberOfWheelsInMotorcycle = 2;
          private const int k_MaximumAirPressure = 30;
          private const GasolineEngine.eFuelType k_MotorcycleFuelType = GasolineEngine.eFuelType.Octan96;
          private const float k_MotorcycleVolumeOfFuelTank = 6;
          private const float k_MaximumBatteryLifeHours = 1.8f;
          private eLicenseType m_LicenseType;
          private int m_EngineCapacity;

          public int EngineCapacity
          {
               get { return m_EngineCapacity; }
               set { m_EngineCapacity = value; }
          }

          public eLicenseType LicenseType
          {
               get { return m_LicenseType; }
               set { m_LicenseType = value; }
          }

          public Motorcycle(VehicleEntranceForm i_VehicleEntranceForm)
               : base(i_VehicleEntranceForm.VehicleModel, i_VehicleEntranceForm.LicenseNumber)
          {
               m_LicenseType = i_VehicleEntranceForm.MotorcycleLicenseType;
               m_EngineCapacity = i_VehicleEntranceForm.MotorcycleEngineCapacity;
               if (i_VehicleEntranceForm.VehicleType == VehicleFactory.eVehicleType.ElectricMotorcycle)
               {
                    Engine = new ElectricEngine(
                         i_VehicleEntranceForm.RemainingBatteryHours,
                         k_MaximumBatteryLifeHours);
               }
               else
               {
                    Engine = new GasolineEngine(
                         k_MotorcycleFuelType,
                         i_VehicleEntranceForm.CurrentFuelAmount,
                         k_MotorcycleVolumeOfFuelTank);
               }

               for (int i = 0; i < k_NumberOfWheelsInMotorcycle; i++)
               {
                    Wheel WheelToAdd = new Wheel(
                         i_VehicleEntranceForm.WheelManufacturer,
                         i_VehicleEntranceForm.WheelCurrentAirPressure,
                         k_MaximumAirPressure);
                    Wheels.Add(WheelToAdd);
               }
          }

          public override List<string> GetSpecificInfo()
          {
               List<string> infoArray = new List<string>();
               infoArray.Add(m_EngineCapacity.ToString());
               infoArray.Add(m_LicenseType.ToString());
               return infoArray;
          }

          public enum eLicenseType
          {
               A = 1,
               A1,
               B1,
               B2
          }

     }
}
