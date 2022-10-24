using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WendigoController : MonoBehaviour
{
    enum State { Chasing, Patrolling };
    State currentState;
    NavMeshAgent agent;
    public Transform[] waypoints;
    int n;
    Animator anim;
    FieldOfView fov;
    public float chaseSpeed;
    public float patrolSpeed;
    private bool isChasing;

    AudioSource[] audSrcs;
    public AudioSource footstepsAudSrc;
    AudioSource otherAudSrc;
    public AudioClip alertAudio;

    Vector3 destination;

    public PlayerInteract playerInteract;
    public AmbiantSoundManager ambiantSoundManager;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        fov = GetComponent<FieldOfView>();
        audSrcs = GetComponents<AudioSource>();
        footstepsAudSrc = audSrcs[0];
        otherAudSrc = audSrcs[1];
        footstepsAudSrc.pitch = 0.75f;
        n = Random.Range(0, waypoints.Length - 1);
        currentState = State.Patrolling;

    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(destination);

        if (agent.transform.position == agent.destination)
        {
            n = Random.Range(0, waypoints.Length - 1);
        }


        if (fov.canSeePlayer && playerInteract.flashlightActive && playerInteract.inside == false && playerInteract.safe == false)
        {
            if (currentState == State.Patrolling)
            {
                otherAudSrc.pitch = 1.5f;
                otherAudSrc.PlayOneShot(alertAudio, 1);
                agent.speed = chaseSpeed;
                footstepsAudSrc.pitch = 3;
                ambiantSoundManager.stopMusic();
            }
            currentState = State.Chasing;
            ChasePlayer();
        }
        else
        {
            currentState = State.Patrolling;
            Patrol();
        }
    }

    void ChasePlayer()
    {
        destination = fov.player.transform.position;
        anim.SetBool("isRunning", true);
        anim.SetBool("isWalking", false);
    }

    public void Patrol()
    {
        destination = waypoints[n].position;
        anim.SetBool("isWalking", true);
        anim.SetBool("isRunning", false);
        agent.speed = patrolSpeed;
        footstepsAudSrc.pitch = 0.75f;
    }





}
