using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *       Creator:  Mark G
 * Creation Date:  April 16, 2022
 *   Script Name:  ControllerMgr.cs
 */

/*
 * Modification Log:
 *   2022:
 *     April:
 *       16:
 *         - Key binding functionailty added.
 *         - Main keys (Up, Down, Escape) added.
 *         - Script Created.
 */



public class ControllerMgr : MonoBehaviour
{
    public static ControllerMgr inst;

    private void Awake()
    {
        inst = this;
    }


    void Update()
    {
        ProcessControls();
    }

    private void ProcessControls()
    {
        // Escape Key => Pause Game
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;    
            #else
                Application.Quit();
            #endif
        }
    }
}
