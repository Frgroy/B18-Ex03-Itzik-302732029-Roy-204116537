using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
     public class ElectricEngine : EnergySource
     {
          private float m_RemainingBatteryHours;
          private readonly float r_MaxBatteryHours;

          public float RemainingBatteryHours
          {
               get { return m_RemainingBatteryHours; }
               set { m_RemainingBatteryHours = value; }
          }

          public float MaxBatteryHours
          {
               get { return r_MaxBatteryHours; }
          }

          public ElectricEngine (float i_RemainingBatteryHours, float i_MaxBatteryHours)
               : base(i_RemainingBatteryHours / i_MaxBatteryHours * 100)
          {
               m_RemainingBatteryHours = i_RemainingBatteryHours;
               r_MaxBatteryHours = i_MaxBatteryHours;
          }

          public void Recharge(float i_HoursToCharge)
          {
               if (m_RemainingBatteryHours + i_HoursToCharge <= r_MaxBatteryHours)
               {
                    m_RemainingBatteryHours += i_HoursToCharge;
               }
               else
               {
                    throw (new ValueOutOfRangeException(0, r_MaxBatteryHours - m_RemainingBatteryHours));
               }
          }
     }
}
