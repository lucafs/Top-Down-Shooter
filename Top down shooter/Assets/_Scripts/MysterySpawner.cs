using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysterySpawner : MonoBehaviour
{

    GameManager gm;
    private int countFilhos;
    private Transform[] spawnpoints;
    private int spawnIndexRandom;
    public GameObject box;

    // Start is called before the first frame update
    void Start()
    {
        countFilhos = transform.childCount;

        spawnpoints = new Transform[countFilhos];

        for (int i = 0; i < countFilhos; i++)
        {
            spawnpoints[i] = transform.GetChild(i);
        }

        gm = GameManager.GetInstance();

        spawnIndexRandom = Random.Range(0, countFilhos);
        Debug.Log(spawnpoints[spawnIndexRandom].position);
        Instantiate(box, spawnpoints[spawnIndexRandom].position, Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
