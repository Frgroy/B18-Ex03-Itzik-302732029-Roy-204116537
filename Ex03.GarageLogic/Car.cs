using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
     public class Car : Vehicle
     {
          private const int k_FamilyWithTrunkDoors = 5;
          private const int k_FamilyDoors = 4;
          private const int k_MiniWithTrunkDoors = 3;
          private const int k_MiniDoors = 2;
          private eCarColor m_Color;
          private int m_DoorsNumber;

          public eCarColor Color
          {
               get { return m_Color; }
               set { m_Color = value; }
          }

          public int DoorsNumber
          {
               get { return m_DoorsNumber; }
               set { m_DoorsNumber = value; }
          }

          public enum eCarColor
          {
               Grey,
               Blue,
               White,
               Black
          }

          private string m_Model;
          private string m_LicenseNumber;
          private float m_EnergyPercentage;
          private List<Wheel> m_Wheels;
          private EnergySource m_Engine;

     }
}
