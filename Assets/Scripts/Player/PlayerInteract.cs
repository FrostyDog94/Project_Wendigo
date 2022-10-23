using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    bool journalOpen = false;

    //Player is safe after exiting building
    float safeTimer;
    public float safeTime = 2;
    public bool safe;



    private void Start()
    {
        aud = GetComponent<AudioSource>();
        safeTimer = safeTime;
        safe = false;
        Flashlight();

    }

    // Update is called once per frame
    void Update()
    {
        if (safeTimer <= 0)
        {
            safe = false;
        }
        else
        {
            safeTimer -= Time.deltaTime;
            safe = true;
        }



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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (journalOpen == false)
            {
                inventory.SetActive(true);
                journalOpen = true;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                inventory.SetActive(false);
                journalOpen = false;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }

        }

        //Map
        if (Input.GetKeyDown(KeyCode.M))
        {
            map.gameObject.SetActive(!map.gameObject.activeSelf);
        }

        //Quit
        /*
         if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        */




    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Wendigo" && flashlightActive)
        {
            gameOverScreen.SetActive(true);
            collision.transform.gameObject.SetActive(false);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            wendigoController.enabled = false;
            wendigoController.footstepsAudSrc.volume = 0;
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
            safeTimer = safeTime;
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
        RaycastHit hit;
        Physics.Raycast(cam.position, cam.TransformDirection(Vector3.forward), out hit, interactDistance);

        //Open doors
        if (hit.transform != null)
        {
            if (hit.transform.GetComponent<DialogueTrigger>())
            {
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
                aud.PlayOneShot(doorLocked, 0.3f);
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
        StoryManager.Instance.CheckInventory();
        JournalManager.Instance.checkJournal();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

}
