using System;
using System.Security.Cryptography;

namespace LoanShark.Core
{
    //http://www.dotnetnoob.com/2012/07/generating-secure-guids.html
    public static class SecureIdGenerator
    {
        
        public static Guid NewGuid()
        {
            byte[] bytes = { 0x00, 0x00, 0x00, 0x00,
                            0x00, 0x00, 0x00, 0x00,
                            0x00, 0x00, 0x00, 0x00,
                            0x00, 0x00, 0x00, 0x00 };

            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(bytes);
            }

            var time = BitConverter.ToUInt32(bytes, 0);
            var time_mid = BitConverter.ToUInt16(bytes, 4);
            var time_hi_and_ver = BitConverter.ToUInt16(bytes, 6);
            time_hi_and_ver = (ushort)((time_hi_and_ver | 0x4000) & 0x4FFF);

            bytes[8] = (byte)((bytes[8] | 0x80) & 0xBF);

            return new Guid(time, time_mid, time_hi_and_ver,
                bytes[8], bytes[9], bytes[10], bytes[11], bytes[12], bytes[13],
                bytes[14], bytes[15]);
        }
    }
}
