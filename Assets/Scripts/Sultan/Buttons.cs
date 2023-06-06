using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    public GameObject record;
    public Text placeholderName;
    public string recordName;
    public GameObject tutorial;
    public int count = 700;

    public void goBack(){
    	shMove.num=0;
    	maMove.num=0;
    	GameController.points=0;
    	GameController.start=false;
    	SceneManager.LoadScene("Games");
    }

    public void reLoad(){
    	shMove.num=0;
    	maMove.num=0;
    	GameController.points=0;
    	GameController.start=false;

    	Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }
    public void recordIs(){
        record.SetActive(false);
        recordName = placeholderName.text;
        PlayerPrefs.SetString("ItTakesRecord", recordName);
        print(recordName);
    }
    public void tutori(){
        tutorial.SetActive(true);
        count=700;
        
    }
    public void Update(){
    	if(count>0){
    		count--;;
    	}else{
    		tutorial.SetActive(false);
    	}

    }

}
