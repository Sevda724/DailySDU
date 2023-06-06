using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maMove : MonoBehaviour
{
	public static int num = 0;
	private Rigidbody2D rb;
	public AudioSource swap;
    // Start is called before the first frame update
    void Start()
    {
    	rb=GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity=Vector2.zero;
        if(Input.GetKey(KeyCode.W)){
        	rb.MovePosition(rb.position + new Vector2(0f,15f)*Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.A)){
        	rb.MovePosition(rb.position + new Vector2(-15f,0f)*Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.S)){
        	rb.MovePosition(rb.position + new Vector2(0f,-15f)*Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.D)){
        	rb.MovePosition(rb.position + new Vector2(15f,0f)*Time.deltaTime);
        }
    }


    void OnTriggerEnter2D(Collider2D col)
    {
    	swap.Play();
        if(col.tag=="one"&&shMove.num!=1){
        	num = 1;
        }
        if(col.tag=="two"&&shMove.num!=2){
        	num = 2;
        }
        if(col.tag=="three"&&shMove.num!=3){
        	num = 3;
        }
        if(col.tag=="four"&&shMove.num!=4){
        	num = 4;
        }
        if(col.tag=="five"&&shMove.num!=5){
        	num = 5;
        }
        if(col.tag=="six"&&shMove.num!=6){
        	num = 6;
        }
        if(col.tag=="seven"&&shMove.num!=7){
        	num = 7;
        }
        if(col.tag=="eight"&&shMove.num!=8){
        	num = 8;
        }
        if(col.tag=="nine"&&shMove.num!=9){
        	num = 9;
        }
    }

}
