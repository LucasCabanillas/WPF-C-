using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public class Seguridad
{
    private static readonly string key = "ClaveSecreta1234"; // Reemplaza con una clave segura de al menos 16 caracteres

    public string Encrypt(string plainText)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes(key.PadRight(32, ' '));
            aes.IV = new byte[16];
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    byte[] inputBytes = Encoding.UTF8.GetBytes(plainText);
                    cs.Write(inputBytes, 0, inputBytes.Length);
                    cs.FlushFinalBlock();
                }
                return Convert.ToBase64String(ms.ToArray());
            }
        }
    }

    public string Decrypt(string encryptedText)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes(key.PadRight(32, ' '));
            aes.IV = new byte[16];
            using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(encryptedText)))
            {
                using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    byte[] outputBytes = new byte[ms.Length];
                    int bytesRead = cs.Read(outputBytes, 0, outputBytes.Length);
                    return Encoding.UTF8.GetString(outputBytes, 0, bytesRead).TrimEnd('\0');
                }
            }
        }
    }
}
