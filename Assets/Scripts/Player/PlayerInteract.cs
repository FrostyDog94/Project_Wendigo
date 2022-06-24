using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public float interactDistance = 3.0f;
    public Transform cam;
    AudioSource aud;

    private void Start()
    {
        aud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Physics.Raycast(cam.position, cam.TransformDirection(Vector3.forward), out hit, interactDistance);

        if (hit.transform != null)
        {
            if (Input.GetMouseButtonDown(0) && hit.transform.tag == "Door")
            {
                transform.position = hit.transform.GetComponent<DoorController>().doorPosition.position;
                transform.rotation = hit.transform.rotation;
                aud.Play();
            }
        }
    }
}
