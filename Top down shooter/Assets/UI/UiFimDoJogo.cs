using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiFimDoJogo : MonoBehaviour
{
    public Text message;
    public GameObject player;
    Vector2 whereToSpawn;

    GameManager gm;

    public void Voltar()
    {
        gm.vidas = 3;
        gm.pontos = 0;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("inimigos");
        foreach(GameObject enemy in enemies)
        GameObject.Destroy(enemy);


        whereToSpawn = new Vector2(-18.49f , -4.41f);
        Instantiate(player,whereToSpawn,Quaternion.identity);
        gm.ChangeState(GameManager.GameState.GAME);
    }   
   private void OnEnable()
   {
       gm = GameManager.GetInstance();
       message.text = "Your score was: " + gm.pontos;
   }
}