using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
     public class Motorcycle : Vehicle
     {
          private eLicenseType m_LicenseType;
          private int m_EngineCapacity;

          public int EngineCapacity
          {
               get { return m_EngineCapacity; }
               set { m_EngineCapacity = value; }
          }

          public eLicenseType LicenseType
          {
               get { return m_LicenseType; }
               set { m_LicenseType = value; }
          }

          public enum eLicenseType
          {
               A,
               A1,
               B1,
               B2
          }
     }
}
