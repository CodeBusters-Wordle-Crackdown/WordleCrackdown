using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;
//using Firebase.Database;
using System;

public static class CS_SaveSystem 
{
    public static string filePath = Application.persistentDataPath;
    public static string  fileName = "savedData.json";
    public static string  statsFileName = "stats.json";
    public static cs_playerData loadedData; 
    public static cs_playerData loadedStats; 
    public static bool isDataLoaded = false; 
    public static bool isStatsLoaded = false; 
    
    
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
        string path = filePath+"/"+fileName;
        FileStream stream = new FileStream(path, FileMode.Create);
        
        cs_playerData data = new cs_playerData(mode); // Create the saveddata json file
        formatter.Serialize(stream, data); // Serialize the data object, not the MonoBehaviour
        stream.Close();

        pushToDB(data); //attempt to push game isntance data to data base

        Debug.Log("Saved data path: " + path);
        Debug.Log("high score saved is " + data.highScore);
    }

    public static void saveGameStats(CS_playerStats stats)
    {
    BinaryFormatter formatter = new BinaryFormatter();
    string path = filePath+"/"+statsFileName;
    FileStream stream = new FileStream(path, FileMode.Create);

    cs_playerData data = new cs_playerData(stats);
    formatter.Serialize(stream, data);
    stream.Close();
    }

  

    //loads and deserializes game instance data
    public static cs_playerData loadGameData()
    {
        string path = filePath+"/"+fileName;
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            
            cs_playerData data = formatter.Deserialize(stream) as cs_playerData; //change the data back inot a readable unity file
            stream.Close();
            loadedData = data;
            isDataLoaded = true;
            return data;
        }
        else
        {
            Debug.LogError("GameMode data not found: " + path);
            return null;
        }
    }

    public static cs_playerData loadGameStats()
    {
        string path = filePath+"/"+statsFileName;
        if(File.Exists(path))
        {
            Debug.Log("Game Stats file found"+path+" found");
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            
            cs_playerData data = formatter.Deserialize(stream) as cs_playerData; //change the data back inot a readable unity file
            stream.Close();
            loadedStats = data;
            isStatsLoaded = true;
            return data;
        }
        else
        {
            Debug.Log("gameStats data not found: " + path);
           //                      saveGameStats();
            return null;
        }
    }


    public static void printSavedData()
    {
        Debug.Log("Score" + loadedData.score);
        //Debug.Log("Time Remaining" + loadedData.timeRemaining);
        Debug.Log("Word length" + loadedData.wordLength);

    }

    //firebase implementatation
    public static void pushToDB(cs_playerData data)
    {
       try
       {
            bool isDataSaved =false; 
            Debug.Log("Attempting to load player data to server...");
            //enter firebase scripts to push data to firebase here


            if (isDataSaved)
                Debug.Log("Player data saved");
            else
                Debug.Log("Failed to save player data to server");
       }
       catch (Exception e)
       {
        Debug.LogError("Failed to connect to server: " + e.Message);
       }
    }
}