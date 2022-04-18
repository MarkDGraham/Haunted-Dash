using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *       Creator:  Mark G
 * Creation Date:  April 16, 2022
 *   Script Name:  GameplayMgr.cs
 */

public class SpawnMgr : MonoBehaviour
{
    public static SpawnMgr inst;

    private void Awake()
    {
        inst = this;
    }

    // Variables
    public List<GameObject> Spawners;
    public List<GameObject> enemyPrefabs;
    private bool beginSpawn;
    private int spawnNumb;
    private int enemyNumb;
    private float spawnTimer;
    private float spawnTime = 7.0f;

    // Start is called before the first frame update
    void Start()
    {
        beginSpawn = true;
        spawnTimer = spawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(beginSpawn)
        {
            spawnTimer -= Time.deltaTime;
            if (spawnTimer <= 0)
            {
                spawnNumb = Random.Range(0, 3);
                enemyNumb = Random.Range(0, 9);
                Instantiate(enemyPrefabs[enemyNumb], Spawners[spawnNumb].transform);
                spawnTimer = spawnTime;
                if(spawnTime <= 1.0f)
                {
                    spawnTime = 1.0f;
                }
                else
                {
                    spawnTime--;
                }
            }
        }

        if(GameplayMgr.inst.hasLost || GameplayMgr.inst.hasWon)
        {
            beginSpawn = false;
        }
    }
}
