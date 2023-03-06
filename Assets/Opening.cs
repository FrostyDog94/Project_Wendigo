using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opening : MonoBehaviour
{
    public Crosshair crosshair;
    public GameObject player;

    void Start()
    {
        player.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            gameObject.SetActive(false);
            crosshair.gameObject.SetActive(true);
            player.SetActive(true);
        }
    }
}
