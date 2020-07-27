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
    }
    void DiceSpriteChange()
    {
        diceOneButton.image.sprite = diceSprites[diceOne];
        diceTwoButton.image.sprite = diceSprites[diceTwo];
        diceThreeButton.image.sprite = diceSprites[diceThree];
    }
    //Which dice was clicked 
    public void DecisionMakingOne()
    {
        if (temp == 0)
        {
            temp = diceOne;
            numberChosen.text = "Number: " + diceOne.ToString();
            diceOneButton.image.sprite = diceSprites[0];
            diceOneButton.interactable = false;
        }
    }
    public void DecisionMakingTwo()
    {
        if (temp == 0)
        {
            temp = diceTwo;
            numberChosen.text = "Number: " + diceTwo.ToString();
            diceTwoButton.image.sprite = diceSprites[0];
            diceTwoButton.interactable = false;
        }
    }
    public void DecisionMakingThree()
    {
        if (temp == 0)
        {
            numberChosen.text = "Number: " + diceThree.ToString();
            temp = diceThree;
            diceThreeButton.image.sprite = diceSprites[0];
            diceThreeButton.interactable = false;
        }
    }
    public void ActionDecision()
    {
        action = temp;
        diceAction.image.sprite = diceSprites[action];
        if (temp % 2 == 0)
            actionFeedback.text = "Defending!";
        else
            actionFeedback.text = "Attacking!";
        diceAction.interactable = false;
        temp = 0;
        diceMelee.interactable = true;
        diceMagic.interactable = true;
        diceSkill.interactable = true;
        numberChosen.text = " ";
    }
    public void MeleeDecision()
    {
        melee = temp;
        diceMelee.image.sprite = diceSprites[melee];
        diceMelee.interactable = false;
        temp = 0;
        numberChosen.text = " ";
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
