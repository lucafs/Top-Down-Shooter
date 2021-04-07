using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoPlayer : MonoBehaviour
{
    public float velocidade = 5f;
    public Rigidbody2D rb;
    public int vida = 3;
    Vector2 movimento;
    Vector2 mousePos;
    Vector2 lookDir;
    GameManager gm;

    // Update is called once per frame
    void Start(){
        gm = GameManager.GetInstance();
    }
    void Update()
    {
        Debug.Log(gm.gameState);
        //Pause Game
        if(Input.GetKeyDown(KeyCode.Escape)) {
            if(gm.gameState == GameManager.GameState.GAME){
                gm.ChangeState(GameManager.GameState.PAUSE);
            }
            else if(gm.gameState == GameManager.GameState.PAUSE){
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
        float angle = Mathf.Atan2(lookDir.y,lookDir.x)* Mathf.Rad2Deg ;
        rb.rotation = angle;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (vida == 0)
            {
                //Destroy(gameObject);
                ;
            }
            Debug.Log(vida);

            vida -= 1;

        }
    }
}
