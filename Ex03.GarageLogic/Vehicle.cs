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


          public Vehicle(string i_VehicleModel, string i_LicenseNumber, float i_MaximumEnergyCapacity, float i_CurrentEnergyAmount)
          {
               m_Model = i_VehicleModel;
               m_LicenseNumber = i_LicenseNumber;
               m_EnergyPercentage = (i_CurrentEnergyAmount / i_MaximumEnergyCapacity);
          }
     }
}
