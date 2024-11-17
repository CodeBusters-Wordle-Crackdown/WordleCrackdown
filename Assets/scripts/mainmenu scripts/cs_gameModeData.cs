using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[System.Serializable]
public class cs_gameModeData 
{
    public int wordLength;
    public int attempts;
    public bool timer;
    public bool infinite;

    public cs_gameModeData(cs_mainmenu menu)
    {
        wordLength = menu.wordLength;
        attempts = menu.attempts;
        timer = menu.timer;
        infinite = menu.infinite;
    }
}