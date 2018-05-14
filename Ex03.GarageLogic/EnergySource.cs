using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
     public class EnergySource
     {
          private float m_EnergyPercentage;

          public float EnergyPercentage
          {
               get { return m_EnergyPercentage; }
               set { m_EnergyPercentage = value; }
          }

          public EnergySource (float i_EnergyPercentage)
          {
               m_EnergyPercentage = i_EnergyPercentage;
          }
     }
}
