using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class cs_gamemanager
{
    public int wordLength = 5;
    public int attempts = 6; 
    public bool timer = false;
    public bool infinite = false;

    [Header("Game Statistics")]
    [SerializeField] public int highScore = 0;

  
    public cs_gamemanager (cs_mainmenu mode)
    {
        wordLength = mode.wordLength;
        attempts =mode.attempts;
        timer = mode.timer;
        infinite = mode.infinite;

    }

    public cs_gamemanager()
    {
        highScore = 0;
    }

    public void updateHighScore(int score)
    {
        if (score>highScore)
            {
                highScore = score;
                Debug.Log("High Score: "+highScore);
            }
    }


    

    
}
