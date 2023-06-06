using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
	public Text firstNum;
	public Text secondNum;
	public Text result;
    public Text recordText;
	public int sum = 0;
	public static bool start = false;
	public AudioSource swap;
	int counter = 80;
	public static int points = 0;
    public int record;
    public AudioSource sta;
    // Start is called before the first frame update
    void Start()
    {
    	sum = Random.Range(3,17);
    	sta.Play();
        //PlayerPrefs.SetInt("ItTakesTwoRecord", GameController.points);
    }

    // Update is called once per frame
    void Update()
    {

        recordText.text= "RECORD" + "\n" + record.ToString();
        record=PlayerPrefs.GetInt("ItTakesTwoRecord");
        firstNum.text = maMove.num.ToString ();
        secondNum.text = shMove.num.ToString ();
        result.text = sum.ToString ();
        if(maMove.num+shMove.num==sum){
        	
        	counter--;
        	if(counter<0){
        	swap.Play();
        	sum = random(3,17,sum);
        	counter=80;
        	start=true;
        	points++;

        }
        }
    }

    public int random(int min,int max,int previous){
    	int a=Random.Range(min,max);
    	if(a==previous){
    		a=random(min,max,previous);
    	}
    	return a;

    }
}
