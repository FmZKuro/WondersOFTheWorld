using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovimentPlayer : MonoBehaviour
{
    private Rigidbody2D rb;                                                         
    private Animator AnimPlayer;                                                    // Refer�ncia ao componente Animator do Player
    float directionMove = 0f;                                                       // Vari�vel de movimento horizontal

    bool isRight = true;                                                            // Verifica��o do Player estar virado para a direita

    private GameInputActions playerControls;                                        // Controles de sistema de entrada do Player
    private InputAction move;
    private InputAction jump;

    [Header("Moviment")]
    [SerializeField] float speedMove = 2.0f;                                        // Velocidade do Player

    [Header("Jumping")]
    [SerializeField] float jumpForce = 12.0f;                                       // For�a aplicada de pulo
    private bool IsJumping = false;                                                 // Verificar se o Player est� pulando
    private float jumpTimeCounter;                                                  // Contador de quanto tempo o jogador pode manter o bot�o de pulo pressionado
    public float jumpTime;                                                          // Tempo m�ximo que o jogo pode manter o pulo

    [Header("Ground")]
    public LayerMask groundLayer;                                                   // Camada de detec��o do ch�o
    [SerializeField] private Transform feetPos;                                     // Representa��o da posi��o dos p�s do Player
    [SerializeField] private float feetRadius;                                      // Raio para o c�rculo usado de verifica��o se o Player est� no ch�o
    private bool isGrounded = true;                                                 // Verificar se o Player est� no ch�o

    private void Awake()
    {
        playerControls = new GameInputActions();                                    // Inicializar os controles do sistema de entrada
    }


    // Start is called before the first frame update
    void Start()
    {
        AnimPlayer = GetComponent<Animator>();                                      // Obter o componente Animator no Player
        rb = GetComponent<Rigidbody2D>();                                           // Obter o componente Rigidbody2D no Player
        GameManager.instance.setPlayer(gameObject);                                 // Definir o Player no Gerenciador de Jogo
    }

    private void OnEnable()
    {
        move = playerControls.Player.Move;                                          // Obter a a��o de movimento do sistema de entrada
        move.Enable();

        jump = playerControls.Player.Jump;                                          // Obter a a��o de pulo do sistema de entrada
        jump.Enable();
        jump.performed += jumpPlayer;                                               // Adicionar um callback para a a��o de pulo
    }

    private void OnDisable()
    {
        move.Disable();                                                             // Desativar o movimento
        jump.Disable();                                                             // Desativar o pulo
    }

    // Update is called once per frame
    void Update()
    {
        directionMove = move.ReadValue<float>();                                    // Ler a entrada de movimento horizontal

        FlipPlayer();                                                               // Chamar a fun��o de inverter os Sprites do Player com base na dire��o

        isGround();                                                                 // Chamar a fun��o de verifica��o se o Player est� no ch�o

        if (jump.IsPressed() && IsJumping)                                          // Verificar se o bot�o de pulo est� pressionado e o Player est� pulando
        {
            if(jumpTimeCounter > 0)
            {
                AnimPlayer.SetBool("IsJumping", true);                              // Definir o par�metro de anima��o de pulo do Player
                rb.velocity = Vector2.up * jumpForce;                               // Aplicar a for�a de pular para cima
                jumpTimeCounter -= Time.deltaTime;                                  // Decrementar o contador de tempo de pulo
            }
            else
            {
                IsJumping = false;                                                  // Parar de pular se o tempo de pulo estiver no limite
                AnimPlayer.SetBool("IsFall", true);                                 // Definir o par�metro de anima��o de queda do Player
            }
            
        }       

        if (jump.WasReleasedThisFrame())
        {
            IsJumping = false;                                                      // Resetar o pulo quando o bot�o de pulo � solto
        }

        if (rb.velocity.y <= 0)
        {
            AnimPlayer.SetBool("IsFall", true);                                     // Definir o par�metro de anima��o de queda do Player ao cair
        }

        if (isGround())
        {
            AnimPlayer.SetBool("IsJumping", false);                                 // Resetar anima��o de pulo e queda quando estiver no ch�o
            AnimPlayer.SetBool("IsFall", false);
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
            GetComponent<SpriteRenderer>().flipX = !isRight;                        // Inverter o Sprite do Player com base na dire��o
        }
            AnimPlayer.SetBool("IsRunning", directionMove != 0);                    // Definir o par�metro de anima��o de corrida
    }

    void jumpPlayer(InputAction.CallbackContext context)
    {
        if (isGrounded && !IsJumping)
        {
            rb.velocity = Vector2.up * jumpForce;                                   // Aplicar for�a para cima para pular
            jumpTimeCounter = jumpTime;                                             // Definir o contador inicial de tempo de pulo
            IsJumping = true;                                                       // Definir o sinalizador de pulo
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(feetPos.position, feetRadius);                            // Desenhar uma esfera de vizualizal�ao da posi��o de verifica��o do ch�o
    }

    public bool isGround()
    {
        isGrounded = false;
        
        if (Physics2D.OverlapCircle(feetPos.position, feetRadius, groundLayer))
        {
            isGrounded = true;                                                      // Verificar se o Player est� no ch�o usando uma sobreposi��o de c�rculo
        }

        return isGrounded;
    }
}
