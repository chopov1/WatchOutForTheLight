using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader 
{
    public static int NumberOfScenes = 5;
    public enum Scene
    {
        UI_Main_Menu,
        UI_Loading,
        UI_Restart_Menu,
        IP_Level_0,
        IP_Level_1,
        IP_Level_2,
        IP_Level_3,
        IP_Level_4,
        IP_Level_5,
        UI_Win_Screen,
    }

    public static Scene lastActiveScene;
    private static Action onLoaderCallback;

    
    public static void LoadScene(Scene scene)
    {
        SunManager.sunObjects.Clear();
        if (scene != Scene.UI_Restart_Menu && scene != Scene.UI_Loading && scene != Scene.UI_Main_Menu)
        {
            lastActiveScene = scene;
        }
        //set the loader callback function to load the target scene
        onLoaderCallback = () =>
        {
            SceneManager.LoadScene(scene.ToString());
        };

        //load the loading scene
        SceneManager.LoadScene(Scene.UI_Loading.ToString());
    }

    public static void LoaderCallBack()
    {
        //triggered after the first update which lets the screen refresh
        //execute the loadercallback function which will load the target screen
        if(onLoaderCallback != null)
        {
            onLoaderCallback();
            onLoaderCallback = null;
        }
    }
}
