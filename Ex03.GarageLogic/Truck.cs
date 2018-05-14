using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
     public class Truck : Vehicle
     {
          private const int k_NumberOfWheelsInTruck = 12;
          private const int k_MaximumAirPressure = 28;
          private const GasolineEngine.eFuelType k_TruckFuelType = GasolineEngine.eFuelType.Soler;
          private const float k_TruckVolumeOfFuelTank = 115;
          private bool m_IsTrunkCool;
          private float m_TrunkCapacity;

          public bool IsTrunkCool
          {
               get { return m_IsTrunkCool; }
               set { m_IsTrunkCool = value; }
          }

          public float TrunkCapacity
          {
               get { return m_TrunkCapacity; }
               set { m_TrunkCapacity = value; }
          }

          public Truck (VehicleEntranceForm i_VehicleEntranceForm)
               : base(i_VehicleEntranceForm.VehicleModel, i_VehicleEntranceForm.LicenseNumber)
          {
               m_IsTrunkCool = i_VehicleEntranceForm.IsTruckTrunkCool;
               m_TrunkCapacity = i_VehicleEntranceForm.TruckTrunkCapacity;
               Engine = new GasolineEngine(
                    i_VehicleEntranceForm.FuelType, 
                    i_VehicleEntranceForm.CurrentFuelAmount, 
                    k_TruckVolumeOfFuelTank);
               for (int i = 0; i < k_NumberOfWheelsInTruck; i++)
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
               infoArray.Add(m_TrunkCapacity.ToString());
               infoArray.Add(m_IsTrunkCool.ToString());
               return infoArray;
          }
     }
}
