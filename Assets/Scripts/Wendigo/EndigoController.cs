using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EndigoController : MonoBehaviour
{
    public GameObject player;
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
        Vector3 directionToTarget = (transform.position - player.transform.position).normalized;

        if(Vector3.Angle(player.transform.forward, directionToTarget) < 90)
        {
            float distanceToTarget = Vector3.Distance(player.transform.position, transform.position);

            if (!Physics.Raycast(player.transform.position, directionToTarget, distanceToTarget, obstructionMask))
            {
                playerHasSeenWendigo = true;
            }
        }
    }

 private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            gameOverScreen.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            this.enabled = false;
            footstepsAudSrc.volume = 0;
        }


    }



}
