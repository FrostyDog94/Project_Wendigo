using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public float interactDistance = 5.0f;
    public Transform cam;
    AudioSource aud;
    public AudioClip doorOpen;
    public AudioClip doorLocked;
    public AudioClip lightSwitch;
    public AudioClip nightAmbiance;

    public Light flashlight;

    public GameObject inventory;

    public GameObject gameOverScreen;

    public bool inside;


    private void Start()
    {
        aud = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Physics.Raycast(cam.position, cam.TransformDirection(Vector3.forward), out hit, interactDistance);

        //Open doors
        if (hit.transform != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (hit.transform.tag == "Door")
                {
                    {
                        transform.position = hit.transform.GetComponent<DoorController>().doorPosition.position;
                        transform.rotation = hit.transform.rotation;
                        aud.PlayOneShot(doorOpen, 1);
                    }
                }
                else if (hit.transform.tag == "Locked Door")
                {
                    aud.PlayOneShot(doorLocked, 1);
                } 
                else if (hit.transform.TryGetComponent<ItemObject>(out ItemObject item))
                {
                    if (hit.transform.tag == "Apple" || hit.transform.tag == "Notes")
                    {
                        item.OnHandlePickupItem();
                    }
                }
            }

    
        }



        //Flashlight
        if (Input.GetKeyDown(KeyCode.F))
        {
            flashlight.gameObject.SetActive(!flashlight.gameObject.activeSelf);
            aud.PlayOneShot(lightSwitch, 1);
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            inventory.SetActive(!inventory.activeSelf);
        }


    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Wendigo")
        {
            gameOverScreen.SetActive(true);
            Debug.Log("Success");
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Interior")
        {
            inside = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Interior")
        {
            inside = false;
        }
    }

}
