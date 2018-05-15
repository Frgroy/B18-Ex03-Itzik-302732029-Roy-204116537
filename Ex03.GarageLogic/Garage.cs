using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
     public class Garage
     {
          public enum eFilter
          {
               InRepair = 1,
               Fixed,
               Payed,
               All

          }

          public enum eVehicleStatus
          {
               InRepair = 1,
               Fixed,
               Payed
          }

          public class VehicleInfo
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

               public Vehicle Vehicle
               {
                    get { return m_Vehicle; }
                    set { m_Vehicle = value; }
               }

               public Garage.eVehicleStatus VehicleStatus
               {
                    get { return m_VehicleStatus; }
                    set { m_VehicleStatus = value; }
               }

               public VehicleInfo(Vehicle i_Vehicle, string i_OwnerName, string i_OwnerPhoneNumber)
               {
                    m_Vehicle = i_Vehicle;
                    m_OwnerName = i_OwnerName;
                    m_OwnerPhoneNumber = i_OwnerPhoneNumber;
                    m_VehicleStatus = eVehicleStatus.InRepair;
               }

               public override string ToString()
               {
                    StringBuilder str = new StringBuilder();
                    str.AppendFormat("{0}, {1}", m_Vehicle.ToString(), Environment.NewLine);
                                        
                    return str.ToString();
               }
          }

          private List<VehicleInfo> m_VehiclesInfo;

          public List<VehicleInfo> VehiclesInfo
          {
               get { return m_VehiclesInfo; }
               set { m_VehiclesInfo = value; }
          }

          public Garage()
          {
               m_VehiclesInfo = new List<VehicleInfo>();
          }

          public void EnterNewVehicle(Vehicle i_NewVehicleToEnter, VehicleEntranceForm i_VehicleForm)
          {
               VehicleInfo newVehicleInfo = new VehicleInfo(i_NewVehicleToEnter, i_VehicleForm.OwnerName, i_VehicleForm.OwnerPhone);
               m_VehiclesInfo.Add(newVehicleInfo);
          }

          public bool FindLicenseInGarage(string i_LicenseNumber)
          {
               bool isLicenseNumberFound = false;
               foreach (VehicleInfo vehicleInfo in m_VehiclesInfo)
               {
                    if (vehicleInfo.Vehicle.LicenseNumber == i_LicenseNumber)
                    {
                         isLicenseNumberFound = true;
                    }
               }

               return isLicenseNumberFound;
          }

          public string DisplayAllLicenseNumberOfVehicles()
          {
               StringBuilder allLicenseNumberOfVehicles = new StringBuilder();
               foreach (VehicleInfo vehicle in m_VehiclesInfo)
               {
                    allLicenseNumberOfVehicles.AppendLine(vehicle.Vehicle.LicenseNumber);
               }

               return allLicenseNumberOfVehicles.ToString();
          }

          public string DisplayLicenseNumberOfVehiclesByStatus(eVehicleStatus i_RequestedStatusToFilter)
          {
               StringBuilder licenseNumberOfVehiclesByStatus = new StringBuilder();
               foreach (VehicleInfo vehicleInfo in m_VehiclesInfo)
               {
                    if (vehicleInfo.VehicleStatus == i_RequestedStatusToFilter)
                    {
                         licenseNumberOfVehiclesByStatus.AppendLine(vehicleInfo.Vehicle.LicenseNumber);
                    }
               }

               return licenseNumberOfVehiclesByStatus.ToString();
          }

          public void ChangeVehicleStatus(string i_LicenseNumber, eVehicleStatus i_RecievedNewStatus)
          {
               foreach (VehicleInfo vehicleInfo in m_VehiclesInfo)
               {
                    if (vehicleInfo.Vehicle.LicenseNumber == i_LicenseNumber)
                    {
                         vehicleInfo.VehicleStatus = i_RecievedNewStatus;
                    }
               }
          }

          public void InflateWheelsToMax(string i_LicenseNumber)
          {
               foreach (VehicleInfo vehicleInfo in m_VehiclesInfo)
               {
                    if (vehicleInfo.Vehicle.LicenseNumber == i_LicenseNumber)
                    {
                         vehicleInfo.Vehicle.Inflate();
                    }
               }
          }

          public void Fuel(string i_LicenseNumber, GasolineEngine.eFuelType i_fuelToAdd, float i_amountToAdd)
          {
               foreach (VehicleInfo vehicleInfo in m_VehiclesInfo)
               {
                    if (vehicleInfo.Vehicle.LicenseNumber == i_LicenseNumber)
                    {
                         GasolineEngine gasolineEngine = vehicleInfo.Vehicle.Engine as GasolineEngine;
                         if (gasolineEngine != null)
                         {
                              gasolineEngine.Fuel(i_amountToAdd, i_fuelToAdd);
                         }
                         else
                         {
                              throw (new ArgumentException());
                         }
                    }
               }
          }

          public void Charge(string i_LicenseNumber, float i_minutesAmountToAdd)
          {
               foreach (VehicleInfo vehicleInfo in m_VehiclesInfo)
               {
                    if (vehicleInfo.Vehicle.LicenseNumber == i_LicenseNumber)
                    {
                         ElectricEngine electricEngine = vehicleInfo.Vehicle.Engine as ElectricEngine;
                         if (electricEngine != null)
                         {
                              electricEngine.Recharge(i_minutesAmountToAdd / 60);
                         }
                         else
                         {
                              throw new ArgumentException();
                         }
                    }
               }
          }

          public string GetSpecificVehicleInfo(string i_LicenseNumber)
          {
               string specificVehicleInfo = null;
               foreach (VehicleInfo vehicleInfo in m_VehiclesInfo)
               {
                    if (vehicleInfo.Vehicle.LicenseNumber == i_LicenseNumber)
                    {
                         specificVehicleInfo = vehicleInfo.ToString();
                    }
               }

               return specificVehicleInfo;
          }

          public bool IsExistInGarage(string i_licenseNumber)
          {
               bool isLicenseNumberExists = false;

               foreach(VehicleInfo vehicleInfo in m_VehiclesInfo)
               {
                    if (i_licenseNumber == vehicleInfo.Vehicle.LicenseNumber)
                    {
                         isLicenseNumberExists = true;
                    }
               }

               return isLicenseNumberExists;
          }
     }
}
