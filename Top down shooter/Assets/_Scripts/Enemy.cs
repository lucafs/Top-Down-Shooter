using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float velocidade;

    private Transform alvo;
    // Start is called before the first frame update
    void Start()
    {
        alvo = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, alvo.position) > 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, alvo.position, velocidade * Time.deltaTime);
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
}
