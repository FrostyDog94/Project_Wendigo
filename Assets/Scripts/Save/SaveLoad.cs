using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoad : MonoBehaviour
{

    StoryManager storyManager;
    public PlayerInteract player;
    public WendigoController wendigo;

    public GameObject opening;


    void Start()
    {
        storyManager = StoryManager.Instance;

    }

    void Update()
    {
        if (GameObject.Find("Player"))
        {
            player = GameObject.Find("Player").GetComponent<PlayerInteract>();
        }
        if (GameObject.Find("Wendigo"))
        {
            wendigo = GameObject.Find("Wendigo").GetComponent<WendigoController>();
        }
    }


    public void SaveGameData()
    {
        //SaveSystem.DeleteGameData();
        SaveSystem.SaveGameData(storyManager, player, wendigo);

    }

    public void LoadGameData()
    {
        SaveData data = SaveSystem.LoadGameData();


        storyManager.book = data.book;
        storyManager.bills = data.bills;
        storyManager.hotelKey = data.hotelKey;
        storyManager.journal = data.journal;
        storyManager.altar = data.altar;
        storyManager.bookKey = data.bookKey;
        storyManager.bottle = data.bottle;
        storyManager.blood = data.blood;
        storyManager.ritual = data.ritual;
        storyManager.badBlood = data.badBlood;
        storyManager.badRitual = data.badRitual;

        Vector3 playerPosition;

        playerPosition.x = data.playerPosition[0];
        playerPosition.y = data.playerPosition[1];
        playerPosition.z = data.playerPosition[2];
        player.transform.position = playerPosition;

        Vector3 wendigoPosition;

        wendigoPosition.x = data.wendigoPosition[0];
        wendigoPosition.y = data.wendigoPosition[1];
        wendigoPosition.z = data.wendigoPosition[2];
        wendigo.transform.position = wendigoPosition;

        player.flashlight.gameObject.SetActive(true);
        player.flashlightActive = true;

        opening.SetActive(false);

    }



}
