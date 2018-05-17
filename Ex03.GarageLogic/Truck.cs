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

          public override string ToString()
          {
               StringBuilder str = new StringBuilder();
               str.AppendLine(base.ToString());
               str.AppendLine("Truck Properties:");
               str.AppendFormat("Is Truck cool: {0}{1}", m_IsTrunkCool.ToString(), Environment.NewLine);
               str.AppendFormat("Truck Capacity in m^3: {0}{1}", m_TrunkCapacity, Environment.NewLine);
               return str.ToString();
          }

          public bool IsTrunkCool
          {
               get { return m_IsTrunkCool; }
          }

          public float TrunkCapacity
          {
               get { return m_TrunkCapacity; }
          }

          public Truck(string i_LicenseNumber)
               : base(i_LicenseNumber)
          {
          }

          public override void FulfillVehicleDetails(VehicleEntranceForm i_VehicleEntranceForm)
          {
               m_IsTrunkCool = i_VehicleEntranceForm.IsTruckTrunkCool;
               m_TrunkCapacity = i_VehicleEntranceForm.TruckTrunkCapacity;
               Engine = new GasolineEngine(k_TruckFuelType, i_VehicleEntranceForm.CurrentFuelAmount, k_TruckVolumeOfFuelTank);
               for (int i = 0; i < k_NumberOfWheelsInTruck; i++)
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
