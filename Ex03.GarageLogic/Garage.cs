using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
     public class Garage
     {
          private List<Vehicle> m_Vehicles;

          public List<Vehicle> Vehicles
          {
               get { return m_Vehicles; }
               set { m_Vehicles = value; }
          }

          public void EnterNewVehicle(Vehicle i_NewVehicleToEnter)
          {

          }

          public void DisplayAllActualLicenseNumberOfVehicles() //to do filter
          {

          }

          public void ChangeVehicleStatus(string i_LicenseNumber) //to do enum for status
          {

          }

          public void InflateWheelToMax(string i_LicenseNumber)
          {

          }

          public void Fuel()
          {

          }
     }
}
