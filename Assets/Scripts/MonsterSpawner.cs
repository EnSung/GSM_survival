using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public float currentSpawnTimer;
    void Start()
    {
        
    }
    
    void Update()
    {
        if(Time.time >= currentSpawnTimer)
        {
            SpawnMonster();
        }    
    }

    public void SpawnMonster()
    {
        Instantiate(IngameManager.Instance.monsterPrefabs[0],transform.position,Quaternion.identity);

        currentSpawnTimer = Time.time + Random.Range(2, 9);
    }
}
