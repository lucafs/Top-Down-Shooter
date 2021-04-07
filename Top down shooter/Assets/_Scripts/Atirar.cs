using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atirar : MonoBehaviour
{
    public Transform arma;
    public GameObject tiroPrefab;

    public float bulletForce = 20f;
    public int Bullets = 5;

    private float counter;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;

        if(Input.GetButtonDown("Fire1")){
            if (Bullets <= 0)
            {
                animator.SetInteger("Reloading", 1);

                if (counter > 1)
                {
                    Bullets = 5;
                }
    
            }
            else
            {
                animator.SetInteger("Reloading", 0);
                Bullets -= 1;
                Shoot();
            }
            
        }
        
    }
    void Shoot(){
        GameObject tiro = Instantiate(tiroPrefab , arma.position,arma.rotation);
        Rigidbody2D rb= tiro.GetComponent<Rigidbody2D>();
        rb.AddForce(-arma.up * bulletForce, ForceMode2D.Impulse);


    }
}
