using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    [SerializeField] Fish fish;

    private void Awake()
    {
        Instantiate(fish, transform.position, Quaternion.identity);
    }

}
