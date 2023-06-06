using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class Player_script : MonoBehaviour
{
    int kcal = 0;
    public TextMeshProUGUI kcalText;
    SpriteRenderer sprite;
    int food_ind;
    public bool game_play = false;
    Generate_food generate_food_script;
    public GameObject boy;
    public new ParticleSystem light;
    int i = 0;

    public GameObject menu;
    public Timer_script timer_script;

    public bool isBomb = false;
    public bool isSec = false;

    public AudioSource[] sounds;
    public Image bomb_img;
    public Image sec_img;
    [SerializeField] public TextMeshProUGUI highKcalText;

    // [SerializeField] public int current_highscore = 0;
    int record_highscore;
    bool isHigh = false;
    public TMP_InputField input;

    public GameObject mouse;


    // Start is called before the first frame update
    public void Start()
    {
        PlayerPrefs.GetInt("CatcherScore");
        sprite = GetComponent<SpriteRenderer>();
        sprite.enabled = true;
        GameObject generate_food = GameObject.Find("generate_food");
        generate_food_script = generate_food.GetComponent<Generate_food>();
        GameObject timer_value = GameObject.Find("Timer");
        timer_script = timer_value.GetComponent<Timer_script>();
        //sounds = GetComponents<AudioSource>();
        boy.SetActive(false);
        kcalText.enabled = false;
        StartCoroutine(Wait());
        bomb_img.enabled = false;
        sec_img.enabled = false;
        

    }


    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        menu.SetActive(false);
        yield return new WaitForSeconds(1);
        kcal = 0;
        game_play = true;
        timer_script.game_run_timer = true;
        kcalText.enabled = true;
        StartCoroutine(MouseMoving());
    }

    IEnumerator MouseMoving()
    {
        mouse.transform.LeanMoveLocal(new Vector2(7, -4), 1).setEaseOutQuart();
        yield return new WaitForSeconds(1);
        mouse.transform.LeanMoveLocal(new Vector2(3, -4), 1).setEaseOutQuart();
        yield return new WaitForSeconds(1);
        mouse.transform.LeanMoveLocal(new Vector2(7, -4), 1).setEaseOutQuart();
        yield return new WaitForSeconds(1);
        mouse.transform.LeanMoveLocal(new Vector2(3, -4), 1).setEaseOutQuart();
        Destroy(mouse, 2);
    }
    IEnumerator Bomb_time()
    {
        bomb_img.enabled = true;
        bomb_img.transform.LeanMoveLocal(new Vector2(transform.position.x, 160), 1).setEaseOutQuart();
        yield return new WaitForSeconds(1);
        bomb_img.enabled = false;
        bomb_img.transform.LeanMoveLocal(new Vector2(transform.position.x, 12), 1).setEaseOutQuart();
    }

    IEnumerator Sec_time()
    {
        sec_img.enabled = true;
        sec_img.transform.LeanMoveLocal(new Vector2(transform.position.x, 160), 1).setEaseOutQuart();
        yield return new WaitForSeconds(1);
        sec_img.enabled = false;
        sec_img.transform.LeanMoveLocal(new Vector2(transform.position.x, 12), 1).setEaseOutQuart();
    }

    // Update is called once per frame
    void Update()
    {
        record_highscore = kcal;
        if (record_highscore > PlayerPrefs.GetInt("CatcherScore"))
        {
            isHigh = true;
            PlayerPrefs.SetInt("CatcherScore", record_highscore);
        }

        highKcalText.text = "High: " + PlayerPrefs.GetInt("CatcherScore").ToString();

        //Debug.Log(game_play);
        Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(mouse.x, transform.position.y);
        if (transform.position.x < 0)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }

        if (kcal > 450)
        {
            i++;
            if (i == 1)
            {
                light.Play();
                i++;
            }
            sprite.enabled = false;
            boy.SetActive(true);
        }

        game_play = timer_script.game_run_timer;
        if (!game_play && isHigh)
        {
            sprite.enabled = true;
            boy.SetActive(false);
            input.gameObject.SetActive(true);
            PlayerPrefs.SetString("CatcherName", input.text);
            Debug.Log(input.text);
            kcalText.text = "Game over. ";
        }
        else
        {
            kcalText.text = "Score: " + kcal.ToString();
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        food_ind = 0;

        if (collision.gameObject.tag == "sec")
        {
            isSec = true;
            sounds[0].Play();
            StartCoroutine(Sec_time());
            timer_script.isSec = isSec;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "bomb")
        {
            isBomb = true;
            sounds[1].Play();
            StartCoroutine(Bomb_time());
            timer_script.isBomb = isBomb;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "food")
        {
            sounds[2].Play();
            food_ind = generate_food_script.food_index;
            switch (food_ind)
            {
                case 0:
                    kcal += 110;
                    break;
                case 1:
                    kcal += 150;
                    break;
                case 2:
                    kcal += 150;
                    break;
                case 3:
                    kcal += 100;
                    break;
                case 4:
                    kcal += 10;
                    break;
                case 5:
                    kcal += 120;
                    break;
                case 6:
                    kcal += 130;
                    break;
                case 7:
                    kcal += 100;
                    break;


            }
            Destroy(collision.gameObject);


        }
    }
}
