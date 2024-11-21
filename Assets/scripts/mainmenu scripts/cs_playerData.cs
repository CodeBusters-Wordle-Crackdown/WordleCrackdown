using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[System.Serializable]
public class cs_playerData 
{
    public int wordLength;
    public int attempts;
    public bool timer;
    public bool infinite;
    public float timeRemaining;
    public int score;
    public int difficulty = 5;  //4 = easy (4 letters), 5 = normal (5 letters), 6 = challenging (6 letters), 7 = hard (7 letters)

    public cs_playerData (Board gameStats)
    {
        
        wordLength = gameStats.word_size;
        attempts = gameStats.row_count;
        timer = gameStats.timerMode;
        timeRemaining = gameStats.CS_Timer.timer;
        //score = gameStats.getScore();
        difficulty = wordLength;
    }
}