using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
     public class Truck : Vehicle
     {
          private bool m_IsTrunkCool;
          private float m_TrunkCapacity;

          public bool IsTrunkCool
          {
               get { return m_IsTrunkCool; }
               set { m_IsTrunkCool = value; }
          }

          public float TrunkCapacity
          {
               get { return m_TrunkCapacity; }
               set { m_TrunkCapacity = value; }
          }
     }
}
