using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    
    public void LoadLevel0()
    {
        Loader.LoadScene(Loader.Scene.IP_Level_0);
    }

    public void LoadLevel1()
    {
        Loader.LoadScene(Loader.Scene.IP_Level_1);
    }

    public void LoadLevel2()
    {
        Loader.LoadScene(Loader.Scene.IP_Level_3);
    }
}
