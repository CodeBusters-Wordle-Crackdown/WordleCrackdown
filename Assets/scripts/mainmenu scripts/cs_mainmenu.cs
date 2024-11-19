using UnityEngine;
using UnityEngine.SceneManagement;

public class cs_mainmenu : MonoBehaviour
{
    public int wordLength = 5;
    public int attempts = 6;
    public bool timer = false;
    public bool infinite = false;

    private void SaveAndLoadScene()
    {
        CS_SaveSystem.saveGameMode(this);
        SceneManager.LoadScene("WordleGameScene");
    }

    public void PlayGame()
    {  
        SetGameMode(5, 6, false, false);
        SaveAndLoadScene();
    }

    public void playClassic()
    {
        SetGameMode(5, 6, false, false);
        SaveAndLoadScene();
    }

    public void playArcade()
    {
        SetGameMode(5, 6, false, false);
        SaveAndLoadScene();
    }

    public void playTimed()
    {
        SetGameMode(5, 6, true, false);
        SaveAndLoadScene();
    }

    public void playInfinite()
    {
        SetGameMode(5, 6, true, true);
        SaveAndLoadScene();
    }

    public void playEasy()
    {
        SetGameMode(4, 8, true, true);
        SaveAndLoadScene();
    }

    public void playNormal()
    {
        SetGameMode(5, 6, true, true);
        SaveAndLoadScene();
    }

    public void playChallenging()
    {
        SetGameMode(6, 6, true, true);
        SaveAndLoadScene();
    }

    public void playHard()
    {
        SetGameMode(7, 6, true, true);
        SaveAndLoadScene();
    }

    private void SetGameMode(int wordLen, int attemptCount, bool timerEnabled, bool infiniteMode)
    {
        wordLength = wordLen;
        attempts = attemptCount;
        timer = timerEnabled;
        infinite = infiniteMode;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}