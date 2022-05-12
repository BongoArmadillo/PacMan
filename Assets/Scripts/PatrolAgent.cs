using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolAgent : MonoBehaviour
{
    //Waypoints
   public Transform[] points;

   private int destinationPoints = 0;

    //Agent
   private NavMeshAgent agent;

    //Player
    public Transform player;
    Vector3 origialPosition;

    public LayerMask whatIsPlayer;
    public LayerMask whatIsWall;

    public float angle;
    public float sightRange;
    public bool playerInSightRange;


    private void Awake() {
        player = GameObject.Find("PlayerObj").transform;
    }

   private void Start() {
       agent = GetComponent<NavMeshAgent>();
       agent.autoBraking = false;
       origialPosition = player.transform.position;
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
        if(FOV())
        ChasePlayer();
        
        if(origialPosition == player.transform.position)
        {
            destinationPoints = 0;
            agent.destination = points[destinationPoints].position;
        }

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

   public bool FOV()
    {
        Vector3 directToTarget = (player.position  - transform.position);
           
            if(Vector3.Angle(transform.forward, directToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, player.position);
                
                if(!Physics.Raycast(transform.position, directToTarget, distanceToTarget, whatIsWall))
                return true;
            }
    
        return false;
    }

}
