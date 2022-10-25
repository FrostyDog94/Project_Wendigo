using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JournalManager : MonoBehaviour
{
    public static JournalManager Instance { get; private set; }

    AudioSource openJournal;

    public List<string> journalEntries = new List<string>();

    public GameObject entry1;
    public GameObject entry2;
    public GameObject entry3;
    public GameObject entry4;
    public GameObject entry5;
    public GameObject entry6;
    public GameObject entry7;
    public GameObject entry8;

    [TextArea(3, 8)]
    public string initialEntry;
    [TextArea(3, 8)]
    public string bookEntry;
    [TextArea(3, 8)]
    public string billsEntry;
    [TextArea(3, 8)]
    public string hotelKeyEntry;
    [TextArea(3, 8)]
    public string journalEntry;
    [TextArea(3, 8)]
    public string bookKeyEntry;
    [TextArea(3, 8)]
    public string bottleEntry;
    [TextArea(3, 8)]
    public string bloodEntry;



    void Awake()
    {
        if (Instance != null && Instance != this) Destroy(this);
        else Instance = this;

        openJournal = GetComponent<AudioSource>();
        openJournal.Play();
    }

    void Start()
    {
        journalEntries.Add(initialEntry);
        checkJournal();
    }

    public void checkJournal()
    {

        if (StoryManager.Instance.saveData.book && !journalEntries.Contains(bookEntry))
        {
            journalEntries.Add(bookEntry);
        }

        if (StoryManager.Instance.saveData.bills && !journalEntries.Contains(billsEntry))
        {
            journalEntries.Add(billsEntry);
        }

        if (StoryManager.Instance.saveData.hotelKey && !journalEntries.Contains(hotelKeyEntry))
        {
            journalEntries.Add(hotelKeyEntry);
        }

        if (StoryManager.Instance.saveData.journal && !journalEntries.Contains(journalEntry))
        {
            journalEntries.Add(journalEntry);
        }

        if (StoryManager.Instance.saveData.bookKey && !journalEntries.Contains(bookKeyEntry))
        {
            journalEntries.Add(bookKeyEntry);
        }

        if (StoryManager.Instance.saveData.bottle && !journalEntries.Contains(bottleEntry))
        {
            journalEntries.Add(bottleEntry);
        }

        if (StoryManager.Instance.saveData.badBlood || StoryManager.Instance.saveData.blood)
        {
            if (!journalEntries.Contains(bloodEntry))
            {
                journalEntries.Add(bloodEntry);
            }
        }


        if (journalEntries[0] != null)
        {
            entry1.GetComponent<TextMeshProUGUI>().text = journalEntries[0];
        }
        if (journalEntries[1] != null)
        {
            entry2.GetComponent<TextMeshProUGUI>().text = journalEntries[1];
        }
        if (journalEntries[2] != null)
        {
            entry3.GetComponent<TextMeshProUGUI>().text = journalEntries[2];
        }
        if (journalEntries[3] != null)
        {
            entry4.GetComponent<TextMeshProUGUI>().text = journalEntries[3];
        }
        if (journalEntries[4] != null)
        {
            entry5.GetComponent<TextMeshProUGUI>().text = journalEntries[4];
        }
        if (journalEntries[5] != null)
        {
            entry6.GetComponent<TextMeshProUGUI>().text = journalEntries[5];
        }
        if (journalEntries[6] != null)
        {
            entry7.GetComponent<TextMeshProUGUI>().text = journalEntries[6];
        }


    }

}

