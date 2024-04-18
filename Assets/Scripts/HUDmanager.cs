using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HUDmanager : MonoBehaviour
{

    [SerializeField] TMP_Text statusTextObject;

    public string status;

    public void UpdateStatus()
    {
        statusTextObject.text = $"{status}";
    }
}
