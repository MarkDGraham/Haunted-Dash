using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    // Variables:
    private Rigidbody playerRB;
    private bool isJump;
    private float thrust = 130.0f;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessControls();
    }

    private void ProcessControls()
    {
        // Down Arrow => Slide
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            // Add Animation later?
        }

        // Up Arrow => Jump
        if (Input.GetKeyDown(KeyCode.UpArrow) && !isJump)
        {
            playerRB.AddForce(0, thrust, 0, ForceMode.Impulse);
            isJump = true;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Level")
        {
            isJump = false;
        }
        else
        {
            GameplayMgr.inst.SpeedDecrease(other.gameObject);
            
        }
    }
}
