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
    public int specialAct;

    //Number to save clicks.
    public int temp;

    //Action Feedback
    public Text actionFeedback;

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
        diceOneButton.interactable = false;
    }
    public void DecisionMakingTwo()
    {
        temp = diceTwo;
        diceTwoButton.image.sprite = empty;
        diceTwoButton.interactable = false;
    }
    public void DecisionMakingThree()
    {
        temp = diceThree;
        diceThreeButton.image.sprite = empty;
        diceThreeButton.interactable = false;
    }
    public void ActionDecision()
    {
        action = temp;
        switch (temp)
        {
            case 1:
                {
                    diceAction.image.sprite = one;
                    actionFeedback.text = "Attacking!";
                }
                break;
            case 2:
                {
                    diceAction.image.sprite = two;
                    actionFeedback.text = "Defending!";

                }
                break;
            case 3:
                {
                    diceAction.image.sprite = three;
                    actionFeedback.text = "Attacking!";
                }
                break;
            case 4:
                {
                    diceAction.image.sprite = four;
                    actionFeedback.text = "Defending!";
                }
                break;
            case 5:
                {
                    diceAction.image.sprite = five;
                    actionFeedback.text = "Attacking!";
                }
                break;
            case 6:
                {
                    diceAction.image.sprite = six;
                    actionFeedback.text = "Defending!";
                }
                break;
            default:
                {
                    diceAction.image.sprite = empty;
                    action = 0;
                }
                break;
        }
        diceAction.interactable = false;
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
                    melee = 0;
                }
                break;
        }
        diceMelee.interactable = false;
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
                    magic = 0;

                }
                break;
        }
        diceMagic.interactable = false;
        temp = 0;
    }
    public void SpecialAction()
    {
        if (temp > 3)
        {
            specialAct = 0;
            //Feedback que es mayor a 3 y no se puede 
        }
        else
        {
            specialAct = temp;
            switch (temp)
            {
                case 1:
                    {
                        diceSkill.image.sprite = one;
                    }
                    break;
                case 2:
                    {
                        diceSkill.image.sprite = two;
                    }
                    break;
                case 3:
                    {
                        diceSkill.image.sprite = three;
                    }
                    break;
                default:
                    {
                        diceSkill.image.sprite = empty;
                        specialAct = 0;
                    }
                    break;
            }
            diceSkill.interactable = false;
            temp = 0;
        }
    }
}
