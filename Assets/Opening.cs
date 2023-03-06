using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opening : MonoBehaviour
{
    public Crosshair crosshair;
    public GameObject player;
    public GameObject ambientSoundManager;

    void Start()
    {
        player.SetActive(false);
        ambientSoundManager.SetActive(false);
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Time.timeScale = 1;
            gameObject.SetActive(false);
            crosshair.gameObject.SetActive(true);
            player.SetActive(true);
            ambientSoundManager.SetActive(true);
        }
    }
}
