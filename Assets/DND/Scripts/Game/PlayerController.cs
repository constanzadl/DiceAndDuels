using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameController controller;

    //Dice buttons to click
    public Button diceOneButton;
    public Button diceTwoButton;
    public Button diceThreeButton;

    //Dice Images for actions
    public Button diceAction;
    public Button diceMelee;
    public Button diceMagic;
    public Button diceSkill;

    //Dice number sprites
    public Sprite[] diceSprites;

    //Number thrown
    private int diceOne;
    private int diceTwo;
    private int diceThree;

    //Actions
    public int melee;
    public int magic;
    public int action;
    public int specialAct;

    //Number to save clicks.
    int temp = 0;

    //Text counter
    float counter;

    //Text Feedback
    public Text actionFeedback;
    public Text numberChosen;
    public Text playerFeedback;

    //Player Class
    string playerClass;

    //Berserker Class
    int berserkerCooldown;

    // Start is called before the first frame update
    public void StartTurn()
    {
        playerClass = PlayerPrefs.GetString("playerClass");
        diceAction.image.sprite = diceSprites[0];
        diceMelee.image.sprite = diceSprites[0];
        diceMagic.image.sprite = diceSprites[0];
        diceSkill.image.sprite = diceSprites[0];
        diceOne = Random.Range(1, 7);
        diceTwo = Random.Range(1, 7);
        diceThree = Random.Range(1, 7);
        DiceSpriteChange();
        diceMelee.interactable = false;
        diceMagic.interactable = false;
        diceSkill.interactable = false;
    }
    //Delete Text Values
    private void Update()
    {
        counter -= Time.deltaTime;
        if (counter <= 0)
        {
            playerFeedback.text = "";
        }
        berserkerCooldown = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().berserkerCoolDown;
    }
    void DiceSpriteChange()
    {
        diceOneButton.image.sprite = diceSprites[diceOne];
        diceTwoButton.image.sprite = diceSprites[diceTwo];
        diceThreeButton.image.sprite = diceSprites[diceThree];
    }
    //Which dice was clicked 

    public void MeleeDecision()
    {
        if (berserkerCooldown == 0 && specialAct != 0)
        {
            diceMelee.interactable = false;
        }
        else
        {
            melee = temp;
            diceMelee.image.sprite = diceSprites[melee];
            diceMelee.interactable = false;
            temp = 0;
            numberChosen.text = " ";
        }
    }
    public void MagicDecision()
    {
        magic = temp;
        diceMagic.image.sprite = diceSprites[magic];
        diceMagic.interactable = false;
        temp = 0;
        numberChosen.text = " ";
    }
    public void SpecialAction()
    {
        if (playerClass == "Thief" && temp > 3)
        {
            Debug.Log(playerClass);
            Debug.Log(temp);
            specialAct = 0;
            playerFeedback.text = "Number must be 3 or less.";
            counter = 2;
        }
        else if (playerClass == "Doctor" && temp % 2 != 0)
        {
            specialAct = 0;
            playerFeedback.text = "Number must be even.";
            counter = 2;
        }
        else
        {
            specialAct = temp;
            diceSkill.image.sprite = diceSprites[specialAct];
            diceSkill.interactable = false;
            temp = 0;
        }
    }
}
