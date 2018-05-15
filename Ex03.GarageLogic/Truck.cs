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
          private readonly bool r_IsTrunkCool;
          private readonly float r_TrunkCapacity;

          public override string ToString()
          {
               StringBuilder str = new StringBuilder();
               str.AppendLine(base.ToString());
               str.AppendLine("Truck Properties:");
               str.AppendFormat("Is Truck cool: {0}{1}", r_IsTrunkCool.ToString(), Environment.NewLine);
               str.AppendFormat("Truck Capacity in m^3: {0}{1}", r_TrunkCapacity, Environment.NewLine);
               return str.ToString();
          }

          public bool IsTrunkCool
          {
               get { return r_IsTrunkCool; }
          }

          public float TrunkCapacity
          {
               get { return r_TrunkCapacity; }
          }

          public Truck(VehicleEntranceForm i_VehicleEntranceForm)
               : base(i_VehicleEntranceForm.VehicleModel, i_VehicleEntranceForm.LicenseNumber)
          {
               r_IsTrunkCool = i_VehicleEntranceForm.IsTruckTrunkCool;
               r_TrunkCapacity = i_VehicleEntranceForm.TruckTrunkCapacity;
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

          public override List<string> GetSpecificInfo()
          {
               List<string> infoArray = new List<string>();
               infoArray.Add(r_TrunkCapacity.ToString());
               infoArray.Add(r_IsTrunkCool.ToString());
               return infoArray;
          }
     }
}
