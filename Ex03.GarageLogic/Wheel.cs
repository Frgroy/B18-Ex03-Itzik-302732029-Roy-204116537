using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
     public class Wheel
     {
          private string m_Manufacturer;
          private float m_CurrentAirPressure;
          private float m_MaxAirPressure;

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
               get { return m_MaxAirPressure; }
               set { m_MaxAirPressure = value; }
          }

          public Wheel (string i_Manufacturer, float i_CurrentAirPressure, float i_MaxAirPressure)
          {
               m_Manufacturer = i_Manufacturer;
               m_CurrentAirPressure = i_CurrentAirPressure;
               m_MaxAirPressure = i_MaxAirPressure;
          }

          public void InflateWheelToFull() //to do out of range exveption
          {
               m_CurrentAirPressure = m_MaxAirPressure;
          }

          public void InflateWheelByAmount(int i_AirAmountToAdd) //to do out of range exveption
          {
               m_CurrentAirPressure += i_AirAmountToAdd;
          }
     }
}
