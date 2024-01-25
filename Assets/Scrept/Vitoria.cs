using UnityEngine;
using UnityEngine.SceneManagement;

public class Vitoria : MonoBehaviour
{
    [SerializeField] private GameObject menus;
    private bool inimigoDerrotado = false;

    void Update()
    {
        // Verifica se o inimigo foi derrotado e ativa o menu se necess�rio
        if (inimigoDerrotado)
        {
            MenuAtc();
        }

        // Carregar cena 1 ao pressionar a tecla 1
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (inimigoDerrotado)
            {
                SceneManager.LoadScene("Menu");
            }
        }

        // Carregar cena 2 ao pressionar a tecla 2
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (inimigoDerrotado)
            {
                SceneManager.LoadScene("quefren");
            }
        }

        // Carregar cena 3 ao pressionar a tecla 3
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (inimigoDerrotado)
            {
                SceneManager.LoadScene("queops");
            }
        }
    }

    // M�todo para ativar o menu de op��es
    void MenuAtc()
    {
        menus.SetActive(true);
    }

    // M�todo chamado quando um inimigo � derrotado
    public void InimigoDerrotado()
    {
        inimigoDerrotado = true;
    }
}
