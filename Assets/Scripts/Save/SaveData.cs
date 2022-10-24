using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public bool book;
    public bool bills;
    public bool hotelKey;
    public bool journal;
    public bool altar;
    public bool bookKey;
    public bool bottle;
    public bool blood;
    public bool ritual;
    public bool badBlood;
    public bool badRitual;

    public float[] playerPosition;
    public float[] wendigoPosition;

    public SaveData(StoryManager storyManager, PlayerInteract player, WendigoController wendigo)
    {
        book = storyManager.book;
        bills = storyManager.bills;
        hotelKey = storyManager.hotelKey;
        journal = storyManager.journal;
        altar = storyManager.altar;
        bookKey = storyManager.bookKey;
        bottle = storyManager.bottle;
        blood = storyManager.blood;
        ritual = storyManager.ritual;
        badBlood = storyManager.badBlood;
        badRitual = storyManager.badRitual;

        playerPosition = new float[3];
        playerPosition[0] = player.transform.position.x;
        playerPosition[1] = player.transform.position.y;
        playerPosition[2] = player.transform.position.z;

        wendigoPosition = new float[3];
        wendigoPosition[0] = wendigo.transform.position.x;
        wendigoPosition[1] = wendigo.transform.position.y;
        wendigoPosition[2] = wendigo.transform.position.z;

    }

}
