using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SUPERCharacter;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField]
    public Dialogue _dialogue;

    public void TriggerDialogue() {
        if (!DialogueManager.Instance.inDialogue) {
            DialogueManager.Instance.StartDialogue(_dialogue);
        }
    }
}
