using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class CS_SaveSystem 
{
    public static string filePath = Application.persistentDataPath;
    public static string  fileName = "savedData.json";
    
    
    public static void saveGameMode(cs_mainmenu mode)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/gamemode.dat";
        FileStream stream = new FileStream(path, FileMode.Create);
        
        cs_gameModeData data = new cs_gameModeData(mode); // Create the data object
        formatter.Serialize(stream, data); // Serialize the data object, not the MonoBehaviour
        stream.Close();
    }

    public static cs_gameModeData loadMode()
    {
        string path = Application.persistentDataPath + "/gamemode.dat";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            
            cs_gameModeData data = formatter.Deserialize(stream) as cs_gameModeData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("GameMode data not found: " + path);
            return null;
        }
    }

    //Save game data functions
    public static void saveGameData(Board mode)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = filePath+fileName;
        FileStream stream = new FileStream(path, FileMode.Create);
        
        cs_playerData data = new cs_playerData(mode); // Create the saveddata json file
        formatter.Serialize(stream, data); // Serialize the data object, not the MonoBehaviour
        stream.Close();

        Debug.Log("Saved data path: " + path);
    }

    public static cs_playerData loadGameData()
    {
        string path = filePath+fileName;
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            
            cs_playerData data = formatter.Deserialize(stream) as cs_playerData; //change the data back inot a readable unity file
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("GameMode data not found: " + path);
            return null;
        }
    }

    
}