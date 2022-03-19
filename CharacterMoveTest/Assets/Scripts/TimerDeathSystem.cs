using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TimerDeathSystem : MonoBehaviour
{
    // Start is called before the first frame update
    CapsuleCollider2D playerCollider;
    float currentTime;
    float startSeconds;
    //[SerializeField] float biteTime = 3f;
    bool count;
    bool bitingPlayer;
    public Text counter;
    public float TimerTresh = 5.0f;

    public PlayerMovement moveScript;

    /*public delegate void BitePlayerEventHandler();
    public static event BitePlayerEventHandler BiteHuman;
    public static event BitePlayerEventHandler BiteDeath;*/


    void Start()
    {
        playerCollider = GetComponent<CapsuleCollider2D>();
        SunManager.OnPlayerHit += playerHit;
    }
    
    private void OnDestroy()
    {
        SunManager.OnPlayerHit -= playerHit;
    }
    // Update is called once per frame
    void Update()
    {
        if (!bitingPlayer)
        {
            if (count == false)
            {
                if(moveScript.currentMoveSpeed != moveScript.moveSpeed)
                {
                    moveScript.currentMoveSpeed = moveScript.moveSpeed;
                    moveScript.currentJumpForce = moveScript.jumpForce;
                }
                currentTime = startSeconds;
            }
            if (count == true)
            {
                if(moveScript.currentMoveSpeed != moveScript.moveSpeedInSun)
                {
                    moveScript.currentMoveSpeed = moveScript.moveSpeedInSun;
                    moveScript.currentJumpForce = moveScript.jumpForceInSun;
                }
                currentTime += Time.deltaTime;
            }
            counter.text = currentTime.ToString("#.00");
            if (currentTime >= TimerTresh)
            {
                Loader.LoadScene(Loader.Scene.RestartMenu);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Human")
        {
            currentTime = startSeconds;
        }
    }

    public void playerHit(bool isHit)
    {
        count = isHit;
    }

    
}
