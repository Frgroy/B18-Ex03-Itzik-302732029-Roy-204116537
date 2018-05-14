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

               public List<string> GetVehicleInfo()
               {
                    List<string> vehicleInfoList = new List<string>();
                    vehicleInfoList.AddRange(m_Vehicle.GetBasicInfo());
                    vehicleInfoList.AddRange(m_Vehicle.GetSpecificInfo());
                    vehicleInfoList.Add(m_OwnerName);
                    vehicleInfoList.Add(m_VehicleStatus.ToString());
                    return vehicleInfoList;
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

          public void EnterNewVehicle(VehicleInfo i_NewVehicleToEnter)
          {

               m_VehiclesInfo.Add(i_NewVehicleToEnter);
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

          public void ChangeVehicleStatusToInRepair(string i_LicenseNumber)
          {
               foreach (VehicleInfo vehicleInfo in m_VehiclesInfo)
               {
                    if (vehicleInfo.Vehicle.LicenseNumber == i_LicenseNumber)
                    {
                         vehicleInfo.VehicleStatus = eVehicleStatus.InRepair;
                    }
               }
          }

          public List<string> DisplayAllLicenseNumberOfVehicles()
          {
               List<string> allLicenseNumberOfVehicles = new List<string>();
               foreach (VehicleInfo vehicle in m_VehiclesInfo)
               {
                    allLicenseNumberOfVehicles.Add(vehicle.Vehicle.LicenseNumber);
               }

               return allLicenseNumberOfVehicles;
          }

          public List<string> DisplayLicenseNumberOfVehiclesByStatus(eVehicleStatus i_RequestedStatusToFilter)
          {
               List<string> LicenseNumberOfVehiclesByStatus = new List<string>();
               foreach (VehicleInfo vehicleInfo in m_VehiclesInfo)
               {
                    if (vehicleInfo.VehicleStatus == i_RequestedStatusToFilter)
                    {
                         LicenseNumberOfVehiclesByStatus.Add(vehicleInfo.Vehicle.LicenseNumber);
                    }
               }

               return LicenseNumberOfVehiclesByStatus;
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
                    if (vehicleInfo.Vehicle.LicenseNumber == i_LicenseNumber) //checks
                    {
                         GasolineEngine gasolineEngine = vehicleInfo.Vehicle.Engine as GasolineEngine;
                         if (gasolineEngine != null)
                         {
                              gasolineEngine.Fuel(i_amountToAdd);
                         }
                         else
                         {
                              throw new Exception();
                         }
                    }
               }
          }

          public void Charge(string i_LicenseNumber, float i_minutesAmountToAdd)
          {
               foreach (VehicleInfo vehicleInfo in m_VehiclesInfo)
               {
                    if (vehicleInfo.Vehicle.LicenseNumber == i_LicenseNumber) //checks
                    {
                         ElectricEngine electricEngine = vehicleInfo.Vehicle.Engine as ElectricEngine;
                         if (electricEngine != null)
                         {
                              electricEngine.Recharge(i_minutesAmountToAdd / 60);
                         }
                         else
                         {
                              throw new Exception();
                         }
                    }
               }
          }

          public List<string> GetSpecificVehicleInfo(string i_LicenseNumber)
          {
               List<string> specificVehicleInfo = new List<string>();
               foreach (VehicleInfo vehicleInfo in m_VehiclesInfo)
               {
                    if (vehicleInfo.Vehicle.LicenseNumber == i_LicenseNumber)
                    {
                         specificVehicleInfo.AddRange(vehicleInfo.GetVehicleInfo());
                    }
               }

               return specificVehicleInfo;
          }
     }
}
