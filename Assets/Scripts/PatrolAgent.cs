using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolAgent : MonoBehaviour
{
   public Transform[] points;

   private int destinationPoints = 0;

   private NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsPlayer;

    public float sightRange;
    public bool playerInSightRange;


    private void Awake() {
        player = GameObject.Find("PlayerObj").transform;
    }

   private void Start() {
       agent = GetComponent<NavMeshAgent>();
       agent.autoBraking = false;
       GoToNextPoit();
   }

    void GoToNextPoit()
    {
        agent.destination = points[destinationPoints].position;
        //destinationPoints = (destinationPoints + 1) % points.Length;
        destinationPoints = Random.Range(0,26);
    }

    private void Update() {

        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);

        if(!agent.pathPending && agent.remainingDistance < 0.5f && !playerInSightRange)
        GoToNextPoit();
        if(playerInSightRange)
        ChasePlayer();
    }
 private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

}
