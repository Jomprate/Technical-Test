using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;
using UnityEngine.PlayerLoop;

public static class Helper
{

    public static string Serialize<T>(this T toserialize)
    {
        XmlSerializer xml = new XmlSerializer(typeof(T));
        StringWriter writer = new StringWriter();
        // ReSharper disable once HeapView.PossibleBoxingAllocation
        xml.Serialize(writer, toserialize);
        return writer.ToString();
    }

    public static T Deserialize<T>(this string toDeserialize)
    {
        XmlSerializer xml = new XmlSerializer(typeof(T));
        StringReader reader = new StringReader(toDeserialize);
        return (T) xml.Deserialize(reader);

    }


    private static string hash = "kkashdkjashh123";
    
    
    //Encrypt
    public static string Encrypt(string input)
    {
        byte[] data = Encoding.UTF7.GetBytes(input);
        //using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider())
        using (MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider())
        {
            byte[] key = MD5.ComputeHash(Encoding.UTF7.GetBytes(hash));
            using (TripleDESCryptoServiceProvider trip = new TripleDESCryptoServiceProvider() {Key = key, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7} )
            {
                ICryptoTransform tr = trip.CreateEncryptor();
                byte[] results = tr.TransformFinalBlock(data, 0, data.Length);
                return Convert.ToBase64String(results, 0, results.Length);
            }
        }
    }


    //Decrypt
    public static string Decrypt(string input)
    {
        byte[] data = Convert.FromBase64String(input);
        using (MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider())
        {
            byte[] key = MD5.ComputeHash(Encoding.UTF7.GetBytes(hash));
            using (TripleDESCryptoServiceProvider trip = new TripleDESCryptoServiceProvider() {Key = key, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7} )
            {
                ICryptoTransform tr = trip.CreateDecryptor();
                byte[] results = tr.TransformFinalBlock(data, 0, data.Length);
                return Encoding.UTF7.GetString(results);
            }
        }
    }



}
