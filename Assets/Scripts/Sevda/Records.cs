using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Records : MonoBehaviour
{
    public Text recItTakesMore;
    public Text recBasketball;
    public Text recCatcher;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {

        recItTakesMore.text = PlayerPrefs.GetInt("ItTakesTwoRecord") + "     -     " + PlayerPrefs.GetString("ItTakesRecord");
        recBasketball.text = PlayerPrefs.GetInt("BasketScore") + "     -     " + PlayerPrefs.GetString("BasketName");
        recCatcher.text = PlayerPrefs.GetInt("CatcherScore") + "     -     " + PlayerPrefs.GetString("CatcherName");
    }
}
