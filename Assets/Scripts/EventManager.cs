using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class EventListener : UnityEvent { } 
public class EventManager : MonoBehaviour
{
    [SerializeField] private List<EventListener>_listener;

    private int _iterator = 0;

    private void Start()
    {
    }
    public void TriggerNextEvent()
    {

        if (_iterator < _listener.Count)
        {
            _listener[_iterator]?.Invoke();
            _listener.RemoveAt(0);
        }
    }

}
