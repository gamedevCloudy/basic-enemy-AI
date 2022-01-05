using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

public class enemyAI : MonoBehaviour
{
    [SerializeField] 
    private EnemySpawner enemySpawer;  
    private NavMeshAgent nav; 

    private Transform target; 

    private enum State
    {
        Idle, Chase
    }
    private State currentState; 
    // Start is called before the first frame update
    void Start()
    {
        currentState = State.Idle; 
        transform.parent = GameObject.Find("Enemy Spawner").transform; 
        target = transform.parent.GetComponent<EnemySpawner>().player.transform; 
        nav = GetComponent<NavMeshAgent>(); 

    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            default:
            case State.Idle: 
                FindTarget();
                break; 
            case State.Chase:
                transform.LookAt(target); 
                //transform.Translate(target.position); 
                nav.SetDestination(target.position); 
                break; 
        }
    }

    void FindTarget()
    {
        float targetRange = 10f;
        if (Vector3.Distance(transform.position, target.position) < targetRange)
        {
            //attack target
            currentState = State.Chase;
        }
    }
}
