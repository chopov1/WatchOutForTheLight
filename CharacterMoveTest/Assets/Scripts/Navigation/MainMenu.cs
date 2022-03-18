using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
