using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granade_Pickup : MonoBehaviour
{
    float destroyTime = 10f;
    GameManager gm;
    void Start()
    {
        gm = GameManager.GetInstance();

    }
    void Update(){
    if (gm.gameState != GameManager.GameState.GAME && gm.gameState != GameManager.GameState.PAUSE ) Destroy(gameObject);
    Destroy(gameObject, destroyTime);

    }
}
