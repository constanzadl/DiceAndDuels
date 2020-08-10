using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public PlayerControl playerControl;

    bool actionsChosen;

    public Text timerText;
    public float timer;
    public int battleStage;
    // Start is called before the first frame update
    void Start()
    {
        actionsChosen = false;   
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0 && battleStage != 4)
        {
            timer -= Time.deltaTime;
            timerText.text = timer.ToString("#.00");
        }

        playerControl.CheckAction();
    }
    public void Done()
    {
        actionsChosen = true;
    }
}
