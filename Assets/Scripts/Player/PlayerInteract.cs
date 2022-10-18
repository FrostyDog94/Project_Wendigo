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
    public bool flashlightActive;

    public GameObject inventory;

    public GameObject gameOverScreen;

    public bool inside;

    public GameObject map;

    public Animator anim;

    public WendigoController wendigoController;

   


    private void Start()
    {
        aud = GetComponent<AudioSource>();
        Flashlight();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Interact();
        }


        //Flashlight
        if (Input.GetKeyDown(KeyCode.F))
        {
            flashlight.gameObject.SetActive(!flashlight.gameObject.activeSelf);
            aud.PlayOneShot(lightSwitch, 1);
            Flashlight();
        }

       

        //Inventory
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventory.SetActive(!inventory.activeSelf);
        }

        //Map
        if (Input.GetKeyDown(KeyCode.M))
        {
            map.gameObject.SetActive(!map.gameObject.activeSelf);
        }




    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Wendigo" && flashlightActive)
        {
            gameOverScreen.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            wendigoController.enabled = false;
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

    void Flashlight()
    {
        if (flashlight.gameObject.activeSelf)
        {
            flashlightActive = true;
        }
        else
        {
            flashlightActive = false;
        }
    }

    void Interact()
    {
        StoryManager.Instance.CheckInventory();

        RaycastHit hit;
        Physics.Raycast(cam.position, cam.TransformDirection(Vector3.forward), out hit, interactDistance);

        //Open doors
        if (hit.transform != null)
        {
                if (hit.transform.GetComponent<DialogueTrigger>()) {
                    hit.transform.GetComponent<DialogueTrigger>().TriggerDialogue();
                }
                if (hit.transform.tag == "Door")
                {
                    {
                        transform.position = hit.transform.GetComponent<DoorController>().doorPosition.position;
                        transform.rotation = hit.transform.GetComponent<DoorController>().doorPosition.rotation;
                        aud.PlayOneShot(doorOpen, 1);
                    }
                }
                else if (hit.transform.tag == "Locked Door")
                {
                    aud.PlayOneShot(doorLocked, 1);
                }

                //Inventory Pickup
                else if (hit.transform.tag == "book")
                {
                    StoryManager.Instance.book = true;
                    Destroy(hit.transform.gameObject);
                }
                else if (hit.transform.tag == "hotel key")
                {
                    StoryManager.Instance.hotelKey = true;
                }
                else if (hit.transform.tag == "journal")
                {
                    StoryManager.Instance.journal = true;
                }
                else if (hit.transform.tag == "altar")
                {
                    StoryManager.Instance.altar = true;
                }
                else if (hit.transform.tag == "book key")
                {
                    StoryManager.Instance.bookKey = true;
                    Destroy(hit.transform.gameObject);
                }
                else if (hit.transform.tag == "bottle")
                {
                    StoryManager.Instance.bottle = true;
                    Destroy(hit.transform.gameObject);
                }
                else if (hit.transform.tag == "blood")
                {
                    StoryManager.Instance.blood = true;
                }
                else if (hit.transform.tag == "ritual")
                {
                    StoryManager.Instance.ritual = true;
                }
                else if (hit.transform.tag == "bad blood")
                {
                    StoryManager.Instance.badBlood = true;
                }
                else if (hit.transform.tag == "bad ritual")
                {
                    StoryManager.Instance.badRitual = true;
                }
            


        }
    }

}
