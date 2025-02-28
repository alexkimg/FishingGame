using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Bobber : MonoBehaviour
{
    public bool isDetectable = false;

    [SerializeField] public float reelingSpeed = 1f;

    [SerializeField] Fish fish;
    [SerializeField] Player player;

    [SerializeField] EventManagerSO eventManager;

    private Bobber b;


    private void OnEnable()
    {
        eventManager.OnFishBiting += ReelInDebug;
    }
    private void OnDisable()
    {
        eventManager.OnFishBiting -= ReelInDebug;
    }


    private void Awake()
    {
        isDetectable = false;
        player = FindObjectOfType<Player>();
    }


    public void ActivateBobber()
    {
        b = FindObjectOfType<Bobber>();
        b.isDetectable = true;
    }

    public void ReelInDebug()
    {
        Debug.Log($"Reeling In!");
    }

    public void ReelIn()
    {
       b = FindObjectOfType<Bobber>();
        b.isDetectable = false;
            transform.position = Vector3.MoveTowards(
            transform.position,
            player.transform.position,
            reelingSpeed * Time.deltaTime);

    }

}
