using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer_script : MonoBehaviour
{
    Image timerBar;
    public Image loss;
    float maxTime = 30f;
    float timeLeft;
    public bool isBomb = false;
    public bool isSec = false;

    Player_script player_script;
    public bool game_run_timer = false;
    public new ParticleSystem light;
    public GameOver_script gameOver_Script;
    public AudioSource time_audio;

    public GameObject try_again;
    public InputField input;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        timerBar = GetComponent<Image>();
        loss = GetComponent<Image>();
        timeLeft = maxTime;

        GameObject player_game = GameObject.Find("Player");
        player_script = player_game.GetComponent<Player_script>();
        time_audio = GetComponent<AudioSource>();
        input = GetComponent<InputField>();
    }

    // Update is called once per frame
    void Update()
    {
        game_run_timer = player_script.game_play;
        isBomb = player_script.isBomb;
        isSec = player_script.isSec;

        if (isBomb)
        {
            Debug.Log("IS BOMB");

            timeLeft -= 2;
            player_script.isBomb = false;

        }
        if (isSec)
        {
            timeLeft += 2;
            light.Play();
            player_script.isSec = false;
        }
        
        if (timeLeft > 0 && game_run_timer)
        {
            timeLeft -= Time.deltaTime;
            timerBar.fillAmount = timeLeft / maxTime;
        }
        else if (timeLeft < 0)
        {
            try_again.SetActive(true);
            game_run_timer = false;
            player_script.game_play = game_run_timer;
          
            Time.timeScale = 0;
        }
    }
}
