using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [Header("Health")]
    public int startingHealth;                                                          // Quantidade incial de vida
    private int currentHealth;                                                          // Quantidade de vida atual

    [SerializeField] private HealthBar healthBar;                                       // Refer�ncia para a barra de vida (HealthBar)

    [Header("IFrames")]
    [SerializeField] private float IFramesDuration;                                     // Dura��o dos quadros de invulnerabilidade
    [SerializeField] private int CountFlashses;                                         // N�mero de Flashes durante o per�odo de invulnerabilidade
    private SpriteRenderer spriteRender;                                                // Refer�ncia ao componente SpriteRenderer
    [SerializeField] private int[] TargetNumLayers;                                     // N�mero das camadas de colis�o a serem afetadas pela invulnerabilidade

    private Animator AnimPlayer;                                                        // Refer�ncia ao componente Animator do Player
    private Animator AnimEnemy;                                                         // Refer�ncia ao componente Animator do Enemy


    private void Awake()
    {
        currentHealth = startingHealth;                                                 // Inicializa a vida atual com a quantidade inicial de vida
        AnimPlayer = GetComponent<Animator>();                                          // Obter o componente Animator no Player
        AnimEnemy = GetComponent<Animator>();                                           // Obter o componente Animator no Enemy
        spriteRender = GetComponent<SpriteRenderer>();                                  // Obt�m o componente SpriteRenderer
    }
    // Start is called before the first frame update
    void Start()
    {
        if (healthBar != null)
        {
            healthBar.setMaxHealth(startingHealth);                                     // Define a quantidade m�xima de vida na barra de vida (HealthBar)
        }

        IgnoreAllLayersCollision(false);                                                // Garante que as colis�es com as camadas espec�ficas n�o est�o ignoradas
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void takeDamage()
    {
        currentHealth -= 1;                                                             // Reduz a vida atual

        if (healthBar != null)
        {
            healthBar.setHealth(currentHealth);                                         // Atualiza a barra de vida (HealthBar)
        }

        if (currentHealth <= 0)                                                         // Verifica se a vida chegou a zero
        {
            if (gameObject.tag == "Player")
            {
                AnimPlayer.SetBool("IsDeath", true);                                    // Definir o par�metro de anima��o de morte do Player
                Time.timeScale = 0f;                                                    // Pausa o tempo do jogo
                SceneManager.LoadScene("Menu");                                         // Carrega a cena do menu
            }
        }
        else
        {
            StartCoroutine(Invunerability());                                           // Inicia o per�odo de invulnerabilidade
        }

        if (currentHealth <= 0)                                                         // Verifica se a vida chegou a zero
        {
            if (gameObject.tag == "Enemy")
            {
                AnimEnemy.SetBool("Death",true);                                        // Definir o par�metro de anima��o de morte do Enemy
                GetComponent<EnemyFollow>().DeathEnemy();                               // Chama a fun��o de morte do Enemy
            }
        }
        else
        {
            StartCoroutine(Invunerability());                                           // Inicia o per�odo de invulnerabilidade
        }

    }

    private void IgnoreAllLayersCollision(bool IsIgnore)                                // Fun��o para ignorar ou n�o todas as colis�es com camadas espec�ficas
    {
        foreach (int layerNum in TargetNumLayers)
        {
            Physics2D.IgnoreLayerCollision(gameObject.layer, layerNum, IsIgnore);       // Ignora ou restaura as colis�es
        }
    }

    private IEnumerator Invunerability()                                                // Coroutine para controlar o per�odo de invulnerabilidade
    {
        IgnoreAllLayersCollision(true);                                                 // Ignora as colis�es com camadas espec�ficas

        GetComponent<Animator>().SetTrigger("Hurt");                                    // Definir o par�metro de anima��o de Dano
        for (int i = 0; i < CountFlashses; i++)
        {
            spriteRender.color = new Color(1, 0, 0, 0.5f);                              // Altera a cor do Sprite para criar o efeito de flash
            yield return new WaitForSeconds(IFramesDuration / (CountFlashses * 2));     // Aguarda parte do tempo total de invulnerabilidade
            spriteRender.color = Color.white;                                           // Restaura a cor original do Sprite
            yield return new WaitForSeconds(IFramesDuration / (CountFlashses * 2));     // Aguarda a outra parte do tempo total de invulnerabilidade
        }

        IgnoreAllLayersCollision(false);                                                // Restaura as colis�es com camadas espec�ficas
    }
}
