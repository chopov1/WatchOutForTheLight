using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanBehavior : MonoBehaviour
{
    [SerializeField] public float acceleration = 10;
    [SerializeField] public float decceleration = 6;

    [SerializeField] public float moveSpeedY;
    [SerializeField] public float moveSpeedX;
    [SerializeField] public float BoundY;
    [SerializeField] public float BoundYTwo;
    [SerializeField] public float BoundX;
    [SerializeField] public float BoundXTwo;
    [SerializeField] float detectionLength = 80f;
    [SerializeField] LayerMask maskToIgnore;
    
    public GameObject player;
    public float moveSpeed = 6f;
    public bool canMove = true;
    public WaitForSeconds stunnedTime = new WaitForSeconds(0.3f);

    HumanState _currentState;


    public Vector2 startPos = new Vector2(0, 0);
    public Vector2 rightBound = new Vector2(0, 0);
    public Vector2 leftBound = new Vector2(0, 0);
    public Vector2 direction = new Vector2(1, 0);
    

    public void setState(HumanState state)
    {
        _currentState = state;
    }
    // Start is called before the first frame update
    void Start()
    {
        /*TimerDeathSystem.BiteHuman += beingBitten;
        TimerDeathSystem.BiteDeath += finishedBite;*/
        startPos = transform.position;
        direction = Vector2.right;
        rightBound.x = BoundX;
        rightBound.y = BoundY;
        leftBound.x = BoundXTwo;
        leftBound.y = BoundYTwo;
        setState(new HumanIdle(this));
    }

    private void OnDestroy()
    {
        /*TimerDeathSystem.BiteHuman -= beingBitten;
        TimerDeathSystem.BiteDeath -= finishedBite;*/
    }

    private void FixedUpdate()
    {
        if(canMove)
        _currentState.playerMove();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            finishedBite();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Detect();
    }

    void beingBitten()
    {
        canMove = false;
    }

    void finishedBite()
    {
        Destroy(gameObject);
    }

    void Detect()
    {
        /*Vector2 direction = new Vector2(3, 0);
        if(Mathf.Sign(moveSpeedX) == -1)
        {
            direction = new Vector2(-3, 0);
        }*/
        RaycastHit2D detectionHit = Physics2D.Raycast(gameObject.transform.position, direction, detectionLength, maskToIgnore);
        if (detectionHit.collider != null)
        {
            if (detectionHit.collider.tag == "Player")
            {
                if(_currentState.curHumanState != HumanState.humanStateOptions.alerted)
                setState(new HumanAlerted(this));
            }
            else{
                if (_currentState.curHumanState != HumanState.humanStateOptions.idle)
                    setState(new HumanIdle(this));
            }
        }
    }

    
    

    
}
