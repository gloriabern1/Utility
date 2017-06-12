using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBid.Utility
{
    public class Filter
    {
        public static string FilterUserInput(string inputString)
        {



            try
            {

                return inputString.ToUpper().Replace("OR", "").Replace("--", "").Replace("ANY", "").Replace("SOME", "").Replace("NOT", "").Replace("!", "").Replace("*", "").Replace("ALL", "").Replace("SLEEP", "");

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return "";


        }
    }
}
