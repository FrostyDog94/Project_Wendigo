using UnityEngine;

public class FlowStateMachine : MonoBehaviour
{
    [SerializeField]
    private FlowChannel _channel;
    [SerializeField]
    private FlowState _startupState;

    private FlowState _currentState;
    public FlowState CurrentState => _currentState;

    private static FlowStateMachine _instance;
    public static FlowStateMachine Instance => _instance;

    private void Awake()
    {
        if (_instance != null && _instance != this) { 
            Destroy(this); 
        } else { 
            _instance = this;
        }

        _channel.OnFlowStateRequested += SetFlowState;
    }

    private void Start()
    {
        SetFlowState(_startupState);
    }

    private void OnDestroy()
    {
        _channel.OnFlowStateRequested -= SetFlowState;

        _instance = null;
    }

    private void SetFlowState(FlowState state)
    {
        if (_currentState != state)
        {
            _currentState = state;
            _channel.RaiseFlowStateChanged(_currentState);
        }
    }
}
