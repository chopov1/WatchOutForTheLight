using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    [SerializeField] public float moveSpeedY;
    [SerializeField] public float moveSpeedX;
    [SerializeField] public float BoundY;
    [SerializeField] public float BoundYTwo;
    [SerializeField] public float BoundX;
    [SerializeField] public float BoundXTwo;
    
    public MovingObstacle(float sx, float bx1, float bx2, float sy, float by1, float by2)
    {
        moveSpeedX = sx;
        BoundX = bx1;
        BoundXTwo = bx2;
        moveSpeedY = sy;
        BoundY = by1;
        BoundYTwo = by2;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        MoveOnFixedUpdate();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        moveSpeedX *= -1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveOnFixedUpdate()
    {
        MoveObstacle(moveSpeedX, moveSpeedY);
        //find more reliable way to do this. If object gets to far past the bound it gets stuck in a loop
        if (gameObject.transform.position.y > BoundY || gameObject.transform.position.y < BoundYTwo)
        {
            moveSpeedY *= -1;
        }
        if (gameObject.transform.position.x > BoundX || gameObject.transform.position.x < BoundXTwo)
        {
            moveSpeedX *= -1;
        }
    }

    public void MoveObstacle(float moveX, float moveY)
    {
        gameObject.transform.Translate(new Vector2(moveX, moveY) * Time.deltaTime);
    }
}
