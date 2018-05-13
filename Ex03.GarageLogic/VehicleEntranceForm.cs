using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
     public class VehicleEntranceForm
     {
          private VehicleFactory.eVehicleType m_VehicleType;
          private string m_VehicleModel;
          private string m_LicenseNumber;
          private Car.eCarColor m_CarColor;
          private int m_CarDoorsNumber;
          private Motorcycle.eLicenseType m_MotorcycleLicenseType;
          private int m_MotorcycleEngineCapacity;
          private bool m_IsTruckTrunkCool;
          private float m_TruckTrunkCapacity;
          private float m_RemainingBatteryHours;
          private GasolineEngine.eFuelType m_FuelType;
          private float m_CurrentFuelAmount;

          public VehicleFactory.eVehicleType VehicleType
          {
               get { return m_VehicleType; }
               set { m_VehicleType = value; }

          }

          public string VehicleModel
          {
               get { return m_VehicleModel; }
               set { m_VehicleModel = value; }
          }

          public string LicenseNumber
          {
               get { return m_LicenseNumber; }
               set { m_LicenseNumber = value; }
          }

          public Car.eCarColor CarColor
          {
               get { return m_CarColor; }
               set { m_CarColor = value; }
          }

          public int CarDoorsNumber
          {
               get { return m_CarDoorsNumber; }
               set { m_CarDoorsNumber = value; }
          }

          public Motorcycle.eLicenseType MotorcycleLicenseType
          {
               get { return m_MotorcycleLicenseType; }
               set { m_MotorcycleLicenseType = value; }
          }

          public int MotorcycleEngineCapacity
          {
               get { return m_MotorcycleEngineCapacity; }
               set { m_MotorcycleEngineCapacity = value; }
          }

          public bool IsTruckTrunkCool
          {
               get { return m_IsTruckTrunkCool; }
               set { m_IsTruckTrunkCool = value; }
          }

          public float TruckTrunkCapacity
          {
               get { return m_TruckTrunkCapacity; }
               set { m_TruckTrunkCapacity = value; }
          }

          public float RemainingBatteryHours
          {
               get { return m_RemainingBatteryHours; }
               set { m_RemainingBatteryHours = value; }
          }

          public GasolineEngine.eFuelType FuelType
          {
               get { return m_FuelType; }
               set { m_FuelType = value; }
          }

          public float CurrentFuelAmount
          {
               get { return m_CurrentFuelAmount; }
               set { m_CurrentFuelAmount = value; }
          }
     }
}
