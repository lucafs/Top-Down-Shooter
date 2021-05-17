using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bloodDeSpawn : MonoBehaviour
{
    float destroyTime = 30f;


    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, destroyTime);

    }
}
