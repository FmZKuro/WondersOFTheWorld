using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [Header("Health")]
    public int startingHealth;
    private int currentHealth;

    [SerializeField] private HealthBar healthBar;

    [Header("IFrames")]
    [SerializeField] private float IFramesDuration;
    [SerializeField] private int CountFlashses;
    private SpriteRenderer spriteRender;
    [SerializeField] private int[] TargetNumLayers;

    private Animator AnimPlayer;
    private Animator AnimEnemy;


    private void Awake()
    {
        currentHealth = startingHealth;
        AnimPlayer = GetComponent<Animator>();
        AnimEnemy = GetComponent<Animator>();
        spriteRender = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        if (healthBar != null)
        {
            healthBar.setMaxHealth(startingHealth);
        }

        IgnoreAllLayersCollision(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void takeDamage()
    {
        currentHealth -= 1;

        if (healthBar != null)
        {
            healthBar.setHealth(currentHealth);
        }

        if (currentHealth <= 0)
        {
            if (gameObject.tag == "Player")
            {
                AnimPlayer.SetBool("IsDeath", true);
                Time.timeScale = 0f;
                SceneManager.LoadScene("Menu");
            }
        }
        else
        {
            StartCoroutine(Invunerability());
        }

        if (currentHealth <= 0)
        {
            if (gameObject.tag == "Enemy")
            {
                AnimEnemy.SetBool("Death",true);
                GetComponent<EnemyFollow>().DeathEnemy();
            }
        }
        else
        {
            StartCoroutine(Invunerability());
        }

    }

    private void IgnoreAllLayersCollision(bool IsIgnore)
    {
        foreach (int layerNum in TargetNumLayers)
        {
            Physics2D.IgnoreLayerCollision(gameObject.layer, layerNum, IsIgnore);
        }
    }

    private IEnumerator Invunerability()
    {
        IgnoreAllLayersCollision(true);

        GetComponent<Animator>().SetTrigger("Hurt");
        for (int i = 0; i < CountFlashses; i++)
        {
            spriteRender.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(IFramesDuration / (CountFlashses * 2));
            spriteRender.color = Color.white;
            yield return new WaitForSeconds(IFramesDuration / (CountFlashses * 2));
        }

        IgnoreAllLayersCollision(false);
    }
}
