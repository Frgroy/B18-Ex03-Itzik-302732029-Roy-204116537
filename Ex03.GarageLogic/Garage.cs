using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Garage
    {

        public enum eVehicleStatus
        {
            InRepair = 1,
            Fixed,
            Payed
        }

        private class VehicleInfo
        {
            private Vehicle m_Vehicle;
            private string m_OwnerName;
            private string m_OwnerPhoneNumber;
            private Garage.eVehicleStatus m_VehicleStatus;

            public string OwnerName
            {
                get { return m_OwnerName; }
                set { m_OwnerName = value; }
            }

            public string OwnerPhoneNumber
            {
                get { return m_OwnerPhoneNumber; }
                set { m_OwnerPhoneNumber = value; }
            }

            public Vehicle MyProperty
            {
                get { return m_Vehicle; }
                set { m_Vehicle = value; }
            }

            public Garage.eVehicleStatus VehicleStatus
            {
                get { return m_VehicleStatus; }
                set { m_VehicleStatus = value; }
            }
        }

        private List<VehicleInfo> m_Vehicles;

     


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
