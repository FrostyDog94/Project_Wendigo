using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    public static StoryManager Instance { get; private set; }

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

    public GameObject goodEnding;



    void Awake()
    {
        if (Instance != null && Instance != this) Destroy(this);
        else Instance = this;
    }





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
        if (journal && GameObject.Find("Altar2(Clone)") == null)
        {
            Instantiate(altar2, altarPos, altarRot);
            Destroy(altar1);
        }

        //Hotel Door
        if (hotelKey)
        {
            door.tag = "Door";

        }

        //Katie 
        if (book)
        {
            katieTrigger._dialogue = katieDialogue2; //Goto Hospital
        }
        else
        {
            katieTrigger._dialogue = katieDialogue1; //Initial Greeting
        }

        //Altar

        if (journal && altar)
        {
            secretPassage.GetComponent<Animator>().SetBool("isOpen", true);
        }

        //Ritual
        if (bookKey && bottle == false && GameObject.Find("Bottle - post key(Clone)") == null)
        {
            Instantiate(bottle2, bottlePos, bottleRot);
            Destroy(bottle1);
        }

        if (bottle && GameObject.Find("Bed2(Clone)") == null && GameObject.Find("Father2(Clone)") == null)
        {
            Instantiate(bed2, bedPos, bedRot);
            Destroy(bed1);

            Instantiate(father2, fatherPos, fatherRot);
            Destroy(father1);
        }

        if (blood && badBlood == false && GameObject.Find("Ritual2(Clone)") == null)
        {
            Instantiate(ritual2, ritualPos, ritualRot);
            Destroy(ritual1);
        }

        if (ritual)
        {
            goodEnding.SetActive(true);
            anim.SetBool("isEnd", true);
        }

        //Bad Ending
        if (badBlood && blood == false && GameObject.Find("Ritual3(Clone)") == null)
        {
            Instantiate(ritual3, ritualPos, ritualRot);
            Destroy(ritual1);

        }

        if (badRitual)
        {
            endWendigo.SetActive(true);
        }





    }

}
