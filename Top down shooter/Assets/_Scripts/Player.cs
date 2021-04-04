using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [Range(1, 10)]
    public float velocidade;

    public int vida = 3;

    private void Start()
    {
     
    }

    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        transform.position += new Vector3(inputX, inputY, 0) * Time.deltaTime * velocidade;
    }
}
