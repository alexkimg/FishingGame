using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class HUDmanager : MonoBehaviour
{
    [SerializeField] EventManagerSO eventManager;
    [SerializeField] TMP_Text statusTextObject;

    public string status;

    private void OnEnable()
    {
        eventManager.onFishNibbling += UpdateStatusNibbling;
        eventManager.onFishBiting += UpdateStatusBite;
    }

    private void OnDisable()
    {
        eventManager.onFishNibbling -= UpdateStatusNibbling;
        eventManager.onFishBiting -= UpdateStatusBite;
    }

    public void UpdateStatusNibbling()
    {
        statusTextObject.text = $"Fish is Nibbling...";
    }

    public void UpdateStatusBite()
    {
        statusTextObject.text = $"BITE!";
    }

    public void UpdateStatus()
    {
        statusTextObject.text = $"{status}";
    }

}
