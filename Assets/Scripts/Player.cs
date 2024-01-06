using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;

    float move;
    bool jump;
    bool isIdle = true; // 增加一个布尔变量来跟踪人物是否处于静止状态

    public bool isControled = true;
    public float speed = 5f;
    public float rotationSpeed = 200f;
    public GameContrller gameContrller;
    public GameObject walk;
    private bool isDisappear;

    private Animator animator;
    private void Awake()
    {
        if(gameContrller == null)
        {
            gameContrller = GameObject.Find("Player").GetComponent<GameContrller>();
        }
        animator = transform.GetComponentInChildren<Animator>();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(!isControled)
        {
            return;
        }
        move = Input.GetAxis("Horizontal");
        jump = Input.GetButton("Jump");

        if (isIdle && Mathf.Abs(move) > 0.1f) // 当人物处于静止状态且按下键盘时
        {

            isIdle = false; // 将静止状态设为 false
            if (!isDisappear)
                StartCoroutine(disappear());
        }
        if (Input.GetKeyDown(KeyCode.E) && isIdle)
        {
            animator.Play("拿起");
            isIdle = !isIdle;
        }
        if (isIdle) return;
        if (Mathf.Abs(move) < 0.1f)
        {
            isIdle = true;
            animator.Play("呼吸");
        }

        

        if (!isIdle) // 当人物不处于静止状态时
        {
            // 修改人物的转向
            if (move < 0)
            {
                transform.rotation = Quaternion.Euler(0f, 180f, 0f); // 向左转向
            }
            else if (move > 0)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 0f); // 向右转向
            }
            animator.Play("走路"); 

            // 移动人物
            Vector2 movement = new Vector2(move * speed, rb.velocity.y);
            rb.velocity = movement;
        }
    }
    IEnumerator disappear()
    {
        yield return new WaitForSeconds(0.5f);
        walk.gameObject.SetActive(false);
        isDisappear = true;
    }
}