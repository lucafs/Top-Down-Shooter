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
    public int Granades = 3;

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

        if (Input.GetButtonDown("Fire2") && Granades > 0){
            Granades -= 1;
            throwG();

        }
        if (counter > 1 && Granades == 0)
        {
            animator.SetInteger("Reloading", 1);
            Granades = 5;
            counter = 0;
        }
            
    }
    
    void throwG(){
        tiro = Instantiate(granadaPrefab , arma.position,arma.rotation);
        rb= tiro.GetComponent<Rigidbody2D>();
        rb.AddForce(-arma.up * throwForce, ForceMode2D.Impulse);
        // AudioManager.PlaySFX(shootSFX);
    }

}


