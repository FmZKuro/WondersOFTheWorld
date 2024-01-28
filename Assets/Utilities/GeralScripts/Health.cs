using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [Header("Health")]
    public int startingHealth;                                                          // Quantidade incial de vida 
    public int currentHealth;                                                           // Quantidade de vida atual
    [SerializeField] private HealthBar healthBar;                                       // Refer�ncia para a barra de vida (HealthBar)
    [SerializeField] private AudioClip hpSound;                                         // Som a ser reproduzido ao coletar um item de vida

    [Header("IFrames")]
    [SerializeField] private float IFramesDuration;                                     // Dura��o dos quadros de invulnerabilidade
    [SerializeField] private int CountFlashses;                                         // N�mero de Flashes durante o per�odo de invulnerabilidade    
    [SerializeField] private int[] TargetNumLayers;                                     // N�mero das camadas de colis�o a serem afetadas pela invulnerabilidade
    private SpriteRenderer spriteRender;                                                // Refer�ncia ao componente SpriteRenderer

    [Header("Damage Sounds")]
    [SerializeField] private AudioClip deathSound;                                      // Som a ser reproduzido ao morrer
    [SerializeField] private AudioClip hurtSound;                                       // Som a ser reproduzido ao sofrer dano
    [SerializeField] private float pitchHit = 1.0f;                                     // Define o pitch (tom) do �udio

    private Animator AnimPlayer;                                                        // Refer�ncia ao componente Animator do Player
    private Animator AnimEnemy;                                                         // Refer�ncia ao componente Animator do Enemy

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

    void Update()
    {
        if (gameObject.CompareTag("Player"))
        {            
            if (healthBar != null)                                                      // Verifica se healthBar � diferente de null antes de atualizar
            {
                healthBar.setHealth(currentHealth);                                     // Atualiza a barra de vida do jogador
            }
        }
        else if (gameObject.CompareTag("Enemy"))
        {            
            if (healthBar != null)                                                      // Verifica se healthBar � diferente de null antes de atualizar
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
                AnimPlayer.SetBool("IsDeath", true);                                    // Definir o par�metro de anima��o de morte do Player
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
                AnimEnemy.SetBool("Death", true);                                       // Definir o par�metro de anima��o de morte do Enemy
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

        SoundEffectControler.instance.playSound(hurtSound, 1.0f, pitchHit);
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
