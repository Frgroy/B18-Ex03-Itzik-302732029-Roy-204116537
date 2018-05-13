using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
     public class GasolineEngine
     {
          private eFuelType m_FuelType;
          private float m_CurrentFuelAmount;
          private float m_MaxFuelAmount;

          public eFuelType FuelType
          {
               get { return m_FuelType; }
               set { m_FuelType = value; }
          }

          public float CurrentFuelAmount
          {
               get { return m_CurrentFuelAmount; }
               set { m_CurrentFuelAmount = value; }
          }

          public float MaxFuelAmount //to do constants
          {
               get { return m_MaxFuelAmount; }
               set { m_MaxFuelAmount = value; }
          }

          public void Fuel(float i_FuelAmountToAdd)//to do out of range excepreiino
          {
               m_CurrentFuelAmount += i_FuelAmountToAdd;
          }

          public enum eFuelType
          {
               Soler,
               Octan95,
               Octan96,
               Octan98
          }
     }
}
