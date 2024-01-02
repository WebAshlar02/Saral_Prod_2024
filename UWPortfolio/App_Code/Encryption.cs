using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Summary description for Encryption
/// </summary>
public class Encryption
{
    public void Main(string[] args)
    {




        //var strEncrypt = EncryptStringToBytes("IM0032743");

        //string encodedText = Convert.ToBase64String(strEncrypt);

        //byte[] data = Convert.FromBase64String("QXlLZUwyYlgwMlY0a2gzZ2RtRS9MZz09s");
        //string decodedString = Encoding.UTF8.GetString(data);

        //string strDecrypt = DecryptString(Base64Decode(decodedString));

        //var base64EncodedBytes = System.Convert.FromBase64String("QXlLZUwyYlgwMlY0a2gzZ2RtRS9MZz09s");
        //string abc = Encoding.ASCII.GetString(base64EncodedBytes);


        //string newText = "WVFBRWxFWG42Z3JHb3BQUGZpaUxZZ0FOSFFzTjhnU2ptNjhxOUJKUDZDRkQ5cFFhaGlVWENBMXhhTDBNVHB3Y0lxTm42OWpINVAwTGhERjZzNXNSNTJodFV1NHpDeEZZZm5TY25VSWREMHlTd3VBR3lVc1JXSGRmS05mMyt4dzBkUDB4SzR0aTZLVkNQcUVNTGVPNVJ5aUE1V1V1bXJGMjJwa1RPa0lXTzV1QjN3ZkhNVUcveW5qeTVlYW9BbSs3Y2tIVEFnTE15eUJFOXJyajJ6aXRsYVlMcXJoUmJxSDZwVldzQk9iMVZNalFJMysvK01xYXZLSDZGTG9GbGEyNW5tVjMrS0czNmViMEU4MzNSVDdKUG9KZ2p1QVFMSFBEMUxLMDdZcGtleFhrVThqa1BkVFF1azErVHl2alo5b2ZMNGs1NTF5c3lSZlVaa1cwNTVidzRtTmNpdVRjSTNFSjBlRkI4azhEbndOV2ErUy9vZ24vOTgzWE50cjF6WkEvdUNkUFZaZS93bC9lUk5CL1V4SlhNVDR0bGtMcWFkODhreXMwRmVNcXZuckN1V2NUODdjZWQ2RS92dEk2RTVrcldDSGZNN04rMkRsSExQUCtWZ2ZoUklkdTRLOFRJUzRJbnFjUXJsV2tTd2YvdlVQNE1odDNJLzF3TTNKTys0a204c2pvaENxT2c3eSt2Z24vWEQvTGdMWm14b2JaaFJtRDlEaGFQdm1sRWk2K1ZGTWZwS1lWYXFSWS91MDBzQVFZWHM5QSs2czYzU0wrT0toc3g3S3lPRkNGd0t5MVk0cTRBSEZoRXhhZG9FV0Y3cDNJZTdqTTY2SVRlS2VNSUpkY1dLTEl1RlQraFRiTE56Z1o2ZkFWOUNaMEVXR0lYZm41aGtsMHJ1bS9ncTU0R3NVOVdVQWFvMXAvWmptSEVyWkczT1hsMTRSZnpxeklFL0xhK1RueU1MZTRETFliTlFOZ2Ricy9vZjVOTC9DTHNNa1doN005cUtqSlZaTHBHOUR4OGlVWlRyTVBrd29KNlpqV0RuYi9TQVdpSXVEL2xsaldBWTZTYkRua1dGbnRPSmx0K1N1QmJDREJRaW4rakFFdzZSSDhrY1BIN3hWL0o1WVMweFdha1VDMkRlRkJBc3owSGJ3azdtYnYvb2tQQ1o0ZVEza0pxK3NkSWRsVlJnZXNrMjJPWjBab3ViTThDZEVITDBhbjdERUZ4SW9hRWYwZDhVQVlMWm1lQUZibDI5dE9lcWJxSktBYnR2b05IM1d5RFNKN3RIb2pLemN6bUFzVzViN1BodUJDanpYMW5qS2FZckVxbVFUazhsbk42NkNXeU44Y3lhLzlTdGt3ZzJJM2FBeUh0SkhPTEhvV21kZmpBUkhmNGZKSkp1RWoxWUpUQWNySkdvVDNpdEk9";


        //string newText = "G8hkMwRQ9spyhTYu0+pqdA==";
        //string strDecrypt = DecryptString(Base64Decode(newText));




        var request = "IM0032743";

        var strEncrypt = EncryptStringToBytes(request);

        string encodedText = Convert.ToBase64String(strEncrypt);
        //FWzjStXlz5iuwrmXAI/AOA==

        // convert code plaint to base64
        string convertText = Base64Encode(encodedText);


        //FWzjStXlz5iuwrmXAI/AOA==
    }


