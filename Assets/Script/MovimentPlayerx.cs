using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovimentPlayerx : MonoBehaviour
{
    public CheckPoint checkPoint;
    private Rigidbody2D player_RigidBody;
    private Animator player_Animator;
    float directionMove = 0f;
    public float RespawnHeight = -5f;

    bool isRight = true;

    private GameInputActions playerControls;
    private InputAction move;
    private InputAction jump;

    [Header("Moviment")]
    float speedMove = 2f;

    [Header("Jumping")]
    float jumpForce = 12f;
    private bool IsJumping = false;
    private float jumpTimeCounter;
    public float jumpTime;

    [Header("Ground")]
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;

    private void Awake()
    {
        playerControls = new GameInputActions();
    }


    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        player_Animator = GetComponent<Animator>();
        player_RigidBody = GetComponent<Rigidbody2D>();
        GameManager.instance.setPlayer(gameObject);
    }

    private void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();
        
        jump = playerControls.Player.Jump;
        jump.Enable();
        //jump.performed += jumpPlayer;
        
    }

    private void OnDisable()
    {
        move.Disable();
        jump.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        directionMove = move.ReadValue<float>();

        FlipPlayer();

        if(Input.GetButtonDown("Jump") && isTouchingGround)
        {
            player_RigidBody.velocity = new Vector2(player_RigidBody.velocity.x, jumpForce);
            player_Animator.Play("IsJumping");
        }
        
        if(player_RigidBody.velocity.y < 0)
        {
            player_Animator.SetBool("isFall", true);
        }
        else
        {
            player_Animator.SetBool("isFall", false);
        }
    /*
        if (jump.IsPressed() && IsJumping)
        {
            if(jumpTimeCounter > 0)
            {
                AnimPlayer.SetBool("IsJumping", true);
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                IsJumping = false;
                AnimPlayer.SetBool("IsFall", true);
            }
            
        }       

        if (jump.WasReleasedThisFrame())
        {
            IsJumping = false;
        }

        if (rb.velocity.y <= 0 && !isGrounded)
        {
            AnimPlayer.SetBool("IsFall", true);
        }

        if (isGrounded)
        {
            AnimPlayer.SetBool("IsJumping", false);
            AnimPlayer.SetBool("IsFall", false);
        }        

        if (transform.position.y < RespawnHeight)
        {
            GetComponent<Health>().takeDamage();
            checkPoint.ResPlayer();
        }
     */

        
    
    }

    private void FixedUpdate()
    {
        player_RigidBody.velocity = new Vector2(directionMove * speedMove, player_RigidBody.velocity.y);       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*
        if (collision.gameObject.tag == "Ground")
            isGrounded = true;
        */
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        /*
        if (collision.gameObject.tag == "Ground")
            isGrounded = false;
        */
    }


    void FlipPlayer()
    {
        if ((isRight && directionMove < 0f) || (!isRight && directionMove > 0f))
        {
            isRight = !isRight;
            GetComponent<SpriteRenderer>().flipX = !isRight;
        }
            player_Animator.SetBool("IsRunning", directionMove != 0);        
    }

    /*
    void jumpPlayer(InputAction.CallbackContext context)
    {
        if (isGrounded && !IsJumping)
        {
            rb.velocity = Vector2.up * jumpForce;
            jumpTimeCounter = jumpTime;
            IsJumping = true;
        }
    }
    */
    
}
