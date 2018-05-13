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


          public void Inflate(int i_AirAmountToAdd) //to do out of range exveption
          {
               m_CurrentAirPressure += i_AirAmountToAdd;
          }
     }
}
