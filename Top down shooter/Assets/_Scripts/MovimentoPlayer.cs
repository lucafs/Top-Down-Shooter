using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoPlayer : MonoBehaviour
{
    GameManager gm;

    public float velocidade = 7f;
    public Rigidbody2D rb;
    public int vida = 3;
    Vector2 movimento;
    Vector2 mousePos;
    Vector2 lookDir;
    public float angle;
    public Vector2 spawn;

    Animator animator;
    // public Camera cam; 
    void Start()
    {
        animator = GetComponent<Animator>();
        gm = GameManager.GetInstance();
        gm.spawn = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(gm.gameState);
        //Pause Game
        if(gm.reset == 2){
            rb.MovePosition(spawn);
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);  
            lookDir = mousePos - rb.position;
            angle = Mathf.Atan2(lookDir.y,lookDir.x)* Mathf.Rad2Deg ;
            rb.rotation = angle;
            gm.reset = 0;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gm.gameState == GameManager.GameState.GAME)
            {
                gm.ChangeState(GameManager.GameState.PAUSE);
            }
            else if (gm.gameState == GameManager.GameState.PAUSE)
            {
                gm.ChangeState(GameManager.GameState.GAME);
            }
        }

        if (gm.gameState != GameManager.GameState.GAME) return;

        movimento.x = Input.GetAxisRaw("Horizontal");
        movimento.y = Input.GetAxisRaw("Vertical");
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    
    void FixedUpdate(){
        if (gm.gameState != GameManager.GameState.GAME) return;
        rb.MovePosition(rb.position + movimento * velocidade * Time.fixedDeltaTime);
        lookDir = mousePos - rb.position;
        angle = Mathf.Atan2(lookDir.y,lookDir.x)* Mathf.Rad2Deg ;
        rb.rotation = angle;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (gm.vidas <= 0)
            {
                gm.ChangeState(GameManager.GameState.ENDGAME);
            }

            gm.vidas -= 1;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
   {
        if (collision.gameObject.tag == "Heart")
        {
            Debug.Log("SAbsudaibfuaibfiasbiudasbiufb");
            Destroy(collision.gameObject);
            gm.vidas += 1;
        }
   }
}
