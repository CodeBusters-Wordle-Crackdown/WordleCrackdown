using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cs_quitGame : MonoBehaviour
{
    //Returns to main menu
    public void returnToMainMenu()
    {
        SceneManager.LoadScene("scene_MainMenu");
    
    }
}
