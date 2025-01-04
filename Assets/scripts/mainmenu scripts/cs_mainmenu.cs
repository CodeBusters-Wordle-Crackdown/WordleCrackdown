using TMPro.Examples;
using UnityEngine;
using UnityEngine.SceneManagement;


public class cs_mainmenu : MonoBehaviour
{
    [Header("Main Menu Config")]
    [SerializeField] public int wordLength = 5;
    [SerializeField] public int attempts = 6;
    [SerializeField] public bool timer = false;
    [SerializeField] public bool infinite = false;
    [SerializeField] public bool isCustomMode = false;

    



    private void SaveAndLoadScene()
    {
        CS_SaveSystem.saveGameMode(this);
        SceneManager.LoadScene("WordleGameScene");
    }

    public void setTimerBool (bool toggleVal)
    {
        timer = toggleVal;
        //Debug.Log(message: "Timer is set to: "+toggleVal, context:this);
        printGameCurrentConfig();
    }

    public void setInfiniteBool (bool toggleVal)
    {
        infinite = toggleVal;
        //Debug.Log(message: "Infite is set to: "+toggleVal, context:this);
        printGameCurrentConfig();
    }

    public void setWordLength (int value)
    {
        wordLength = value;
        printGameCurrentConfig();
    }

    public void setNumberOfAttempts (int value)
    {
        attempts = value;
        printGameCurrentConfig();
    }



    public void PlayGame()
    {  
         
        //SetGameMode(wordLength, attempts, timer, infinite);
        
        Debug.Log(message: "loading game scene...", context: this);
        printGameCurrentConfig();
        SaveAndLoadScene();
    }

    public void playClassic()
    {
        wordLength = 5;
        attempts = 6;
        PlayGame();
       
    }

    public void playArcade()
    {
        wordLength = 5;
        attempts = 6;
        PlayGame();
       
    }

    public void playTimed()
    {
        wordLength = 5;
        attempts = 6;
        PlayGame();
        
    }

    public void playInfinite()
    {
        wordLength = 4;
        attempts = 6;
        infinite = true;
        PlayGame();
    }

    public void playEasy()
    {
        wordLength = 4;
        attempts = 6;
        PlayGame();
    }

    public void playNormal()
    {
        wordLength = 5;
        attempts = 6;
        PlayGame();
    }

    public void playChallenging()
    {
        wordLength = 6;
        attempts = 6;
        PlayGame();
    }

     public void playTimer()
    {
        timer=true;
        PlayGame();
    }

    public void playHard()
    {
        wordLength = 7;
        attempts = 6;
        PlayGame();
    }

    private void SetGameMode(int wordLen, int attemptCount, bool timerEnabled, bool infiniteMode)
    {
        wordLength = wordLen;
        Debug.Log(message: "SetGameMode: Initializing wordlength to " + wordLength, context: this);
        attempts = attemptCount;
        Debug.Log(message: "SetGameMode: Initializing attempts to " + attempts, context: this);
        timer = timerEnabled;
        Debug.Log(message: "SetGameMode: Initializing timer to " + timer, context: this);
        infinite = infiniteMode;
        Debug.Log(message: "SetGameMode: Initializing inifite to " + infinite, context: this);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void printGameCurrentConfig()
    {
        Debug.Log(message: "current game config:  wordlength to " + wordLength, context: this);
        Debug.Log(message: "current game config:  attempts to " + attempts, context: this);
        Debug.Log(message: "current game config:  timer to " + timer, context: this);
        Debug.Log(message: "current game config:  infinite to " + infinite, context: this);
    }

}