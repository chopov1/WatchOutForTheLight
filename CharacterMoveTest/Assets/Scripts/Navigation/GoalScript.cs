using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalScript : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            LoadGoalScene();  
        }
    }

    private void LoadGoalScene()
    {
        int i = SceneManager.GetActiveScene().buildIndex;

        Loader.Scene s = (Loader.Scene)i + 1;
        if ((int)s < Loader.NumberOfScenes)
        {
            Loader.LoadScene(s);

        }
        else
        {
            Loader.LoadScene(Loader.Scene.WinScreen);
        }
    }
}
