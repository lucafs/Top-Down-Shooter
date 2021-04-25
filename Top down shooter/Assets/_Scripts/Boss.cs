using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    GameManager gm;

    public float velocidade;
    public Rigidbody2D rb;
    private Transform alvo;
    public Vector2 positionZ;
    public GameObject bloodObject;
    private GameObject BloodInstance;
    Animator animator;
    Vector2 direction;
    public float angle;
    private int vidaBoss = 6;

    public GameObject shotgun;
    Vector2 posicaoDeSpawn;

    // Start is called before the first frame update
    void Start()
    {
        alvo = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        gm = GameManager.GetInstance();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (gm.gameState != GameManager.GameState.GAME) return;

        if (Vector2.Distance(transform.position, alvo.position) > 9)
        {
            animator.SetInteger("Atking", 0);
            rb.MovePosition(transform.position - transform.up * velocidade * Time.deltaTime);
            RotateTowards(alvo.position);
        }
        if(Vector2.Distance(transform.position, alvo.position) < 9)
        {
            animator.SetInteger("Atking", 1);
            rb.MovePosition(transform.position - transform.up * velocidade * Time.deltaTime);
            RotateTowards(alvo.position);
        }
    }

    private void RotateTowards(Vector2 alvo)
    {
        if (gm.gameState != GameManager.GameState.GAME) return;

        var offset = 90f;
        direction = alvo - (Vector2)transform.position;
        direction.Normalize();
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset + 360));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet" && gm.shotgun == 0)
        {
            vidaBoss -= 1;
            if (vidaBoss <= 0)
            {
                float spawnYindex = Random.Range(new Vector2(0, -45).y, new Vector2(0, 2).y);
                float spawnXindex = Random.Range(new Vector2(-90, 0).x, new Vector2(15, 0).x);

                posicaoDeSpawn = new Vector2(spawnXindex + 10f, spawnYindex + 10f);

                GameObject shotgunInstance = Instantiate(shotgun, posicaoDeSpawn, Quaternion.identity);
                
                gm.pontos += 5;
                Destroy(gameObject);

                Instantiate(bloodObject, transform.position, Quaternion.identity);
            }
        }
        else if (collision.gameObject.tag == "Bullet" && gm.shotgun == 1)
        {
            vidaBoss -= 2;
            if (vidaBoss <= 0)
            {
                float spawnYindex = Random.Range(new Vector2(0, -70).y, new Vector2(0, -30).y);
                float spawnXindex = Random.Range(new Vector2(-150, 0).x, new Vector2(-60, 0).x);

                posicaoDeSpawn = new Vector2(spawnXindex + 10f, spawnYindex + 10f);

                GameObject shotgunInstance = Instantiate(shotgun, posicaoDeSpawn, Quaternion.identity);

                gm.pontos += 5;
                Destroy(gameObject);

                Instantiate(bloodObject, transform.position, Quaternion.identity);
            }
        }
    }

}
