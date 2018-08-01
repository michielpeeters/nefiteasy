namespace NefitEasy.Codecs
{
    public interface IEncryptingCodec
    {
        string Decrypt(string data);
        string Encrypt(string data);
    }
}