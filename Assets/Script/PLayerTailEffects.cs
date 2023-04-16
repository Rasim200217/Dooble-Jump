using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerTailEffects : MonoBehaviour
{
    public float startTimeBtwSpawn;
    float timeBtwSpawn;
    public GameObject tailPrefab;

    private void Update()
    {
        if (timeBtwSpawn <= 0)
        {
            GameObject tail = Instantiate(tailPrefab, transform.position, Quaternion.identity);
            timeBtwSpawn = startTimeBtwSpawn;
            Destroy(tail, 3f);
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }
}
