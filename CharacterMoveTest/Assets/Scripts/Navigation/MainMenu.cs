using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    
    public void PlayGame()
    {
        Loader.LoadScene(Loader.Scene.IP_Level_0);
    }

    public void LoadTutorial()
    {
        Loader.LoadScene(Loader.Scene.UI_Tutorial);
    }

    public void BackToMenu()
    {
        Loader.LoadScene(Loader.Scene.UI_Main_Menu);
    }

}
