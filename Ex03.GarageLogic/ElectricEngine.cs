using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
     public class ElectricEngine : EnergySource
     {
          private float m_RemainingBatteryHours;
          private float m_MaxBatteryHours;

          public float RemainingBatteryHours
          {
               get { return m_RemainingBatteryHours; }
               set { m_RemainingBatteryHours = value; }
          }

          public float MaxBatteryHours //to do constants
          {
               get { return m_MaxBatteryHours; }
               set { m_MaxBatteryHours = value; }
          }

          public ElectricEngine (float i_RemainingBatteryHours, float i_MaxBatteryHours)
          {
               m_RemainingBatteryHours = i_RemainingBatteryHours;
               m_MaxBatteryHours = i_MaxBatteryHours;
          }

          public void Recharge(float i_HoursToCharge)//to do excteption
          {
               m_RemainingBatteryHours += i_HoursToCharge;
          }
     }
}
