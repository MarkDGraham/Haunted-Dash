using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMgr : MonoBehaviour
{

    public static UIMgr inst;

    private void Awake()
    {
        inst = this;
    }

    // Variables
    public float timeCounter;
    public Text timerText;
    public Text conditionText;

    // Start is called before the first frame update
    void Start()
    {
        timeCounter = 59.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameplayMgr.inst.hasWon && !GameplayMgr.inst.hasLost)
        {
            timeCounter -= Time.deltaTime;
        }

        timerText.text = timeCounter.ToString("F0");

        if(GameplayMgr.inst.hasWon)
        {
            conditionText.text = "You've Escaped!";
            conditionText.color = Color.green;
        }
        else if(GameplayMgr.inst.hasLost)
        {
            conditionText.text = "Forever Mine!!";
            conditionText.color = Color.red;
        }
        else
        {
            conditionText.text = string.Empty;
        }

    }
}
