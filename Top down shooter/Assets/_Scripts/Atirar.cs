using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atirar : MonoBehaviour
{
    public Transform arma;
    public GameObject tiroPrefab;

    public float bulletForce = 20f;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            Shoot();
        }
        
    }
    void Shoot(){
        GameObject tiro = Instantiate(tiroPrefab , arma.position,arma.rotation);
        Rigidbody2D rb= tiro.GetComponent<Rigidbody2D>();
        rb.AddForce(-arma.up * bulletForce, ForceMode2D.Impulse);


    }
}
