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

    public cs_playerData()
    {
        
    }
}