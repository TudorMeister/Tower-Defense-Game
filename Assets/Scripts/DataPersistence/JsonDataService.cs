using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using UnityEngine;

//https://www.youtube.com/watch?v=mntS45g8OK4
public class JsonDataService : IDataService
{
    private const string KEY = "jiTreShlR5vtV8N/UBlyE1fz+frGJTZDSmyhIc/RGEw=";
    private const string IV = "zuvR4zCvSIHBczrKoOL+VA==";

    public T LoadData<T>(string Path, bool Encrypt)
    {
        string path = Application.persistentDataPath + Path;

        if(!File.Exists(path))
        {
            Debug.LogError($"File {path} does not exist!");
            throw new FileNotFoundException($"{path} does not exist!");
        }

        try {
            T data;
            if (Encrypt)
            {
                byte[] fileBytes = File.ReadAllBytes(path);
                using Aes aesProvider = Aes.Create();
                aesProvider.Key = Convert.FromBase64String(KEY);
                aesProvider.IV = Convert.FromBase64String(IV);

                using ICryptoTransform cryptoTransform = aesProvider.CreateDecryptor(
                    aesProvider.Key,
                    aesProvider.IV
                );
                using MemoryStream decryptStream = new MemoryStream(fileBytes);
                using CryptoStream cryptoStream = new CryptoStream(
                    decryptStream,
                    cryptoTransform,
                    CryptoStreamMode.Read
                );

                using StreamReader reader = new StreamReader(cryptoStream);
                string result = reader.ReadToEnd();

                data = JsonConvert.DeserializeObject<T>(result);
            }
            else 
            {
                data = JsonConvert.DeserializeObject<T>(File.ReadAllText(path));
            }

            return data;
        }
        catch(Exception e)
        {
            Debug.LogError($"Error on loading of {path}: {e.Message} {e.StackTrace}");
            throw e;
        }
    }

    public bool SaveData<T>(string Path, T Data, bool Encrypt)
    {
        string path = Application.persistentDataPath + Path;
        if (File.Exists(path))
        {
            Debug.Log("File already exists. Deleting "+path);
            File.Delete(path);
        }

        using FileStream stream = File.Create(path);
        if (Encrypt)
        {
            using Aes aesProvider = Aes.Create();
            aesProvider.Key = Convert.FromBase64String(KEY);
            aesProvider.IV = Convert.FromBase64String(IV);
            using ICryptoTransform cryptoTransform = aesProvider.CreateEncryptor();
            using CryptoStream cryptoStream = new CryptoStream(
                stream,
                cryptoTransform,
                CryptoStreamMode.Write
            );

            cryptoStream.Write(Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(Data)));
            return true;
        }

        stream.Close();

        File.WriteAllText(path, JsonConvert.SerializeObject(Data));
        return true;
    }
}
