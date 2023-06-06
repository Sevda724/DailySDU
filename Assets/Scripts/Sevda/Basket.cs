using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    int max;
    // Start is called before the first frame update
    void Start()
    {
        max = Ball.count;
    }

    // Update is called once per frame
    void Update()
    {
        if(Ball.count > max && Ball.isGround)
        {
            max = Ball.count;
            gameObject.transform.position = new Vector3(Random.Range(-7,1), Random.Range(0,5), 0f);
        }
    }
}
