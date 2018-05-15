﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
     public abstract class Vehicle
     {
          private int m_NumberOfWheels;
          private string m_Model;
          private string m_LicenseNumber;
          private List<Wheel> m_Wheels = new List<Wheel>();
          private EnergySource m_Engine;

          public int NumberOfWheels
          {
               get { return m_NumberOfWheels; }
               set { m_NumberOfWheels = value; }
          }

          public string Model
          {
               get { return m_Model; }
               set { m_Model = value; }
          }

          public string LicenseNumber
          {
               get { return m_LicenseNumber; }
               set { m_LicenseNumber = value; }
          }

          public EnergySource Engine
          {
               get { return m_Engine; }
               set { m_Engine = value; }
          }

          public List<Wheel> Wheels
          {
               get { return m_Wheels; }
               set { m_Wheels = value; }
          }

          public Vehicle(string i_VehicleModel, string i_LicenseNumber)
          {
               m_Model = i_VehicleModel;
               m_LicenseNumber = i_LicenseNumber;
          }

          public void Inflate()
          {
               foreach (Wheel wheel in Wheels)
               {
                    wheel.InflateWheelToFull();
               }
          }

          public List<string> GetBasicInfo()
          {
               List<string> infoArray = new List<string>();
               infoArray.Add(LicenseNumber);
               infoArray.Add(Model);
               infoArray.Add(Wheels[0].CurrentAirPressure.ToString());
               infoArray.Add(Wheels[0].Manufacturer);
               return infoArray;
          }

          public abstract List<string> GetSpecificInfo();
     
     }
}
