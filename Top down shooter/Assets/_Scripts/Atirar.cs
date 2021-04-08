using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atirar : MonoBehaviour
{
    GameManager gm;
    public AudioClip shootSFX;
    public Transform arma;
    public GameObject tiroPrefab;

    public float bulletForce = 20f;
    public int Bullets = 5;

    private float counter;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        gm = GameManager.GetInstance();

    }

    // Update is called once per frame
    void Update()
    {
        if (gm.gameState != GameManager.GameState.GAME) return;

        int reloadingValue = animator.GetInteger("Reloading");

        if(counter > 1 && reloadingValue == 1)
        {
            animator.SetInteger("Reloading", 0);
        }

        counter += Time.deltaTime;

        if (Input.GetButtonDown("Fire1") && Bullets > 0 && animator.GetInteger("Reloading") != 1){
            animator.SetInteger("Reloading", 0);
            Bullets -= 1;
            Shoot();

        }
        if (counter > 1 && Bullets == 0)
        {
            animator.SetInteger("Reloading", 1);
            Bullets = 5;
            counter = 0;
        }
            
    }
    
    void Shoot(){
        GameObject tiro = Instantiate(tiroPrefab , arma.position,arma.rotation);
        Rigidbody2D rb= tiro.GetComponent<Rigidbody2D>();
        rb.AddForce(-arma.up * bulletForce, ForceMode2D.Impulse);
<<<<<<< HEAD
        AudioManager.PlaySFX(shootSFX);
        
=======

        StartCoroutine(waiter());
    }
    
    IEnumerator waiter()
    {
        // Debug.Log(Time.time);
        yield return new WaitForSeconds(1f);
        // Debug.Log(Time.time);
>>>>>>> 9695f351b295b4309c0d6af37d9104d949e97540
    }

}


