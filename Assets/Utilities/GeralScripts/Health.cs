using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [Header("Health")]
    public int startingHealth;                                                          // Quantidade incial de vida 
    public int currentHealth;                                                           // Quantidade de vida atual
    [SerializeField] private HealthBar healthBar;                                       // Referência para a barra de vida (HealthBar)
    [SerializeField] private AudioClip hpSound;                                         // Som a ser reproduzido ao coletar um item de vida

    [Header("IFrames")]
    [SerializeField] private float IFramesDuration;                                     // Duração dos quadros de invulnerabilidade
    [SerializeField] private int CountFlashses;                                         // Número de Flashes durante o período de invulnerabilidade    
    [SerializeField] private int[] TargetNumLayers;                                     // Número das camadas de colisão a serem afetadas pela invulnerabilidade
    private SpriteRenderer spriteRender;                                                // Referência ao componente SpriteRenderer

    [Header("Damage Sounds")]
    [SerializeField] private AudioClip deathSound;                                      // Som a ser reproduzido ao morrer
    [SerializeField] private AudioClip hurtSound;                                       // Som a ser reproduzido ao sofrer dano
    [SerializeField] private float pitchHit = 1.0f;                                     // Define o pitch (tom) do áudio

    private Animator AnimPlayer;                                                        // Referência ao componente Animator do Player
    private Animator AnimEnemy;                                                         // Referência ao componente Animator do Enemy

    public int getCurrentHealth()
    {
        return this.currentHealth;
    }

    public void setCurrentHealth(int numero)
    {
        this.currentHealth = numero;
    }


    private void Awake()
    {
        currentHealth = startingHealth;                                                 // Inicializa a vida atual com a quantidade inicial de vida
        AnimPlayer = GetComponent<Animator>();                                          // Obter o componente Animator no Player
        AnimEnemy = GetComponent<Animator>();                                           // Obter o componente Animator no Enemy
        spriteRender = GetComponent<SpriteRenderer>();                                  // Obtém o componente SpriteRenderer
    }
    // Start is called before the first frame update
    void Start()
    {
        if (healthBar != null)
        {
            healthBar.setMaxHealth(startingHealth);                                     // Define a quantidade máxima de vida na barra de vida (HealthBar)
        }
        IgnoreAllLayersCollision(false);                                                // Garante que as colisões com as camadas específicas não estão ignoradas
    }

    void Update()
    {
        if (gameObject.CompareTag("Player"))
        {            
            if (healthBar != null)                                                      // Verifica se healthBar é diferente de null antes de atualizar
            {
                healthBar.setHealth(currentHealth);                                     // Atualiza a barra de vida do jogador
            }
        }
        else if (gameObject.CompareTag("Enemy"))
        {            
            if (healthBar != null)                                                      // Verifica se healthBar é diferente de null antes de atualizar
            {
                healthBar.setHealth(currentHealth);                                     // Atualiza a barra de vida do inimigo
            }
        }

        if (healthBar != null && gameObject.tag == "Enemy")
        {
            healthBar.setHealth(currentHealth);                                         // Atualiza a barra de vida (HealthBar)
        }
    }

    public void takeDamage()
    {
        currentHealth -= 1;                                                             // Reduz a vida atual
        if (currentHealth <= 0)                                                         // Verifica se a vida chegou a zero
        {
            SoundEffectControler.instance.playSound(deathSound, 1.0f);                  // Reproduz o som do Morte
            if (gameObject.tag == "Player")
            {
                AnimPlayer.SetBool("IsDeath", true);                                    // Definir o parâmetro de animação de morte do Player
            }
        }
        else
        {
            StartCoroutine(Invunerability());                                           // Inicia o período de invulnerabilidade
        }

        if (currentHealth <= 0)                                                         // Verifica se a vida chegou a zero
        {
            if (gameObject.tag == "Enemy")
            {
                AnimEnemy.SetBool("Death", true);                                       // Definir o parâmetro de animação de morte do Enemy
                GetComponent<EnemyFollow>().DeathEnemy();                               // Chama a função de morte do Enemy
            }
        }
        else
        {
            StartCoroutine(Invunerability());                                           // Inicia o período de invulnerabilidade
        }

    }

    private void IgnoreAllLayersCollision(bool IsIgnore)                                // Função para ignorar ou não todas as colisões com camadas específicas
    {
        foreach (int layerNum in TargetNumLayers)
        {
            Physics2D.IgnoreLayerCollision(gameObject.layer, layerNum, IsIgnore);       // Ignora ou restaura as colisões
        }
    }

    private IEnumerator Invunerability()                                                // Coroutine para controlar o período de invulnerabilidade
    {
        IgnoreAllLayersCollision(true);                                                 // Ignora as colisões com camadas específicas

        SoundEffectControler.instance.playSound(hurtSound, 1.0f, pitchHit);
        GetComponent<Animator>().SetTrigger("Hurt");                                    // Definir o parâmetro de animação de Dano
        for (int i = 0; i < CountFlashses; i++)
        {
            spriteRender.color = new Color(1, 0, 0, 0.5f);                              // Altera a cor do Sprite para criar o efeito de flash
            yield return new WaitForSeconds(IFramesDuration / (CountFlashses * 2));     // Aguarda parte do tempo total de invulnerabilidade
            spriteRender.color = Color.white;                                           // Restaura a cor original do Sprite
            yield return new WaitForSeconds(IFramesDuration / (CountFlashses * 2));     // Aguarda a outra parte do tempo total de invulnerabilidade
        }
        IgnoreAllLayersCollision(false);                                                // Restaura as colisões com camadas específicas
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("hp"))
        {
            currentHealth += 1;                                                         // Aumenta a vida atual
            Destroy(other.gameObject);                                                  // Destroi o objeto colidido
            SoundEffectControler.instance.playSound(hpSound, 1.0f, pitchHit);           // Reproduz o som associado ao ganho de vida
        }
    }
}
