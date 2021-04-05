using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoPlayer : MonoBehaviour
{
    public float velocidade = 5f;
    public Rigidbody2D rb;
    Vector2 movimento;
    Vector2 mousePos;
    Vector2 lookDir;
    // public Camera cam; 

    // Update is called once per frame
    void Update()
    {
        movimento.x = Input.GetAxisRaw("Horizontal");
        movimento.y = Input.GetAxisRaw("Vertical");
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        
    }
    void FixedUpdate(){
        rb.MovePosition(rb.position + movimento * velocidade * Time.fixedDeltaTime);
        lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y,lookDir.x)* Mathf.Rad2Deg ;
        rb.rotation = angle;
    }
}
