using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerControl : MonoBehaviour
{
    public GameController controller;

    //GameObjects

    public GameObject actionSlot;
    public GameObject meleeSlot;
    public GameObject magicSlot;
    public GameObject skillSlot;

    //Actions
    public int melee;
    private Sprite meleeSprite;
    public int magic;
    private Sprite magicSprite;
    public int action;
    private Sprite actionSprite;

    //Special Skills
    public int skill;
    private Sprite skillSprite;
    //Player Class
    string playerClass;
    //Berserker Class
    int berserkerCooldown;

    //Text counter
    float counter;

    //Text Feedback
    public Text actionFeedback;
    public Text playerFeedback;

    int temp;

    private void Start()
    {
        meleeSlot.GetComponent<CanvasGroup>().alpha = 0f;
        magicSlot.GetComponent<CanvasGroup>().alpha = 0f;
        skillSlot.GetComponent<CanvasGroup>().alpha = 0f;
        StartTurn();
    }
    void StartTurn()
    {
        playerClass = PlayerPrefs.GetString("playerClass");
    }
    //BORRAR UPDATE
    private void Update()
    {
        CheckAction();
    }
    public void CheckAction()
    {
        temp = actionSlot.GetComponent<DropDice>().num;
        if (temp > 0)
        {
            meleeSlot.GetComponent<CanvasGroup>().alpha = 1f;
            magicSlot.GetComponent<CanvasGroup>().alpha = 1f;
            skillSlot.GetComponent<CanvasGroup>().alpha = 1f;
            if (temp % 2 == 0)
                actionFeedback.text = "Defending!";
            else
                actionFeedback.text = "Attacking!";
        }
    }
}
