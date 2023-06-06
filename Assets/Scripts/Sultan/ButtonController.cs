using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void goBack(){
    	SceneManager.LoadScene("Main");
    }
    public void goCatcher(){
    	SceneManager.LoadScene("Catcher");
    }
    public void goBasketball(){
    	SceneManager.LoadScene("Basketball");
    }
    public void goIt(){
        Time.timeScale = 1f;
    	SceneManager.LoadScene("ItTakesMore");
    }

}
