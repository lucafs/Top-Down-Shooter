using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameManager gm;

    // public float velocidade;
    public Rigidbody2D rb;
    private Transform alvo;
    public Vector2 positionZ;
    public int dead = 0;
    public int random;
    public float counterBlood = 0.0f;
    public GameObject bloodObject;
    public GameObject heart;
    public GameObject granade;
    public GameObject boost;


    // Start is called before the first frame update
    void Start()
    {
        alvo = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        gm = GameManager.GetInstance();

    }

    // Update is called once per frame
    void Update()
    {
        if (gm.gameState != GameManager.GameState.GAME) return;

        if (Vector2.Distance(transform.position, alvo.position) > 0.5)
        {
            // rb.MovePosition(transform.position + transform.up * velocidade * Time.deltaTime);
            RotateTowards(alvo.position);
        }
    }

    private void RotateTowards(Vector2 alvo)
    {
        if (gm.gameState != GameManager.GameState.GAME) return;

        var offset = 90f;
        Vector2 direction = alvo - (Vector2)transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset + 180));
    }
    public void Morrer(){
        random = Random.Range(0,100);

        if(random < 10){
            GameObject Heart = Instantiate(heart, transform.position,Quaternion.identity);
        }
        if(random > 95){
            GameObject Granade = Instantiate(granade, transform.position,Quaternion.identity);
        }
        gm.pontos += 1;
        Destroy(gameObject);
        GameObject BloodInstance = Instantiate(bloodObject, transform.position, Quaternion.identity);

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            random = Random.Range(0,100);
            if(random < 16){
                if(random < 6){
                    GameObject Heart = Instantiate(heart, transform.position,Quaternion.identity);
                }
                else if(random < 9){
                    GameObject Boost = Instantiate(boost, transform.position,Quaternion.identity);
                }
                else{
                    GameObject Granade = Instantiate(granade, transform.position,Quaternion.identity);
                }
            }
            gm.coins +=10;
            gm.pontos += 1;
            
            Destroy(gameObject);
            GameObject BloodInstance = Instantiate(bloodObject, transform.position, Quaternion.identity);
            
            
        }
    }
        
}
