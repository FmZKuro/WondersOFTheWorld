using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovimentPlayer : MonoBehaviour
{
    public CheckPoint checkPoint;
    private Rigidbody2D rb;
    private Animator AnimPlayer;
    float directionMove = 0f;
    public float RespawnHeight = -5f;

    bool isRight = true;

    private GameInputActions playerControls;
    private InputAction move;
    private InputAction jump;

    [Header("Moviment")]
    [SerializeField] float speedMove = 2.0f;

    [Header("Jumping")]
    [SerializeField] float jumpForce = 12.0f;
    private bool IsJumping = false;
    private float jumpTimeCounter;
    public float jumpTime;

    [Header("Ground")]
    public LayerMask groundLayer;
    [SerializeField] private Transform feetPos;
    [SerializeField] private float feetRadius;
    private bool isGrounded = true;

    private void Awake()
    {
        playerControls = new GameInputActions();
    }


    // Start is called before the first frame update
    void Start()
    {
        AnimPlayer = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        GameManager.instance.setPlayer(gameObject);
    }

    private void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();

        jump = playerControls.Player.Jump;
        jump.Enable();
        jump.performed += jumpPlayer;
    }

    private void OnDisable()
    {
        move.Disable();
        jump.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        directionMove = move.ReadValue<float>();

        FlipPlayer();

        isGround();

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

        if (rb.velocity.y <= 0)
        {
            AnimPlayer.SetBool("IsFall", true);
        }

        if (isGround())
        {
            AnimPlayer.SetBool("IsJumping", false);
            AnimPlayer.SetBool("IsFall", false);
        }        

        if (transform.position.y < RespawnHeight)
        {
            GetComponent<Health>().takeDamage();
            checkPoint.ResPlayer();
        }
        
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(directionMove * speedMove, rb.velocity.y);       
    }

    void FlipPlayer()
    {
        if ((isRight && directionMove < 0f) || (!isRight && directionMove > 0f))
        {
            isRight = !isRight;
            GetComponent<SpriteRenderer>().flipX = !isRight;
        }
            AnimPlayer.SetBool("IsRunning", directionMove != 0);        
    }

    void jumpPlayer(InputAction.CallbackContext context)
    {
        if (isGrounded && !IsJumping)
        {
            rb.velocity = Vector2.up * jumpForce;
            jumpTimeCounter = jumpTime;
            IsJumping = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(feetPos.position, feetRadius);
    }

    public bool isGround()
    {
        isGrounded = false;
        
        if (Physics2D.OverlapCircle(feetPos.position, feetRadius, groundLayer))
        {
            isGrounded = true;
        }

        return isGrounded;
    }
}
