using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanBehavior : MonoBehaviour
{
    #region Properties
    [SerializeField] public float acceleration = 10;
    [SerializeField] public float decceleration = 6;
    [SerializeField] public float moveSpeedY;
    [SerializeField] public float moveSpeedX;
    [SerializeField] public float BoundY;
    [SerializeField] public float BoundYTwo;
    [SerializeField] public float BoundX;
    [SerializeField] public float BoundXTwo;
    [SerializeField] float detectionLength = 80f;
    public float moveSpeed = 6f;
    [SerializeField] LayerMask maskToIgnore;
    
    public GameObject player;
    public bool canMove = true;
    public WaitForSeconds stunnedTime = new WaitForSeconds(0.3f);
    HumanState _currentState;

    public Vector2 startPos = new Vector2(0, 0);
    public Vector2 rightBound = new Vector2(0, 0);
    public Vector2 leftBound = new Vector2(0, 0);
    public Vector2 direction = new Vector2(1, 0);
    #endregion

    public void setState(HumanState state)
    {
        _currentState = state;
    }

    void Start()
    {
        startPos = transform.position;
        direction = Vector2.right;
        rightBound.x = BoundX;
        rightBound.y = BoundY;
        leftBound.x = BoundXTwo;
        leftBound.y = BoundYTwo;
        setState(new HumanIdle(this));
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
