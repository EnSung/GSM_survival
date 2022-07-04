using System.Collections.Generic;
using UnityEngine;

public class HeadOfMonsterSpawner : MonoBehaviour
{
    public MonsterSpawner[] spawners;
    public bool isWallSpawn;
    public bool isBossSpawn;

    public float meat_spawnTime;
    void Start()
    {
        
    }

    void Update()
    {
        meat_spawnTime += Time.deltaTime;

        if(meat_spawnTime >= 30)
        {
            HealObjectSpawn();
        }
        
        if((int)(IngameManager.Instance.gameTime) %300 == 0 && (int)(IngameManager.Instance.gameTime) !=0)
        {
            wallMonsterSpawn();
            isWallSpawn = true;
        }
        else
        {
            isWallSpawn=false;
        }

        if((int)(IngameManager.Instance.gameTime) % 180 == 0 && (int)(IngameManager.Instance.gameTime) != 0)
        {
            bossMonsterSpawn();
            isBossSpawn = true;
        }
        else
        {
            isBossSpawn = false;
        }
    }

    public void wallMonsterSpawn()
    {
        if(!isWallSpawn)
            Instantiate(IngameManager.Instance.wallMonsterPrefab, IngameManager.Instance.player.transform.position, Quaternion.identity);
    }

    public void bossMonsterSpawn()
    {
        if(!isBossSpawn)
            Instantiate(IngameManager.Instance.bossMonsterPrefab, IngameManager.Instance.player.transform.position +new Vector3(0,17) , Quaternion.identity);
    }

    public void HealObjectSpawn()
    {
        Instantiate(IngameManager.Instance.HealObjectPrefab, new Vector2(Random.Range(-31.97f, 31.97f), Random.Range(-20.67292f, 20.67292f)), Quaternion.identity);
        meat_spawnTime = 0;
    }
}
