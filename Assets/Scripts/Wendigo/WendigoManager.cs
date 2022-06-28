using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WendigoManager : MonoBehaviour
{
    public TimeController timeController;
    public GameObject wendigo;
    public FieldOfView fov;



    void Update()
    {
        if (timeController.currentTime.TimeOfDay > timeController.sunriseTime && timeController.currentTime.TimeOfDay < timeController.sunsetTime)
        {
            wendigo.SetActive(false);
        } else
        {
            wendigo.SetActive(true);
            fov.startFOVRoutine();
        }
    }
}
