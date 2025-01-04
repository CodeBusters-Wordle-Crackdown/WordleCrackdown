using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using UnityEngine;

public class CS_playerStats : MonoBehaviour
{
    
    public static string  fileName = "savedData.json";
    public static string  statsFileName = "stats.json";
    public int highScore = 0;
    public bool newSave = true;

    private string prompt_statsFound = "Player profile found";
    private string prompt_statsNotFound = "Player profile not found";
    private string prompt_initStats = "Initializing player profile...";
    private string prompt_StatsInitialized = "Player profile initialized!";
    
    // Start is called before the first frame update
    void Start()
    {
        cs_playerData data = CS_SaveSystem.loadGameData(); 
        if (data== null)
            {
                Debug.Log(prompt_statsNotFound);
                Debug.Log(prompt_initStats);
                CS_SaveSystem.saveGameData(new Board());
                Debug.Log(prompt_StatsInitialized);
            }
        else
            {
                Debug.Log(prompt_statsFound);
                highScore = data.highScore;
                Debug.Log("High Score: " +data.highScore);
                
            }
            

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
