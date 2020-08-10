using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    //Number thrown
    private int diceOne;
    private int diceTwo;
    private int diceThree;
    //Images UI
    public Image diceOneSprite;
    public Image diceTwoSprite;
    public Image diceThreeSprite;
    //Dice number sprites
    public Sprite one;
    public Sprite two;
    public Sprite three;
    public Sprite four;
    public Sprite five;
    public Sprite six;
    //Action dice
    public int enemyAction;
    public int enemyMelee;
    public int enemyMagic;

    // Start is called before the first frame update
    public void StartTurn()
    {
        diceOne = Random.Range(1, 7);
        diceTwo = Random.Range(1, 7);
        diceThree = Random.Range(1, 7);
        DiceSpriteChange();
        //change for random actions
        enemyAction = diceOne;
        enemyMelee = diceTwo;
        enemyMagic = diceThree;
    }
    void DiceSpriteChange()
    {
        switch (diceOne)
        {
            case 1:
                {
                    diceOneSprite.sprite = one;
                }
                break;
            case 2:
                {
                    diceOneSprite.sprite = two;
                }
                break;
            case 3:
                {
                    diceOneSprite.sprite = three;
                }
                break;
            case 4:
                {
                    diceOneSprite.sprite = four;
                }
                break;
            case 5:
                {
                    diceOneSprite.sprite = five;
                }
                break;
            case 6:
                {
                    diceOneSprite.sprite = six;
                }
                break;
            default:
                {
                    diceOneSprite.sprite = one;
                }
                break;
        }
        switch (diceTwo)
        {
            case 1:
                {
                    diceTwoSprite.sprite = one;
                }
                break;
            case 2:
                {
                    diceTwoSprite.sprite = two;
                }
                break;
            case 3:
                {
                    diceTwoSprite.sprite = three;
                }
                break;
            case 4:
                {
                    diceTwoSprite.sprite = four;
                }
                break;
            case 5:
                {
                    diceTwoSprite.sprite = five;
                }
                break;
            case 6:
                {
                    diceTwoSprite.sprite = six;
                }
                break;
            default:
                {
                    diceTwoSprite.sprite = one;
                }
                break;
        }
        switch (diceThree)
        {
            case 1:
                {
                    diceThreeSprite.sprite = one;
                }
                break;
            case 2:
                {
                    diceThreeSprite.sprite = two;
                }
                break;
            case 3:
                {
                    diceThreeSprite.sprite = three;
                }
                break;
            case 4:
                {
                    diceThreeSprite.sprite = four;
                }
                break;
            case 5:
                {
                    diceThreeSprite.sprite = five;
                }
                break;
            case 6:
                {
                    diceThreeSprite.sprite = six;
                }
                break;
            default:
                {
                    diceThreeSprite.sprite = one;
                }
                break;
        }
    }
}
