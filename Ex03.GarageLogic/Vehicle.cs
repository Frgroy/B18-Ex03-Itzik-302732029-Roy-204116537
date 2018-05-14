using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
     public abstract class Vehicle
     {
          private string m_Model;
          private string m_LicenseNumber;
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

          public EnergySource Engine
          {
               get { return m_Engine; }
               set { m_Engine = value; }
          }

          public List<Wheel> Wheels
          {
               get { return m_Wheels; }
               set { m_Wheels = value; }
          }
          public Vehicle(string i_VehicleModel, string i_LicenseNumber)
          {
               m_Model = i_VehicleModel;
               m_LicenseNumber = i_LicenseNumber;
          }
     }
}
