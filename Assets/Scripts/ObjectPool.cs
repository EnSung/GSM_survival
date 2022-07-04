using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : Singleton<ObjectPool>
{

    public GameObject monsterPrefab;
    public GameObject wallMonsterPrefab;
    public GameObject bossMonsterPrefab;
    public GameObject expPrefab;



    public Queue<Monster> monsterQueue = new Queue<Monster>();
    public Queue<MonsterWall> monsterWallQueue = new Queue<MonsterWall>();
    public Queue<BossMonster> bossMonsterQueue = new Queue<BossMonster>();
    public Queue<EXPObject> expQueue = new Queue<EXPObject>();

    private void Start()
    {
    }

    public void Initialize(int initCnt)
    {
        for (int i = 0; i < initCnt; i++)
        {

        }
    }

    public T CreateObject<T>(GameObject prefab)
    {
        GameObject newObj = Instantiate(prefab);
        newObj.transform.SetParent(Instance.gameObject.transform);
        return newObj.GetComponent<T>();
    }

    public Monster GetMonster(Vector2 pos)
    {
        if(monsterQueue.Count > 0)
        {
            Monster obj = monsterQueue.Dequeue();
            obj.transform.position = pos;
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            var newObj = Instance.CreateObject<Monster>(monsterPrefab);
            newObj.gameObject.SetActive(true);
            newObj.transform.position = pos;
            return newObj;
        }
    }

    public MonsterWall GetMonsterwall(Vector2 pos)
    {
        if (monsterWallQueue.Count > 0)
        {
            MonsterWall obj = monsterWallQueue.Dequeue();
            obj.transform.position = pos;
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            MonsterWall newObj = Instance.CreateObject<MonsterWall>(wallMonsterPrefab);
            newObj.gameObject.SetActive(true);
            newObj.transform.position = pos;
            return newObj;
        }
    }
    public BossMonster GetBossMonster(Vector2 pos)
    {
        if (monsterQueue.Count > 0)
        {
            BossMonster obj = bossMonsterQueue.Dequeue();
            obj.transform.position = pos;
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            var newObj = Instance.CreateObject<BossMonster>(bossMonsterPrefab);
            newObj.gameObject.SetActive(true);
            newObj.transform.position = pos;
            return newObj;
        }
    }

    public EXPObject GetExp(Vector2 pos)
    {
        if (monsterQueue.Count > 0)
        {
            EXPObject obj = expQueue.Dequeue();
            obj.transform.position = pos;
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            EXPObject newObj = Instance.CreateObject<EXPObject>(expPrefab);
            newObj.gameObject.SetActive(true);
            newObj.transform.position = pos;
            return newObj;
        }
    }
}
