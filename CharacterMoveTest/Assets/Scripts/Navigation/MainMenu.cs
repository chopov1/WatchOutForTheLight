using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    
    public void LoadLevel0()
    {
        Loader.LoadScene(Loader.Scene.Level0);
    }

    public void LoadLevel1()
    {
        Loader.LoadScene(Loader.Scene.Level1);
    }

    public void LoadLevel2()
    {
        Loader.LoadScene(Loader.Scene.level2);
    }
}
