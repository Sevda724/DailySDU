using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_food : MonoBehaviour
{
    private float speed = 0.01f;

    Player_script player_script;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player_game = GameObject.Find("Player");
        player_script = player_game.GetComponent<Player_script>();
    }

    // Update is called once per frame
    void Update()
    {

        if (player_script.game_play)
        {
            transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x, transform.position.y), speed);
            Debug.Log("Moving Things");
        }

    }
}
