using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *       Creator:  Mark G
 * Creation Date:  April 16, 2022
 *   Script Name:  EnemyAI.cs
 */

public class EnemyAI : MonoBehaviour
{
    // Variables
    private GameObject player;
    public GameObject enemy;
    private float offset = 4.0f;
    private float speed = 2.5f;
    private float heading;
    private Vector3 truePosition;
    //private float delay = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if(enemy.tag == "Enemy1")
        {
            speed = 7.5f;
        }
        else if(enemy.tag == "Enemy2")
        {
            speed = 5.0f;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x <= player.transform.position.x - offset)
        {
            Destroy(enemy);
        }

        truePosition = player.transform.position - enemy.transform.position;
        heading = Mathf.Atan2(truePosition.y, truePosition.x) * Mathf.Rad2Deg;
        enemy.transform.Translate(Mathf.Cos(heading) * speed * Time.deltaTime, Mathf.Sin(heading) * speed * Time.deltaTime, truePosition.z);

        if(GameplayMgr.inst.hasWon || GameplayMgr.inst.hasLost)
        {
            Destroy(enemy);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(enemy);
        }
    }
}
