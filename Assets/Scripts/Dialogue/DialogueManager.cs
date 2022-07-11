using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    private static DialogueManager _instance;
    public static DialogueManager Instance => _instance;

    public bool inDialogue { get; private set; }

    
    private Queue<string> _lines;
    [SerializeField]

    private GameObject _dialogueBox;
    [SerializeField]
    private TextMeshProUGUI _speakerText;
    [SerializeField]
    private TextMeshProUGUI _dialogueText;
    [SerializeField]
    private int _typingSpeed = 50;
    private bool _isTyping = false;
    private string _currLine = null;

    [SerializeField]
    private FlowChannel _flowChannel;
    [SerializeField]
    private FlowState _dialogueState;
    private FlowState _cachedState;

    private void Awake()
    {
        if (_instance != null && _instance != this) { 
            Destroy(this); 
        } else { 
            _instance = this;
        }
        _dialogueBox.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        _lines = new Queue<string>();
    }

    void Update()
    {
        if (inDialogue && Input.GetMouseButtonDown(0)) {
            if (_isTyping) {
                StopAllCoroutines();
                _dialogueText.text = _currLine;
                _isTyping = false;
            } else {
                DisplayNextLine();
            }
        }
    }

    public void StartDialogue(Dialogue dialogue) {
        _cachedState = FlowStateMachine.Instance.CurrentState;
        _flowChannel.RaiseFlowStateRequest(_dialogueState);
        inDialogue = true;
        _lines.Clear();
        _speakerText.text = dialogue.speaker;
        _dialogueBox.SetActive(true);

        foreach (string line in dialogue.lines) 
        {
            _lines.Enqueue(line);
        }
        DisplayNextLine();
    }

    private void DisplayNextLine()
    {
        if (_lines.Count == 0) {
            EndDialogue();
            return;
        }
        _currLine = _lines.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeLine(_currLine));
    }

    IEnumerator TypeLine(string line)
    {
        _isTyping = true;
        _dialogueText.text = "";
        foreach (char c in line) {
            _dialogueText.text += c;
            yield return new WaitForSeconds(1/_typingSpeed);
        }
        _isTyping = false;
    }

    private void EndDialogue()
    {
        _flowChannel.RaiseFlowStateRequest(_cachedState);
        _cachedState = null;
        _dialogueBox.SetActive(false);
        inDialogue = false;
    }
}
