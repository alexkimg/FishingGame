using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    [SerializeField] List <Fish> fishes;
    private Vector3 randomPosition;

    [SerializeField] int howManyFish = 4;

    [SerializeField] float randomDelayMin = 2f;
    [SerializeField] float randomDelayMax = 5f;

    private void Start()
    {
        StartCoroutine(Round01());
    }

    private void SpawnFish( Fish fishToSpawn)
    {
        randomPosition = new Vector3(Random.Range(-4f, 4f), 1.5f, Random.Range(-4f, 4f));      
        Instantiate(fishToSpawn, randomPosition, Quaternion.identity );
    }

    IEnumerator Round01()
    {
        for (int i = 0; i < howManyFish; i++)
        {
            SpawnFish(fishes[(int)Random.Range(0, fishes.Count)]);
            yield return new WaitForSeconds(Random.Range(randomDelayMin, randomDelayMax));
        }
    }
}
