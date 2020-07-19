using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public PlayerController player;
    public EnemyController enemy;

    //Start/none/EndOfTurn
    public Text turnFeedback;

    //Turn check
    //1 - start turn
    //2 - battle starts
    //3 - ready to reset
    public int battleStage;

    //Player Stats
    int playerAction;
    int playerMelee;
    int playerMagic;
    int specialAction;

    //Stats by Class
    public Text playerHP;
    public int playerLife;
    string playerClass;
    string skill;
    int berserkerCoolDown;

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
        GetPlayerInitialStats();
        temp = timer;
        battleStage = 1;
        playerHP.text = playerLife.ToString();
        enemyHP.text = enemyLife.ToString();
        timerText.text = timer.ToString();
        turnFeedback.text = "Start!";
        if (playerClass == "Berserker")
        {
            berserkerCoolDown = 8;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //EnemyController and PlayerController are called to put UI in place
        //Start Turn
        //Start Timer and let player start their turn.
        if (timer > 0 && battleStage != 4)
        {
            timer -= Time.deltaTime;
            timerText.text = timer.ToString("#.00");
        }
        if (battleStage == 1)
        {
            turnFeedback.text = "Battle!";
            battleStage = 2;
            player.StartTurn();
            enemy.StartTurn();
        }
        if (timer < 0 && battleStage == 2)
        {
            turnFeedback.text = "";
            GetEnemyActions();
            GetPlayerActions();
            timerText.text = "00.00";
            BattleStarts();
            //turn off buttons (wip)
        }
        if (battleStage == 3)
        {
            timer -= Time.deltaTime;
            turnFeedback.text = "End of Turn!";
            timerText.text = "";
            if (timer <= 0)
            {
                battleStage = 4;
            }
        }
        if (battleStage == 4)
        {
            if (playerLife > 0 && enemyLife > 0)
            {
                //Se va a quedar un ratito el letrero ahí? Cuánto tiempo?
                battleStage = 1;
                timer = temp;
            }
            else
            {
                timerText.text = "GameOver";
            }
        }
        
    }
    //Get player's class, hp and available skill
    void GetPlayerInitialStats()
    {
        playerLife = GameObject.FindGameObjectWithTag("ClassPicking").GetComponent<ClassStats>().hp;
        playerClass = GameObject.FindGameObjectWithTag("ClassPicking").GetComponent<ClassStats>().playerClass;
        skill = GameObject.FindGameObjectWithTag("ClassPicking").GetComponent<ClassStats>().skill;
    }
    //Get action values from player
    void GetPlayerActions()
    {
        playerAction = GameObject.FindGameObjectWithTag("PlayerController").GetComponent<PlayerController>().action;
        playerMagic = GameObject.FindGameObjectWithTag("PlayerController").GetComponent<PlayerController>().magic;
        playerMelee = GameObject.FindGameObjectWithTag("PlayerController").GetComponent<PlayerController>().melee;
        specialAction = GameObject.FindGameObjectWithTag("PlayerController").GetComponent<PlayerController>().specialAct;
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
        //Berserker cooldown and doubles the attack
        if (skill == "Double Damage")
        {
            if (berserkerCoolDown > 0)
            {
                berserkerCoolDown -= specialAction;
            }
            else
            {
                //double melee
                playerMelee *= 2;
            }
        }
        //Thief always attacks
        if (skill == "Hidden dagger")
        {
            if (specialAction > 0)
            {
                enemyLife -= specialAction;
            }
        }
        if ((playerAction % 2 != 0) && (enemyAction % 2 != 0))
        {
            //Both attack
            if (skill == "Reflect")
            {
                playerMelee -= 2;
            }
            playerLife -= (enemyMelee + enemyMagic);
            enemyLife -= (playerMelee + playerMagic);
            this.battleStage = 3;
        }
        else if ((playerAction % 2 == 0) && (enemyAction % 2 != 0))
        {
            //Player defends, enemy attacks
            if (skill == "Heal")
            {
                playerLife += specialAction;
            }
            if (skill == "Reflect")
            {
                enemyLife -= specialAction;//(int)Mathf.Floor(specialAction / 2);
            }
            if (playerMelee < enemyMelee)
                playerLife -= (enemyMelee - playerMelee);
            if (playerMagic < enemyMagic)
                playerLife -= (enemyMagic - playerMagic);
            this.battleStage = 3;
        }
        else if ((playerAction % 2 != 0) && (enemyAction % 2 == 0))
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
        timer = 3;
    }
}
