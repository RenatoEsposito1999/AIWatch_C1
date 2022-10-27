using System;
using System.IO;
using System.Text;
using UnityEngine;

public static class FileManager
{
    private static string _filePath;

    private static FileStream _file;

    public  static void _init(string filePath)
    {
        _filePath = filePath+"/data.json";
        if (!File.Exists(_filePath))
            _file = File.Create(_filePath);
        else
            _file = File.Open(_filePath, FileMode.Truncate, FileAccess.ReadWrite);
            
            
    }

    public static void WriteOnFile(string _string)
    {

        try
        {
            _file.Write(Encoding.ASCII.GetBytes(_string), 0, Encoding.ASCII.GetBytes(_string).Length);
        }
        catch (ObjectDisposedException)
        {
            _file = File.Open(_filePath, FileMode.Truncate, FileAccess.Write);
            _file.Write(Encoding.ASCII.GetBytes(_string), 0, Encoding.ASCII.GetBytes(_string).Length);
        }

        _file.Close();
    }

    public static string ReadFromFile(){

        _file = File.Open(_filePath, FileMode.Open, FileAccess.Read);

        byte[] buffer = new byte[_file.Length];

        try
        {
            _file.Read(buffer, 0, buffer.Length);
        }catch (ObjectDisposedException )
        {
            _file = File.Open(_filePath, FileMode.Truncate, FileAccess.Read);
            _file.Read(buffer, 0, buffer.Length);
        }

        _file.Close();
        return Encoding.UTF8.GetString(buffer, 0, buffer.Length);
             
    }


    public static void DestroyFile()
    {
        File.Delete(_filePath);
        File.Delete(_filePath+".meta");
    }
}