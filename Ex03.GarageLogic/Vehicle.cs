using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
     public abstract class Vehicle
     {
          private readonly int r_NumberOfWheels;
          private readonly string r_Model;
          private readonly string r_LicenseNumber;
          private List<Wheel> m_Wheels = new List<Wheel>();
          private EnergySource m_Engine;

          public override string ToString()
          {
               StringBuilder str = new StringBuilder();
               str.AppendLine("Vehicle properties:");
               str.AppendFormat("Vehicle model: {0}{1}", r_Model, Environment.NewLine);
               str.AppendFormat("Licende Number: {0}{1}", r_LicenseNumber, Environment.NewLine);
               str.AppendFormat(m_Engine.ToString());
               str.AppendFormat(m_Wheels[0].ToString());
               return str.ToString();
          }
          public int NumberOfWheels
          {
               get { return r_NumberOfWheels; }
          }

          public string Model
          {
               get { return r_Model; }
          }

          public string LicenseNumber
          {
               get { return r_LicenseNumber; }
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
               r_Model = i_VehicleModel;
               r_LicenseNumber = i_LicenseNumber;
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
