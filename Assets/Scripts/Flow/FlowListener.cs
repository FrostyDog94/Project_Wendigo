using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class FlowListenerEntry
{
    public FlowState state;
    public UnityEvent unityEvent;
}

public class FlowListener : MonoBehaviour
{
    [SerializeField]
    private FlowChannel _channel;
    [SerializeField]
    private FlowListenerEntry[] _entries;

    private void Awake()
    {
        _channel.OnFlowStateChanged += OnFlowStateChanged;
    }

    private void OnDestroy()
    {
        _channel.OnFlowStateChanged -= OnFlowStateChanged;
    }

    private void OnFlowStateChanged(FlowState state)
    {
        FlowListenerEntry foundEntry = Array.Find(_entries, x => x.state == state);
        if (foundEntry != null)
        {
            foundEntry.unityEvent.Invoke();
        }
    }
}
