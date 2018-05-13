using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
     public class Truck
     {
          private bool m_IsTrunkCool;
          private float m_EngineCapacity;

          public bool IsTrunkCool
          {
               get { return m_IsTrunkCool; }
               set { m_IsTrunkCool = value; }
          }

          public float EngineCapacity
          {
               get { return m_EngineCapacity; }
               set { m_EngineCapacity = value; }
          }
     }
}
