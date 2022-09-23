using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float radius;
    [Range(0, 360)]
    public float angle;

    public GameObject player;

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool canSeePlayer;

    public PlayerInteract playerInteract;
    float time = 0.2f;
    float timer;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //StartCoroutine(FOVRoutine());
        timer = time;
    }

   /* public IEnumerator FOVRoutine()
    {
        float delay = 0.2f;
        WaitForSeconds wait = new WaitForSeconds(delay);

        while (true)
        {
            if (playerInteract.inside)
            {
                yield return wait;
                FieldOfViewCheck();
            }
        }
    }
   */

    private void Update()
    {
        timer -= Time.deltaTime;
        
        if (timer <= 0)
        {
            
            FieldOfViewCheck();
            timer = time;
            
        }
    }

    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;
            
            
            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                    canSeePlayer = true;
                    
                }

                else
                {
                    canSeePlayer = false;
                }

            }
            else
            {
                canSeePlayer = false;
            }
        } else if (canSeePlayer)
        {
            canSeePlayer = false;
        }

        
    }

   /* public void startFOVRoutine()
    {

        StartCoroutine(FOVRoutine());
    }
   */
}