    public string Base64Encode(string plainText)
    {
        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
        return System.Convert.ToBase64String(plainTextBytes);
    }
    public string Base64Decode(string base64EncodedData)
    {
        var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
        return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
    }


    public byte[] EncryptStringToBytes(string plainText)
    {
        var key = Encoding.UTF8.GetBytes("5TGB&YHN7UJM(IK<5TGB&YHN7UJM(IK<");
        var iv = Encoding.UTF8.GetBytes("!QAZ2WSX#EDC4RFV");

        byte[] encrypted;
        // Create a RijndaelManaged object  
        // with the specified key and IV.  
        using (var rijAlg = new RijndaelManaged())
        {
            rijAlg.Mode = CipherMode.CBC;
            rijAlg.Padding = PaddingMode.PKCS7;
            rijAlg.FeedbackSize = 128;

            rijAlg.Key = key;
            rijAlg.IV = iv;

            // Create a decrytor to perform the stream transform.  
            var encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);

            // Create the streams used for encryption.  
            using (var msEncrypt = new MemoryStream())
            {
                using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (var swEncrypt = new StreamWriter(csEncrypt))
                    {
                        //Write all data to the stream.  
                        swEncrypt.Write(plainText);
                    }
                    encrypted = msEncrypt.ToArray();
                }
            }
        }
        // Return the encrypted bytes from the memory stream.  
        return encrypted;
    }



    public string DecryptString(string text)
    {

        byte[] cipherText = Convert.FromBase64String(text);
        var key = Encoding.UTF8.GetBytes("5TGB&YHN7UJM(IK<5TGB&YHN7UJM(IK<");
        var iv = Encoding.UTF8.GetBytes("!QAZ2WSX#EDC4RFV");

        //  byte[] key, byte[] iv
        // Check arguments.  
        if (cipherText == null || cipherText.Length <= 0)
        {
            throw new ArgumentNullException("cipherText");
        }

        // Declare the string used to hold  
        // the decrypted text.  
        string plaintext = null;

        // Create an RijndaelManaged object  
        // with the specified key and IV.  
        using (var rijAlg = new RijndaelManaged())
        {
            //Settings  
            rijAlg.Mode = CipherMode.CBC;
            rijAlg.Padding = PaddingMode.PKCS7;
            rijAlg.FeedbackSize = 128;

            rijAlg.Key = key;
            rijAlg.IV = iv;

            // Create a decrytor to perform the stream transform.  
            var decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);

            try
            {
                // Create the streams used for decryption.  
                using (var msDecrypt = new MemoryStream(cipherText))
                {
                    using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {

                        using (var srDecrypt = new StreamReader(csDecrypt))
                        {
                            // Read the decrypted bytes from the decrypting stream  
                            // and place them in a string.  
                            plaintext = srDecrypt.ReadToEnd();

                        }

                    }
                }
            }
            catch
            {
                plaintext = "keyError";
            }
        }

        return plaintext;
    }
}