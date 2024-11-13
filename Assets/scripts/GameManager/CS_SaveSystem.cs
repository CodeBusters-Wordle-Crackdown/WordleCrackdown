using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class CS_SaveSystem
{
   public static void saveGameMode(cs_mainmenu mode)
   {
    BinaryFormatter formatter = new BinaryFormatter();  //changes data to binary
 
    string path = Application.persistentDataPath + "/gamemode.json";  //saves file to the data path into a gamemode.json file
    FileStream stream = new FileStream(path, FileMode.Create);  

    cs_gamemanager data = new cs_gamemanager(mode);

    formatter.Serialize(stream, mode);
    stream.Close();


   }

   public static cs_gamemanager loadMode()
   {
    string path = Application.persistentDataPath + "/gamemode.json";
    if(File.Exists(path))
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Open);

        cs_gamemanager data = formatter.Deserialize(stream) as cs_gamemanager;

        stream.Close();
        return data;

    }
    else
    {
        Debug.LogError("GameMode data not found" + path);
        return null;
    }
   }
}
