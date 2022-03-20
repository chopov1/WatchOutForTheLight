using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunRayCast : MonoBehaviour
{
    public LayerMask maskToIgnore;

    public bool isHittingPlayer;
    //IDEA
    //draw 2 raycasts, 1 that goes from sun to top of players head, and 1 that goes from sun to players feet. 
    //If the raycast are not obstructed, start a timer countdown 
    public Transform playerTransform;
    // Start is called before the first frame update
    
    void Start()
    {
        SunManager.sunObjects.Add(this);
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector2 direction = playerTransform.position - gameObject.transform.position;
        //Ray sunToPlayer = new Ray(gameObject.transform.position, direction);
        Debug.DrawRay(gameObject.transform.position, direction);
        RaycastHit2D headHit = Physics2D.Raycast(transform.position, direction, Mathf.Infinity, maskToIgnore);
        if (headHit.collider != null)
        {
            if (headHit.collider.tag == "Player")
            {
                isHittingPlayer = true;
            }
            else
            {
                isHittingPlayer = false;
            }
        }
    }
    void Update()
    {
        
        
    }

    public float findDistance(Vector2 v1, Vector2 v2)
    {
        return (v2.y - v1.y) / (v2.x - v1.x);
    }

    

    
}
