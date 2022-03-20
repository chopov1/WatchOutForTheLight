using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatorScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] bool boolToPass;
    [SerializeField] float pushGracePeriod = 2f;

    BoxCollider2D trigger;
    bool canPush = true;

    public delegate void ActivatorScriptDelegate(object obj, bool state);
    public event ActivatorScriptDelegate ActivatorScriptEvent;
    void Start()
    {
        trigger = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (canPush)
            {
                ActivatorScriptEvent.Invoke(this, boolToPass);
                StartCoroutine(waitForPushDelay());
                if (boolToPass == true)
                {
                    boolToPass = false;
                }
                else
                {
                    boolToPass = true;
                }
            }
        }
    }

    IEnumerator waitForPushDelay()
    {
        canPush = false;
        yield return new WaitForSeconds(pushGracePeriod);
        canPush = true;
    }

}
