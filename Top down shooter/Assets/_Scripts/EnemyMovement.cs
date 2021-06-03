using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    Transform target;
    NavMeshAgent agent;
    GameManager gm;

    // Start is called before the first frame update
    void Start()	
    {
        gm = GameManager.GetInstance();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		agent = GetComponent<NavMeshAgent>();
		agent.updateRotation = false;
		agent.updateUpAxis = false;
	}

    // Update is called once per frame
    void Update()
    {
        if (gm.gameState != GameManager.GameState.GAME) return;
        agent.SetDestination(target.position);
    }
}
