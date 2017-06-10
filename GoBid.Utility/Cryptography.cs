using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBid.Utility
{
    public class Cryptography
    {
        public static string Encrypt(string encrypData)
        {
            string good = "";
            try
            {
                for (int i = 0; i < encrypData.Length; i++)
                {
                    string charData = Convert.ToString(encrypData.Substring(i, 1));
                    string conChar = char.ConvertFromUtf32(char.ConvertToUtf32(charData, 0) + 128);
                    good = good + conChar;

                }


            }
            catch (Exception ex)
            {
                return ex.Message;

            }
            return good;


        }

        public static string Decrypt(string encrypData)
        {
            string good = "";
            try
            {
                for (int i = 0; i < encrypData.Length; i++)
                {
                    string charData = Convert.ToString(encrypData.Substring(i, 1));
                    string conChar = char.ConvertFromUtf32(char.ConvertToUtf32(charData, 0) - 128);
                    good = good + conChar;

                }


            }
            catch (Exception ex)
            {
                return ex.Message;

            }
            return good;


        }
    }
}
