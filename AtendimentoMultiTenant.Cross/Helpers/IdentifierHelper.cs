﻿namespace AtendimentoMultiTenant.Cross.Helpers
{
    public class IdentifierHelper
    {
        private const string keyString = Configurations.KEYSTRING;
        private static readonly byte[] IV = {0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };

        /// <summary>
        /// Método que retorna o id do usuário e o id do token, criptografados
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static string SetIdentifier(Guid? userId, Guid? tokenId)
        {
            return Encrypt(userId + "|" + tokenId);
        }

        /// <summary>
        /// Método que retorna o id do usuário e o id do token, descriptografados
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns></returns>
        public static Dictionary<string, Guid> GetIdentifier(string identifier)
        {
            var result = Decrypt(identifier);

            string[] parts = result.Split(new char[] { '|' });

            var dic = new Dictionary<string, Guid>
            {
                { "USERID", Guid.Parse(parts[0].ToString()) },
                { "TOKENID", Guid.Parse(parts[1].ToString()) }
            };

            return dic;
        }

        public static string Encrypt(string text)
        {
            using (var aesAlg = Aes.Create())
            {
                aesAlg.Key = DeriveKeyFromPassword(keyString);
                aesAlg.Mode = CipherMode.CBC;
                aesAlg.Padding = PaddingMode.PKCS7;
                aesAlg.IV = IV;

                using (var encryptor = aesAlg.CreateEncryptor())
                {
                    byte[] encryptedBytes;
                    using (var msEncrypt = new MemoryStream())
                    {
                        using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(text);
                        }
                        encryptedBytes = msEncrypt.ToArray();
                    }
                    return Convert.ToBase64String(encryptedBytes);
                }
            }
        }

        public static string Decrypt(string cipherText)
        {
            try
            {
                using (var aesAlg = Aes.Create())
                {
                    aesAlg.Key = DeriveKeyFromPassword(keyString);
                    aesAlg.Mode = CipherMode.CBC;
                    aesAlg.Padding = PaddingMode.PKCS7;
                    aesAlg.IV = IV;

                    using (var decryptor = aesAlg.CreateDecryptor())
                    {
                        byte[] cipherBytes = Convert.FromBase64String(cipherText);
                        using (var msDecrypt = new MemoryStream(cipherBytes))
                        using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        using (var srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            catch (CryptographicException ex)
            {
                Console.WriteLine($"Decryption error: {ex.Message}");
            }

            return "";
        }

        private static byte[] DeriveKeyFromPassword(string key)
        {
            var emptySalt = Array.Empty<byte>();
            var iterations = 1000;
            var desiredKeyLength = 16; // 16 bytes = 128 bits.
            var hashMethod = HashAlgorithmName.SHA384;
            return Rfc2898DeriveBytes.Pbkdf2(Encoding.Unicode.GetBytes(key),
                                             emptySalt,
                                             iterations,
                                             hashMethod,
                                             desiredKeyLength);
        }
    }
}
