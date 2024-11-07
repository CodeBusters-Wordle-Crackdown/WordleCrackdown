using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cs_mainmenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("WordleGameScene");

    }

    public void playClassic()
    {
        SceneManager.LoadScene("scene_classicmode");
    }

    public void playArcade()
    {
        SceneManager.LoadScene("scene_arcademode");
    }


    public void QuitGame()
    {
        Application.Quit();
    
    }
}
