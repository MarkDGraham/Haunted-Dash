using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *       Creator:  Mark G
 * Creation Date:  April 16, 2022
 *   Script Name:  GameplayMgr.cs
 */

/*
 * Modification Log:
 *   2022:
 *     April:
 *       16:
 *         - 
 *         - Script Created.
 */

public class GameplayMgr : MonoBehaviour
{
    public static GameplayMgr inst;

    private void Awake()
    {
        inst = this;
    }

    // Variables:
    private GameObject level;
    private Vector3 playerPosition;
    private Vector3 playerVelocity;
    private float levelSpeed = -5.0f;
    private float speedIncrease = -1.0f;
    private float timer = 5.0f;
    public bool hasWon, hasLost;

    
    void Start()
    {
        level = GameObject.FindGameObjectWithTag("Level");
    }

    void Update()
    {
        if (!hasWon && !hasLost)
        {
            level.transform.Translate(levelSpeed * Time.deltaTime, 0, 0);
            if (levelSpeed >= -15.0f)
            {
                levelSpeed += speedIncrease * Time.deltaTime;
            }

            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                if (speedIncrease > -10.0f)
                {
                    speedIncrease += speedIncrease;
                }
                timer = 5.0f;
            }
        }

        if(level.transform.position.x <= -430)
        {
            hasWon = true;
        }

        if(UIMgr.inst.timeCounter <= 0)
        {
            hasLost = true;
        }
    }

    public void SpeedDecrease(GameObject enemy)
    {
        if(enemy.tag == "Enemy1")
        {
            if (speedIncrease <= -1.0f)
            {
                speedIncrease -= -1.0f;
            }
            else
            {
                speedIncrease -= -1.0f;
            }
            UIMgr.inst.timeCounter -= 1;
        }
        else if(enemy.tag == "Enemy2")
        {
            if (speedIncrease <= -3.0f)
            {
                speedIncrease -= -3.0f;
            }
            else
            {
                speedIncrease -= -1.0f;
            }
            UIMgr.inst.timeCounter -= 2;
        }
        else
        {
            if(speedIncrease <= -5.0f)
            {
                speedIncrease -= -5.0f;
            }
            else
            {
                speedIncrease -= -1.0f;
            }
            UIMgr.inst.timeCounter -= 3;
        }
        levelSpeed = -5.0f;
    }

    public float GetLevelSpeed()
    {
        return levelSpeed;
    }
}
