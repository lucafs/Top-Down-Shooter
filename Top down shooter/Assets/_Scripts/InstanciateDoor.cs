using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciateDoor : MonoBehaviour
{
    GameManager gm;
    private int countFilhos;
    private Transform[] spawnpoints;
    public GameObject portas;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GetInstance();
    }

    void Update()
    {
        if (gm.reset == 1)
        {
            countFilhos = transform.childCount;

            spawnpoints = new Transform[countFilhos];

            for (int i = 0; i < countFilhos; i++)
            {
                spawnpoints[i] = transform.GetChild(i);
            }

            for (int i = 0; i < countFilhos; i++)
            {
                Instantiate(portas, spawnpoints[i].position, Quaternion.identity);
            }

            gm.reset = 0;
        }
    }
}
