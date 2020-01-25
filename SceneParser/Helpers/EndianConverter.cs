using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SceneParser.Helpers
{
    /**
     * This class is taken from interactive 7 by Sagachief
     * @source https://github.com/Segachief/Godo/blob/master/Godo/Helper/EndianConvert.cs
     **/
    public class EndianConverter
    {

        // This converts little endian values to int
        public static int GetLittleEndianInt(byte[] data)
        {
            return  (data[3] << 24)
                    | (data[2] << 16)
                    | (data[1] << 8)
                    | data[0];
        }

        public static int GetLittleEndianIntTwofer(byte[] data)
        {
            return (data[1] << 8)
                    | data[0];
        }

        public static int GetPreviousLittleEndianInt(byte[] data, int startIndex)
        {
            return (data[startIndex - 1] << 24)
                    | (data[startIndex - 2] << 16)
                    | (data[startIndex - 3] << 8)
                    | data[startIndex - 4];
        }

        // This converts a ulong value (16-bit number) to a 2-byte little endian value (8-bit per byte)
        public static byte[] GetLittleEndianConvert(ulong value)
        {
            byte[] bytes = BitConverter.GetBytes(value);

            // If it was big endian, reverse it
            if (!BitConverter.IsLittleEndian)
                Array.Reverse(bytes);
            return bytes;
        }

        public static byte[] AddLittleEndian(byte[] a, byte[] b)
        {
            List<byte> result = new List<byte>();
            if (a.Length < b.Length)
            {
                byte[] t = a;
                a = b;
                b = t;
            }
            int carry = 0;
            for (int i = 0; i < b.Length; ++i)
            {
                int sum = a[i] + b[i] + carry;
                result.Add((byte)(sum & 0xFF));
                carry = sum >> 8;
            }
            for (int i = b.Length; i < a.Length; ++i)
            {
                int sum = a[i] + carry;
                result.Add((byte)(sum & 0xFF));
                carry = sum >> 8;
            }
            if (carry > 0)
            {
                result.Add((byte)carry);
            }
            return result.ToArray();
        }
    }
}
