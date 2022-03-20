using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    #region Properties
    BoxCollider2D playerCollider;
    [SerializeField] LayerMask layerMask;
    Animator playerAnimator;
    SpriteRenderer spriteRenderer;
    Rigidbody2D playerRB;
    public float currentMoveSpeed = 9f;
    [SerializeField] public float moveSpeed = 100f;
    [SerializeField] public float moveSpeedInSun = 200f;
    public float currentJumpForce;
    [SerializeField] public float jumpForce = 900f;
    [SerializeField] public float jumpForceInSun = 1100f;
    [SerializeField] float acceleration = 13;
    [SerializeField] float decceleration = 16;
    [SerializeField] float frictionAmount = 0.22f;
    [SerializeField] float fallGravityMultiplier = 2;
    [SerializeField] float gravityScale = 1;
    float velPower = 0.9f;
    float extraHeight = .1f;

    bool hasJumped = false;
    bool isJumping;
    public bool canAcceptInput = true;
    Vector2 movement;
    bool cayoteTimeUp = true;
    #endregion


    #region UnityMethods
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        playerAnimator = GetComponentInChildren<Animator>();
        playerCollider = GetComponent<BoxCollider2D>();
        currentMoveSpeed = moveSpeed;
        currentJumpForce = jumpForce;
        Loader.lastActiveScene = (Loader.Scene)SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (canAcceptInput)
        {
            movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            playerAnimator.SetFloat("Speed", Mathf.Abs(movement.x));
        }
        isGrounded();
        if (movement.x > 0.1f || movement.x < -0.1f)
        {
            if(movement.x < -0.1f)
            {
                spriteRenderer.flipX = true;
            }
            else
            {
                spriteRenderer.flipX = false;
            }
            //calculate direction we want to move in and our desired velocity
            float targetSpeed = movement.x * currentMoveSpeed;
            //calculate the difference between the current velocity and desired velocity
            float speedDif = targetSpeed - playerRB.velocity.x;
            //change acceleration rate depedning on situation
            float accelRate = (Mathf.Abs(targetSpeed) > 0.01f ? acceleration : decceleration);

            //applies acceleration to speed difference, then raises to a set power so acceleration increases with highr speeds
            //finnaly multiplies by sign to reapply direction
            float move = Mathf.Pow(Mathf.Abs(speedDif)* accelRate, velPower) * Mathf.Sign(speedDif);

            playerRB.AddForce(move * Vector2.right);

            //playerRB.AddForce(new Vector2 (moveHorizontal * moveSpeed * Time.deltaTime, 0f), ForceMode2D.Force);
            playerRB.velocity = new Vector2(movement.x * currentMoveSpeed * Time.deltaTime, playerRB.velocity.y);
            //transform.Translate(new Vector2(movement.x * moveSpeed * Time.deltaTime, 0f));
            //playerRB.MovePosition(playerRB.position + (movement * moveSpeed *Time.deltaTime));
        }

        if (CanJump())
        {
            addJumpForce();
        }
        if(movement == new Vector2(0, 0) )
        {
            applyFriction();
        }
        /*if (playerRB.velocity.y < 0.01f && hasJumped)
        {
            playerRB.AddForce(Vector2.down * playerRB.velocity.y * (1 - jumpCutMultiplier), ForceMode2D.Impulse);
        }*/
        if (playerRB.velocity.y < 0 && hasJumped)
        {
            playerRB.gravityScale = gravityScale * fallGravityMultiplier;
        }
        else
        {
            playerRB.gravityScale = gravityScale;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DeathFloor")
        {
            Loader.LoadScene(Loader.Scene.UI_Restart_Menu);
        }
    }
    #endregion

    public void applyFriction()
    {
        //we use either the friction amount or our velocity
        float amount = Mathf.Min(Mathf.Abs(playerRB.velocity.x), Mathf.Abs(frictionAmount));
        //sets to movement direction
        amount *= Mathf.Sign(playerRB.velocity.x);
        //applies force against movement direction
        playerRB.AddForce(Vector2.right * -amount, ForceMode2D.Impulse);
    }

    #region Jumping
    private bool CanJump()
    {
        if (!canAcceptInput)
        {
            return false;
        }
        if (movement.y > 0.1f && isGrounded())
        {
            return true;
        }
        else if(movement.y > 0.1f && !cayoteTimeUp && !hasJumped)
        {
            return true;
        }
        
        return false;
    }

    

    private void addJumpForce()
    {   
        playerRB.AddForce(new Vector2(0f, movement.y * currentJumpForce * Time.deltaTime), ForceMode2D.Impulse);
        hasJumped = true;
    }
    #endregion


    #region Grounding
    private bool isGrounded()
    {
        RaycastHit2D groundCheckRay = Physics2D.Raycast(playerCollider.bounds.center, Vector2.down, playerCollider.bounds.extents.y + extraHeight, layerMask);
        DrawDebugRay(groundCheckRay);
        if (groundCheckRay.collider != null)
        {
            if (hasJumped)
            {
                hasJumped = false;
            }
            return true;
        }
        if (cayoteTimeUp && !hasJumped)
        {
            StartCoroutine(startCayoteTime());
        }
        return false;
    }

    
    IEnumerator startCayoteTime()
    {
        cayoteTimeUp = false;
        yield return new WaitForSeconds(0.1f);
        cayoteTimeUp = true;
    }

    public void DrawDebugRay(RaycastHit2D groundCheckRay)
    {
        
        Color raycolor;
        Debug.Log(groundCheckRay.collider);
        if (groundCheckRay.collider != null)
        {
            raycolor = Color.green;
        }
        else
        {
            raycolor = Color.red;
        }
        Debug.DrawRay(playerCollider.bounds.center, Vector2.down * (playerCollider.bounds.extents.y + extraHeight), raycolor);
    }
    #endregion


}
