using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    //BoxCollider2D doorCollider;
    SpriteRenderer spriteRenderer;
    public GameObject activator;
    public GameObject activator2;
    public bool defaultState;
    bool doorState;
    
    // Start is called before the first frame update
    void Start()
    {
        //doorCollider = GetComponent<BoxCollider2D>();
        activator.GetComponent<ActivatorScript>().ActivatorScriptEvent += openDoor;
        if(activator2 != null)
        {
            activator2.GetComponent<ActivatorScript>().ActivatorScriptEvent += openDoor;
        }
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        gameObject.SetActive(defaultState);
        doorState = !defaultState;
    }

    private void OnDestroy()
    {
       /* activator.GetComponent<ActivatorScript>().ActivatorScriptEvent -= openDoor;
        if(activator2 != null)
        activator2.GetComponent<ActivatorScript>().ActivatorScriptEvent -= openDoor;*/
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    

    private void openDoor(object obj, bool state)
    {
        //doorCollider.enabled = doorState;
        if(doorState == true)
        {
            gameObject.SetActive(true);  
            doorState=false;
        }
        else if(doorState == false)
        {
            gameObject.SetActive(false);
            doorState = true;
        }
    }
}
