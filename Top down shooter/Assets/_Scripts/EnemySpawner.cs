using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    GameManager gm;
    Vector2 posicaoDeSpawn;
    public GameObject enemy;
    public GameObject Boss;
    public Transform barreiras;
    private int timeStamp;
    private float contadorSegundos = 0;
    private int countBoss = 0;
    float spawnYindex;
    float spawnXindex;
    float minorX = 0f;
    float minorY = 0f;
    float majorX = 0f;
    float majorY = 0f;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in barreiras)
        {
            if (child.position.x < minorX) minorX = child.position.x ;
            if (child.position.x < minorY) minorY = child.position.x;
            if (child.position.x < majorX) majorX = child.position.x;
            if (child.position.x < majorY) majorY = child.position.x;
        }

        GameObject jogador = GameObject.FindGameObjectWithTag("Player");
        MovimentoPlayer playerScript = jogador.GetComponent<MovimentoPlayer>();
        gm = GameManager.GetInstance();
        timeStamp = 25;

        spawnEnemies(15);
    }

    void spawnEnemies(int loopCount)
    {
        GameObject jogador = GameObject.FindGameObjectWithTag("Player");

        float playerXpositionRight = jogador.transform.position.x + 15;
        float playerXpositionLeft = jogador.transform.position.x - 15;
        float playerYpositionUp = jogador.transform.position.y + 15;
        float playerYpositionDown = jogador.transform.position.y - 15;

        for (int i = 0; i < loopCount; i++)
        {

            spawnYindex = Random.Range(new Vector2(0, -45).y, new Vector2(0, 2).y);
            spawnXindex = Random.Range(new Vector2(-90, 0).x, new Vector2(15, 0).x);
            
            while(spawnXindex <= playerXpositionRight && spawnXindex >= playerXpositionLeft || spawnYindex >= playerYpositionDown && spawnYindex <= playerYpositionUp)
            {
                spawnYindex = Random.Range(new Vector2(0, -45).y, new Vector2(0, 2).y);
                spawnXindex = Random.Range(new Vector2(-90, 0).x, new Vector2(15, 0).x);
            }

            while (spawnYindex <= minorY && spawnYindex >= majorY && spawnXindex <= minorX && spawnXindex >= majorX)
            {
                spawnYindex = Random.Range(new Vector2(0, -45).y, new Vector2(0, 2).y);
                spawnXindex = Random.Range(new Vector2(-90, 0).x, new Vector2(15, 0).x);
            }
            posicaoDeSpawn = new Vector2(spawnXindex + 10f, spawnYindex + 10f);
            Instantiate(enemy, posicaoDeSpawn, Quaternion.identity);


        }
    }

    void spawnBoss(int loopCount)
    {
        for (int i = 0; i < loopCount; i++)
        {
            spawnYindex = Random.Range(new Vector2(0, -45).y, new Vector2(0, 2).y);
            spawnXindex = Random.Range(new Vector2(-90, 0).x, new Vector2(15, 0).x);
            while (spawnYindex <= minorY && spawnYindex >= majorY && spawnXindex <= minorX && spawnXindex >= majorX)
            {
                spawnYindex = Random.Range(new Vector2(0, -45).y, new Vector2(0, 2).y);
                spawnXindex = Random.Range(new Vector2(-90, 0).x, new Vector2(15, 0).x);
            }
            posicaoDeSpawn = new Vector2(spawnXindex + 10f, spawnYindex + 10f);
            Instantiate(Boss, posicaoDeSpawn, Quaternion.identity);
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (gm.gameState != GameManager.GameState.GAME) return;
        if (gm.reset == 1 )
        {
            spawnEnemies(15);
            timeStamp = 25;
            gm.reset++;

        }
        contadorSegundos += Time.deltaTime;

        if (contadorSegundos >= 1)
        {
            new WaitForSeconds(1);
            timeStamp -= 1;

            if (timeStamp == 0 && gm.difCount == 0)
            {
                gm.difCount = 1;
                timeStamp = 20;
                gm.hordes += 1;
                spawnEnemies(10);
            }
            if (timeStamp == 0 && gm.difCount == 1)
            {
                gm.difCount = 2;
                timeStamp = 15;
                gm.hordes += 1;
                spawnEnemies(15);
            }
            if (timeStamp == 0 && gm.difCount == 2)
            {
                gm.difCount = 0;
                timeStamp = 10;
                gm.hordes += 1;
                countBoss += 1;
                spawnEnemies(20);
                spawnBoss(countBoss);
            }
            contadorSegundos = 0;
        }


    }
}
