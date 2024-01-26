using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BossDead : MonoBehaviour
{
       
    [SerializeField] private GameObject thisInimigo; // Inimigo referencia
    [SerializeField] private GameObject menus; // tela referencia

    private Health healthScript;

    void Start()
    {
        // Obtém uma referência ao componente Health desse monstro
        healthScript = GetComponent<Health>();

    }

    void FixedUpdate()
    {
        // Verifica se o inimigo é o objeto referenciado e se hp chegou a zero
        if (healthScript != null && healthScript.getCurrentHealth() <= 0 && gameObject.CompareTag(thisInimigo.tag))
        {
            MenuAtc();
        }
    }


    // evento que libera tela final de vitoria
    void MenuAtc()
    {
        Invoke("MethodName", 3f);
        menus.SetActive(true);

    }


    
}
