using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SUPERCharacter;

public class DialogueTrigger : MonoBehaviour, IInteractable
{
    [SerializeField]
    public Dialogue _dialogue;

    public bool Interact() {
        if (!DialogueManager.Instance.inDialogue) {
            DialogueManager.Instance.StartDialogue(_dialogue);
            return true;
        }
        return false;
    }
}
