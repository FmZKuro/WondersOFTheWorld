using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BossDead : MonoBehaviour
{       
    [SerializeField] private GameObject thisInimigo;        // Inimigo referencia
    [SerializeField] private GameObject menus;              // tela referencia

    private Health healthScript;                            // Referência ao script de saúde do inimigo

    void Start()
    {        
        healthScript = GetComponent<Health>();              // Obtém uma referência ao componente Health desse monstro
    }

    void FixedUpdate()
    {
        // Verifica se o inimigo é o objeto referenciado e se hp chegou a zero
        if (healthScript != null && healthScript.getCurrentHealth() <= 0 && gameObject.CompareTag(thisInimigo.tag))
        {
            MenuAtc();                                      // Chama a função para ativar o menu de vitória
        }
    }

    // evento que libera tela final de vitoria
    void MenuAtc()
    {
        Invoke("MethodName", 3f);                           // Aguarda 3 segundos antes de chamar o método "MethodName" (deve ser renomeado)
        menus.SetActive(true);                              // Ativa a tela de vitória
        Time.timeScale = 0f;                                // Pausa o tempo do jogo
    }    
}
