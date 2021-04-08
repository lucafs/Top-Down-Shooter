using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    GameManager gm;

    public GameObject enemy;
    public GameObject Boss;
    private int timeStamp;
    private float contadorSegundos = 0;
    private int difCount = 0;
    private int countBoss = 0;
    private int hordes = 0;

    // Start is called before the first frame update
    void Start()
    {
        GameObject jogador = GameObject.FindGameObjectWithTag("Player");
        MovimentoPlayer playerScript = jogador.GetComponent<MovimentoPlayer>();
        gm = GameManager.GetInstance();
        timeStamp = 25;

        spawnEnemies(20);
    }

    void spawnEnemies(int loopCount)
    {
        for(int i = 0; i < loopCount; i++)
        {
            float spawnYindex = Random.Range(new Vector2(0, -45).y, new Vector2(0, 2).y);
            float spawnXindex = Random.Range(new Vector2(-90, 0).x, new Vector2(15, 0).x);

            Vector2 posicaoDeSpawn = new Vector2(spawnXindex + 10f, spawnYindex +10f);
            Instantiate(enemy, posicaoDeSpawn, Quaternion.identity);
        }
    }

    void spawnBoss(int loopCount)
    {
        for (int i =0; i < loopCount; i++)
        {
            float spawnYindex = Random.Range(new Vector2(0, -45).y, new Vector2(0, 2).y);
            float spawnXindex = Random.Range(new Vector2(-90, 0).x, new Vector2(15, 0).x);

            Vector2 posicaoDeSpawn = new Vector2(spawnXindex + 10f, spawnYindex + 10f);
            Instantiate(Boss, posicaoDeSpawn, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.gameState != GameManager.GameState.GAME) return;

        contadorSegundos += Time.deltaTime;

        if (contadorSegundos >= 1)
        {
            new WaitForSeconds(1);
            //Debug.Log(timeStamp);
            timeStamp -= 1;
            
            if (timeStamp == 0 && difCount == 0)
            {
                difCount = 1;
                timeStamp = 20;
                hordes += 1;
                spawnEnemies(10);
            }
            if (timeStamp == 0 && difCount == 1)
            {
                difCount = 2;
                timeStamp = 15;
                hordes += 1;
                spawnEnemies(15);
            }
            if (timeStamp == 0 && difCount == 2)
            {
                difCount = 0;
                timeStamp = 10;
                hordes += 1;
                countBoss += 1;
                spawnEnemies(20);
                spawnBoss(countBoss);
            }
            contadorSegundos = 0;
        }

        
    }
}