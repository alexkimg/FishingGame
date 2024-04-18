using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="EventManager", menuName = "Managers/EventManager")]
public class EventManagerSO : ScriptableObject
{
    public event Action onFishBiting;

    public void FishBiting()
    {
        onFishBiting?.Invoke();
    }
}
