using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WendigoController : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform[] waypoints;
    int n;
    Animator anim;
    FieldOfView fov;
    public float chaseSpeed;
    public float patrolSpeed;
    AudioSource aud;
    
    bool playerSpotted;

    Vector3 destination;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        fov = GetComponent<FieldOfView>();
        aud = GetComponent<AudioSource>();
        aud.pitch = 0.75f;
        n = Random.Range(0, waypoints.Length - 1);
        playerSpotted = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(destination);
        

        if (agent.transform.position == agent.destination)
        {
            n = Random.Range(0, waypoints.Length - 1);
        }


        if (fov.canSeePlayer)
        {
            playerSpotted = true;
        }

        if (playerSpotted)
        {
            ChasePlayer();
            Debug.Log(destination);
        }
        else
        {
            Patrol();
        }


    }

    void ChasePlayer()
    {
        destination = fov.player.transform.position;
        anim.SetBool("isRunning", true);
        agent.speed = chaseSpeed;
        aud.pitch = 2;
        
    }

    void Patrol()
    {
        destination = waypoints[n].position;
        anim.SetBool("isWalking", true);
        agent.speed = patrolSpeed;
        aud.pitch = 0.75f;
    }



}
