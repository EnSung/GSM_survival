using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameManager : Singleton<IngameManager>
{

    public IngameUIManager _UIManager;
    public Player player;

    [Header("Prefab")]
    public List<GameObject> monsterPrefabs;
    public GameObject expPrefab;


    [Header("list")]
    public List<Item> itemList;

    public GameObject backpackPrefab;

    public GameObject wallMonsterPrefab;

    public GameObject bossMonsterPrefab;

    public GameObject HealObjectPrefab;
    public float gameTime;


    
    protected override void Awake()
    {
        base.Awake();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    private void Update()
    {
        gameTime += Time.deltaTime;
    }
}
