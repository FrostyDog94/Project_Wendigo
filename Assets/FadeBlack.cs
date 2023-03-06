using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeBlack : MonoBehaviour
{

    public GameObject playerCamera;
    public GameObject cutsceneCamera;
    
    public void SwitchCameras() {
        playerCamera.SetActive(false);
        cutsceneCamera.SetActive(true);
    }
}
