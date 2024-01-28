using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BossDead : MonoBehaviour
{       
    [SerializeField] private GameObject thisInimigo;        // Inimigo referencia
    [SerializeField] private GameObject menus;              // tela referencia

    private Health healthScript;                            // Refer�ncia ao script de sa�de do inimigo

    void Start()
    {        
        healthScript = GetComponent<Health>();              // Obt�m uma refer�ncia ao componente Health desse monstro
    }

    void FixedUpdate()
    {
        // Verifica se o inimigo � o objeto referenciado e se hp chegou a zero
        if (healthScript != null && healthScript.getCurrentHealth() <= 0 && gameObject.CompareTag(thisInimigo.tag))
        {
            MenuAtc();                                      // Chama a fun��o para ativar o menu de vit�ria
        }
    }

    // evento que libera tela final de vitoria
    void MenuAtc()
    {
        Invoke("MethodName", 3f);                           // Aguarda 3 segundos antes de chamar o m�todo "MethodName" (deve ser renomeado)
        menus.SetActive(true);                              // Ativa a tela de vit�ria
        Time.timeScale = 0f;                                // Pausa o tempo do jogo
    }    
}
