using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class StoryManager : MonoBehaviour
{
    public static StoryManager Instance { get; private set; }
    public SaveData saveData;
    public GameObject bookObject;
    public GameObject bookKeyObject;
    public GameObject bottleObject;

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
    private GameObject father2Instance;
    Vector3 fatherPos;
    Quaternion fatherRot;

    public Animator anim;



    //Blood
    public GameObject bed1;
    public GameObject bed2;
    private GameObject bed2Instance;
    Vector3 bedPos;
    Quaternion bedRot;

    public GameObject endWendigo;

    public GameObject goodEndingCutscene;




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
        if (saveData.journal && GameObject.Find("Altar2(Clone)") == null)
        {
            Instantiate(altar2, altarPos, altarRot);
            Destroy(altar1);
        }

        //Hotel Door
        if (saveData.hotelKey)
        {
            door.tag = "Door";

        }

        //Katie 
        if (saveData.book)
        {
            katieTrigger._dialogue = katieDialogue2; //Goto Hospital
            Destroy(bookObject);
        }
        else
        {
            katieTrigger._dialogue = katieDialogue1; //Initial Greeting
        }

        //Altar

        if (saveData.journal && saveData.altar)
        {
            secretPassage.GetComponent<Animator>().SetBool("isOpen", true);
        }

        if (saveData.bookKey)
        {
            Destroy(bookKeyObject);
        }

        //Ritual
        if (saveData.bookKey && saveData.bottle == false && GameObject.Find("Bottle - post key(Clone)") == null)
        {
            Instantiate(bottle2, bottlePos, bottleRot);
            Destroy(bottle1);
        }

        if (saveData.bottle && GameObject.Find("Bed2(Clone)") == null && GameObject.Find("Father2(Clone)") == null)
        {
            bed2Instance = Instantiate(bed2, bedPos, bedRot);
            Destroy(bed1);

            father2Instance = Instantiate(father2, fatherPos, fatherRot);
            Destroy(father1);
        }

        if (saveData.bottle)
        {
            Destroy(bottleObject);
        }

        if (saveData.blood && saveData.badBlood == false && GameObject.Find("Ritual2(Clone)") == null)
        {
            Instantiate(ritual2, ritualPos, ritualRot);
            Destroy(ritual1);
            // after collecting blood, remove ability to interact with either blood
            Destroy(bed2Instance.gameObject.GetComponentsInChildren<DialogueTrigger>()[0]);
            Destroy(father2Instance.gameObject.GetComponentsInChildren<DialogueTrigger>()[0]);
        }

        if (saveData.ritual)
        {
            goodEndingCutscene.SetActive(true);
            anim.SetTrigger("FadeToBlack");
        }

        //Bad Ending
        if (saveData.badBlood && saveData.blood == false && GameObject.Find("Ritual3(Clone)") == null)
        {
            Instantiate(ritual3, ritualPos, ritualRot);
            Destroy(ritual1);
            // after collecting blood, remove ability to interact with either blood
            Destroy(bed2Instance.gameObject.GetComponentsInChildren<DialogueTrigger>()[0]);
            Destroy(father2Instance.gameObject.GetComponentsInChildren<DialogueTrigger>()[0]);
        }

        if (saveData.badRitual)
        {
            endWendigo.SetActive(true);
        }





    }

}
