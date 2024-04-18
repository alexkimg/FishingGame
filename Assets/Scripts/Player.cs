using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void Awake()
    {
        transform.position = new Vector3(0f, 1f, -5f);
    }
}
