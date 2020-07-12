using System.Collections;
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
            GetPlayerActions();
            GetEnemyActions();
        }
        if (timer < 0 && battleStage == 2)
        {
            timerText.text = "00.00";
            BattleStarts();
            //turn off buttons (wip)
        }
        if (battleStage == 3)
        {
            timerText.text = "End of turn";
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
    //MATH IS WRONG BUT TURN ENDS. HAVE TO FIX BATTLE STARTS AND MODIFY ENEMY HEALTH METHODS.
    void BattleStarts()
    {
        Debug.Log("battle starts");
        if (playerAction % 2 == 0)
        {
            //Enemy is being attacked (Can defend or not)
            ModifyEnemyHealth(playerMelee, playerMagic);
            //Enemy attacks back
            playerLife -= (enemyMagic + enemyMelee);
            //Next Turn
            this.battleStage = 3;
        }
        //Player Defends
        else
        {
            //Enemy attacks
            if (enemyAction % 2 == 0)
            {
                if (playerMelee < enemyMelee)
                    playerLife -= (enemyMelee - playerMelee);
                if (playerMagic < enemyMagic)
                    playerLife -= (enemyMagic - enemyMagic);
            }
            //If both enemy and player defend, nothing happens.
            //Next Turn
            this.battleStage = 3;
        }
        playerHP.text = playerLife.ToString();
        //end of turn
    }

    void ModifyEnemyHealth(int meleeDamage, int magicDamage)
    {
        //Enemy doesn't defend and is being attacked
        if (enemyAction % 2 == 0)
        {
            enemyLife -= (meleeDamage + magicDamage);
        }
        //Enemy defends and is being attacked
        else
        {
            if (enemyMelee < meleeDamage)
                enemyLife -= (enemyMelee - meleeDamage);
            if (enemyMagic < magicDamage)
                enemyLife -= (enemyMagic - magicDamage);
        }

    }
}
