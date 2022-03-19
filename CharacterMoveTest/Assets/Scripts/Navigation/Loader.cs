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
        MainMenu,
        Loading,
        RestartMenu,
        Level0,
        Level1,
        level2,
        level3,
        level4,
        level5,
        WinScreen,
    }

    public static Scene lastActiveScene;
    private static Action onLoaderCallback;

    
    public static void LoadScene(Scene scene)
    {
        SunManager.sunObjects.Clear();
        if (scene != Scene.RestartMenu && scene != Scene.Loading && scene != Scene.MainMenu)
        {
            lastActiveScene = scene;
        }
        //set the loader callback function to load the target scene
        onLoaderCallback = () =>
        {
            SceneManager.LoadScene(scene.ToString());
        };

        //load the loading scene
        SceneManager.LoadScene(Scene.Loading.ToString());
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
