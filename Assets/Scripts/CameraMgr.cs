using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *       Creator:  Mark G
 * Creation Date:  April 16, 2022
 *   Script Name:  CameraMgr.cs
 */

/*
 * Modification Log:
 *   2022:
 *     April:
 *       16:
 *         - Adjusting camera to match player box added.
 *         - Script Created.
 */

public class CameraMgr : MonoBehaviour
{
    // Variables:
    private GameObject player;
    private Camera cameraMain;
    private float offsetYTop = 2.0f, offsetYBot = 4.0f;
    private float offsetX = 2.0f;

    void Start()
    {
        player = GameObject.Find("Player");
        cameraMain = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.y >= cameraMain.transform.position.y + offsetYTop)
        {
            cameraMain.transform.Translate(new Vector3(0, 10.0f * Time.deltaTime, 0));
        }

        if (player.transform.position.x <= cameraMain.transform.position.x - offsetX)
        {
            cameraMain.transform.Translate(new Vector3(-5.0f * Time.deltaTime, 0, 0));
        }

        if (player.transform.position.y <= cameraMain.transform.position.y - offsetYBot)
        {
            cameraMain.transform.Translate(new Vector3(0, -10.0f * Time.deltaTime, 0));
        }
    }
}
