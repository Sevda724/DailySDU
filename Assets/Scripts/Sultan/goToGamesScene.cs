using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goToGamesScene : MonoBehaviour
{
    public void goNext(){
    	SceneManager.LoadScene("Games");
    }

    public void QuitGame()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}
