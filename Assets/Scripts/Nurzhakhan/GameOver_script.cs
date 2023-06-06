using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOver_script : MonoBehaviour
{
    public Player_script player_script;

    void Start()
    {
        player_script = gameObject.GetComponent<Player_script>();
    }

    public void TryAgainButton()
    {
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }

}
