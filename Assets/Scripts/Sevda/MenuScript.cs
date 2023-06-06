using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public GameObject recTab;
    public GameObject buttons;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void clickRec()
    {
        recTab.SetActive(true);
        buttons.SetActive(false);
    }

    public void clickCloseRec()
    {
        recTab.SetActive(false);
        buttons.SetActive(true);
    }
}
