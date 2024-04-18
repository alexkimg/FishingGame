using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Bobber : MonoBehaviour
{
    public bool isDetectable = false;

    [SerializeField] public float reelingSpeed = 1f;

    [SerializeField] Fish fish;
    [SerializeField] Transform player;

    [SerializeField] EventManagerSO eventManager;



    //private void Update()
    //{
    //    if (player != null)
    //    {
    //        Debug.Log("Player not null");
    //        Debug.Log(player.transform.position);
    //        Debug.Log(transform.position);
    //        Debug.Log(reelingSpeed);
    //    }
    //}


    private void OnEnable()
    {
        eventManager.OnFishBiting += ReelIn;
    }
    private void OnDisable()
    {
        eventManager.OnFishBiting -= ReelIn;
    }

    private void Awake()
    {
        isDetectable = false;
    }

    public void ActivateBobber()
    {
        isDetectable = true;
    }
    private void ReelIn()
    {

        if (player != null)
        {
            Debug.Log($"Reeling In!");
            
                //transform.position = Vector3.MoveTowards(transform.position, player.transform.position, reelingSpeed * Time.deltaTime);
            

        }

    }

}
