using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


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
    public AudioClip damageSFX;

    public AudioClip dashCooldownSFX;
    public GameObject floatingTextlife;
    public GameObject floatingTextGranade;
    public GameObject messageText;
    private int is_trigger = 0;

 //Dash
    public float dashVelocidade = 100000f;
    bool isDashing;
    float lastDashTime;
    float dashDelay = 1.2f;

    Animator animator;
    // public Camera cam; 
    void Start()
    {
        animator = GetComponent<Animator>();
        gm = GameManager.GetInstance();
        gm.spawn = transform.position;
        lastDashTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.G))
        {
            is_trigger = 1;
        }

        if(gm.reset == 2){
            rb.MovePosition(spawn);
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);  
            lookDir = mousePos - rb.position;
            angle = Mathf.Atan2(lookDir.y,lookDir.x)* Mathf.Rad2Deg ;
            rb.rotation = angle;
            gm.reset = 0;
        }

        if (gm.gameState != GameManager.GameState.GAME) return;

        movimento.x = Input.GetAxisRaw("Horizontal");
        movimento.y = Input.GetAxisRaw("Vertical");
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Dash esquerda
        if(Input.GetKey(KeyCode.A) && Input.GetButtonDown("Jump")){
            StartCoroutine(Dash(-1f,true));
        }
        //Dash direita
        else if(Input.GetKey(KeyCode.D) && Input.GetButtonDown("Jump")){
            StartCoroutine(Dash(1f,true));
        }
        //Dash cima
        else if(Input.GetKey(KeyCode.W) && Input.GetButtonDown("Jump")){
            StartCoroutine(Dash(1f,false));
        }
        //Dash baixo
        else if(Input.GetKey(KeyCode.S) && Input.GetButtonDown("Jump")){
            StartCoroutine(Dash(-1f,false));
        }
    }
    
    void FixedUpdate(){
        if (gm.gameState != GameManager.GameState.GAME) return;
        if(!isDashing){
        rb.MovePosition(rb.position + movimento * velocidade * Time.fixedDeltaTime);
        }
        lookDir = mousePos - rb.position;
        angle = Mathf.Atan2(lookDir.y,lookDir.x)* Mathf.Rad2Deg;
        rb.rotation = angle;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Boss")
        {
            if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("taking_damage"))
            {
                return;
            }
            if (gm.vidas <= 0)
            {
                gm.ChangeState(GameManager.GameState.ENDGAME);
            }

            animator.SetTrigger("Damage");
            AudioManager.PlaySFX(damageSFX);
            gm.vidas -= 1;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
   {
        if (collision.gameObject.tag == "Door")
        {
            Instantiate(messageText, transform.position, Quaternion.identity);

            if(gm.coins >= 500 && is_trigger == 1)
            {
                Debug.Log(gameObject.transform.position);
                gm.position_doors = gameObject.transform.position;
                gm.level_setter += 1;
                Destroy(collision.gameObject);
                gm.coins -= 500;
                is_trigger = 0;
            }
        }
        if (collision.gameObject.tag == "Heart"){
            if(gm.vidas == 4){
                Instantiate(floatingTextlife,transform.position,Quaternion.identity);      
            }
            else{
                Destroy(collision.gameObject);
                gm.vidas += 1;
            }
        }
        if (collision.gameObject.tag == "Granade"){
            if(gm.granades == 5){
                Instantiate(floatingTextGranade,transform.position,Quaternion.identity);      

            }
            else{
                Destroy(collision.gameObject);
                gm.granades += 1;
            }
        }
        if (collision.gameObject.tag == "Shotgun")
        {
            Destroy(collision.gameObject);
            gm.shotgunBullets = 20;
            gm.shotgun = 1;
        }
   }

   IEnumerator Dash(float direction,bool horizontal){
       if(Time.time - lastDashTime > dashDelay ){
            isDashing = true;
            if(horizontal){
                    rb.velocity = new Vector2(dashVelocidade*direction,0f);
                    rb.AddForce(new Vector2(2f*dashVelocidade*direction,0f),ForceMode2D.Impulse);
            }
            else{
                    rb.velocity = new Vector2(0f,dashVelocidade*direction);
                    rb.AddForce(new Vector2(0f,2f*dashVelocidade*direction),ForceMode2D.Impulse);

            }
            yield return new WaitForSeconds(0.2f);
            isDashing = false;
            lastDashTime = Time.time;
       }
       else{
            AudioManager.PlaySFX(dashCooldownSFX);
       }
   }
}
