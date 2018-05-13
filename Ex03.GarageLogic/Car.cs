using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
     public class Car : Vehicle
     {
          private const int k_NumberOfWheelsInCar = 4;
          private const int k_MaximumAirPressure = 32;
          private const GasolineEngine.eFuelType k_CarFuelType = GasolineEngine.eFuelType.Octan98;
          private const float k_CarVolumeOfFuelTank = 45;
          private const float k_MaximumBatteryLifeHours = 3.2f;
          private const int k_FamilyCarWithTrunkDoors = 5;
          private const int k_FamilyCarDoors = 4;
          private const int k_MiniCarWithTrunkDoors = 3;
          private const int k_MiniCarDoors = 2;
          private eCarColor m_Color;
          private int m_DoorsNumber;
          private EnergySource m_Engine;

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

          public EnergySource Engine
          {
               get { return m_Engine; }
               set { m_Engine = value; }
          }

          public Car(VehicleEntranceForm i_vehicleEntranceForm)
               : base(i_vehicleEntranceForm.VehicleModel, 
                      i_vehicleEntranceForm.LicenseNumber
                      )
          {

          }

     }
}
