using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunManager : MonoBehaviour
{
    public static List<SunRayCast> sunObjects = new List<SunRayCast>();

    int sunsHittingPlayer;
    public delegate void PlayerHitEventHandler(bool isHit);
    public static event PlayerHitEventHandler OnPlayerHit;

    // Start is called before the first frame update
    
    void Start()
    {

    }

    private void FixedUpdate()
    {
        isPlayerHit();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    

    public void isPlayerHit()
    {
        sunsHittingPlayer = 0;
        foreach(var sun in sunObjects)
        {
            if (sun.isHittingPlayer)
            {
                sunsHittingPlayer++;
            }
        }
        if(sunsHittingPlayer > 0)
        {
            if(OnPlayerHit != null)
                OnPlayerHit(true);
        }
        else
        {
            if(OnPlayerHit != null)
                OnPlayerHit(false);
        }
    }
}
