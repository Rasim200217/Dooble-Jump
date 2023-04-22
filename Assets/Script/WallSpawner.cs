using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    /*public float maxTime;
    private float time;

    public float maxHeight;
    public float minHeight;


    public GameObject[] wallPrefab;
    GameObject wall;

    private void Start()
    {
        time = 1;
    }

    private void Update()
    {
        
        if (time > maxTime)
        {
            for (int i = 0; i < wallPrefab.Length; i++) { 
                wall = Instantiate(wallPrefab[i]);
                wall.transform.position = transform.position + new Vector3(0, Random.Range(minHeight, maxHeight), 0);
                time = 0;
            }
        }
        time += Time.deltaTime;
        Destroy(wall, 6f);
    }*/

    [System.Serializable]
    public struct SpawnableObject
    {
        public GameObject perfab;
        [Range(0f, 1f)]
        public float spawnChance;
    }
    public SpawnableObject[] objects;

    public float minSpawnRate = 1f;
    public float maxSpawnRate = 2f;

    private void OnEnable()
    {
        Invoke(nameof(Spawn), Random.Range(minSpawnRate, maxSpawnRate));
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void Spawn()
    {
        float spawnChance = Random.value;

        foreach (var obj in objects)
        {
            if(spawnChance < obj.spawnChance)
            {
              GameObject obstacle = Instantiate(obj.perfab);
                obstacle.transform.position += transform.position;
                break;
            }
            spawnChance -= obj.spawnChance;
        }

        Invoke(nameof(Spawn), Random.Range(minSpawnRate, maxSpawnRate));
    }
}
