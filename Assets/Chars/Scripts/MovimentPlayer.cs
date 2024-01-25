using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovimentPlayer : MonoBehaviour
{
    private Rigidbody2D rb;                                                         
    private Animator AnimPlayer;                                                    // Referência ao componente Animator do Player
    float directionMove = 0f;                                                       // Variável de movimento horizontal

    bool isRight = true;                                                            // Verificação do Player estar virado para a direita

    private GameInputActions playerControls;                                        // Controles de sistema de entrada do Player
    private InputAction move;
    private InputAction jump;

    [Header("Moviment")]
    [SerializeField] float speedMove = 2.0f;                                        // Velocidade do Player

    [Header("Jumping")]
    [SerializeField] float jumpForce = 12.0f;                                       // Força aplicada de pulo
    private bool IsJumping = false;                                                 // Verificar se o Player está pulando
    private float jumpTimeCounter;                                                  // Contador de quanto tempo o jogador pode manter o botão de pulo pressionado
    public float jumpTime;                                                          // Tempo máximo que o jogo pode manter o pulo

    [Header("Ground")]
    public LayerMask groundLayer;                                                   // Camada de detecção do chão
    [SerializeField] private Transform feetPos;                                     // Representação da posição dos pés do Player
    [SerializeField] private float feetRadius;                                      // Raio para o círculo usado de verificação se o Player está no chão
    private bool isGrounded = true;                                                 // Verificar se o Player está no chão

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
        move = playerControls.Player.Move;                                          // Obter a ação de movimento do sistema de entrada
        move.Enable();

        jump = playerControls.Player.Jump;                                          // Obter a ação de pulo do sistema de entrada
        jump.Enable();
        jump.performed += jumpPlayer;                                               // Adicionar um callback para a ação de pulo
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

        FlipPlayer();                                                               // Chamar a função de inverter os Sprites do Player com base na direção

        isGround();                                                                 // Chamar a função de verificação se o Player está no chão

        if (jump.IsPressed() && IsJumping)                                          // Verificar se o botão de pulo está pressionado e o Player está pulando
        {
            if(jumpTimeCounter > 0)
            {
                AnimPlayer.SetBool("IsJumping", true);                              // Definir o parâmetro de animação de pulo do Player
                rb.velocity = Vector2.up * jumpForce;                               // Aplicar a força de pular para cima
                jumpTimeCounter -= Time.deltaTime;                                  // Decrementar o contador de tempo de pulo
            }
            else
            {
                IsJumping = false;                                                  // Parar de pular se o tempo de pulo estiver no limite
                AnimPlayer.SetBool("IsFall", true);                                 // Definir o parâmetro de animação de queda do Player
            }
            
        }       

        if (jump.WasReleasedThisFrame())
        {
            IsJumping = false;                                                      // Resetar o pulo quando o botão de pulo é solto
        }

        if (rb.velocity.y <= 0)
        {
            AnimPlayer.SetBool("IsFall", true);                                     // Definir o parâmetro de animação de queda do Player ao cair
        }

        if (isGround())
        {
            AnimPlayer.SetBool("IsJumping", false);                                 // Resetar animação de pulo e queda quando estiver no chão
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
            GetComponent<SpriteRenderer>().flipX = !isRight;                        // Inverter o Sprite do Player com base na direção
        }
            AnimPlayer.SetBool("IsRunning", directionMove != 0);                    // Definir o parâmetro de animação de corrida
    }

    void jumpPlayer(InputAction.CallbackContext context)
    {
        if (isGrounded && !IsJumping)
        {
            rb.velocity = Vector2.up * jumpForce;                                   // Aplicar força para cima para pular
            jumpTimeCounter = jumpTime;                                             // Definir o contador inicial de tempo de pulo
            IsJumping = true;                                                       // Definir o sinalizador de pulo
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(feetPos.position, feetRadius);                            // Desenhar uma esfera de vizualizalçao da posição de verificação do chão
    }

    public bool isGround()
    {
        isGrounded = false;
        
        if (Physics2D.OverlapCircle(feetPos.position, feetRadius, groundLayer))
        {
            isGrounded = true;                                                      // Verificar se o Player está no chão usando uma sobreposição de círculo
        }

        return isGrounded;
    }
}
