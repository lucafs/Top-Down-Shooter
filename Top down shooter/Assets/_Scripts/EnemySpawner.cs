using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemy;
    private int vida;
    private int timeStamp;
    private float contadorSegundos = 0;
    private int difCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        GameObject jogador = GameObject.FindGameObjectWithTag("Player");
        Player playerScript = jogador.GetComponent<Player>();
        vida = playerScript.vida;
        timeStamp = 25;

        spawnEnemies(10);
    }

    void spawnEnemies(int loopCount)
    {
        for(int i = 0; i < loopCount; i++)
        {
            float spawnYindex = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
            float spawnXindex = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);

            Vector2 posicaoDeSpawn = new Vector2(spawnXindex, spawnYindex);
            Instantiate(enemy, posicaoDeSpawn, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        contadorSegundos += Time.deltaTime;

        if (contadorSegundos >= 1)
        {
            new WaitForSeconds(1);
            Debug.Log(timeStamp);
            timeStamp -= 1;
            
            if (timeStamp == 0 && difCount == 0)
            {
                difCount = 1;
                timeStamp = 20;
                spawnEnemies(10);
            }
            if (timeStamp == 0 && difCount == 1)
            {
                difCount = 2;
                timeStamp = 15;
                spawnEnemies(15);
            }
            if (timeStamp == 0 && difCount == 2)
            {
                timeStamp = 10;
                spawnEnemies(20);
            }

            contadorSegundos = 0;
        }

        
    }
}