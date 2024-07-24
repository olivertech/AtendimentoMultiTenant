namespace AtendimentoMultiTenant.Cross.Helpers
{
    public static class CryptoHelper
    {
        private const string cryptoKey = CoreConfigurations.CRYPTOKEY;
        private static readonly byte[] IV = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };

        public static string Encrypt(string text)
        {
            using (var aesAlg = Aes.Create())
            {
                aesAlg.Key = DeriveKeyFromSecretKey(cryptoKey);
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
                    aesAlg.Key = DeriveKeyFromSecretKey(cryptoKey);
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

        private static byte[] DeriveKeyFromSecretKey(string cryptoKey)
        {
            var emptySalt = Array.Empty<byte>();
            var iterations = 1000;
            var desiredKeyLength = 16; // 16 bytes = 128 bits.
            var hashMethod = HashAlgorithmName.SHA384;
            return Rfc2898DeriveBytes.Pbkdf2(Encoding.Unicode.GetBytes(cryptoKey),
                                             emptySalt,
                                             iterations,
                                             hashMethod,
                                             desiredKeyLength);
        }
    }
}
