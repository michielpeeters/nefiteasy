namespace NefitEasy.Codecs
{
    using System;
    using System.Security.Cryptography;
    using System.Text;

    public class SigningKeyGenerator
    {
        private readonly NefitEasyCredentials _credentials;
        private byte[] _cachedKey;

        public SigningKeyGenerator(NefitEasyCredentials credentials)
        {
            _credentials = credentials;
        }

        public byte[] Execute()
        {
            if (_cachedKey == null || _cachedKey.Length == 0)
            {
                _cachedKey = GenerateKey(
                    new byte[] {
                        0x58, 0xf1, 0x8d, 0x70, 0xf6, 0x67, 0xc9, 0xc7,
                        0x9e, 0xf7, 0xde, 0x43, 0x5b, 0xf0, 0xf9, 0xb1,
                        0x55, 0x3b, 0xbb, 0x6e, 0x61, 0x81, 0x62, 0x12,
                        0xab, 0x80, 0xe5, 0xb0, 0xd3, 0x51, 0xfb, 0xb1
                    }, _credentials.AccessKey, _credentials.Password);
            }

            return _cachedKey;
        }

        private static byte[] GenerateKey(byte[] magicKey, string accessKey, string password)
        {
            var md5 = MD5.Create();
            return CombineByteArrays(
                md5.ComputeHash(CombineByteArrays(Encoding.Default.GetBytes(accessKey), magicKey)),
                md5.ComputeHash(CombineByteArrays(magicKey, Encoding.Default.GetBytes(password)))
            );
        }

        private static byte[] CombineByteArrays(byte[] inputBytes1, byte[] inputBytes2)
        {
            var inputBytes = new byte[inputBytes1.Length + inputBytes2.Length];
            Buffer.BlockCopy(inputBytes1, 0, inputBytes, 0, inputBytes1.Length);
            Buffer.BlockCopy(inputBytes2, 0, inputBytes, inputBytes1.Length, inputBytes2.Length);
            return inputBytes;
        }
    }
}