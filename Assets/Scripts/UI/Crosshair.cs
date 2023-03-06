using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{
    public PlayerInteract playerInteract;
    public Texture defaultCrosshair;
    public Texture inspectCrosshair;
    
    private RawImage image;

    // Start is called before the first frame update
    void Start()
    {
        image = gameObject.GetComponent<RawImage>();
        image.texture = defaultCrosshair;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Physics.Raycast(playerInteract.cam.position, playerInteract.cam.TransformDirection(Vector3.forward), out hit, playerInteract.interactDistance);
        if (hit.transform != null && 
            (hit.transform.tag == "Door" 
            || hit.transform.tag == "Locked Door" 
            || hit.transform.tag == "ritual"
            || hit.transform.tag == "bad ritual"
            || hit.transform.gameObject.GetComponent<DialogueTrigger>() != null))
        {
            image.texture = inspectCrosshair;
        }
        else
        {
            image.texture = defaultCrosshair;
        }
    }
}
