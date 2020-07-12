﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
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

    //Number thrown
    private int diceOne;
    private int diceTwo;
    private int diceThree;

    //Actions
    public int melee;
    public int magic;
    public int action;

    //Number to save clicks.
    public int temp;

    // Start is called before the first frame update
    public void StartTurn()
    {
        diceAction.image.sprite = empty;
        diceMelee.image.sprite = empty;
        diceMagic.image.sprite = empty;
        diceOne = Random.Range(1, 7);
        diceTwo = Random.Range(1, 7);
        diceThree = Random.Range(1, 7);
        DiceSpriteChange();
    }
    //Delete Text Values
    void DiceSpriteChange()
    {
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
}
