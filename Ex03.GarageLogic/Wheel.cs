using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
     public class Wheel
     {
          private readonly float r_MaxAirPressure;
          private string m_Manufacturer;
          private float m_CurrentAirPressure;

          public string Manufacturer
          {
               get { return m_Manufacturer; }
               set { m_Manufacturer = value; }
          }

          public float CurrentAirPressure
          {
               get { return m_CurrentAirPressure; }
               set { m_CurrentAirPressure = value; }
          }

          public float MaxAirPressure
          {
               get { return r_MaxAirPressure; }
          }

          public Wheel(string i_Manufacturer, float i_CurrentAirPressure, float i_MaxAirPressure)
          {
               m_Manufacturer = i_Manufacturer;
               r_MaxAirPressure = i_MaxAirPressure;
               if (i_CurrentAirPressure <= r_MaxAirPressure)
               {
                    m_CurrentAirPressure = i_CurrentAirPressure;
               }
               else
               {
                    throw new ValueOutOfRangeException(0, r_MaxAirPressure);
               }
          }

          public void InflateWheelToFull()
          {
               m_CurrentAirPressure = r_MaxAirPressure;
          }

          public void InflateWheelByAmount(int i_AirAmountToAdd)
          {
               if (m_CurrentAirPressure + i_AirAmountToAdd <= r_MaxAirPressure)
               {
                    m_CurrentAirPressure += i_AirAmountToAdd;
               }
               else
               {
                    throw new ValueOutOfRangeException(0, r_MaxAirPressure - m_CurrentAirPressure);
               }
          }

          public new string ToString()
          {
               StringBuilder str = new StringBuilder();
               str.AppendLine("Wheel Properties:");
               str.AppendFormat("Wheel Manufacturer: {0}{1}", m_Manufacturer, Environment.NewLine);
               str.AppendFormat("Wheel current air pressure: {0} {1}", m_CurrentAirPressure, Environment.NewLine);
               str.AppendFormat("Wheel max air pressure: {0}{1}", r_MaxAirPressure, Environment.NewLine);
               return str.ToString();
          }
     }
}
