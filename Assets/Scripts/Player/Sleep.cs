using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sleep : MonoBehaviour
{

    public TimeController timeController;
    float timeMultiplier;
    float bedTimeMultiplier;

    public Transform cam;
    public float interactDistance = 5.0f;

    public float sleepMultiplier;
    // Start is called before the first frame update
    void Start()
    {
        timeMultiplier = timeController.timeMultiplier;
        bedTimeMultiplier = timeController.timeMultiplier * sleepMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Physics.Raycast(cam.position, cam.TransformDirection(Vector3.forward), out hit, interactDistance);

        if (Input.GetMouseButton(0))
        {

            if (hit.transform.tag == "Bed")
            {
                timeController.timeMultiplier = bedTimeMultiplier;

            }


        }
        else if (Input.GetMouseButtonUp(0))
        {
            timeController.timeMultiplier = timeMultiplier;
        }
    }
}
