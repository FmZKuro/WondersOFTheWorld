using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    private GameInputActions playerControls;                                // Controles de entrada do Player
    private InputAction attack;                                             // Ação de ataque no sistema de entrada

    private Animator AnimPlayer;                                            // Referência ao componente Animator do Player

    [Header("Attack Player")]
    private bool inAttack = false;                                          // Sinalizador para controlar se o Player está em um estado de ataque
    public float AtttackDuration;                                           // Duração do ataque do Player

    public GameObject HitBoxAttack;                                         // Caixa de colisão para o ataque
    private Vector2 initPosHitBoxAttack;                                    // Posição inicial da caixa de colisão do ataque

    private void Awake()
    {
        playerControls = new GameInputActions();                            // Inicializar os controles de entrada do jogador
    }

    // Start is called before the first frame update
    void Start()
    {
        AnimPlayer = GetComponent<Animator>();                              // Obter o componente Animator no Player
        initPosHitBoxAttack = HitBoxAttack.transform.localPosition;         // Armazenar a posição inicial da caixa de colisão do ataque
    }

    private void OnEnable()
    {
        attack = playerControls.Player.Attack;                              // Obter a ação de ataque do sistema de entrada
        attack.Enable();
        attack.performed += OnAttack;                                       // Adicionar um callback para a ação de ataque
    }

    private void OnDisable()
    {
        attack.Disable();                                                   // Desativar a ação de ataque
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnAttack(InputAction.CallbackContext context)
    {
        if (!inAttack)
        {
            FlipHitBox();                                                   // Chama a função de ajuste de posição da caixa de colisão com base na direção do Player
            StartCoroutine(TimeAnimAttack());                               // Inicia a rotina para controlar a duração do ataque
        }
    }

    void FlipHitBox()
    {
        Vector2 posHitBox = initPosHitBoxAttack;                            // Inicializa a posição da caixa de colisão

        if (GetComponent<SpriteRenderer>().flipX)                           // Verifica se o Player está virado para a esquerda e ajusta a posição da caixa de colisão
        {
            posHitBox = new Vector2(-initPosHitBoxAttack.x, posHitBox.y);
        }
        else                                                                // Se o Player não estiver virado para a esquerda, ajusta a posição da caixa de colisão normalmente
        {
            posHitBox = new Vector2(initPosHitBoxAttack.x, posHitBox.y);
        }

        HitBoxAttack.transform.localPosition = posHitBox;                   // Definir a posição da caixa de colisão
        StartCoroutine(TimeAnimAttack());                                   // Inicia a rotina para controlar a duração do ataque
    }

    private IEnumerator TimeAnimAttack()
    {
        inAttack = true;                                                    // Define o sinalizador de ataque como verdadeiro
        AnimPlayer.SetBool("InAttack", true);                               // Definir o parâmetro de animação de ataque do Player

        yield return new WaitForSeconds(AtttackDuration);                   // Aguardar a duração do ataque

        inAttack = false;                                                   // Resetar o sinalizador de ataque
        AnimPlayer.SetBool("InAttack", false);                              // Resetar animação de ataque do Player
    }
}
