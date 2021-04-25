﻿using System.Collections;
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
    int reloadingValue;
    Rigidbody2D rb;
    GameObject tiro;
    GameObject tiro2;

    void Start()
    {
        animator = GetComponent<Animator>();
        gm = GameManager.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.gameState != GameManager.GameState.GAME) return;

        reloadingValue = animator.GetInteger("Reloading");

        if (gm.shotgun == 1)
        {
            if (gm.shotgunBullets <= 0)
            { 
                gm.shotgun = 0;
            }

            if (Input.GetButtonDown("Fire1"))
            {
                gm.shotgunBullets -= 1;
                ShootShot();
            }
        }

        if (counter > 1 && reloadingValue == 1 && gm.shotgun == 0)
        {
            animator.SetInteger("Reloading", 0);
        }

        counter += Time.deltaTime;

        if (Input.GetButtonDown("Fire1") && Bullets > 0 && animator.GetInteger("Reloading") != 1 && gm.shotgun == 0){
            animator.SetInteger("Reloading", 0);
            Bullets -= 1;
            Shoot();

        }
        if (counter > 1 && Bullets == 0 && gm.shotgun == 0)
        {
            animator.SetInteger("Reloading", 1);
            Bullets = 5;
            counter = 0;
        }
            
    }
    
    void Shoot(){
        tiro = Instantiate(tiroPrefab , arma.position,arma.rotation);
        rb= tiro.GetComponent<Rigidbody2D>();
        rb.AddForce(-arma.up * bulletForce, ForceMode2D.Impulse);
        AudioManager.PlaySFX(shootSFX);
    }

    void ShootShot()
    {
        Debug.Log("Entrei");

        tiro = Instantiate(tiroPrefab, arma.position, arma.rotation);
        rb = tiro.GetComponent<Rigidbody2D>();
        rb.AddForce(-arma.up * bulletForce * 2, ForceMode2D.Impulse);

        AudioManager.PlaySFX(shootSFX);
    }

}


