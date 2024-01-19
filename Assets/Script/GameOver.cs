using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] public string nomeDaCena ; // Nome da cena a ser carregada (verifique se o nome está correto)

    public void CarregarCenaMenu()
    {
        // Carrega a cena chamada "Menu"
        SceneManager.LoadScene("Menu");
    }


    public void CarregarCenaFase()
    {
        // Carrega a cena chamada "Menu"
        SceneManager.LoadScene(nomeDaCena);
    }
}
