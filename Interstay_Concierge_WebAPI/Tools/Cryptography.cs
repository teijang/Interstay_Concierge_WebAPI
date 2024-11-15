using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace Interstay_Concierge_WebAPI.Tools
{
    public static class Cryptography
    {
        const string saltkey = "dlsxjtmxpdlakstp";
        private static byte[] _BytKey = null;

        private static SymmetricAlgorithm _SymmetricAlgorithm;
        static Cryptography()
        {
            if (_SymmetricAlgorithm == null)
            {
                _SymmetricAlgorithm = new AesManaged();
                // new RijndaelManaged();
            }

            if (_BytKey == null)
            {
                _BytKey = GetKey(saltkey);
            }
        }

        // 양방향
        public static string Encrypting(string sourceData)
        {
            if (string.IsNullOrWhiteSpace(sourceData))
                return string.Empty;

            byte[] bytIn = UTF8Encoding.UTF8.GetBytes(sourceData.Trim());

            System.IO.MemoryStream msMemoryStream = new System.IO.MemoryStream();

            _SymmetricAlgorithm.Key = _BytKey;
            _SymmetricAlgorithm.IV = _BytKey;

            ICryptoTransform ictEncrypto = _SymmetricAlgorithm.CreateEncryptor();
            CryptoStream csCryptoStream = new CryptoStream(msMemoryStream, ictEncrypto, CryptoStreamMode.Write);

            // write out encrypted content into MemoryStream
            csCryptoStream.Write(bytIn, 0, bytIn.Length);
            csCryptoStream.FlushFinalBlock();

            return Convert.ToBase64String(msMemoryStream.ToArray());
        }


        // 단방향
        public static string EncryptingPassword(string sourceData)
        {
            if (string.IsNullOrWhiteSpace(sourceData))
                return string.Empty;

            // Use input string to calculate MD5 hash
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(sourceData);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }
            return sb.ToString();
        }


        public static string Decrypting(string sourceData)
        {
            return Decrypting(sourceData, true);
        }


        public static string Decrypting(string sourceData, bool checkCridential)
        {
            if (string.IsNullOrWhiteSpace(sourceData))
                return string.Empty;

            //if (checkCridential && !SessionClass.HasConfidentialRights)
            //    return "열람 권한 없음";


            // convert from Base64 to binary
            try
            {
                byte[] bytIn = Convert.FromBase64String(sourceData.Trim());
                //create a MemoryStream with the input
                System.IO.MemoryStream msMemoryStream = new System.IO.MemoryStream(bytIn, 0, bytIn.Length);


                //set the private key
                _SymmetricAlgorithm.Key = _BytKey;
                _SymmetricAlgorithm.IV = _BytKey;

                //create a Decryptor from the Provider Service instance
                ICryptoTransform ictEncrypto = _SymmetricAlgorithm.CreateDecryptor();

                //create Crypto Stream that transforms a stream using the decryption
                CryptoStream cs = new CryptoStream(msMemoryStream, ictEncrypto, CryptoStreamMode.Read);

                //read out the result from the Crypto Stream
                System.IO.StreamReader srStreamReader = new System.IO.StreamReader(cs);

                return srStreamReader.ReadToEnd();
            }
            catch
            {
                //throw ex;
                // 암호화 되지 않은 문자열은 원본 리턴
                return sourceData;
            }
        }

        private static byte[] GetKey(string keyValue)
        {
            string tempValue;
            if (_SymmetricAlgorithm.LegalKeySizes.Length > 0)
            {
                //int lessSize = 0;
                int moreSize = _SymmetricAlgorithm.LegalKeySizes[0].MinSize;
                //key sizes are in bits
                while (keyValue.Length * 8 > moreSize)
                {
                    //lessSize = moreSize;
                    moreSize += _SymmetricAlgorithm.LegalKeySizes[0].SkipSize;
                }
                tempValue = keyValue.PadRight(moreSize / 8, ' ');
            }
            else
            {
                tempValue = keyValue;
            }

            return ASCIIEncoding.ASCII.GetBytes(tempValue);
        }


    }
}