using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public PlayerController player;
    public EnemyController enemy;

    //Quit or PlayAgain
    public GameObject endGame;
    //Dice to activate and deactivate turn based
    //Dice buttons to click
    Button diceOneButton;
    Button diceTwoButton;
    Button diceThreeButton;

    //Dice Images for actions
    Button diceAction;
    Button diceMelee;
    Button diceMagic;
    Button diceSkill;

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
    Text actionFeedback;

    //Stats by Class
    public Text playerHP;
    public int playerLife;
    string playerClass;
    string skill;
    public int berserkerCoolDown;
    public Text bCoolDown;

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
        actionFeedback = GameObject.FindGameObjectWithTag("PlayerController").GetComponent<PlayerController>().actionFeedback;
        if (playerClass == "Berserker")
        {
            berserkerCoolDown = 8;
            bCoolDown.text = "Cooldown: " + berserkerCoolDown.ToString();
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
            turnFeedback.text = "Choose your action!";
            battleStage = 2;
            player.StartTurn();
            enemy.StartTurn();
        }
        playerAction = GameObject.FindGameObjectWithTag("PlayerController").GetComponent<PlayerController>().action;
        if (playerAction != 0)
        {
            turnFeedback.text = " ";
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
                endGame.SetActive(true);
                diceOneButton.interactable = false;
                diceTwoButton.interactable = false;
                diceThreeButton.interactable = false;
                diceAction.interactable = false;
                diceMelee.interactable = false;
                diceMagic.interactable = false;
                diceSkill.interactable = false;
            }
        }
        
    }
    //Get player's class, hp and available skill
    void GetPlayerInitialStats()
    {
        //Stats by class
        playerLife = GameObject.FindGameObjectWithTag("ClassPicking").GetComponent<ClassStats>().hp;
        playerClass = GameObject.FindGameObjectWithTag("ClassPicking").GetComponent<ClassStats>().playerClass;
        skill = GameObject.FindGameObjectWithTag("ClassPicking").GetComponent<ClassStats>().skill;

        //Stats by turn
        diceOneButton = GameObject.FindGameObjectWithTag("PlayerController").GetComponent<PlayerController>().diceOneButton;
        diceTwoButton = GameObject.FindGameObjectWithTag("PlayerController").GetComponent<PlayerController>().diceTwoButton;
        diceThreeButton = GameObject.FindGameObjectWithTag("PlayerController").GetComponent<PlayerController>().diceThreeButton;
        diceAction = GameObject.FindGameObjectWithTag("PlayerController").GetComponent<PlayerController>().diceAction;
        diceMelee = GameObject.FindGameObjectWithTag("PlayerController").GetComponent<PlayerController>().diceMelee;
        diceMagic = GameObject.FindGameObjectWithTag("PlayerController").GetComponent<PlayerController>().diceMagic;
        diceSkill = GameObject.FindGameObjectWithTag("PlayerController").GetComponent<PlayerController>().diceSkill;
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
        actionFeedback.text = "";
        //Berserker cooldown and doubles the attack
        if (skill == "Double Damage")
        {
            if (berserkerCoolDown > 0)
            {
                berserkerCoolDown -= specialAction;
                if (berserkerCoolDown < 0)
                {
                    berserkerCoolDown = 0;
                }
                bCoolDown.text = "Cooldown: " + berserkerCoolDown.ToString();
            }
            else
            {
                //double melee
                if (playerAction % 2 != 0)
                {
                    playerMelee = specialAction * 2;
                    berserkerCoolDown = 8;
                }
            }
        }
        //Thief always attacks
        else if (skill == "Hidden dagger")
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
                enemyLife -= (int)Mathf.Floor(specialAction / 2);
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
        diceOneButton.interactable = true;
        diceTwoButton.interactable = true;
        diceThreeButton.interactable = true;
        diceAction.interactable = true;
        diceMelee.interactable = true;
        diceMagic.interactable = true;
        diceSkill.interactable = true;
        //end of turn
        timer = 3;
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void PlayAgain()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("ClassPick");
    }
}
