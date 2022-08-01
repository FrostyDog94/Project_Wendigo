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

    //Ending
    [Header("Ending")]
    public GameObject endingScreen;






    // Start is called before the first frame update
    void Start()
    {
        altarPos = altar1.transform.position;
        altarRot = altar1.transform.rotation;

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

        //Ending
        if (inventorySystem.Get(bookKey) != null)
        {
            endingScreen.GetComponent<Animator>().SetBool("isEnding", true);
        }
    }

}
