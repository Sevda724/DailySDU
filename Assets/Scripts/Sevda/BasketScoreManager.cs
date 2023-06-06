using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasketScoreManager : MonoBehaviour
{
    [SerializeField] Text highScoreText;
    [SerializeField] Text score;
    int highScore;
    [SerializeField] private InputField _inputField;
    public GameObject confetti;
    public AudioSource audio;
    bool ishigh = false;
    public static bool canPlay = true;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //PlayerPrefs.DeleteKey("BasketScore");
        highScore = (int)Ball.count;
        if (PlayerPrefs.GetInt("BasketScore") < highScore)
        {
            ishigh = true;           
            PlayerPrefs.SetInt("BasketScore", highScore);
            canPlay = false;
            //confetti.gameObject.SetActive(true);
        }
        else
        {
            canPlay = true;
        }

        if (ishigh && Ball.isGameOver)
        {
            _inputField.gameObject.SetActive(true);
            PlayerPrefs.SetString("BasketName", _inputField.text);
            confetti.gameObject.SetActive(true);
            audio.Play();
        }
        highScoreText.text = "HIGHSCORE: " + PlayerPrefs.GetInt("BasketScore");

    }
}
