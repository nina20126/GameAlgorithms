using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyMovement : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public GameObject Playerr;

    public float EnemyDistanceRun = 4.0f;

    private Vector3 escape = new Vector3(5, 0, 2);

    bool escapePlayer = false;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, Playerr.transform.position);

        if (escapePlayer == false)
        {
            chasePlayer();
        }
        

        if (Input.GetKeyDown(KeyCode.I)) 
        {
            //escapePlayer = true;

            //Vector3 dirToPlayer = transform.position - Playerr.transform.position;

            //Vector3 newPosition = transform.position + dirToPlayer;

            //agent.SetDestination(Vector3.zero);

            fleeFromPlayer();
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            escapePlayer= false;
            chasePlayer();
        }
    }

    private void fleeFromPlayer()
    {
        agent.SetDestination(-player.position);

    }

    private void chasePlayer()
    {
        agent.SetDestination(player.position);
    }

}
