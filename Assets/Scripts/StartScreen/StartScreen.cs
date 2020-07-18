using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
    string playerClass;
    //Make the class available through all the scenes
    private void Start()
    {
        if (!PlayerPrefs.HasKey("playerClass"))
        {
            playerClass = "";
            PlayerPrefs.SetString("playerClass", playerClass);
        }
        else if (PlayerPrefs.HasKey("playerClass"))
        {
            playerClass = "";
        }
    }
    //Go to pick a class
    public void Play()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("ClassPick");
    }
    //Go to the Store
}
