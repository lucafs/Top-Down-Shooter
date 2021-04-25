using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunPickUp : MonoBehaviour
{
    GameManager gm;

    public GameObject shotgunObj;
    public int setShotgun = 0;

    void Start()
    {
        gm = GameManager.GetInstance();

    }
    void Update()
    {
        if (gm.gameState != GameManager.GameState.GAME && gm.gameState != GameManager.GameState.PAUSE) Destroy(gameObject);
    }
}
