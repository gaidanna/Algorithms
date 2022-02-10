/* Writing your own Convert.ToBase64String */

using System;

namespace CertificateTasks
{
    using System.Linq;

    public class Challenge
    {
        public const byte threeOctets = 24;
        public const byte sixBits = 6;
        private static readonly char[] Base64Letters = new[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '+', '/' };

        public static string ToBase64(string str)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(str);
            return System.Convert.ToBase64String(bytes);
            //return ConvertToBase64(bytes);
        }

        private static string ConvertToBase64(byte[] bytes)
        {
            var bits = string.Empty;
            var base64 = string.Empty;
            var octetsSelected = 0;

            for (var i = 0; i < bytes.Length; i++)
            {
                bits += Convert.ToString(bytes[i], 2).PadLeft(8, '0');
            }

            while (octetsSelected < bits.Length)
            {
                var octects = bits.Skip(octetsSelected).Take(threeOctets).ToList();

                var hextetsSelected = 0;
                while (hextetsSelected < octects.Count())
                {
                    var chunk = octects.Skip(hextetsSelected).Take(sixBits);
                    hextetsSelected += sixBits;

                    var bitString = chunk.Aggregate(string.Empty, (current, currentBit) => current + currentBit);

                    if (bitString.Length < 6)
                    {
                        bitString = bitString.PadRight(6, '0');
                    }
                    var singleInt = Convert.ToInt32(bitString, 2);

                    base64 += Base64Letters[singleInt];
                }

                octetsSelected += threeOctets;
            }

            for (var i = 0; i < (bits.Length % 3); i++)
            {
                base64 += "=";
            }

            return base64;
        }
    }
}
