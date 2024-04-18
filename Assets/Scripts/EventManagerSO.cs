using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="EventManager", menuName = "Managers/EventManager")]
public class EventManagerSO : ScriptableObject
{
    public event Action OnFishNibbling;
    public event Action OnFishBiting;

    public void FishNibbling()
    {
        OnFishNibbling?.Invoke();
    }

    public void FishBiting()
    {
        OnFishBiting?.Invoke();
    }
}
