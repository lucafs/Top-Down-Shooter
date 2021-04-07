using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float velocidade;
    public Rigidbody2D rb;
    private Transform alvo;
    public Vector2 positionZ;
    public int dead = 0;

    public float counterBlood = 0.0f;
    public GameObject bloodObject;

    // Start is called before the first frame update
    void Start()
    {
        alvo = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, alvo.position) > 0.5)
        {
            rb.MovePosition(transform.position + transform.up * velocidade * Time.deltaTime);
            RotateTowards(alvo.position);
        }
    }

    private void RotateTowards(Vector2 alvo)
    {
        var offset = 90f;
        Vector2 direction = alvo - (Vector2)transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset + 180));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);

            GameObject BloodInstance = Instantiate(bloodObject, transform.position, Quaternion.identity);
            
            
        }
    }
        
}
