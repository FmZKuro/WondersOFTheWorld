using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    private GameInputActions playerControls;                                // Controles de entrada do Player
    private InputAction attack;                                             // A��o de ataque no sistema de entrada

    private Animator AnimPlayer;                                            // Refer�ncia ao componente Animator do Player

    [Header("Attack Player")]
    private bool inAttack = false;                                          // Sinalizador para controlar se o Player est� em um estado de ataque
    public float AtttackDuration;                                           // Dura��o do ataque do Player

    public GameObject HitBoxAttack;                                         // Caixa de colis�o para o ataque
    private Vector2 initPosHitBoxAttack;                                    // Posi��o inicial da caixa de colis�o do ataque

    private void Awake()
    {
        playerControls = new GameInputActions();                            // Inicializar os controles de entrada do jogador
    }

    // Start is called before the first frame update
    void Start()
    {
        AnimPlayer = GetComponent<Animator>();                              // Obter o componente Animator no Player
        initPosHitBoxAttack = HitBoxAttack.transform.localPosition;         // Armazenar a posi��o inicial da caixa de colis�o do ataque
    }

    private void OnEnable()
    {
        attack = playerControls.Player.Attack;                              // Obter a a��o de ataque do sistema de entrada
        attack.Enable();
        attack.performed += OnAttack;                                       // Adicionar um callback para a a��o de ataque
    }

    private void OnDisable()
    {
        attack.Disable();                                                   // Desativar a a��o de ataque
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnAttack(InputAction.CallbackContext context)
    {
        if (!inAttack)
        {
            FlipHitBox();                                                   // Chama a fun��o de ajuste de posi��o da caixa de colis�o com base na dire��o do Player
            StartCoroutine(TimeAnimAttack());                               // Inicia a rotina para controlar a dura��o do ataque
        }
    }

    void FlipHitBox()
    {
        Vector2 posHitBox = initPosHitBoxAttack;                            // Inicializa a posi��o da caixa de colis�o

        if (GetComponent<SpriteRenderer>().flipX)                           // Verifica se o Player est� virado para a esquerda e ajusta a posi��o da caixa de colis�o
        {
            posHitBox = new Vector2(-initPosHitBoxAttack.x, posHitBox.y);
        }
        else                                                                // Se o Player n�o estiver virado para a esquerda, ajusta a posi��o da caixa de colis�o normalmente
        {
            posHitBox = new Vector2(initPosHitBoxAttack.x, posHitBox.y);
        }

        HitBoxAttack.transform.localPosition = posHitBox;                   // Definir a posi��o da caixa de colis�o
        StartCoroutine(TimeAnimAttack());                                   // Inicia a rotina para controlar a dura��o do ataque
    }

    private IEnumerator TimeAnimAttack()
    {
        inAttack = true;                                                    // Define o sinalizador de ataque como verdadeiro
        AnimPlayer.SetBool("InAttack", true);                               // Definir o par�metro de anima��o de ataque do Player

        yield return new WaitForSeconds(AtttackDuration);                   // Aguardar a dura��o do ataque

        inAttack = false;                                                   // Resetar o sinalizador de ataque
        AnimPlayer.SetBool("InAttack", false);                              // Resetar anima��o de ataque do Player
    }
}
