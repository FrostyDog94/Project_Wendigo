using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    public InventorySystem inventorySystem;

    public InventoryItemData book;
    public InventoryItemData hotelKey;
    public InventoryItemData journal;
    public InventoryItemData altar;
    public InventoryItemData bookKey;
    public InventoryItemData bottle;
    public InventoryItemData blood;
    public InventoryItemData ritual;
    public InventoryItemData badBlood;
    public InventoryItemData badRitual;

    public GameObject secretPassage;

    //Katie
    [Header("Katie")]
    public DialogueTrigger katieTrigger;
    public Dialogue katieDialogue1;
    public Dialogue katieDialogue2;

    //Hotel Door
    [Header("Hotel Door")]
    public GameObject door;

    //Altar
    [Header("Altar")]
    public GameObject altar1;
    public GameObject altar2;
    Vector3 altarPos;
    Quaternion altarRot;

    //Ritual
    [Header("Ritual")]
    public GameObject bottle1;
    public GameObject bottle2;
    Vector3 bottlePos;
    Quaternion bottleRot;

    public GameObject ritual1;
    public GameObject ritual2;
    public GameObject ritual3;
    Vector3 ritualPos;
    Quaternion ritualRot;

    public GameObject father1;
    public GameObject father2;
    Vector3 fatherPos;
    Quaternion fatherRot;

    public Animator anim;



    //Blood
    public GameObject bed1;
    public GameObject bed2;
    Vector3 bedPos;
    Quaternion bedRot;

    public GameObject endWendigo;









    // Start is called before the first frame update
    void Start()
    {
        altarPos = altar1.transform.position;
        altarRot = altar1.transform.rotation;

        bottlePos = bottle1.transform.position;
        bottleRot = bottle1.transform.rotation;

        bedPos = bed1.transform.position;
        bedRot = bed1.transform.rotation;

        ritualPos = ritual1.transform.position;
        ritualRot = ritual1.transform.rotation;

        fatherPos = father1.transform.position;
        fatherRot = father1.transform.rotation;

        CheckInventory();
    }


    public void CheckInventory()
    {
        //Secret Passage
        if (inventorySystem.Get(journal) != null && GameObject.Find("Altar2(Clone)") == null)
        {
            Instantiate(altar2, altarPos, altarRot);
            Destroy(altar1);
        }

        //Hotel Door
        if (inventorySystem.Get(hotelKey) != null)
        {
            door.tag = "Door";
        }
        else
        {
            door.tag = "Locked Door";
        }

        //Katie 
        if (inventorySystem.Get(book) != null)
        {
            katieTrigger._dialogue = katieDialogue2; //Goto Hospital
        }
        else
        {
            katieTrigger._dialogue = katieDialogue1; //Initial Greeting
        }

        //Altar

        if (inventorySystem.Get(journal) != null && inventorySystem.Get(altar) != null)
        {
            secretPassage.GetComponent<Animator>().SetBool("isOpen", true);
        }

        //Ritual
        if (inventorySystem.Get(bookKey) != null && inventorySystem.Get(bottle) == null)
        {
            Instantiate(bottle2, bottlePos, bottleRot);
            Destroy(bottle1);
        }

        if (inventorySystem.Get(bottle) != null && GameObject.Find("Bed2(Clone)") == null && GameObject.Find("Father2(Clone)") == null)
        {
            Instantiate(bed2, bedPos, bedRot);
            Destroy(bed1);

            Instantiate(father2, fatherPos, fatherRot);
            Destroy(father1);
        }

        if (inventorySystem.Get(blood) != null && inventorySystem.Get(badBlood) == null && GameObject.Find("Ritual2(Clone)") == null)
        {
            Instantiate(ritual2, ritualPos, ritualRot);
            Destroy(ritual1);
        }

        if (inventorySystem.Get(ritual) != null)
        {
            anim.SetBool("isEnd", true);
        }

        //Bad Ending
        if (inventorySystem.Get(badBlood) != null && inventorySystem.Get(blood) == null && GameObject.Find("Ritual3(Clone)") == null)
        {
            Instantiate(ritual3, ritualPos, ritualRot);
            Destroy(ritual1);
        }

        if (inventorySystem.Get(badRitual) != null)
        {
            endWendigo.SetActive(true);
        }



    }

}
