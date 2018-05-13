using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
     public class ElectricEngine
     {
          י
          private float m_RemainingBatteryHours;
          private float m_MaxBatteryHours;
          private float roy;
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

          public void Recharge(float i_HoursToCharge)//to do excteption
          {
               m_RemainingBatteryHours += i_HoursToCharge;
          }
     }
}
