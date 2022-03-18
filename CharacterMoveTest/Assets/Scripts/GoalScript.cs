using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalScript : MonoBehaviour
{
    // Start is called before the first frame update

    CircleCollider2D circleCollider;
    void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            int i = SceneManager.GetActiveScene().buildIndex;
            
                Loader.Scene s = (Loader.Scene)i+1;
                if((int)s < Loader.NumberOfScenes)
                {
                    Loader.LoadScene(s);

                }
            else
            {
                Loader.LoadScene(Loader.Scene.WinScreen);
            }
        }
    }
}
