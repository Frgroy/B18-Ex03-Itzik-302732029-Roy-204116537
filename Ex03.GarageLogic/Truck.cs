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
          private EnergySource m_Engine;

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

          public EnergySource Engine
          {
               get { return m_Engine; }
               set { m_Engine = value; }
          }
     }
}
