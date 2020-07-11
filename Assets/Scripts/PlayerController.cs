using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //Check for One Turn
    bool battlePlayed;
    //Text values will be deleted
    public Text diceOneText;
    public Text diceTwoText;
    public Text diceThreeText;

    //Dice buttons to click
    public Button diceOneButton;
    public Button diceTwoButton;
    public Button diceThreeButton;

    //Dice Images for actions
    public Button diceAction;
    public Button diceMelee;
    public Button diceMagic;

    //Dice number sprites
    public Sprite one;
    public Sprite two;
    public Sprite three;
    public Sprite four;
    public Sprite five;
    public Sprite six;
    public Sprite empty;

    //Player health
    public Text playerHP;
    int hp = 50;

    //Number thrown
    private int diceOne;
    private int diceTwo;
    private int diceThree;

    //Actions
    private int melee;
    private int magic;
    public int action;

    //Number to save clicks.
    public int temp;

    //Timer
    public Text timerText;
    public float timer;

    //reference for enemyStats
    public int enemyAction;
    public int enemyMagic;
    public int enemyMelee;
    public int enemyHP;
    // Start is called before the first frame update
    void Start()
    {
        battlePlayed = false;
        playerHP.text = hp.ToString();
        diceAction.image.sprite = empty;
        diceMelee.image.sprite = empty;
        diceMagic.image.sprite = empty;
        diceOne = Random.Range(1, 7);
        diceTwo = Random.Range(1, 7);
        diceThree = Random.Range(1, 7);
        DiceSpriteChange();
        timerText.text = timer.ToString();
    }
    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            timerText.text = timer.ToString("#.00");
        }
        if (timer <= 0)
        {
            timerText.text = "00.00";
            BattleStart();
            //turn off buttons (wip)
        }
    }
    //Delete Text Values
    void DiceSpriteChange()
    {
        //text to check values on UI
        diceOneText.text = diceOne.ToString();
        switch (diceOne)
        {
            case 1:
                {
                    diceOneButton.image.sprite = one;
                }
                break;
            case 2:
                {
                    diceOneButton.image.sprite = two;
                }
                break;
            case 3:
                {
                    diceOneButton.image.sprite = three;
                }
                break;
            case 4:
                {
                    diceOneButton.image.sprite = four;
                }
                break;
            case 5:
                {
                    diceOneButton.image.sprite = five;
                }
                break;
            case 6:
                {
                    diceOneButton.image.sprite = six;
                }
                break;
            default:
                {
                    diceOneButton.image.sprite = one;
                }
                break;
        }
        diceTwoText.text = diceTwo.ToString();
        switch (diceTwo)
        {
            case 1:
                {
                    diceTwoButton.image.sprite = one;
                }
                break;
            case 2:
                {
                    diceTwoButton.image.sprite = two;
                }
                break;
            case 3:
                {
                    diceTwoButton.image.sprite = three;
                }
                break;
            case 4:
                {
                    diceTwoButton.image.sprite = four;
                }
                break;
            case 5:
                {
                    diceTwoButton.image.sprite = five;
                }
                break;
            case 6:
                {
                    diceTwoButton.image.sprite = six;
                }
                break;
            default:
                {
                    diceTwoButton.image.sprite = one;
                }
                break;
        }
        diceThreeText.text = diceThree.ToString();
        switch (diceThree)
        {
            case 1:
                {
                    diceThreeButton.image.sprite = one;
                }
                break;
            case 2:
                {
                    diceThreeButton.image.sprite = two;
                }
                break;
            case 3:
                {
                    diceThreeButton.image.sprite = three;
                }
                break;
            case 4:
                {
                    diceThreeButton.image.sprite = four;
                }
                break;
            case 5:
                {
                    diceThreeButton.image.sprite = five;
                }
                break;
            case 6:
                {
                    diceThreeButton.image.sprite = six;
                }
                break;
            default:
                {
                    diceThreeButton.image.sprite = one;
                }
                break;
        }
    }
    //Which dice was clicked 
    public void DecisionMakingOne()
    {
        temp = diceOne;
        diceOneButton.image.sprite = empty;
    }
    public void DecisionMakingTwo()
    {
        temp = diceTwo;
        diceTwoButton.image.sprite = empty;
    }
    public void DecisionMakingThree()
    {
        temp = diceThree;
        diceThreeButton.image.sprite = empty;
    }
    public void ActionDecision()
    {
        action = temp;
        switch (temp)
        {
            case 1:
                {
                    diceAction.image.sprite = one;
                }
                break;
            case 2:
                {
                    diceAction.image.sprite = two;
                }
                break;
            case 3:
                {
                    diceAction.image.sprite = three;
                }
                break;
            case 4:
                {
                    diceAction.image.sprite = four;
                }
                break;
            case 5:
                {
                    diceAction.image.sprite = five;
                }
                break;
            case 6:
                {
                    diceAction.image.sprite = six;
                }
                break;
            default:
                {
                    diceAction.image.sprite = empty;
                }
                break;
        }
        temp = 0;
    }
    public void MeleeDecision()
    {
        melee = temp;
        switch (temp)
        {
            case 1:
                {
                    diceMelee.image.sprite = one;
                }
                break;
            case 2:
                {
                    diceMelee.image.sprite = two;
                }
                break;
            case 3:
                {
                    diceMelee.image.sprite = three;
                }
                break;
            case 4:
                {
                    diceMelee.image.sprite = four;
                }
                break;
            case 5:
                {
                    diceMelee.image.sprite = five;
                }
                break;
            case 6:
                {
                    diceMelee.image.sprite = six;
                }
                break;
            default:
                {
                    diceMelee.image.sprite = empty;
                }
                break;
        }
        temp = 0;
    }
    public void MagicDecision()
    {
        magic = temp;
        switch (temp)
        {
            case 1:
                {
                    diceMagic.image.sprite = one;
                }
                break;
            case 2:
                {
                    diceMagic.image.sprite = two;
                }
                break;
            case 3:
                {
                    diceMagic.image.sprite = three;
                }
                break;
            case 4:
                {
                    diceMagic.image.sprite = four;
                }
                break;
            case 5:
                {
                    diceMagic.image.sprite = five;
                }
                break;
            case 6:
                {
                    diceMagic.image.sprite = six;
                }
                break;
            default:
                {
                    diceMagic.image.sprite = empty;
                }
                break;
        }
        temp = 0;
    }
    public void BattleStart()
    {
        if (!battlePlayed)
        {
            enemyAction = GameObject.FindGameObjectWithTag("EnemyController").GetComponent<EnemyController>().enemyAction;
            enemyMagic = GameObject.FindGameObjectWithTag("EnemyController").GetComponent<EnemyController>().enemyMagic;
            enemyMelee = GameObject.FindGameObjectWithTag("EnemyController").GetComponent<EnemyController>().enemyMelee;
            enemyHP = GameObject.FindGameObjectWithTag("EnemyController").GetComponent<EnemyController>().hp;
            //Plater Attacks
            if (action % 2 == 0)
            {
                //EnemyAttacks
                if (enemyAction % 2 == 0)
                {
                    hp -= (enemyMagic + enemyMelee);
                    enemyHP -= (melee + magic);
                }
                //EnemyDefends
                if (enemyAction % 2 != 0)
                {
                    //Player attack is more than enemy defence
                    if (melee > enemyMelee)
                    {
                        enemyHP -= (enemyMelee - melee);
                    }
                    if (magic > enemyMagic)
                    {
                        enemyHP -= (enemyMagic - magic);
                    }
                }
                //Next Turn
            }
            //Player Defends
            else
            {
                //EnemyAttacks
                if (enemyAction % 2 == 0)
                {
                    if (enemyMelee > melee)
                    {
                        hp -= (melee - enemyMelee);
                    }
                    if (enemyMagic > magic)
                    {
                        hp -= (magic - enemyMagic);
                    }
                }
                //EnemyDefends
                //Next Turn
            }
            playerHP.text = hp.ToString();
            //end of turn
            battlePlayed = false;
        }

    }
}
