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

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        fov = GetComponent<FieldOfView>();
        aud = GetComponent<AudioSource>();
        aud.pitch = 0.75f;
       
        n = 0;
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = waypoints[n].position;
        anim.SetBool("isWalking", true);

        if (agent.transform.position == agent.destination)
        {
            n += 1;
        }

        if (n >= waypoints.Length)
        {
            n = 0;
        }

        if (fov.canSeePlayer)
        {
            anim.SetBool("isRunning", true);
            agent.destination = fov.player.transform.position;
            agent.speed = chaseSpeed;
            aud.pitch = 2;
            
        } else
        {
            agent.destination = waypoints[n].position;
            anim.SetBool("isRunning", false);
            agent.speed = patrolSpeed;
            aud.pitch = 0.75f;
            

        }
    }
}
