using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    public trajectory trajectory;
    Camera cam;
    public Ball ball;
    public GameObject forNewBall;
    [SerializeField] float pushForce = 4f;
    bool isDragging = false;
    Vector2 startPoint;
    Vector2 endPoint;
    Vector2 direction;
    Vector2 force;
    float distance;
    void Start()
    {
        cam = Camera.main;
        ball.DesActivateRb();
    }

    #region singleton class: LevelManager
    public static LevelManager Instance;
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else { Destroy(gameObject); }
    }
    #endregion
    // Update is called once per frame
    void Update()
    {
        if (Ball.isGame == true && Ball.isPlay)
        {
            Vector2 pos = cam.ScreenToWorldPoint(Input.mousePosition);
            if (Input.GetMouseButtonDown(0))
            {
                isDragging = true;
                OnDragStart();
            }

            if (Input.GetMouseButtonUp(0))
            {
                isDragging = false;
                OnDragEnd();
            }

            if (isDragging)
            {
                OnDrag();
            }
        }
    }
    #region Drag

   
    public void OnDragStart()
    {
        ball.DesActivateRb();
        startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        trajectory.Show();

    }

    public void OnDrag()
    {
        endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        distance = Vector2.Distance(startPoint, endPoint);
        direction = (startPoint - endPoint).normalized;
        force = direction * pushForce;
        Debug.DrawLine(startPoint, endPoint);
        trajectory.UpdateDots(ball.pos, force);
    }
    
    public void OnDragEnd()
    {
        ball.ActivateRb();
        ball.push(force);
        trajectory.Hide();
       //ball.transform.position = new Vector3(-5f, 0.14f, 0f);
    }
    #endregion
}
