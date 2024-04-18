using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="EventManager", menuName = "Managers/EventManager")]
public class EventManagerSO : ScriptableObject
{
    public event Action onFishNibbling;
    public event Action onFishBiting;

    public void FishNibbling()
    {
        onFishNibbling?.Invoke();
    }

    public void FishBiting()
    {
        onFishBiting?.Invoke();
    }
}
