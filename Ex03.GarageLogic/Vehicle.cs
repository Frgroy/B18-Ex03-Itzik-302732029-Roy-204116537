using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
     public abstract class Vehicle
     {
          private string m_Model;
          private string m_LicenseNumber;
          private float m_EnergyPercentage;
          private List<Wheel> m_Wheels;
          private EnergySource m_Engine;

          public string Model
          {
               get { return m_Model; }
               set { m_Model = value; }
          }

          public string LicenseNumber
          {
               get { return m_LicenseNumber; }
               set { m_LicenseNumber = value; }
          }

          public float EnergyPercentage
          {
               get { return m_EnergyPercentage; }
               set { m_EnergyPercentage = value; }
          }

          public List<Wheel> Wheels
          {
               get { return m_Wheels; }
               set { m_Wheels = value; }
          }

          public EnergySource Engine
          {
               get { return m_Engine; }
               set { m_Engine = value; }
          }
     }
}
