using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClassStats : MonoBehaviour
{
    public int hp;
    public string skill;
    public string playerClass;
    public Text specialAction;

    // Start is called before the first frame update
    private void Start()
    {
        playerClass = PlayerPrefs.GetString("playerClass");
        switch (playerClass)
        {
            case "Thief":
                {
                    ThiefClass();
                }
                break;
            case "Berserker":
                {
                    BerserkerClass();
                }
                break;
            case "Doctor":
                {
                    DoctorClass();
                }
                break;
            case "ShieldHero":
                {
                    ShieldHeroClass();
                }
                break;
            default:
                break;
        }
        specialAction.text = skill;
    }
    public void ThiefClass()
    {
        this.hp = 20;
        skill = "Hidden Dagger";
        
    }
    public void BerserkerClass()
    {
        this.hp = 30;
        skill = "Double Damage";
    }
    public void DoctorClass()
    {
        this.hp = 20;
        skill = "Heal";
    }
    public void ShieldHeroClass()
    {
        this.hp = 25;
        skill = "Reflect";
    }
}
