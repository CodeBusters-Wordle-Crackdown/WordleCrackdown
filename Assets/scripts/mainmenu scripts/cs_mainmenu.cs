using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class cs_mainmenu : MonoBehaviour
{
    public int wordLength =5;
    public int attempts = 6;
    public bool timer = false;
    public bool infinite = false;
    public void PlayGame() =>

        //wordLength = 5;
        //attempts = 6;
        //timer = false;
        //infinite = false;
        //CS_SaveSystem.saveGameMode(this);
        SceneManager.LoadScene("WordleGameScene");

    public void playClassic()
    {
        wordLength = 5;
        attempts = 6;
        timer = false;
        infinite = false;
        CS_SaveSystem.saveGameMode(this);
        SceneManager.LoadScene("WordleGameScene");
    }

    public void playArcade()
    {
        wordLength = 5;
        attempts = 6;
        timer = false;
        infinite = false;
        CS_SaveSystem.saveGameMode(this);
        SceneManager.LoadScene("WordleGameScene");
    }

    public void playTimed()
    {
        wordLength = 5;
        attempts = 6;
        timer = true;
        infinite = false;
        CS_SaveSystem.saveGameMode(this);
        SceneManager.LoadScene("WordleGameScene");

    }

    public void playInfinite()
    {
        wordLength = 5;
        attempts = 6;
        timer = true;
        infinite = true;
        CS_SaveSystem.saveGameMode(this);
        SceneManager.LoadScene("WordleGameScene");
    }

    public void playEasy()
    {
        wordLength = 4;
        attempts = 8;
        timer = true;
        infinite = true;
        CS_SaveSystem.saveGameMode(this);
        SceneManager.LoadScene("WordleGameScene");
    }

    public void playNormal()
    {
        wordLength = 5;
        attempts = 6;
        timer = true;
        infinite = true;
        CS_SaveSystem.saveGameMode(this);
        SceneManager.LoadScene("WordleGameScene");
    }

    public void playChallenging()
    {
        wordLength = 6;
        attempts = 6;
        timer = true;
        infinite = true;
        CS_SaveSystem.saveGameMode(this);
        SceneManager.LoadScene("WordleGameScene");
    }

    public void playHard()
    {
        wordLength = 7;
        attempts = 6;
        timer = true;
        infinite = true;
        CS_SaveSystem.saveGameMode(this);
        SceneManager.LoadScene("WordleGameScene");
    }


    public void QuitGame()
    {
        Application.Quit();
    
    }
}
