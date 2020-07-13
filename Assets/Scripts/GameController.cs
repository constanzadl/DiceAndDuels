﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public PlayerController player;
    public EnemyController enemy;

    //Turn check
    //1 - start turn
    //2 - battle starts
    //3 - ready to reset
    public int battleStage;

    //Player Stats
    public Text playerHP;
    public int playerLife;
    int playerAction;
    int playerMelee;
    int playerMagic;

    //EnemyStats
    public Text enemyHP;
    public int enemyLife;
    int enemyAction;
    int enemyMelee;
    int enemyMagic;

    //Timer
    public Text timerText;
    public float timer;
    float temp;

    // Start is called before the first frame update
    void Start()
    {
        temp = timer;
        battleStage = 1;
        playerHP.text = playerLife.ToString();
        enemyHP.text = enemyLife.ToString();
        timerText.text = timer.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //EnemyController and PlayerController are called to put UI in place
        //Start Turn
        //Start Timer and let player start their turn.
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            timerText.text = timer.ToString("#.00");
        }
        if (battleStage == 1)
        {
            battleStage = 2;
            player.StartTurn();
            enemy.StartTurn();
        }
        if (timer < 0 && battleStage == 2)
        {
            GetEnemyActions();
            GetPlayerActions();
            timerText.text = "00.00";
            BattleStarts();
            //turn off buttons (wip)
        }
        if (battleStage == 3)
        {
            if (playerLife > 0 && enemyLife > 0)
            {
                battleStage = 1;
                timer = temp;
            }
            else
            {
                timerText.text = "GameOver";
            }
        }
        
    }
    //Get action values from player
    void GetPlayerActions()
    {
        playerAction = GameObject.FindGameObjectWithTag("PlayerController").GetComponent<PlayerController>().action;
        playerMagic = GameObject.FindGameObjectWithTag("PlayerController").GetComponent<PlayerController>().magic;
        playerMelee = GameObject.FindGameObjectWithTag("PlayerController").GetComponent<PlayerController>().melee;
    }
    //Get action values from enemy
    void GetEnemyActions()
    {
        enemyAction = GameObject.FindGameObjectWithTag("EnemyController").GetComponent<EnemyController>().enemyAction;
        enemyMagic = GameObject.FindGameObjectWithTag("EnemyController").GetComponent<EnemyController>().enemyMagic;
        enemyMelee = GameObject.FindGameObjectWithTag("EnemyController").GetComponent<EnemyController>().enemyMelee;
    }
    void BattleStarts()
    {
        if ((playerAction % 2 == 0) && (enemyAction % 2 == 0))
        {
            //Both attack
            playerLife -= (enemyMelee + enemyMagic);
            enemyLife -= (playerMelee + playerMagic);
            this.battleStage = 3;
        }
        else if ((playerAction % 2 != 0) && (enemyAction % 2 == 0))
        {
            //Player defends, enemy attacks
            if (playerMelee < enemyMelee)
                playerLife -= (enemyMelee - playerMelee);
            if (playerMagic < enemyMagic)
                playerLife -= (enemyMagic - playerMagic);
            this.battleStage = 3;
        }
        else if ((playerAction % 2 == 0) && (enemyAction % 2 != 0))
        {
            //player attacks, enemy defends
            if (enemyMelee < playerMelee)
                enemyLife -= (playerMelee - enemyMelee);
            if (enemyMagic < playerMagic)
                enemyLife -= (playerMagic - enemyMagic);
            this.battleStage = 3;
        }
        else
        {
            //Both defend, nothing happens
            this.battleStage = 3;
        }
        enemyHP.text = enemyLife.ToString();
        playerHP.text = playerLife.ToString();
        //end of turn
    }
}