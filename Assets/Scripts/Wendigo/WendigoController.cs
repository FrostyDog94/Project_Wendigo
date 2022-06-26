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

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
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
    }
}
