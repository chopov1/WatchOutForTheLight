using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            restart();
        }
    }

    public void restart()
    {
        Loader.LoadScene(Loader.lastActiveScene);
    }

    public void BackToMenu()
    {
        Loader.LoadScene(Loader.Scene.MainMenu);
    }
}
