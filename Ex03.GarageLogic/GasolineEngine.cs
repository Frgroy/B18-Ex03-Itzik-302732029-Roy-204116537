using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
     public class GasolineEngine : EnergySource
     {
          private eFuelType m_FuelType;
          private float m_CurrentFuelAmount;
          private readonly float r_MaxFuelAmount;

          public eFuelType FuelType
          {
               get { return m_FuelType; }
               set { m_FuelType = value; }
          }

          public float CurrentFuelAmount
          {
               get { return m_CurrentFuelAmount; }
               set
               {
                    m_CurrentFuelAmount = value;
                    EnergyPercentage = m_CurrentFuelAmount / r_MaxFuelAmount * k_ToDecimalPrecentage;
               }
          }

          public float MaxFuelAmount
          {
               get { return r_MaxFuelAmount; }
          }

          public void Fuel(float i_FuelAmountToAdd, eFuelType i_fuelType)
          {
               if (i_fuelType != m_FuelType)
               {
                    throw new ArgumentException();
               }

               if (m_CurrentFuelAmount + i_FuelAmountToAdd <= r_MaxFuelAmount)
               {
                    m_CurrentFuelAmount += i_FuelAmountToAdd;
               }
               else
               {
                    throw (new ValueOutOfRangeException(0, r_MaxFuelAmount - m_CurrentFuelAmount));
               }
          }

          public GasolineEngine(eFuelType i_FuelType, float i_CurrentFuelAmount, float i_MaxFuelAmount)
               : base(i_CurrentFuelAmount / i_MaxFuelAmount * k_ToDecimalPrecentage)
          {
               m_FuelType = i_FuelType;
               r_MaxFuelAmount = i_MaxFuelAmount;
               if (i_CurrentFuelAmount <= r_MaxFuelAmount)
               {
                    m_CurrentFuelAmount = i_CurrentFuelAmount;
               }
               else
               {
                    throw new ValueOutOfRangeException(0, r_MaxFuelAmount);
               }
          }

          public enum eFuelType
          {
               Soler,
               Octan95,
               Octan96,
               Octan98
          }
          public override string ToString()
          {
               StringBuilder str = new StringBuilder();
               str.AppendLine("Engine Properties:");
               str.AppendFormat("Engine Type {0} {1}", eEngineType.Gasoline, Environment.NewLine);
               str.AppendLine(base.ToString());
               str.AppendFormat("remaining battery status {0}/{1} {2}", m_CurrentFuelAmount, r_MaxFuelAmount, Environment.NewLine);
               return str.ToString();
          }
     }
}
