using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiFimDoJogo : MonoBehaviour
{
    public GameObject player;
    Vector2 whereToSpawn;

    GameManager gm;
    MovimentoPlayer mp;

    public void Voltar()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in enemies) GameObject.Destroy(enemy);
        gm.Reset();
        gm.ChangeState(GameManager.GameState.MENU);
    }   
   private void OnEnable()
   {
        GameObject jogador = GameObject.FindGameObjectWithTag("Player");
        mp = jogador.GetComponent<MovimentoPlayer>();
       gm = GameManager.GetInstance();
    //    message.text = "Your score was: " + gm.pontos;
   }
}