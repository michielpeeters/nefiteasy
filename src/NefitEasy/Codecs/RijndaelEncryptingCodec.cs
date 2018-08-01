namespace NefitEasy.Codecs
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;

    public class RijndaelEncryptingCodec : IEncryptingCodec
    {
        private readonly SigningKeyGenerator _generator;
        private readonly RijndaelManaged _rijndael;

        public RijndaelEncryptingCodec(SigningKeyGenerator generator)
        {
            _rijndael = new RijndaelManaged {
                Mode = CipherMode.ECB,
                Padding = PaddingMode.Zeros
            };
            _generator = generator;
        }

        public string Decrypt(string data)
        {
            var parts = new List<byte>(Convert.FromBase64String(data));
            var moduloResult = parts.Count % 8;
            for (var i = 0; i < moduloResult; i++)
                parts.Add(0x00);

            _rijndael.Key = _generator.Execute();

            using (var decryptor = CreateRijndaelDecryptor(parts))
                return decryptor.ReadToEnd().Trim('\0');
        }

        private StreamReader CreateRijndaelDecryptor(List<byte> parts)
        {
            return new StreamReader(new CryptoStream(new MemoryStream(parts.ToArray()), _rijndael.CreateDecryptor(), CryptoStreamMode.Read));
        }

        public string Encrypt(string data)
        {
            var parts = new List<byte>(Encoding.Default.GetBytes(data));
            while (parts.Count % 16 != 0)
                parts.Add(0x00);

            _rijndael.Key = _generator.Execute();

            using (var encryptor = CreateRijndaelEncryptor(parts))
            {
                using (var encryptionStream = new MemoryStream())
                {
                    encryptor.CopyTo(encryptionStream);
                    return Convert.ToBase64String(encryptionStream.ToArray());
                }
            }
        }

        private CryptoStream CreateRijndaelEncryptor(List<byte> parts)
        {
            return new CryptoStream(new MemoryStream(parts.ToArray()), _rijndael.CreateEncryptor(), CryptoStreamMode.Read);
        }
    }
}