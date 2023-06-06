using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public CircleCollider2D col;
    [SerializeField] private GameObject sec3Prefab;
    public Animator anim;
    public Animator basket;
    public Animator chain;
    public Animator chainS;
    public Animator mouse; 
    public AudioSource inBasketballHoop;
    public AudioSource inBasketballRim;
    public AudioSource ballBounce;
    public AudioSource gameOverSound;
    public AudioSource crowed;
    public AudioSource chainSound;
    public Text text;
    public Text text2;
    public Text text3;
    public GameObject gameOver;
    public static int count = 0;
    public float timeRemaining = 30f;
    public TextMeshProUGUI sectext;
    public int countCombo = 0;
    public static bool isdesactivated = false;
    int ballCount = 0;
    public Button btnBack;
    public static bool isGame = true;
    public static bool isPlay = true;
    public static bool isGameOver = false;
    public static bool isGround = false;
    bool stopanim = false;
    public GameObject mouseOb;
    bool basketNotClean = true;
    public GameObject cleanShotPanel;
    public GameObject epicStreakPanel;
    bool cleanShot = false;
    bool epicStreak = false;

    [HideInInspector] public Vector3 pos { get { return transform.position; } }
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CircleCollider2D>();
    }

    private void Start()
    {
       //PlayerPrefs.DeleteAll();
        mouseOb.SetActive(false);
        //PlayerPrefs.SetInt("mouseCount",0);
        int mouseCount = PlayerPrefs.GetInt("mouseCount");
        if (mouseCount < 4)
        {
            mouseOb.SetActive(true);
            PlayerPrefs.SetInt("mouseCount", mouseCount+1);

        }
        rb.isKinematic = true;
        ballCount++;
        count = 0;
        Time.timeScale = 1;
    }
    private void Update()
    {
        if (stopanim == true)
        {
            mouse.enabled = false;
            mouseOb.SetActive(false);   
        }
        setText();
        if (timeRemaining > 1)
        {
            timeRemaining -= Time.deltaTime;
            float sec = Mathf.FloorToInt(timeRemaining);
            text2.text = sec.ToString();
            isGame = true;
            isGameOver = false;
        }
        else
        {
            
            isGameOver = true;
            btnBack.gameObject.SetActive(false);
            gameOver.gameObject.SetActive(true);
            text3.text = "Your score:  " + count;
            Destroy(gameObject);
            isGame = false;

        }
        if (timeRemaining < 1 && BasketScoreManager.canPlay)
        {
            gameOverSound.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            ballBounce.Play();
            isGround = true;
            basketNotClean = true;
            if (ballCount != countCombo)
            {
                ballCount = 0;
                countCombo = 0;
            }
            gameObject.transform.position = new Vector3(-13f, -1f, 0f);
            DesActivateRb();
            ballCount++;
        }
        if(collision.gameObject.tag == "Basket")
        {
            basket.Play("basket", -1, 0f);
            inBasketballRim.Play();
            basketNotClean = false;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGround = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "chain")
        {
            Debug.Log("fefdcrc");
            chainSound.Play();
            chainS.Play("chain", -1, 0f);
            
        }

        if (collision.gameObject.tag == "Basket")
        {
            count++;
            basket.Play("chainsanim", -1, 0f);
            inBasketballHoop.Play();

            if (basketNotClean && countCombo >= 2)
            {
                countCombo++;
                sectext.gameObject.SetActive(true);
                sectext.text = "+10sec";
                timeRemaining += 10;
                anim.Play("3sec", -1, 0f);
                epicStreak = true;
                cleanShot = false;
                StartCoroutine(comboAnim());
                crowed.Play();
            }
            else if (basketNotClean)
            {
                countCombo++;
                sectext.gameObject.SetActive(true);
                sectext.text = "+6sec";
                timeRemaining += 6;
                anim.Play("3sec", -1, 0f);
                cleanShot = true;
                epicStreak = false;
                StartCoroutine(comboAnim());
                crowed.Play();
            }
            else
            {
                sectext.gameObject.SetActive(true);
                anim.Play("3sec",-1,0f);
                sectext.text = "+3sec";
                timeRemaining += 3;
                epicStreak = false;
                cleanShot = false;
            }
            
            setText();
        }
       
    }

    IEnumerator comboAnim()
    {
        if (cleanShot)
        {
            cleanShotPanel.SetActive(true);
            yield return new WaitForSeconds(1f);
            cleanShotPanel.SetActive(false);

        }
        if (epicStreak)
        {
            epicStreakPanel.SetActive(true);
            yield return new WaitForSeconds(1f);
            epicStreakPanel.SetActive(false);

        }

    }
    public void setText()
    {
        text.text = "SCORE:" + count.ToString();

    }
    public void push(Vector2 force)
    {
        rb.AddForce(force, ForceMode2D.Impulse);
        stopanim = true;
    }

    public void ActivateRb()
    {
        isPlay = false;
        rb.isKinematic = false;
    }
    public void DesActivateRb()
    {
        isPlay = true;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0f;
        rb.isKinematic = true;
    }



}