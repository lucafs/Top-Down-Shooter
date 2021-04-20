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
            Debug.Log(Vector2.Distance(transform.position, alvo.position));
            animator.SetInteger("Atking", 0);
            rb.MovePosition(transform.position - transform.up * velocidade * Time.deltaTime);
            RotateTowards(alvo.position);
        }
        if(Vector2.Distance(transform.position, alvo.position) < 9)
        {
            animator.SetInteger("Atking", 1);
            Debug.Log(animator.GetInteger("Atking"));
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
        if (collision.gameObject.tag == "Bullet")
        {
            vidaBoss -= 1;
            if (vidaBoss <= 0)
            {
                gm.pontos += 5;
                Destroy(gameObject);

                BloodInstance = Instantiate(bloodObject, transform.position, Quaternion.identity);
            }
        }
    }

}
