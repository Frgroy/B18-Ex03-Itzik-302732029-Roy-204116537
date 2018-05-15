using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
     public class ValueOutOfRangeException : Exception
     {
          private const string k_MassageError = "Error: Value should be in range of [{0},{1}]";
          private readonly float r_MaxValue;
          private readonly float r_MinValue;

          public ValueOutOfRangeException(float i_MinValue, float i_MaxValue) : 
               base(string.Format(k_MassageError, i_MinValue, i_MaxValue))
          {
               r_MaxValue = i_MaxValue;
               r_MinValue = i_MinValue;
          }
     }
}
