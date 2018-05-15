using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
     public static class VehicleFactory
     {
          public static Vehicle CreateNewVehicle(VehicleEntranceForm i_VehicleEntranceForm)
          {
               Vehicle generatedVehicle = null;
               if (i_VehicleEntranceForm.VehicleType == eVehicleType.ElectricCar
                    || i_VehicleEntranceForm.VehicleType == eVehicleType.GasolineCar)
               {
                    generatedVehicle = new Car(i_VehicleEntranceForm);
               }
               else if (i_VehicleEntranceForm.VehicleType == eVehicleType.ElectricMotorcycle
                    || i_VehicleEntranceForm.VehicleType == eVehicleType.GasolineMotorcycle)
               {
                    generatedVehicle = new Motorcycle(i_VehicleEntranceForm);
               }
               else if (i_VehicleEntranceForm.VehicleType == eVehicleType.Truck)
               {
                    generatedVehicle = new Truck(i_VehicleEntranceForm);
               }

               return generatedVehicle;
          }

          public enum eVehicleType
          {
               GasolineCar = 1,
               ElectricCar,
               GasolineMotorcycle,
               ElectricMotorcycle,
               Truck
          }
     }
}
