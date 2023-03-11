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
    public GameObject playerObject;


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


        storyManager.saveData.book = data.book;
        storyManager.saveData.bills = data.bills;
        storyManager.saveData.hotelKey = data.hotelKey;
        storyManager.saveData.journal = data.journal;
        storyManager.saveData.altar = data.altar;
        storyManager.saveData.bookKey = data.bookKey;
        storyManager.saveData.bottle = data.bottle;
        storyManager.saveData.blood = data.blood;
        storyManager.saveData.ritual = data.ritual;
        storyManager.saveData.badBlood = data.badBlood;
        storyManager.saveData.badRitual = data.badRitual;

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
        playerObject.SetActive(true);
        Time.timeScale = 1;

    }



}
