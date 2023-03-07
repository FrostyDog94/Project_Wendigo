using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EndigoController : MonoBehaviour
{
    public GameObject player;
    public GameObject playerCamera;
    public LayerMask obstructionMask;
    NavMeshAgent agent;
    Animator anim;
    public float chaseSpeed;
    AudioSource[] audSrcs;
    AudioSource footstepsAudSrc;
    AudioSource otherAudSrc;
    public AudioClip alertAudio;
    bool playerHasSeenWendigo;
    public GameObject gameOverScreen;

    Vector3 destination;
    float time = 0.2f;
    float timer;
    bool alertPlayed;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        audSrcs = GetComponents<AudioSource>();
        footstepsAudSrc = audSrcs[0];
        otherAudSrc = audSrcs[1];
        footstepsAudSrc.pitch = 0.75f;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(destination);

        timer -= Time.deltaTime;
        
        if (timer <= 0)
        {
            FOVCheck();
            timer = time;
        }

        if (playerHasSeenWendigo)
        {
            ChasePlayer();
        }
    }

    void ChasePlayer()
    {
        if(!alertPlayed) 
        {
            agent.enabled = true;
            alertPlayed = true;
            otherAudSrc.pitch = 1.5f;
            otherAudSrc.PlayOneShot(alertAudio, 1);
            anim.SetBool("isRunning", true);
            agent.speed = chaseSpeed;
            footstepsAudSrc.pitch = 3;
        }
        destination = player.transform.position;
    }

    private void FOVCheck()
    {
        Vector3 directionToTarget = (transform.position - playerCamera.transform.position).normalized;

        if(Vector3.Angle(playerCamera.transform.forward, directionToTarget) < 45)
        {
            float distanceToTarget = Vector3.Distance(playerCamera.transform.position, transform.position);

            if (!Physics.Raycast(playerCamera.transform.position, directionToTarget, distanceToTarget, obstructionMask))
            {
                playerHasSeenWendigo = true;
            }
        }
    }

 private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            player.gameObject.GetComponent<PlayerInteract>().Die();
            footstepsAudSrc.volume = 0;
            this.enabled = false;
        }


    }



}
