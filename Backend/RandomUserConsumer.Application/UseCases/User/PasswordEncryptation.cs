using System.Security.Cryptography;
using System.Text;
using RandomUserConsumer.Application.Enums;

namespace RandomUserConsumer.Application.UseCases.User;

public class PasswordEncryption
{
    public static string HashPassword(string password, string salt, EncryptionTypeEnum algorithm)
    {
        var saltedPassword = password + salt;

        HashAlgorithm hashAlgorithm;
        switch (algorithm)
        {
            case EncryptionTypeEnum.MD5:
                hashAlgorithm = MD5.Create();
                break;
            case EncryptionTypeEnum.SHA1:
                hashAlgorithm = SHA1.Create();
                break;
            case EncryptionTypeEnum.SHA256:
                hashAlgorithm = SHA256.Create();
                break;
            default:
                hashAlgorithm = SHA256.Create();
                break;
        }

        byte[] passwordBytes = Encoding.UTF8.GetBytes(saltedPassword);
        byte[] hashBytes = hashAlgorithm.ComputeHash(passwordBytes);
        StringBuilder sb = new StringBuilder();
        foreach (byte b in hashBytes)
        {
            sb.Append(b.ToString("x2"));
        }
        return sb.ToString();
    }

}