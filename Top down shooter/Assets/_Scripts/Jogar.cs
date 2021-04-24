using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogar : MonoBehaviour
{
    GameManager gm;
    // public AudioClip shootSFX;
    public Transform arma;
    public GameObject granadaPrefab;

    public float throwForce = 4f;
    private float counter;
    Animator animator;
    int reloadingValue;
    Rigidbody2D rb;
    GameObject tiro;
    void Start()
    {
        animator = GetComponent<Animator>();
        gm = GameManager.GetInstance();

    }

    // Update is called once per frame
    void Update()
    {
        if (gm.gameState != GameManager.GameState.GAME) return;

        counter += Time.deltaTime;

        if (Input.GetButtonDown("Fire2") && gm.granades > 0){
            gm.granades -= 1;
            throwG();
        }
            
    }
    
    void throwG(){
        tiro = Instantiate(granadaPrefab , arma.position,arma.rotation);
        rb= tiro.GetComponent<Rigidbody2D>();
        rb.AddForce(-arma.up * throwForce, ForceMode2D.Impulse);
        // AudioManager.PlaySFX(shootSFX);
    }

}


