using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    Image timerBar;
    public float maTime = 30f;
    float timeLeft;
    public GameObject sh;
    public GameObject ma;
    public GameObject equation;
    public GameObject button;
    public GameObject record;
    public Text result;
    public Buttons buttonscript;
    public AudioSource rec;

    void Start()
    {
       timerBar = GetComponent<Image>();
        timeLeft = maTime;
    }

    // Update is called once per frame
    void Update()
    {
    	//print(buttonscript.recordName);

    	if(GameController.start==true&&maMove.num!=0&&shMove.num!=0){
    		
    	
        if(timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timerBar.fillAmount = timeLeft / maTime;
        } else
        {
        	result.text="SCORE:"+GameController.points.ToString ();
        	button.SetActive(true);

        	equation.SetActive(false);

        	Destroy(ma);
        	Destroy(sh);


        	if(PlayerPrefs.GetInt("ItTakesTwoRecord")<GameController.points){
                PlayerPrefs.SetInt("ItTakesTwoRecord", GameController.points);


                PlayerPrefs.SetString("ItTakesRecord", buttonscript.recordName);
                rec.Play();
                    //Debug.Log(PlayerPrefs.GetString("ItTakesRecord"));
                record.SetActive(true);

            }
        }
    }
    }
}
