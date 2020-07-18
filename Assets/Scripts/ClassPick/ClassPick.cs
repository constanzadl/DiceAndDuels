using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClassPick : MonoBehaviour
{
    //UnityEngine.SceneManagement.SceneManager.LoadScene("ClassPick");
    string playerClass;
    public Button thiefButton;
    public Button berserkerButton;
    public Button doctorButton;
    public Button shieldHeroButton;
    public Button cancelButton;
    public Button playGameButton;
    public Button backToChoiceButton;
    public GameObject finalChoice;
    public Text classPick;

    public void Thief()
    {
        playerClass = "Thief";
        PlayerPrefs.SetString("playerClass", playerClass);
        ActivatePanel();
    }
    public void Berserker()
    {
        playerClass = "Berserker";
        PlayerPrefs.SetString("playerClass", playerClass);
        ActivatePanel();
    }
    public void Doctor()
    {
        playerClass = "Doctor";
        PlayerPrefs.SetString("playerClass", playerClass);
        ActivatePanel();
    }
    public void ShieldHero()
    {
        playerClass = "ShieldHero";
        PlayerPrefs.SetString("playerClass", playerClass);
        ActivatePanel();
    }
    void ActivatePanel()
    {
        //Turn off Buttons
        thiefButton.interactable = false;
        berserkerButton.interactable = false;
        doctorButton.interactable = false;
        shieldHeroButton.interactable = false;
        cancelButton.interactable = false;
        finalChoice.SetActive(true);
        classPick.text = PlayerPrefs.GetString("playerClass");
    }
    public void BackToChoice()
    {
        playerClass = "";
        PlayerPrefs.SetString("playerClass", playerClass);
        finalChoice.SetActive(false);
        thiefButton.interactable = true;
        berserkerButton.interactable = true;
        doctorButton.interactable = true;
        shieldHeroButton.interactable = true;
        cancelButton.interactable = true;
    }
    public void PlayGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("WaitingLobby");
    }
    // Start is called before the first frame update
}
