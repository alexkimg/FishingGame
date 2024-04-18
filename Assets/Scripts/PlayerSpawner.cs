using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] Player player;


    void Awake()
    {
        transform.position = new Vector3(4f,1f,-4f);
        Instantiate(player, transform.position, Quaternion.identity);
    }

}
