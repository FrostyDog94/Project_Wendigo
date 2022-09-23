using UnityEngine;
using System.Collections;

public class CameraSway : MonoBehaviour
{
    Vector3 targetPosition;
    Vector3 startPosition;
    public float smoothTime = 3f;
    private Vector3 velocity = Vector3.zero;
    public float swayTime = 1.5f;
    public float amplitude = 0.05f;
    private float timer;

    void Start() 
    {
        startPosition = transform.position;
        targetPosition = startPosition;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > swayTime)
        {
            timer = 0;
            targetPosition = startPosition + (Vector3)(Random.insideUnitCircle * amplitude);
        }
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}