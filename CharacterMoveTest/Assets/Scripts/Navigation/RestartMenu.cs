using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartMenu : MonoBehaviour
{
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
        Loader.LoadScene(Loader.Scene.UI_Main_Menu);
    }
}
