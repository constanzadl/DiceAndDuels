using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeWaiting : MonoBehaviour
{
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 3;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
            UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }
}
