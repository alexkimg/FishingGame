using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour

{
    [SerializeField] Fish fish;
    [SerializeField] private PlayerStats playerStats;

    private void Awake()
    {
        transform.position = new Vector3(0f, 1f, -5f);
    }

    //private void Update()
    //{
    //    if ( Vector3.Distance(transform.position, fish.transform.position) <= 0.1f)
    //    {
    //        playerStats = 
    //    }
    //}
}
